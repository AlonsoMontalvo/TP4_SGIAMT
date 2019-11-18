using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CUS_Actualizar_Datos_Alumno.Models;

namespace CUS_Actualizar_Datos_Alumno.Controllers
{
    public class TUsuariosController : Controller
    {
        private readonly BD_SGIAMTvsActualizar_Datos_AlumnoContext _context;

        public TUsuariosController(BD_SGIAMTvsActualizar_Datos_AlumnoContext context)
        {
            _context = context;
        }

        // GET: TUsuarios
        public async Task<IActionResult> Index()
        {
            var bD_SGIAMTvsActualizar_Datos_AlumnoContext = _context.TUsuario.Include(t => t.FkIc).Include(t => t.FkIdiCodNavigation).Include(t => t.FkItuTipoUsuarioNavigation);
            return View(await bD_SGIAMTvsActualizar_Datos_AlumnoContext.ToListAsync());
        }


        public IActionResult Edit()
        {
            //var tUsuario =  _context.TUsuario.Find(dni);
            
           return View();

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tUsuario = await _context.TUsuario.FindAsync(id);
            if (tUsuario == null)
            {
                return NotFound();
            }
            ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", tUsuario.FkIcId);
            ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", tUsuario.FkIdiCod);
            ViewData["FkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario", tUsuario.FkItuTipoUsuario);
            return View(tUsuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIuDni,VuNombre,VuApaterno,VuAmaterno,VuCelular,VuCorreo,VuDireccion,DuFechaNacimiento,VuSexo,VuContraseña,VuEstado,VuHorario,FkItuTipoUsuario,FkIcId,FkIdiCod")] TUsuario tUsuario)
        {
            if (id != tUsuario.PkIuDni)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TUsuarioExists(tUsuario.PkIuDni))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Alumno", "Alumnohome");
            }
            ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", tUsuario.FkIcId);
            ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", tUsuario.FkIdiCod);
            ViewData["FkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario", tUsuario.FkItuTipoUsuario);
            return View(tUsuario);
        }


        private bool TUsuarioExists(int id)
        {
            return _context.TUsuario.Any(e => e.PkIuDni == id);
        }
    }
}
