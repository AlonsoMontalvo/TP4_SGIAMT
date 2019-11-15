using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGIAMT_RenovarPago.Models.library;
using SGIAMT_RenovarPago.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SGIAMT_RenovarPago.Controllers
{
    public class CategoriasController : Controller
    {
        private TCategoria _categoria;
        private LCategorias _lcategoria;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TCategoria> models;
        public CategoriasController(BD_SGIAMTvsRenovarPagoContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _lcategoria = new LCategorias(context);
        }

        public IActionResult Categoria()
        {
            if (_signInManager.IsSignedIn(User))
            {
                models = new DataPaginador<TCategoria>
                {
                    Input = new TCategoria()
                };

                return View(models);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}