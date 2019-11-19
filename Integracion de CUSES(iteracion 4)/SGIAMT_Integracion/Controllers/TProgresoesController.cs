using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor;

using SGIAMT_Integracion.Models;
using Rotativa.AspNetCore;

namespace SGIAMT_Integracion.Controllers
{
    public class TProgresoesController : Controller
    {
        private readonly BD_SGIAMTIntegracionContext _context;

        public TProgresoesController(BD_SGIAMTIntegracionContext context)
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
            bool Isdniexist = _context.TProgreso.Any
                (x => x.PkIpCod == tProgreso.PkIpCod);
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



        //reporte de progreso del alumno
        public IActionResult DetalleProgreso(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var detalleprogreso = (from progreso in _context.TProgreso
                                     join up in _context.TUsuarioxProgreso on progreso.PkIpCod equals up.FkIpCod
                                     join u in _context.TUsuario on up.FkIuDni equals u.PkIuDni
                                     join ntn in _context.TNivelxTipoNivel on u.PkIuDni equals ntn.FkIuDni
                                     join n in _context.TNivel on ntn.FkInCod equals n.PkInCod
                                     join tn in _context.TTipoNivel on ntn.FkItnCod equals tn.PkItnCod
                                     join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                   where progreso.PkIpCod == id
                                   select new Detalleprogresoview
                                     {
                                         pkasistencia = progreso.PkIpCod,
                                         FkIuDni = u.PkIuDni,
                                         nombre = u.VuNombre,
                                         apellidopa = u.VuApaterno,
                                         apellidoma = u.VuAmaterno,
                                         VupSemana=up.VupSemana,
                                     VupNombreProfesor=up.VupNombreProfesor,

                                         DpNotaPasos=progreso.DpNotaPasos,
                                         DpNotaTecnica = progreso.DpNotaTecnica,
                                         DpNotaInteres = progreso.DpNotaInteres,
                                         DpNotaHabilidad = progreso.DpNotaHabilidad,
                                         DpTotalNota = progreso.DpTotalNota,

                                         VpObservacion =progreso.VpObservacion

                                     }).ToList();

            var detalle = detalleprogreso.ToList();

            if (detalleprogreso == null)
            {
                return NotFound();
            }

            return View(detalle);
        }

        public IActionResult Imprimirdocumentprogreso(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var detalleprogreso = (from progreso in _context.TProgreso
                                   join up in _context.TUsuarioxProgreso on progreso.PkIpCod equals up.FkIpCod
                                   join u in _context.TUsuario on up.FkIuDni equals u.PkIuDni
                                   join ntn in _context.TNivelxTipoNivel on u.PkIuDni equals ntn.FkIuDni
                                   join n in _context.TNivel on ntn.FkInCod equals n.PkInCod
                                   join tn in _context.TTipoNivel on ntn.FkItnCod equals tn.PkItnCod
                                   join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                   where progreso.PkIpCod == id
                                   select new Detalleprogresoview
                                   {
                                       pkasistencia = progreso.PkIpCod,
                                       FkIuDni = u.PkIuDni,
                                       nombre = u.VuNombre,
                                       apellidopa = u.VuApaterno,
                                       apellidoma = u.VuAmaterno,
                                       VupSemana = up.VupSemana,
                                       VupNombreProfesor = up.VupNombreProfesor,

                                       DpNotaPasos = progreso.DpNotaPasos,
                                       DpNotaTecnica = progreso.DpNotaTecnica,
                                       DpNotaInteres = progreso.DpNotaInteres,
                                       DpNotaHabilidad = progreso.DpNotaHabilidad,
                                       DpTotalNota = progreso.DpTotalNota,

                                       VpObservacion = progreso.VpObservacion

                                   }).ToList();

            var detalle = detalleprogreso.ToList();

            if (detalleprogreso == null)
            {
                return NotFound();
            }

          

            return new ViewAsPdf("Imprimirdocumentprogreso", detalle);
        }
    }
    public class Detalleprogresoview
    {
        public int pkasistencia { get; set; }

        public string nombre { get; set; }
        public string apellidopa { get; set; }
        public string apellidoma { get; set; }
        public int FkIuDni { get; set; }


        public string VupSemana { get; set; }
        public string VupNombreProfesor { get; set; }


        public int DpNotaPasos { get; set; }
        public int DpNotaTecnica { get; set; }
        public int DpNotaInteres { get; set; }
        public int DpNotaHabilidad { get; set; }
        public decimal DpTotalNota { get; set; }
        public string VpObservacion { get; set; }
    }
}
