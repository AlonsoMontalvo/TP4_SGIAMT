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
        private readonly BD_SGIAMTContext _context;

        public TPagoesController(BD_SGIAMTContext context)
        {
            _context = context;
        }

        // GET: TPagoes
        public async Task<IActionResult> Index()
        {
            var bD_SGIAMTContext = _context.TPago.Include(t => t.FkIcp).Include(t => t.FkIuDniNavigation);
            return View(await bD_SGIAMTContext.ToListAsync());
        }




        // GET: TPagoes/Create
        public IActionResult Create()
        {
            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
            return View();
        }



        // POST: TPagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIpId,VpValor,VpFecha,VpMes,VpAño,VpPdf,FkIuDni,FkIcpId")] TPago tPago)
        {
            bool pagoTotalAnual = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && x.FkIcpId == 3 && tPago.FkIcpId == 1);
            if (pagoTotalAnual == true)
            {
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO EL PAGO TOTAL");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            bool pagoTotalMensual = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && x.VpMes == tPago.VpMes && x.FkIcpId == 3 && tPago.FkIcpId == 2);
            if (pagoTotalMensual == true)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO YA REALIZO EL PAGO TOTAL");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            bool pagoMensualExiste = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpMes == tPago.VpMes && x.VpAño == tPago.VpAño && tPago.FkIcpId == 2);
            if (pagoMensualExiste == true)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO YA REALIZO ESE PAGO MENSUAL");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            bool pagoMatriculaExiste = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.FkIcpId == 1 && x.VpAño == tPago.VpAño);
            if (pagoMatriculaExiste == true && tPago.FkIcpId == 1)
            {
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESE PAGO ANUAL");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            bool ConMatricula = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && x.FkIcpId == 1);
            if (ConMatricula == false && tPago.FkIcpId == 2)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO AUN NO HA PAGADO LA MATRICULA");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            bool ConPagoCompleto = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.FkIcpId == tPago.FkIcpId && x.VpAño == tPago.VpAño && x.VpMes == tPago.VpMes);
            if (ConPagoCompleto == true)
            {
                ModelState.AddModelError("VpMes", "EL ALUMNO YA REALIZO ESE PAGO TOTAL");
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESE PAGO TOTAL");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            bool ConPagoCompletoMensual = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && x.VpMes == tPago.VpMes && tPago.FkIcpId == 3);
            if (ConPagoCompletoMensual == true)
            {
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESE PAGO ANUAL Y MENSUAL");
                ModelState.AddModelError("VpMes", "EL ALUMNO YA REALIZO ESE PAGO ANUAL Y MENSUAL");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            bool ConPagoCompletoAnual = _context.TPago.Any(x => x.FkIuDni == tPago.FkIuDni && x.VpAño == tPago.VpAño && tPago.FkIcpId == 3);
            if (ConPagoCompletoAnual == true)
            {
                ModelState.AddModelError("VpAño", "EL ALUMNO YA REALIZO ESE PAGO ANUAL");
                ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
                ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
                return View();
            }

            if (ModelState.IsValid)
            {
                if (tPago.FkIcpId == 1)
                {
                    tPago.VpValor = 30;
                    tPago.VpMes = "";
                    _context.Add(tPago);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    if (tPago.FkIcpId == 2)
                    {
                        tPago.VpValor = 80;
                        _context.Add(tPago);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        if (tPago.FkIcpId == 3)
                        {
                            tPago.VpValor = 110;
                            _context.Add(tPago);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
            ViewData["FkIcpId"] = new SelectList(_context.TConceptoPago, "PkIcpId", "VcpDescripcion");
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "PkIuDni");
            return View(tPago);

        }
    }

}
