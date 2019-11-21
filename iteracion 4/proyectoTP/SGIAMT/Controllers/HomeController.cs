using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa;
using Rotativa.AspNetCore;
using SGIAMT.Models;

//using Rotativa.AspNetCore.SGIAMT_Integracion.Models;

namespace SGIAMT.Controllers
{
    public class TestModel
    {
        public string Name { get; set; }
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            //var model = new TestModel { Name = "Giorgio" };
            return new ViewAsPdf(ViewData);
        }

    }
}
