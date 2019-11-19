using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CUS_Iniciar_Sesion.Controllers.Perfiles
{
    public class AlumnohomeController : Controller
    {
        public AlumnohomeController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LockoutA()
        {
            // ViewData["Title"] = "Alumno";
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Alumno()
        {
            // ViewData["ReturnUrl"] = url;

            return View();
        }
    }
}