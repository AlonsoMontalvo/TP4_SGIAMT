using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGIAMT_Integracion.Models;

namespace SGIAMT_Integracion.Controllers
{
    public class TPagoesController : Controller
    {
        private readonly BD_SGIAMTIntegracionContext _context;

        public TPagoesController(BD_SGIAMTIntegracionContext context)
        {
            _context = context;
        }

        // GET: TPagoes
        public async Task<IActionResult> Index()
        {
            //var bD_SGIAMTIntegracionContext = _context.TPago.Include(t => t.FkIcp).Include(t => t.FkIuDniNavigation);

            var index = (from m in _context.TPago
                                    join v in _context.TUsuario on m.FkIuDni equals v.PkIuDni
                                    join b in _context.TTipoUsuario on v.FkItuTipoUsuario equals b.PkItuTipoUsuario

                                    where v.FkItuTipoUsuario == 1 && v.VuEstado=="Activo"

                                    select m
                                      //select new pA
                                      //{
                                      //    dni = v.PkIuDni,
                                      //    nombre = v.VuNombre,
                                      //    paterno = v.VuApaterno,
                                      //    materno = v.VuAmaterno,
                                      //    fecha = m.VpFecha,
                                      //    monto = m.VpMonto,
                                      //    año = m.VpAño,
                                      //    mes = m.VpMes,
                                      //    estadopago = m.VpEstado

                                      //}).ToList();
                                    ).ToList();
            await Task.Delay(200);
            return View(index);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tPago = await _context.TPago
                .Include(t => t.FkIcp)
                .Include(t => t.FkIuDniNavigation)
                .FirstOrDefaultAsync(m => m.PkIpId == id);
            if (tPago == null)
            {
                return NotFound();
            }

            return View(tPago);
        }
        public IActionResult Create()
        {
            var usuario = from m in _context.TUsuario
                          join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                          // join ntp in _context.TNivelxTipoNivel on m.PkIuDni equals ntp.FkIuDni

                          // where m.PkIuDni !=ntp.FkIuDni
                          where m.FkItuTipoUsuario == 1 && m.VuEstado == "Inactivo"
                          select m;


            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(usuario, "PkIuDni", "PkIuDni");
            ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
            return View();
        }

        // POST: TPagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIpId,VpFecha,VpMonto,VpAño,VpMes,VpEstado,FkIuDni,FkIcpId")] TPago tPago)
        {
            var concepto = from a in _context.TConceptoPago where a.PkIcpId == tPago.FkIcpId select a.VcpDescripcion;
            var monto = from b in _context.TConceptoPago where b.PkIcpId == tPago.FkIcpId select b.VcpMonto;
            tPago.VpMonto = Convert.ToDecimal(monto.First());
            if (concepto.First() == "COMPLETO")
            {
                //tPago.VpEstado = "FINALIZADO";
                tPago.VpEstado = "EN PROGRESO";
            }
            else
            {
                if (concepto.First() == "MATRICULA")
                {
                    tPago.VpEstado = "EN PROGRESO";
                    tPago.VpMes = null;
                }
                else
                {
                    //tPago.VpEstado = "PAGADO";
                    tPago.VpEstado = "EN PROGRESO";
                }
            }

            bool pagoTotalAnual = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && x.FkIcpId == 3 && tPago.FkIcpId == 1);
            if (pagoTotalAnual == true)
            {
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESTE PAGO");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
                return View(tPago);
            }

            bool pagoTotalMensual = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && x.VpMes == tPago.VpMes && x.FkIcpId == 3 && tPago.FkIcpId == 2);
            if (pagoTotalMensual == true)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO YA REALIZO ESTE PAGO");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
                return View(tPago);
            }

            bool pagoMensualExiste = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpMes == tPago.VpMes && x.VpAño == tPago.VpAño && tPago.FkIcpId == 2);
            if (pagoMensualExiste == true)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO YA REALIZO ESTE PAGO");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
                return View(tPago);
            }

            bool pagoMatriculaExiste = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.FkIcpId == 1 && x.VpAño == tPago.VpAño);
            if (pagoMatriculaExiste == true && tPago.FkIcpId == 1)
            {
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESTE PAGO");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
                return View(tPago);
            }

            bool ConMatricula = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && x.FkIcpId == 1);
            if (ConMatricula == false && tPago.FkIcpId == 2)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO AUN NO HA PAGADO LA MATRICULA");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
                return View(tPago);
            }

            bool ConPagoCompleto = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.FkIcpId == tPago.FkIcpId && x.VpAño == tPago.VpAño && x.VpMes == tPago.VpMes);
            if (ConPagoCompleto == true)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO YA REALIZO ESTE PAGO");
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESTE PAGO");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
                return View(tPago);
            }

            bool ConPagoCompletoMensual = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && x.VpMes == tPago.VpMes && tPago.FkIcpId == 3);
            if (ConPagoCompletoMensual == true)
            {
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESTE PAGO");
                ModelState.AddModelError("VpMes", "EL ALUMNO YA REALIZO ESTE PAGO");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
                return View(tPago);
            }

            bool ConPagoCompletoAnual = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && tPago.FkIcpId == 3);
            if (ConPagoCompletoAnual == true)
            {
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESTE PAGO");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
                return View(tPago);
            }

            if (ModelState.IsValid)
            {
                _context.Add(tPago);
                await _context.SaveChangesAsync();
                TempData["PkIpId"] = tPago.PkIpId;
                return RedirectToAction("Create", "TComprobantePagoes");
            }
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
            ViewData["FkIcpVcpMonto"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpMonto");
            return View(tPago);
        }


        public IActionResult CreateRenovar()
        {


            var usuario = from m in _context.TUsuario
                          join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                          // join ntp in _context.TNivelxTipoNivel on m.PkIuDni equals ntp.FkIuDni

                          // where m.PkIuDni !=ntp.FkIuDni
                          where m.FkItuTipoUsuario == 1&& m.VuEstado == "Activo"
                          select m;

            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
            ViewData["FkIuDni"] = new SelectList(usuario, "PkIuDni", "PkIuDni");

            return View();
        }

        // POST: TPagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRenovar([Bind("PkIpId,VpFecha,VpMonto,VpAño,VpMes,VpEstado,FkIuDni,FkIcpId")] TPago tPago)
        {
            tPago.VpEstado = "PAGADO";
            bool pagoMensualExiste = _context.TPago.Any
                   (x => x.FkIuDni == tPago.FkIuDni && x.VpMes == tPago.VpMes && x.VpAño == tPago.VpAño);
            if (pagoMensualExiste == true)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO YA REALIZO ESE PAGO");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            bool pagoMatriculaExiste = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.FkIcpId == 1 && x.VpAño == tPago.VpAño);
            if (pagoMatriculaExiste == true && tPago.FkIcpId == 1)
            {
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESE PAGO");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            bool ConMatricula = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && x.FkIcpId == 1);
            if (ConMatricula == false && tPago.FkIcpId == 2)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO AUN NO A PAGO LA MATRICULA");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            if (ModelState.IsValid)
            {
                if (tPago.FkIcpId == 1) { tPago.VpMonto = 30; tPago.VpMes = ""; }
                if (tPago.FkIcpId == 2) { tPago.VpMonto = 80; }
                if (tPago.FkIcpId == 3) { tPago.VpMonto = 110; }
                _context.Add(tPago);
                await _context.SaveChangesAsync();
              return RedirectToAction("Index", "TPagoes");
            }
            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
            return View(tPago);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tPago = await _context.TPago.FindAsync(id);
            if (tPago == null)
            {
                return NotFound();
            }
            var usuario = from m in _context.TUsuario
                          join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                          // join ntp in _context.TNivelxTipoNivel on m.PkIuDni equals ntp.FkIuDni
                          
                          // where m.PkIuDni !=ntp.FkIuDni
                          where m.FkItuTipoUsuario == 1 && m.VuEstado == "Activo"
                          select m;
            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion", tPago.FkIcpId);
            ViewData["FkIuDni"] = new SelectList(usuario, "PkIuDni", "PkIuDni", tPago.FkIuDni);
            return View(tPago);
        }

        // POST: TPagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIpId,VpFecha,VpMonto,VpAño,VpMes,VpEstado,FkIuDni,FkIcpId")] TPago tPago)
        {
            if (id != tPago.PkIpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TPagoExists(tPago.PkIpId))
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
            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "PkIcpId", tPago.FkIcpId);
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni", tPago.FkIuDni);
            return View(tPago);
        }

        // GET: TPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tPago = await _context.TPago
                .Include(t => t.FkIcp)
                .Include(t => t.FkIuDniNavigation)
                .FirstOrDefaultAsync(m => m.PkIpId == id);
            if (tPago == null)
            {
                return NotFound();
            }

            return View(tPago);
        }

        // POST: TPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tPago = await _context.TPago.FindAsync(id);
            _context.TPago.Remove(tPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TPagoExists(int id)
        {
            return _context.TPago.Any(e => e.PkIpId == id);
        }
    }
}
