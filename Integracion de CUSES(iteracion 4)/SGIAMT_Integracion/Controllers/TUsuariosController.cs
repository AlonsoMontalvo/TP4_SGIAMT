using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
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

        //[HttpPost]
        //public IActionResult Select()
        //{
        //    var bD_Administrar_AsistenciaContext = _context.TUsuario.Include(t => t.FkItuTipoUsuarioNavigation);
        //    var usuario = from m in _context.TUsuario
        //                  join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario
        //                  join ntp in _context.TNivelxTipoNivel on m.PkIuDni equals ntp.FkIuDni

        //                  where m.PkIuDni != ntp.FkIuDni
        //                  where m.FkItuTipoUsuario == 1 && m.VuEstado == "Inactivo"
        //                  select m;
        //    return View(usuario.ToList());
        //}

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
            ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", tUsuario.FkIcId);
            ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", tUsuario.FkIdiCod);
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
            ViewData["FkIcId"] = new SelectList(_context.TCategoría, "PkIcId", "VcNombreCat", tUsuario.FkIcId);
            ViewData["FkIdiCod"] = new SelectList(_context.TDistrito, "PkIdiCod", "VdiNombreDis", tUsuario.FkIdiCod);
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



        public IActionResult DetalleHorarioClase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // var tasistencia = await _context.TPago.FindAsync(id);

            var detallehorarioclase = (from progreso in _context.TProgreso
                                       join up in _context.TUsuarioxProgreso on progreso.PkIpCod equals up.FkIpCod
                                       join u in _context.TUsuario on up.FkIuDni equals u.PkIuDni
                                       join ntn in _context.TNivelxTipoNivel on u.PkIuDni equals ntn.FkIuDni
                                       join n in _context.TNivel on ntn.FkInCod equals n.PkInCod
                                       join tn in _context.TTipoNivel on ntn.FkItnCod equals tn.PkItnCod
                                       join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                       join a in _context.TAsistencia on u.PkIuDni equals a.FkIuDni
                                       join sxd in _context.TSemanaxDia on a.FkIsdSemanaxDia equals sxd.PkIsdSemanaxDia
                                       join s in _context.TSemana on sxd.FkIsSemana equals s.PkIsSemana
                                       join d in _context.TDia on sxd.FkIdDia equals d.PkIdDia
                                       where u.PkIuDni == id
                                       select new horarioclaseview
                                       {
                                           pkasistencia = u.PkIuDni,
                                           nombre = u.VuNombre,
                                           apellidopa = u.VuApaterno,
                                           apellidoma = u.VuAmaterno,
                                           semana = s.VsNombreSemana,
                                           dia = d.VdNombreDia,
                                           horario = u.VuHorario,
                                           nivel = n.VnNombreNivel,
                                           tiponivel = tn.ItnNombreTipoNivel,
                                           VupNombreProfesor = up.VupNombreProfesor

                                       }).ToList();

            var detalle = detallehorarioclase.ToList();

            if (detallehorarioclase == null)
            {
                return NotFound();
            }

            return View(detalle);
        }
        public IActionResult ImprimirHorarioClase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // var tasistencia = await _context.TPago.FindAsync(id);

            var imprimirhorariodeclase = (from progreso in _context.TProgreso
                                       join up in _context.TUsuarioxProgreso on progreso.PkIpCod equals up.FkIpCod
                                       join u in _context.TUsuario on up.FkIuDni equals u.PkIuDni
                                       join ntn in _context.TNivelxTipoNivel on u.PkIuDni equals ntn.FkIuDni
                                       join n in _context.TNivel on ntn.FkInCod equals n.PkInCod
                                       join tn in _context.TTipoNivel on ntn.FkItnCod equals tn.PkItnCod
                                       join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                       join a in _context.TAsistencia on u.PkIuDni equals a.FkIuDni
                                       join sxd in _context.TSemanaxDia on a.FkIsdSemanaxDia equals sxd.PkIsdSemanaxDia
                                       join s in _context.TSemana on sxd.FkIsSemana equals s.PkIsSemana
                                       join d in _context.TDia on sxd.FkIdDia equals d.PkIdDia
                                       where u.PkIuDni == id
                                       select new horarioclaseview
                                       {
                                           pkasistencia = u.PkIuDni,
                                           nombre = u.VuNombre,
                                           apellidopa = u.VuApaterno,
                                           apellidoma = u.VuAmaterno,
                                           semana = s.VsNombreSemana,
                                           dia = d.VdNombreDia,
                                           horario = u.VuHorario,
                                           nivel = n.VnNombreNivel,
                                           tiponivel = tn.ItnNombreTipoNivel,
                                           VupNombreProfesor = up.VupNombreProfesor

                                       }).ToList();

            var detalle = imprimirhorariodeclase.ToList();

            if (imprimirhorariodeclase == null)
            {
                return NotFound();
            }

            return new ViewAsPdf("ImprimirHorarioClase", detalle);
        }
        public class horarioclaseview
        {
            public int pkasistencia { get; set; }

            public string nombre { get; set; }
            public string apellidopa { get; set; }
            public string apellidoma { get; set; }
            public string semana { get; set; }
            public string dia { get; set; }
            public string horario { get; set; }
            public string nivel { get; set; }
            public string tiponivel { get; set; }

            public string VupNombreProfesor { get; set; }

        }
    }
}
