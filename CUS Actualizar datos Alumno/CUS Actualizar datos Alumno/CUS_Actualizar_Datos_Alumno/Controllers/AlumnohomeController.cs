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
using CUS_Actualizar_Datos_Alumno.Models;
using Microsoft.EntityFrameworkCore;

namespace CUS_Actualizar_Datos_Alumno.Controllers
{

    public class AlumnohomeController : Controller
    {
        private readonly BD_SGIAMTvsActualizar_Datos_AlumnoContext _context;
        public AlumnohomeController(BD_SGIAMTvsActualizar_Datos_AlumnoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public class Us
        {
            public int PkIuDni { get; set; }
        }
       
        public IActionResult Alumno()
        {
            var modificaralumnos = (from m in _context.TUsuario
                                    join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                    where m.FkItuTipoUsuario == 0

                                    select m
                                    ).ToList();
            var bD_SGIAMTvsActualizar_Datos_AlumnoContext = modificaralumnos.ToList();
            return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alumno(int dni)
        {
            var modificaralumnos = (from m in _context.TUsuario
                                    join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                    where m.FkItuTipoUsuario == 1 && m.PkIuDni == dni

                                    select m
                                    ).ToList();
            var bD_SGIAMTvsActualizar_Datos_AlumnoContext = modificaralumnos.ToList();
            await Task.Delay(200);
            return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext);
        }
    }
}