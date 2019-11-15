using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor;
using SGIAMT_GESTIONAR_PROGRESO.Models;

namespace SGIAMT_GESTIONAR_PROGRESO.Controllers
{
    public class TProgresoesController : Controller
    {
        private readonly BD_SGIAMT_GESTIONAR_PROGRESOContext _context;

        public TProgresoesController(BD_SGIAMT_GESTIONAR_PROGRESOContext context)
        {
            _context = context;
        }

        // GET: TProgresoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TProgreso.ToListAsync());
        }

        // GET: TProgresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProgreso = await _context.TProgreso
                .FirstOrDefaultAsync(m => m.PkIpCod == id);
            if (tProgreso == null)
            {
                return NotFound();
            }

            return View(tProgreso);
        }

        // GET: TProgresoes/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: TProgresoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIpCod,VpNombreProgreso,DpNotaPasos,DpNotaTecnica,DpNotaInteres,DpNotaHabilidad,DpTotalNota,VpObservacion")] TProgreso tProgreso)
        {
            bool Isdniexist = _context.TUsuario.Any
                 (x => x.PkIuDni == tProgreso.PkIpCod);
            if (Isdniexist == true)
            {
                ModelState.AddModelError("PkIpCod", "ya existe este codigo");
            }
            if (ModelState.IsValid)
            {
                _context.Add(tProgreso);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "TUsuarioxProgresoes");
            }
            return View(tProgreso);
        }

        // GET: TProgresoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProgreso = await _context.TProgreso.FindAsync(id);
            if (tProgreso == null)
            {
                return NotFound();
            }
            return View(tProgreso);
        }

        // POST: TProgresoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIpCod,VpNombreProgreso,DpNotaPasos,DpNotaTecnica,DpNotaInteres,DpNotaHabilidad,DpTotalNota,VpObservacion")] TProgreso tProgreso)
        {
            if (id != tProgreso.PkIpCod)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tProgreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TProgresoExists(tProgreso.PkIpCod))
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
            return View(tProgreso);
        }

        // GET: TProgresoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProgreso = await _context.TProgreso
                .FirstOrDefaultAsync(m => m.PkIpCod == id);
            if (tProgreso == null)
            {
                return NotFound();
            }

            return View(tProgreso);
        }

        // POST: TProgresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tProgreso = await _context.TProgreso.FindAsync(id);
            _context.TProgreso.Remove(tProgreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TProgresoExists(int id)
        {
            return _context.TProgreso.Any(e => e.PkIpCod == id);
        }
    }
}
