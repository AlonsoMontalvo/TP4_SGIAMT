using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SGIAMT_Integracion.Models;
using SGIAMT_Integracion.Models.Auxiliar;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SGIAMT_Integracion.Controllers
{
    public class AccountController : Controller
    {
        private readonly BD_SGIAMTIntegracionContext _context;
        public AccountController(BD_SGIAMTIntegracionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            bool Email = _context.TUsuario.Any
                (x => x.VuCorreo == model.Email);
            bool contra = _context.TUsuario.Any
                (con => con.VuContraseña == model.Password);
          
            // bool Isdniexist1 = _context.TUsuario.Any
            //(x => x.FkItuTipoUsuario == 1);
            // bool Isdniexist2 = _context.TUsuario.Any
            //  (x => x.FkItuTipoUsuario == 2);
            // bool Isdniexist3 = _context.TUsuario.Any
            //  (x => x.FkItuTipoUsuario == 3);
            if (Email == true && contra == true && model.TipoUsuario== "Alumno" /*&& Isdniexist1 == true && Isdniexist2 == false && Isdniexist3 == false*/)
            {

                await Task.Delay(100);

                return RedirectToAction("Alumno", "Alumnohome", model.Email);

            }
            else if (Email == true && contra == true && model.TipoUsuario == "Recepcionista"/*&& Isdniexist2 == true && Isdniexist1 == false && Isdniexist3 == false*/)
            {
                await Task.Delay(100);

                return RedirectToAction("Recepcionista", "Recepcionistahome", model.Email);
            }
            else if (Email == true && contra == true && model.TipoUsuario == "Profesor"/* && Isdniexist3 == true && Isdniexist1 == false && Isdniexist2 == false*/)
            {
                await Task.Delay(100);

                return RedirectToAction("Profesor", "Profesorhome", model.Email);
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }

        }


    }
}