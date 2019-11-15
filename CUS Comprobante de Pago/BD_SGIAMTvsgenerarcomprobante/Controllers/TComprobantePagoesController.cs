using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BD_SGIAMTvsgenerarcomprobante.Models;
using Rotativa.AspNetCore;

namespace BD_SGIAMTvsgenerarcomprobante.Controllers
{
    public class TComprobantePagoesController : Controller
    {
        private readonly BD_SGIAMTvsgenerarcomprobanteContext _context;

        public TComprobantePagoesController(BD_SGIAMTvsgenerarcomprobanteContext context)
        {
            _context = context;
        }
        public IActionResult Comprobante()
        {
            //ViewBag.PDF = pdf;
            ViewData["alumno"] = "Edson";
            return View();
            //return new ViewAsPdf();
        }

        // GET: TComprobantePagoes
        public async Task<IActionResult> Index()
        {
            var bD_SGIAMTvsgenerarcomprobanteContext = _context.TComprobantePago.Include(t => t.FkIp);
            return View(await bD_SGIAMTvsgenerarcomprobanteContext.ToListAsync());
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
            ViewData["FkIpId"] = new SelectList(_context.TPago, "PkIpId", "PkIpId");
            return View();
        }

        // POST: TComprobantePagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIcpId,VcpNombre,VcpApaterno,VcpAmaterno,VcpMonto,VcpFecha,VcpPdf,FkIpId")] TComprobantePago tComprobantePago)
        {

            if (ModelState.IsValid)
            {
                _context.Add(tComprobantePago);
                await _context.SaveChangesAsync();
                return RedirectToAction("Comprobante", "TComprobantePagoes");

            }
            ViewData["FkIpId"] = new SelectList(_context.TPago, "PkIpId", "PkIpId", tComprobantePago.FkIpId);
            return View(tComprobantePago);
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
        public async Task<IActionResult> Edit(int id, [Bind("PkIcpId,VcpNombre,VcpApaterno,VcpAmaterno,VcpMonto,VcpFecha,VcpPdf,FkIpId")] TComprobantePago tComprobantePago)
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
