using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CUS_Gestionar_Perfiles_Alumno.Models;

namespace CUS_Gestionar_Perfiles_Alumno.Controllers
{
    public class TUsuariosController : Controller
    {
        private readonly BD_SGIAMTGestionarPerfilesAlumnoContext _context;

        public TUsuariosController(BD_SGIAMTGestionarPerfilesAlumnoContext context)
        {
            _context = context;
        }

        // GET: TUsuarios
        [HttpPost]
        public IActionResult Select()
        {
            // var bD_Administrar_AsistenciaContext = _context.TUsuario.Include(t => t.FkItuTipoUsuarioNavigation);
            var usuario = from m in _context.TUsuario
                          join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                          // join ntp in _context.TNivelxTipoNivel on m.PkIuDni equals ntp.FkIuDni

                          // where m.PkIuDni !=ntp.FkIuDni
                          where m.FkItuTipoUsuario == 1 && m.VuEstado == "Inactivo"
                          select m;
            return View(usuario.ToList());
        }
        public IActionResult Index()
        {
            var usuario = from m in _context.TUsuario
                          join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                          // join ntp in _context.TNivelxTipoNivel on m.PkIuDni equals ntp.FkIuDni

                          // where m.PkIuDni !=ntp.FkIuDni
                          where m.FkItuTipoUsuario == 1

                          select m;
            return View(usuario);
        }

        [HttpGet]
        public IActionResult GetComboBoxDni()
        {

            var ddni = (from m in _context.TUsuario
                        join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                        where m.FkItuTipoUsuario == 1 && m.VuEstado == "Activo"
                        select new ItemCombo
                        {
                            idDni = m.PkIuDni
                        }).ToList();

            return Json(new { dni = ddni });
        }

        [HttpGet]
        public IActionResult GetComboBoxDniInactivo()
        {

            var ddni1 = (from m in _context.TUsuario
                         join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                         where m.FkItuTipoUsuario == 1 && m.VuEstado == "Inactivo"
                         select new ItemCombo2
                         {
                             idDni2 = m.PkIuDni
                         }).ToList();

            return Json(new { dni1 = ddni1 });
        }

        [HttpGet]
        public IActionResult UsuarioActivo(int iddni)
        {
            var usuario = (from m in _context.TUsuario
                           join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                           where (iddni == 0 ? true : m.PkIuDni == iddni)
                           where (v.PkItuTipoUsuario == 1 && m.VuEstado == "Activo")
                           select new UsuarioxTipo
                           {
                               dni = m.PkIuDni,
                               nombre = m.VuNombre,
                               apellidoP = m.VuApaterno,
                               apellidoM = m.VuAmaterno,
                               estado = m.VuEstado,
                               tipousu = v.VtuNombreTipoUsuario,
                           }).ToList();

            return Json(new { listusuarioactivo = usuario });
        }

        [HttpGet]
        public IActionResult UsuarioInactivo()
        {
            var usuarioInac = (from m in _context.TUsuario
                               join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
                               where v.PkItuTipoUsuario == 1 && m.VuEstado == "Inactivo"
                               select new UsuarioxTipo
                               {
                                   dni = m.PkIuDni,
                                   nombre = m.VuNombre,
                                   apellidoP = m.VuApaterno,
                                   apellidoM = m.VuAmaterno,
                                   estado = m.VuEstado,
                                   tipousu = v.VtuNombreTipoUsuario,
                               }).ToList();

            return Json(new { listusuarioinactivo = usuarioInac });
        }
        public class UsuarioxTipo
        {
            public int dni { get; set; }
            public string nombre { get; set; }
            public string apellidoP { get; set; }
            public string apellidoM { get; set; }
            public string estado { get; set; }
            public string tipousu { get; set; }

        }
        public class ItemCombo
        {
            public int idDni { get; set; }
        }
        public class ItemCombo2
        {
            public int idDni2 { get; set; }
        }
      
        public async Task<IActionResult> Activo(int? id)
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
            //ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", tUsuario.FkIcId);
            //ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", tUsuario.FkIdiCod);
            ViewData["FkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario", tUsuario.FkItuTipoUsuario);
            return View(tUsuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activo(int id)
        {

            var tPago = await _context.TUsuario.FindAsync(id);
            tPago.VuEstado = "Activo";
            _context.Update(tPago);
            //var tusuario = await _context.TUsuario.FindAsync(tComprobantePago.FkIpId);
            //tusuario.VuEstado = "Activo";
            //_context.Update(tusuario);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "TUsuarios");
        }
        public async Task<IActionResult> Inactivo(int? id)
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
            //ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", tUsuario.FkIcId);
            //ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", tUsuario.FkIdiCod);
            ViewData["FkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario", tUsuario.FkItuTipoUsuario);
            return View(tUsuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inactivo(int id)
        {

            var tPago = await _context.TUsuario.FindAsync(id);
            tPago.VuEstado = "Inactivo";
            _context.Update(tPago);
            //var tusuario = await _context.TUsuario.FindAsync(tComprobantePago.FkIpId);
            //tusuario.VuEstado = "Activo";
            //_context.Update(tusuario);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "TUsuarios");
        }

    }
}