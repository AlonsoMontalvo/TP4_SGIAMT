using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CUS_Iniciar_Sesion.Controllers.Perfiles
{
    public class ProfesorhomeController : Controller
    {
        public ProfesorhomeController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LockoutP()
        {
            // ViewData["Title"] = "Profesor";
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Profesor()
        {
            // ViewData["ReturnUrl"] = url;

            return View();
        }
    }
}