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
    public class TPagoesController : Controller
    {
        private readonly BD_SGIAMTIntegracionfinalContext _context;

        public TPagoesController(BD_SGIAMTIntegracionfinalContext context)
        {
            _context = context;
        }

    
        public IActionResult Index()
        {
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

            var modificaralumnos = (from m in _context.TPago
                                        //join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                        //where m.FkItuTipoUsuario == 0
                                  //  join v in _context.TConceptoPago on m.FkIcpId equals v.PkIcpId

                                    select m
                                    ).ToList();
            var bD_SGIAMTvsActualizar_Datos_AlumnoContext = modificaralumnos.ToList();
            return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int ?dni)
        {
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

            if (dni == null)
            {
                var modificaralumnos = (from m in _context.TPago
                                           //join v in _context.TConceptoPago on m.FkIcpId equals v.PkIcpId
                                        
                                            //where m.FkItuTipoUsuario == 0

                                        select m
                            ).ToList();
                var bD_SGIAMTvsActualizar_Datos_AlumnoContext = modificaralumnos.ToList();
                return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext);
            }
            else
            {
                var modificaralumnos = (from m in _context.TPago
                                       // join v in _context.TConceptoPago on m.FkIcpId equals v.PkIcpId
                                        join u in _context.TUsuario on m.FkIuDni equals u.PkIuDni

                                        //where m.FkItuTipoUsuario == 1 && m.PkIuDni == dni
                                        where m.FkIuDni == dni
                                        select m
                                        ).ToList();
                var bD_SGIAMTvsActualizar_Datos_AlumnoContext = modificaralumnos.ToList();
                await Task.Delay(200);
                return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

            if (id == null)
            {
                return NotFound();
            }

            var tPago = await _context.TPago
                .Include(t => t.FkIcpIdNavigation)
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
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;


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
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

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


        public IActionResult CreateRenovar(int? id)
        {
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

            var tPago =  _context.TPago.Find(id);

            var usuario = from m in _context.TPago
                              //join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                              // join ntp in _context.TNivelxTipoNivel on m.PkIuDni equals ntp.FkIuDni

                              // where m.PkIuDni !=ntp.FkIuDni
                          where m.PkIpId == id
                          select m;

            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
            ViewData["FkIuDni"] = new SelectList(usuario, "FkIuDni", "FkIuDni", tPago.FkIuDni);

            return View();
        }

        // POST: TPagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRenovar([Bind("PkIpId,VpFecha,VpMonto,VpAño,VpMes,VpEstado,FkIuDni,FkIcpId")] TPago tPago)
        {
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

            tPago.VpEstado = "EN PROGRESO";
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
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

            if (id == null)
            {
                return NotFound();
            }

            var tPago = await _context.TPago.FindAsync(id);
            if (tPago == null)
            {
                return NotFound();
            }
            var usuario = from m in _context.TPago
                          //join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                          // join ntp in _context.TNivelxTipoNivel on m.PkIuDni equals ntp.FkIuDni
                          
                          // where m.PkIuDni !=ntp.FkIuDni
                          where m.PkIpId==id
                          select m;
            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion", tPago.FkIcpId);
            ViewData["FkIuDni"] = new SelectList(usuario, "FkIuDni", "FkIuDni", tPago.FkIuDni);
            return View(tPago);
        }

        // POST: TPagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIpId,VpFecha,VpMonto,VpAño,VpMes,VpEstado,FkIuDni,FkIcpId")] TPago tPago)
        {
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

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
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

            if (id == null)
            {
                return NotFound();
            }

            var tPago = await _context.TPago
                .Include(t => t.FkIcpIdNavigation)
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
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            ViewData["tipousuario"] = SGIAMT_Integracion.Controllers.Recepcionista.tipousuario;

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
