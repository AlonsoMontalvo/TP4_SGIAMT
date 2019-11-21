using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionarProgresoV2.Models;
using System.Runtime.Serialization;

namespace GestionarProgresoV2.Controllers
{
    public class TProgresoesController : Controller
    {
        private readonly BD_GestionarProgresoV2Context _context;

        public TProgresoesController(BD_GestionarProgresoV2Context context)
        {
            _context = context;
        }

        // GET: TProgresoes
        public async Task<IActionResult> Index()
        {
            var bD_GestionarProgresoV2Context = _context.TProgreso.Include(t => t.FkIsdSemanaxDiaNavigation).Include(t => t.FkIuDniNavigation);
            return View(await bD_GestionarProgresoV2Context.ToListAsync());
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
                                 (idtiponivel == 0 ? true : ntn.FkItnCod == idtiponivel)
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
                               join a in _context.TProgreso on sd2.PkIsdSemanaxDia equals a.FkIsdSemanaxDia
                               join u in _context.TUsuario on a.FkIuDni equals u.PkIuDni
                               where u.PkIuDni == iddni
                               select sd2).ToList().Count;
            var semanaList = (from semana in _context.TSemana
                              join sd in _context.TSemanaxDia on semana.PkIsSemana equals sd.FkIsSemana
                              join a in _context.TProgreso on sd.PkIsdSemanaxDia equals a.FkIsdSemanaxDia
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
                                    join a in _context.TProgreso on sd.PkIsdSemanaxDia equals a.FkIsdSemanaxDia
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
        public IActionResult GetProgresoxUsuario(int iddni)
        {
            var progresoXusuario = (from progreso in _context.TProgreso
                                    join u in _context.TUsuario on progreso.FkIuDni equals u.PkIuDni
                                    join sxd in _context.TSemanaxDia on progreso.FkIsdSemanaxDia equals sxd.PkIsdSemanaxDia
                                    join s in _context.TSemana on sxd.FkIsSemana equals s.PkIsSemana
                                    join d in _context.TDia on sxd.FkIdDia equals d.PkIdDia
                                    where progreso.FkIuDni == iddni
                                    select new ProgresoxUsuario
                                    {
                                        idprogreso = progreso.PkIpProgreso,
                                        semana = s.VsNombreSemana,
                                        nombre =progreso.VpNombreProgreso,
                                        notaPasos =progreso.DpNotaPasos,
                                        notaTecnica=progreso.DpNotaTecnica,
                                        notaInteres=progreso.DpNotaInteres,
                                        notaHabilidad=progreso.DpNotaHabilidad,
                                        totalNota=progreso.DpTotalNota,
                                        observacion=progreso.VpObservacion,
                                    }).ToList();

            return Json(new { progresos = progresoXusuario });
        }


        // GET: TProgresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProgreso = await _context.TProgreso
                .Include(t => t.FkIsdSemanaxDiaNavigation)
                .Include(t => t.FkIuDniNavigation)
                .FirstOrDefaultAsync(m => m.PkIpProgreso == id);
            if (tProgreso == null)
            {
                return NotFound();
            }

            return View(tProgreso);
        }

        // GET: TProgresoes/Create
        public IActionResult Create(int iddni)
        {
            var listarusuario = from u in _context.TUsuario
                                where u.FkItuTipoUsuario == 1
                                && u.PkIuDni == iddni
                                select u;


            ViewData["dni"] = iddni;
            return View();
        }

        // POST: TProgresoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Progreso tProgreso)
        {
            int IdSemanaDia = (from a in _context.TSemanaxDia
                               select a).FirstOrDefault(s => s.FkIdDia == tProgreso.IdDia && s.FkIsSemana == tProgreso.IdSemana).PkIsdSemanaxDia;
            var model = new TProgreso();
            
            model.VpNombreProgreso = tProgreso.Nombre;
            model.DpNotaPasos = tProgreso.NotaPasos;
            model.DpNotaTecnica = tProgreso.NotaTecnica;
            model.DpNotaInteres = tProgreso.NotaInteres;
            model.DpNotaHabilidad = tProgreso.NotaHabilidad;
            model.DpTotalNota = tProgreso.Total;
            model.VpObservacion = tProgreso.Observacion;
            model.FkIuDni = tProgreso.DNI;
            model.FkIsdSemanaxDia = IdSemanaDia;
            _context.TProgreso.Add(model);
            await _context.SaveChangesAsync();
            return Json(new { id = model.FkIuDni });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteProgreso tProgreso)
        {
            var model = await _context.TProgreso.FirstOrDefaultAsync(s => s.PkIpProgreso == tProgreso.idProgreso);
            _context.TProgreso.Remove(model);
            await _context.SaveChangesAsync();
            var isDelete = await _context.TProgreso.AnyAsync(s => s.PkIpProgreso == tProgreso.idProgreso);
            var result = isDelete ? false : true;
            return Json(new { result = result });
        }

        // POST: TProgresoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tProgreso = await _context.TProgreso.FindAsync(id);
        //    _context.TProgreso.Remove(tProgreso);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool TProgresoExists(int id)
        {
            return _context.TProgreso.Any(e => e.PkIpProgreso == id);
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
    public class ProgresoxUsuario
    {
        
        public int idprogreso { get; set; }
        public string semana { get; set; }
        public string nombre { get; set; }
        public int notaPasos { get; set; }
        public int notaTecnica { get; set; }
        public int notaInteres { get; set; }
        public int notaHabilidad { get; set; }
        public decimal totalNota { get; set; }
        public string observacion { get; set; }
        public int DNI { get; set; }
    }
    [DataContract]
    public class Progreso
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int NotaPasos { get; set; }
        [DataMember]
        public int NotaTecnica { get; set; }
        [DataMember]
        public int NotaInteres { get; set; }
        [DataMember]
        public int NotaHabilidad { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public string Observacion { get; set; }
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
    public class DeleteProgreso
    {
        [DataMember]
        public int idProgreso { get; set; }
    }
}

