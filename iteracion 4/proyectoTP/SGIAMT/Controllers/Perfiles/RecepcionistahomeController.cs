using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SGIAMT.Models;

namespace SGIAMT.Controllers.Perfiles
{
    public class RecepcionistahomeController : Controller
    {
        private readonly BD_SGIAMTIntegracionfinalContext _context;
        public RecepcionistahomeController(BD_SGIAMTIntegracionfinalContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LockoutS()
        {
          //  ViewData["Title"] = "Recepcionista";
             return RedirectToAction("Index", "Home");
         
        }

        public IActionResult Recepcionista()
        {
            ViewData["dni"] = SGIAMT_Integracion.Controllers.Recepcionista.Dni;
            ViewData["nombre"] = SGIAMT_Integracion.Controllers.Recepcionista.nombre;
            ViewData["paterno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidopa;
            ViewData["materno"] = SGIAMT_Integracion.Controllers.Recepcionista.apellidoma;
            ViewData["correo"] = SGIAMT_Integracion.Controllers.Recepcionista.correo;
            var datosprofe = (from m in _context.TUsuario
                              join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                              join dis in _context.TDistrito on m.FkIdiCod equals dis.PkIdiCod

                              where m.PkIuDni == SGIAMT_Integracion.Controllers.Recepcionista.Dni
                              select new recepcionistaview
                              {
                                  PkIuDni = m.PkIuDni,
                                  VuNombre = m.VuNombre,
                                  VuApaterno = m.VuApaterno,
                                  VuAmaterno = m.VuAmaterno,
                                  VuCelular = m.VuCelular,
                                  VuCorreo = m.VuCorreo,
                                  VuDireccion = m.VuDireccion,
                                  DuFechaNacimiento = m.DuFechaNacimiento,
                                  VuSexo = m.VuSexo,
                                  tipousuario = v.VtuNombreTipoUsuario,
                                  distrito = dis.VdiNombreDis
                              }).ToList();
            var datosprofeview = datosprofe.ToList();
            return View(datosprofeview);

            
        }
        public class recepcionistaview
        {
            public int PkIuDni { get; set; }

            public string VuNombre { get; set; }

            public string VuApaterno { get; set; }

            public string VuAmaterno { get; set; }

            public int VuCelular { get; set; }

            public string VuCorreo { get; set; }

            public string VuDireccion { get; set; }
            public DateTime DuFechaNacimiento { get; set; }

            public string VuSexo { get; set; }



            public string tipousuario { get; set; }


            public string distrito { get; set; }
        }
    }
}