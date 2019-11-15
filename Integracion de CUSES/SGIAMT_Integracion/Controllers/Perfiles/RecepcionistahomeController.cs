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
using SGIAMT_Integracion.Models;

namespace SGIAMT_Integracion.Controllers.Perfiles
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