using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CUS_Iniciar_Sesion.Controllers.Perfiles
{
    public class RecepcionistahomeController : Controller
    {
        public RecepcionistahomeController()
        {

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
            // ViewData["ReturnUrl"] = url;

            return View();
        }
    }
}