using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


using SGIAMT_Integracion.Models;

namespace SGIAMT_Integracion.Controllers
{
    public class TAsistenciasController : Controller
    {
        private readonly BD_SGIAMTIntegracionContext _context;

        public TAsistenciasController(BD_SGIAMTIntegracionContext context)
        {
            _context = context;
        }

        // GET: TAsistencias
        public async Task<IActionResult> Index()
        {
            var bD_Administrar_AsistenciaContext = _context.TAsistencia.Include(t => t.FkIsdSemanaxDiaNavigation).Include(t => t.FkIuDniNavigation);
            return View(await bD_Administrar_AsistenciaContext.ToListAsync());
        }


        [HttpGet]
        public IActionResult GetComboBox()
        {

            var nnivel = _context.TNivel.ToList();
            var tnivel = _context.TTipoNivel.ToList();

            return Json(new { nivel = nnivel, tiponivel = tnivel });//dos listas vacias
        }

        [HttpGet]
        public IActionResult GetUsersPagination(int idnivel, int idtiponivel)
        {

            var listUsuario = _context.TUsuario.ToList();
            var usuario = (from u in _context.TUsuario
                           join ntn in _context.TNivelxTipoNivel on u.PkIuDni equals ntn.FkIuDni
                           join n in _context.TNivel on ntn.FkInCod equals n.PkInCod
                           join tn in _context.TTipoNivel on ntn.FkItnCod equals tn.PkItnCod
                           where (idnivel == 0 ? true : ntn.FkInCod == idnivel) &&
                                 (idtiponivel == 0 ? true : ntn.FkItnCod == idtiponivel)&&(u.VuEstado=="Activo")
                           select new UsuarioxTipo
                           {
                               dni = u.PkIuDni,
                               nombre = u.VuNombre,
                               apellidoP = u.VuApaterno,
                               apellidoM = u.VuAmaterno,
                               nivel = n.VnNombreNivel,
                               tnivel = tn.ItnNombreTipoNivel
                           }).ToList();

            return Json(new { usuarios = usuario });
        }

        [HttpGet]
        public IActionResult GetComboSemana(int iddni)
        {
            int countsemana = (from semana in _context.TSemana
                               join sd2 in _context.TSemanaxDia on semana.PkIsSemana equals sd2.FkIsSemana
                               join a in _context.TAsistencia on sd2.PkIsdSemanaxDia equals a.FkIsdSemanaxDia
                               join u in _context.TUsuario on a.FkIuDni equals u.PkIuDni
                               where u.PkIuDni == iddni
                               select sd2).ToList().Count;
            var semanaList = (from semana in _context.TSemana
                              join sd in _context.TSemanaxDia on semana.PkIsSemana equals sd.FkIsSemana
                              join a in _context.TAsistencia on sd.PkIsdSemanaxDia equals a.FkIsdSemanaxDia
                              join u in _context.TUsuario on a.FkIuDni equals u.PkIuDni
                              where u.PkIuDni == iddni
                              &&
                              (
                                (from td1 in _context.TDia
                                 join tsd2 in _context.TSemanaxDia on td1.PkIdDia equals tsd2.FkIdDia
                                 where tsd2.FkIsSemana == semana.PkIsSemana
                                 select td1
                                ).Count() <= countsemana
                              )
                              select semana).ToList();
            var result = (
                          from t_semana in _context.TSemana
                          where !(
                                  from s_list in semanaList
                                  select s_list.PkIsSemana).Contains(t_semana.PkIsSemana)
                          select new ItemCombo()
                          {
                              id = t_semana.PkIsSemana,
                              value = t_semana.VsNombreSemana
                          }).ToList();
            return Json(new { semanas = result });
        }

        [HttpGet]
        public IActionResult GetComboDia(int iddni, int idsemana)
        {

            var allDaysOfWeek = (from ndia in _context.TDia
                                 join nsd in _context.TSemanaxDia on ndia.PkIdDia equals nsd.FkIdDia
                                 where nsd.FkIsSemana == idsemana
                                 select ndia).ToList();
            var result = (
                            from allday in allDaysOfWeek
                            where !(
                                    from dia in _context.TDia
                                    join sd in _context.TSemanaxDia on dia.PkIdDia equals sd.FkIdDia
                                    join a in _context.TAsistencia on sd.PkIsdSemanaxDia equals a.FkIsdSemanaxDia
                                    join u in _context.TUsuario on a.FkIuDni equals u.PkIuDni
                                    where u.PkIuDni == iddni && sd.FkIsSemana == idsemana
                                    select dia.PkIdDia).Contains(allday.PkIdDia)
                            select new ItemCombo
                            {
                                id = allday.PkIdDia,
                                value = allday.VdNombreDia
                            }).ToList();
            return Json(new { dias = result });
        }

        [HttpGet]
        public IActionResult GetAsistenciaxUsuario(int iddni)
        {
            var asistenciaXusuario = (from asistencia in _context.TAsistencia
                                      join u in _context.TUsuario on asistencia.FkIuDni equals u.PkIuDni
                                      join sxd in _context.TSemanaxDia on asistencia.FkIsdSemanaxDia equals sxd.PkIsdSemanaxDia
                                      join s in _context.TSemana on sxd.FkIsSemana equals s.PkIsSemana
                                      join d in _context.TDia on sxd.FkIdDia equals d.PkIdDia
                                      where asistencia.FkIuDni == iddni
                                      select new AsistenciaxUsuario
                                      {
                                          idasistencia = asistencia.PkIaAsistencia,
                                          semana = s.VsNombreSemana,
                                          dia = d.VdNombreDia,
                                          hora = asistencia.TaHora,
                                          estadoAsistencia = asistencia.VaEstadoAsistencia
                                      }).ToList();

            return Json(new { asistencias = asistenciaXusuario });
        }
        // GET: TAsistencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAsistencia = await _context.TAsistencia
                .Include(t => t.FkIsdSemanaxDiaNavigation)
                .Include(t => t.FkIuDniNavigation)
                .FirstOrDefaultAsync(m => m.PkIaAsistencia == id);
            if (tAsistencia == null)
            {
                return NotFound();
            }

            return View(tAsistencia);
        }
        // GET: TAsistencias/Create
        public IActionResult Create(int iddni)
        {
            var listarusuario = from u in _context.TUsuario
                                where u.FkItuTipoUsuario == 1
                                && u.PkIuDni == iddni
                                select u;


            ViewData["dni"] = iddni;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Asistencia tAsistencia)
        {
            int IdSemanaDia = (from a in _context.TSemanaxDia
                               select a).FirstOrDefault(s => s.FkIdDia == tAsistencia.IdDia && s.FkIsSemana == tAsistencia.IdSemana).PkIsdSemanaxDia;
            var model = new TAsistencia();
            model.TaHora = tAsistencia.Hora;
            model.VaEstadoAsistencia = tAsistencia.EstadoAsistencia;
            model.FkIuDni = tAsistencia.DNI;
            model.FkIsdSemanaxDia = IdSemanaDia;
            _context.TAsistencia.Add(model);
            await _context.SaveChangesAsync();
            return Json(new { id = model.FkIuDni });
        }

        //GET: TAsistencias/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteAsistencia tAsistencia)
        {
            var model = await _context.TAsistencia.FirstOrDefaultAsync(s => s.PkIaAsistencia == tAsistencia.idAsistencia);
            _context.TAsistencia.Remove(model);
            await _context.SaveChangesAsync();
            var isDelete = await _context.TAsistencia.AnyAsync(s => s.PkIaAsistencia == tAsistencia.idAsistencia);
            var result = isDelete ? false : true;
            return Json(new { result = result });
        }


        // POST: TAsistencias/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tAsistencia = await _context.TAsistencia.FindAsync(id);
        //    _context.TAsistencia.Remove(tAsistencia);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool TAsistenciaExists(int id)
        {
            return _context.TAsistencia.Any(e => e.PkIaAsistencia == id);
        }

    }



    public class ItemCombo
    {
        public int id { get; set; }
        public string value { get; set; }
    }

    public class UsuarioxTipo
    {
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string nivel { get; set; }
        public string tnivel { get; set; }

    }
    public class AsistenciaxUsuario
    {
        public int idasistencia { get; set; }
        public string hora { get; set; }
        public string estadoAsistencia { get; set; }
        public string semana { get; set; }
        public string dia { get; set; }

    }
    [DataContract]
    public class Asistencia
    {
        [DataMember]
        public string Hora { get; set; }

        [DataMember]
        public string EstadoAsistencia { get; set; }

        [DataMember]
        public int DNI { get; set; }

        [DataMember]
        public int IdSemanaDia { get; set; }
        [DataMember]
        public int IdDia { get; set; }

        [DataMember]
        public int IdSemana { get; set; }
    }
    [DataContract]
    public class DeleteAsistencia
    {
        [DataMember]
        public int idAsistencia { get; set; }
    }
}
