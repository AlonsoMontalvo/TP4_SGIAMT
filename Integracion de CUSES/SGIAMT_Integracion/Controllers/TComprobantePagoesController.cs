using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using SGIAMT_Integracion.Models;


namespace SGIAMT_Integracion.Controllers
{
    public class TComprobantePagoesController : Controller
    {
        private readonly BD_SGIAMTIntegracionContext _context;

        public TComprobantePagoesController(BD_SGIAMTIntegracionContext context)
        {
            _context = context;
        }

        // GET: TComprobantePagoes
        public async Task<IActionResult> Index()
        {
            var bD_SGIAMTIntegracionContext = _context.TComprobantePago.Include(t => t.FkIp);
            return View(await bD_SGIAMTIntegracionContext.ToListAsync());
        }

        // GET: TComprobantePagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tComprobantePago = await _context.TComprobantePago
                .Include(t => t.FkIp)
                .FirstOrDefaultAsync(m => m.PkIcpId == id);
            if (tComprobantePago == null)
            {
                return NotFound();
            }

            return View(tComprobantePago);
        }

        // GET: TComprobantePagoes/Create
        public IActionResult Create()
        {
           
            ViewBag.estado = TempData["VpEstado"].ToString();
            ViewBag.monto = TempData["VpMonto"].ToString();
            ViewBag.año = TempData["VpAño"].ToString();
            ViewBag.mes = TempData["VpMes"].ToString();
            ViewData["FkIpId"] = new SelectList(_context.TPago, "PkIpId", "PkIpId");
         

            return View();
        }
       
        
        // POST: TComprobantePagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIcpId,VcpFecha,VcpNombre,VcpApaterno,VcpAmaterno,VcpConcepto,VcpMonto,VcpAño,VcpMes,VcpDcumento,FkIpId")] TComprobantePago tComprobantePago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tComprobantePago);
                await _context.SaveChangesAsync();
               
         
                ViewData["Title"] = "Concepto de Pago";
            

            }
            ViewData["FkIpId"] = new SelectList(_context.TPago, "PkIpId", "PkIpId", tComprobantePago.FkIpId);
            
            return new ViewAsPdf(tComprobantePago,ViewData);//return View(tComprobantePago);
        }
       
        // GET: TComprobantePagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tComprobantePago = await _context.TComprobantePago.FindAsync(id);
            if (tComprobantePago == null)
            {
                return NotFound();
            }
            ViewData["FkIpId"] = new SelectList(_context.TPago, "PkIpId", "PkIpId", tComprobantePago.FkIpId);
            return View(tComprobantePago);
        }

        // POST: TComprobantePagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIcpId,VcpFecha,VcpNombre,VcpApaterno,VcpAmaterno,VcpConcepto,VcpMonto,VcpAño,VcpMes,VcpDcumento,FkIpId")] TComprobantePago tComprobantePago)
        {
            if (id != tComprobantePago.PkIcpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tComprobantePago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TComprobantePagoExists(tComprobantePago.PkIcpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIpId"] = new SelectList(_context.TPago, "PkIpId", "PkIpId", tComprobantePago.FkIpId);
            return View(tComprobantePago);
        }

        // GET: TComprobantePagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tComprobantePago = await _context.TComprobantePago
                .Include(t => t.FkIp)
                .FirstOrDefaultAsync(m => m.PkIcpId == id);
            if (tComprobantePago == null)
            {
                return NotFound();
            }

            return View(tComprobantePago);
        }

        // POST: TComprobantePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tComprobantePago = await _context.TComprobantePago.FindAsync(id);
            _context.TComprobantePago.Remove(tComprobantePago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TComprobantePagoExists(int id)
        {
            return _context.TComprobantePago.Any(e => e.PkIcpId == id);
        }
    }
}
