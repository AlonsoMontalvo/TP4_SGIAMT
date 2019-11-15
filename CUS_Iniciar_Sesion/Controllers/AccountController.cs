using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CUS_Iniciar_Sesion.Models;
using CUS_Iniciar_Sesion.Models.Auxiliar;

using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CUS_Iniciar_Sesion.Controllers
{
    public class AccountController : Controller
    {
        private readonly BD_SGIAMTvsIniciar_SesionContext _context;
        public AccountController(BD_SGIAMTvsIniciar_SesionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult LogIn()
        {

            return View();

        }
        public class usr
        {
            public int dniusr { get; set; }
            public string passusr { get; set; }
            public int? tipousr { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn([FromBody]login user)
        {
            //    bool dni = _context.TUsuario.Any(x => x.PkIuDni == user.Dni);
            //    bool contra = _context.TUsuario.Any(con => con.VuContraseña == user.Contra);


            var us = (from c in _context.TUsuario
                      where c.PkIuDni == user.Dni && c.VuContraseña == user.Contra
                      select new usr()
                      {
                          dniusr = c.PkIuDni,



                      }).FirstOrDefault();
            var us1 = (from c in _context.TUsuario
                       where c.PkIuDni == user.Dni && c.VuContraseña == user.Contra
                       select new usr()
                       {
                           passusr = c.VuContraseña,


                       }).FirstOrDefault();
            var us2 = (from c in _context.TUsuario
                       where c.PkIuDni == user.Dni && c.VuContraseña == user.Contra
                       select new usr()
                       {
                           tipousr = c.FkItuTipoUsuario


                       }).FirstOrDefault();


            if (us == null && us1 == null && us2 == null)
            {
                ModelState.AddModelError("Dni", "Los datos son incorrectos");
                ModelState.AddModelError("Contra", "Los datos son incorrectos");

                return View();

            }
            else
            {
                bool dni = _context.TUsuario.Any(x => x.PkIuDni == us.dniusr);
                bool contra = _context.TUsuario.Any(con => con.VuContraseña == us1.passusr);

                if (dni == true && contra == true && us2.tipousr == 1)
                {
                    await Task.Delay(100);
                    var dnip = us.dniusr;
                    var contrap = us.passusr;
                    var tp = us.tipousr;
                    await Task.Delay(200);
                    //return Json(new { dni = dnip, contra = contrap, tipo=tp });
                    return RedirectToAction("Alumno", "Alumnohome");
                }
                else if (dni == true && contra == true && us2.tipousr == 2) //ariana
                {
                    var dnip = us.dniusr;
                    var contrap = us.passusr;
                    var tp = us.tipousr;
                    await Task.Delay(200);
                    return RedirectToAction("Alumno", "Alumnohome");
                    //return Json(new { dni = dnip, contra = contrap, tipo = tp });
                }
                else if (dni == true && contra == true && us2.tipousr == 3) //ariana
                {
                    var dnip = us.dniusr;
                    var contrap = us.passusr;
                    var tp = us.tipousr;
                    await Task.Delay(200);
                    return RedirectToAction("Alumno", "Alumnohome");
                    // return Json(new { dni = dnip, contra = contrap, tipo = tp });
                }
               

                else
                {
                    await Task.Delay(200);
                    return RedirectToAction("LogIn", "Account");
                }
            }





        }
    }
}