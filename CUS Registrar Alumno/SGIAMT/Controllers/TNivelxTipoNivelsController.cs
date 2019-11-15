using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGIAMT.Models;

namespace SGIAMT.Controllers
{
    public class TNivelxTipoNivelsController : Controller
    {
        private readonly BD_SGIAMTContext _context;

        public TNivelxTipoNivelsController(BD_SGIAMTContext context)
        {
            _context = context;
        }

        // GET: TNivelxTipoNivels
        public async Task<IActionResult> Index()
        {
            var bD_SGIAMTContext = _context.TNivelxTipoNivel.Include(t => t.FkInCodNavigation).Include(t => t.FkItnCodNavigation).Include(t => t.FkIuDniNavigation);
            return View(await bD_SGIAMTContext.ToListAsync());
        }

        // GET: TNivelxTipoNivels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tNivelxTipoNivel = await _context.TNivelxTipoNivel
                .Include(t => t.FkInCodNavigation)
                .Include(t => t.FkItnCodNavigation)
                .Include(t => t.FkIuDniNavigation)
                .FirstOrDefaultAsync(m => m.PkIntnCod == id);
            if (tNivelxTipoNivel == null)
            {
                return NotFound();
            }

            return View(tNivelxTipoNivel);
        }

        // GET: TNivelxTipoNivels/Create
        public IActionResult Create()
        {
            ViewBag.data = TempData["PkIuDni"].ToString();
            ViewBag.data1 = TempData["VuNombre"].ToString();
            ViewBag.data2 = TempData["DuFechaNacimiento"].ToString();
            ViewData["FkInCod"] = new SelectList(_context.TNivel, "PkInCod", "VnNombreNivel");
            ViewData["FkItnCod"] = new SelectList(_context.TTipoNivel, "PkItnCod", "ItnNombreTipoNivel");
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "VuNombre");

         

            return View();

        }

        // POST: TNivelxTipoNivels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIntnCod,FkInCod,FkItnCod,NroAlumno,FkIuDni")] TNivelxTipoNivel tNivelxTipoNivel)
        {


            if (ModelState.IsValid)
            {
                if (0 < tNivelxTipoNivel.NroAlumno && tNivelxTipoNivel.NroAlumno < 16)
                {
                    _context.Add(tNivelxTipoNivel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create", "EUsuarios");
                }
                else {

                    ModelState.AddModelError("NroAlumno", "ya no hay cupos");
                }
            }
            ViewData["FkInCod"] = new SelectList(_context.TNivel, "PkInCod", "VnNombreNivel", tNivelxTipoNivel.FkInCod);
            ViewData["FkItnCod"] = new SelectList(_context.TTipoNivel, "PkItnCod", "ItnNombreTipoNivel", tNivelxTipoNivel.FkItnCod);
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "VuNombre", tNivelxTipoNivel.FkIuDni);


            return View(tNivelxTipoNivel);
        }

        // GET: TNivelxTipoNivels/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tNivelxTipoNivel = await _context.TNivelxTipoNivel.FindAsync(id);
        //    if (tNivelxTipoNivel == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["FkInCod"] = new SelectList(_context.TNivel, "PkInCod", "VnNombreNivel", tNivelxTipoNivel.FkInCod);
        //    ViewData["FkItnCod"] = new SelectList(_context.TTipoNivel, "PkItnCod", "ItnNombreTipoNivel", tNivelxTipoNivel.FkItnCod);
        //    ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "VuNombre", tNivelxTipoNivel.FkIuDni);
        //    return View(tNivelxTipoNivel);
        //}

        // POST: TNivelxTipoNivels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PkIntnCod,FkInCod,FkItnCod,NroAlumno,FkIuDni")] TNivelxTipoNivel tNivelxTipoNivel)
        //{
        //    if (id != tNivelxTipoNivel.PkIntnCod)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tNivelxTipoNivel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TNivelxTipoNivelExists(tNivelxTipoNivel.PkIntnCod))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["FkInCod"] = new SelectList(_context.TNivel, "PkInCod", "VnNombreNivel", tNivelxTipoNivel.FkInCod);
        //    ViewData["FkItnCod"] = new SelectList(_context.TTipoNivel, "PkItnCod", "ItnNombreTipoNivel", tNivelxTipoNivel.FkItnCod);
        //    ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "VuNombre", tNivelxTipoNivel.FkIuDni);
        //    return View(tNivelxTipoNivel);
        //}

        //// GET: TNivelxTipoNivels/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tNivelxTipoNivel = await _context.TNivelxTipoNivel
        //        .Include(t => t.FkInCodNavigation)
        //        .Include(t => t.FkItnCodNavigation)
        //        .Include(t => t.FkIuDniNavigation)
        //        .FirstOrDefaultAsync(m => m.PkIntnCod == id);
        //    if (tNivelxTipoNivel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tNivelxTipoNivel);
        //}

        //// POST: TNivelxTipoNivels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tNivelxTipoNivel = await _context.TNivelxTipoNivel.FindAsync(id);
        //    _context.TNivelxTipoNivel.Remove(tNivelxTipoNivel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TNivelxTipoNivelExists(int id)
        //{
        //    return _context.TNivelxTipoNivel.Any(e => e.PkIntnCod == id);
        //}
    }
}
