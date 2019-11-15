using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGIAMT.Models;

namespace SGIAMT.Controllers
{
    public class EUsuariosController : Controller
    {

        private readonly BD_SGIAMTContext _context;
        public EUsuariosController(BD_SGIAMTContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var bD_SGIAMTContext = _context.TUsuario.Include(e => e.FkIcIdNavigation).Include(e => e.FkIdiCodNavigation).Include(e => e.FkItuTipoUsuarioNavigation);
            return View(await bD_SGIAMTContext.ToListAsync());
        }
        // GET: EUsuarios/Create
        public IActionResult Create()
        {
            ViewData["PkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat");
            ViewData["PkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis");
            ViewData["PkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario");
            return View();
        }

        // POST: EUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIuDni,VuNombre,VuApaterno,VuAmaterno,VuCelular,VuCorreo,VuDireccion,DuFechaNacimiento,VuSexo,VuContraseña,VuEstado,VuHorario,FkItuTipoUsuario,FkIcId,FkIdiCod")] TUsuario eUsuario)
        {
            //int id;
            bool Isdniexist = _context.TUsuario.Any
              (x => x.PkIuDni == eUsuario.PkIuDni);
            if (Isdniexist == true)
            {
                ModelState.AddModelError("PkIuDni", "ya existe este dni");
            }
            if (eUsuario.VuSexo == "1")
            {
                ModelState.AddModelError("VuSexo", "completar sexo");
            }
            if (ModelState.IsValid)
            {

                _context.Add(eUsuario);
                await _context.SaveChangesAsync();
                TempData["PkIuDni"] = eUsuario.PkIuDni;
                TempData["VuNombre"] = eUsuario.VuNombre;
                TempData["DuFechaNacimiento"] = eUsuario.DuFechaNacimiento;

                if (eUsuario.FkItuTipoUsuario == 1)
                {
                    return RedirectToAction("Create", "TNivelxTipoNivels");
                }
               else if (eUsuario.FkItuTipoUsuario == 2)
                {
                    return RedirectToAction("Create", "EUsuarios");
                }
                else if (eUsuario.FkItuTipoUsuario == 3)
                {
                    return RedirectToAction("Create", "EUsuarios");
                }


            }
           
            ViewData["PkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", eUsuario.FkIcId);
            ViewData["PkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", eUsuario.FkIdiCod);
            ViewData["PkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario", eUsuario.FkItuTipoUsuario);
            return View(eUsuario);
        }
    }
}