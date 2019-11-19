using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGIAMT_Integracion.Models;

namespace SGIAMT_Integracion.Controllers
{
    public class TUsuariosController : Controller
    {
        private readonly BD_SGIAMTIntegracionContext _context;

        public TUsuariosController(BD_SGIAMTIntegracionContext context)
        {
            _context = context;
        }

        // GET: TUsuarios
        public async Task<IActionResult> Index()
        {
            var bD_Administrar_AsistenciaContext = _context.TUsuario.Include(t => t.FkItuTipoUsuarioNavigation);
            return View(await bD_Administrar_AsistenciaContext.ToListAsync());
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
                           where (iddni == 0 ? true : m.PkIuDni == iddni) where (v.PkItuTipoUsuario == 1 && m.VuEstado == "Activo")
                           select new UsuarioxTipo
                           {
                               dni = m.PkIuDni,
                               nombre = m.VuNombre,
                               apellidoP = m.VuApaterno,
                               apellidoM = m.VuAmaterno,
                               estado = m.VuEstado,
                               tipousu = v.PkItuTipoUsuario,
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
                               tipousu = v.PkItuTipoUsuario,
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
            public int tipousu { get; set; }

        }
        // GET: TUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tUsuario = await _context.TUsuario
                .Include(t => t.FkIcIdNavigation)
                .Include(t => t.FkIdiCodNavigation)
                .Include(t => t.FkItuTipoUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.PkIuDni == id);
            if (tUsuario == null)
            {
                return NotFound();
            }

            return View(tUsuario);
        }

        // GET: TUsuarios/Create
        public IActionResult Create()
        {
            ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat");
            ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis");
            ViewData["FkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario");
            return View();
        }

        // POST: TUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIuDni,VuNombre,VuApaterno,VuAmaterno,VuCelular,VuCorreo,VuDireccion,DuFechaNacimiento,VuSexo,VuContraseña,VuEstado,VuHorario,FkItuTipoUsuario,FkIcId,FkIdiCod")] TUsuario tUsuario)
        {
            bool Isdniexist = _context.TUsuario.Any
                (x => x.PkIuDni == tUsuario.PkIuDni);
            if (Isdniexist == true)
            {
                ModelState.AddModelError("PkIuDni", "ya existe este dni");
            }
            if (tUsuario.VuSexo == "1")
            {
                ModelState.AddModelError("VuSexo", "completar sexo");
            }
            if (ModelState.IsValid)
            {
                _context.Add(tUsuario);
                await _context.SaveChangesAsync();
                TempData["PkIuDni"] = tUsuario.PkIuDni;
                TempData["VuNombre"] = tUsuario.VuNombre;
                TempData["DuFechaNacimiento"] = tUsuario.DuFechaNacimiento;

                if (tUsuario.FkItuTipoUsuario == 1)
                {
                    return RedirectToAction("Create", "TNivelxTipoNivels");
                }
                else if (tUsuario.FkItuTipoUsuario == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (tUsuario.FkItuTipoUsuario == 3)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", tUsuario.FkIcId);
            ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", tUsuario.FkIdiCod);
            ViewData["FkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario", tUsuario.FkItuTipoUsuario);
            return View(tUsuario);
        }
        public class ItemCombo
        {
            public int idDni { get; set; }
        }
        public class ItemCombo2
        {
            public int idDni2 { get; set; }
        }
        // GET: TUsuarios/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tUsuario = await _context.TUsuario.FindAsync(id);
        //    if (tUsuario == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", tUsuario.FkIcId);
        //    ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", tUsuario.FkIdiCod);
        //    ViewData["FkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario", tUsuario.FkItuTipoUsuario);
        //    return View(tUsuario);
        //}

        // POST: TUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PkIuDni,VuNombre,VuApaterno,VuAmaterno,VuCelular,VuCorreo,VuDireccion,DuFechaNacimiento,VuSexo,VuContraseña,VuEstado,VuHorario,FkItuTipoUsuario,FkIcId,FkIdiCod")] TUsuario tUsuario)
        //{
        //    if (id != tUsuario.PkIuDni)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tUsuario);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TUsuarioExists(tUsuario.PkIuDni))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", tUsuario.FkIcId);
        //    ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", tUsuario.FkIdiCod);
        //    ViewData["FkItuTipoUsuario"] = new SelectList(_context.TTipoUsuario, "PkItuTipoUsuario", "VtuNombreTipoUsuario", tUsuario.FkItuTipoUsuario);
        //    return View(tUsuario);
        //}

        // GET: TUsuarios/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tUsuario = await _context.TUsuario
        //        .Include(t => t.FkIcIdNavigation)
        //        .Include(t => t.FkIdiCodNavigation)
        //        .Include(t => t.FkItuTipoUsuarioNavigation)
        //        .FirstOrDefaultAsync(m => m.PkIuDni == id);
        //    if (tUsuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tUsuario);
        //}

        //// POST: TUsuarios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tUsuario = await _context.TUsuario.FindAsync(id);
        //    _context.TUsuario.Remove(tUsuario);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TUsuarioExists(int id)
        //{
        //    return _context.TUsuario.Any(e => e.PkIuDni == id);
        //}
    }
}
