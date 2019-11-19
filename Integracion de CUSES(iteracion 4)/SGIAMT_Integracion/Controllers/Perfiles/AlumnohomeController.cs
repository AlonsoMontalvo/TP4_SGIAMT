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
    public class AlumnohomeController : Controller
    {

        private readonly BD_SGIAMTIntegracionContext _context;
        public AlumnohomeController(BD_SGIAMTIntegracionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public class Us
        {
            public int PkIuDni { get; set; }
        }

        public IActionResult Alumno()
        {
            var modificaralumnos = (from m in _context.TUsuario
                                    join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                    where m.FkItuTipoUsuario == 1
                                    select m
                                    ).ToList();
            var bD_SGIAMTvsActualizar_Datos_AlumnoContext = modificaralumnos.ToList();
            return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Alumno(int dni)
        //{
        //    var modificaralumnos = (from m in _context.TUsuario
        //                            join v in _context.TTipoUsuario on m.FkItuTipoUsuario equals v.PkItuTipoUsuario

        //                            where m.FkItuTipoUsuario == 1 && m.PkIuDni == dni

        //                            select m
        //                            ).ToList();
        //    var bD_SGIAMTvsActualizar_Datos_AlumnoContext = modificaralumnos.ToList();
        //    await Task.Delay(200);
        //    return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext);
        //}



        public IActionResult ReporteProgreso()
        {
            var detalleprogreso = (from progreso in _context.TProgreso
                                   join up in _context.TUsuarioxProgreso on progreso.PkIpCod equals up.FkIpCod
                                   join u in _context.TUsuario on up.FkIuDni equals u.PkIuDni
                                   join ntn in _context.TNivelxTipoNivel on u.PkIuDni equals ntn.FkIuDni
                                   join n in _context.TNivel on ntn.FkInCod equals n.PkInCod
                                   join tn in _context.TTipoNivel on ntn.FkItnCod equals tn.PkItnCod
                                   join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                   where progreso.PkIpCod == 0
                                   select new Detalleprogresoview
                                   {
                                       pkasistencia = progreso.PkIpCod,
                                       FkIuDni = u.PkIuDni,
                                       nombre = u.VuNombre,
                                       apellidopa = u.VuApaterno,
                                       apellidoma = u.VuAmaterno,
                                       VupSemana = up.VupSemana,
                                       VupNombreProfesor = up.VupNombreProfesor,

                                       DpNotaPasos = progreso.DpNotaPasos,
                                       DpNotaTecnica = progreso.DpNotaTecnica,
                                       DpNotaInteres = progreso.DpNotaInteres,
                                       DpNotaHabilidad = progreso.DpNotaHabilidad,
                                       DpTotalNota = progreso.DpTotalNota,

                                       VpObservacion = progreso.VpObservacion

                                   }).ToList();
            var llenarview = detalleprogreso.ToList();
            return View(llenarview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReporteProgreso(string semana, int? dni)
        {
            if (semana != null && dni != null)
            {
                var detalleprogresosemana = (from progreso in _context.TProgreso
                                             join up in _context.TUsuarioxProgreso on progreso.PkIpCod equals up.FkIpCod
                                             join u in _context.TUsuario on up.FkIuDni equals u.PkIuDni
                                             join ntn in _context.TNivelxTipoNivel on u.PkIuDni equals ntn.FkIuDni
                                             join n in _context.TNivel on ntn.FkInCod equals n.PkInCod
                                             join tn in _context.TTipoNivel on ntn.FkItnCod equals tn.PkItnCod
                                             join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                             where u.PkIuDni == dni && up.VupSemana == semana
                                             select new Detalleprogresoview
                                             {
                                                 pkasistencia = progreso.PkIpCod,
                                                 FkIuDni = u.PkIuDni,
                                                 nombre = u.VuNombre,
                                                 apellidopa = u.VuApaterno,
                                                 apellidoma = u.VuAmaterno,
                                                 VupSemana = up.VupSemana,
                                                 VupNombreProfesor = up.VupNombreProfesor,

                                                 DpNotaPasos = progreso.DpNotaPasos,
                                                 DpNotaTecnica = progreso.DpNotaTecnica,
                                                 DpNotaInteres = progreso.DpNotaInteres,
                                                 DpNotaHabilidad = progreso.DpNotaHabilidad,
                                                 DpTotalNota = progreso.DpTotalNota,

                                                 VpObservacion = progreso.VpObservacion

                                             }).ToList();

                var semanaecontrado = detalleprogresosemana.ToList();
                return View(semanaecontrado);
            }

            var detalledniprogreso = (from progreso in _context.TProgreso
                                      join up in _context.TUsuarioxProgreso on progreso.PkIpCod equals up.FkIpCod
                                      join u in _context.TUsuario on up.FkIuDni equals u.PkIuDni
                                      join ntn in _context.TNivelxTipoNivel on u.PkIuDni equals ntn.FkIuDni
                                      join n in _context.TNivel on ntn.FkInCod equals n.PkInCod
                                      join tn in _context.TTipoNivel on ntn.FkItnCod equals tn.PkItnCod
                                      join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario

                                      where u.PkIuDni == dni
                                      select new Detalleprogresoview
                                      {
                                          pkasistencia = progreso.PkIpCod,
                                          FkIuDni = u.PkIuDni,
                                          nombre = u.VuNombre,
                                          apellidopa = u.VuApaterno,
                                          apellidoma = u.VuAmaterno,
                                          VupSemana = up.VupSemana,
                                          VupNombreProfesor = up.VupNombreProfesor,

                                          DpNotaPasos = progreso.DpNotaPasos,
                                          DpNotaTecnica = progreso.DpNotaTecnica,
                                          DpNotaInteres = progreso.DpNotaInteres,
                                          DpNotaHabilidad = progreso.DpNotaHabilidad,
                                          DpTotalNota = progreso.DpTotalNota,

                                          VpObservacion = progreso.VpObservacion

                                      }).ToList();

            var verdetalleprogreso = detalledniprogreso.ToList();
            return View(verdetalleprogreso);
        }
        public IActionResult ReporteAsistencia()
        {
            var modificaralumnos = (from asistencia in _context.TAsistencia
                                    join u in _context.TUsuario on asistencia.FkIuDni equals u.PkIuDni
                                    join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario
                                    join sxd in _context.TSemanaxDia on asistencia.FkIsdSemanaxDia equals sxd.PkIsdSemanaxDia
                                    join s in _context.TSemana on sxd.FkIsSemana equals s.PkIsSemana
                                    join d in _context.TDia on sxd.FkIdDia equals d.PkIdDia
                                    where asistencia.FkIuDni == 0
                                    select new AsistenciaxUsuario1

                                    {
                                        FkIuDni = asistencia.FkIuDni,
                                        hora = u.VuHorario,
                                        VaEstadoAsistencia = asistencia.VaEstadoAsistencia,
                                        semana = s.VsNombreSemana,
                                        dia = d.VdNombreDia
                                    }).ToList();

            var bD_SGIAMTvsActualizar_Datos_AlumnoContext = modificaralumnos.ToList();
            return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReporteAsistencia(string dia, string semana, int? dni)
        {
            if (dia == null && semana != null && dni != null)
            {
                var buscarsemana = (from asistencia in _context.TAsistencia
                                    join u in _context.TUsuario on asistencia.FkIuDni equals u.PkIuDni
                                    join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario
                                    join sxd in _context.TSemanaxDia on asistencia.FkIsdSemanaxDia equals sxd.PkIsdSemanaxDia
                                    join s in _context.TSemana on sxd.FkIsSemana equals s.PkIsSemana
                                    join d in _context.TDia on sxd.FkIdDia equals d.PkIdDia
                                    where s.VsNombreSemana == semana && asistencia.FkIuDni == dni
                                    select new AsistenciaxUsuario1
                                    {
                                        pkasistencia = asistencia.PkIaAsistencia,
                                        FkIuDni = asistencia.FkIuDni,
                                        hora = u.VuHorario,
                                        VaEstadoAsistencia = asistencia.VaEstadoAsistencia,
                                        semana = s.VsNombreSemana,
                                        dia = d.VdNombreDia
                                    }).ToList();

                var semanaecontrado = buscarsemana.ToList();
                return View(semanaecontrado);
            }
            else if (dia != null && semana == null && dni != null)
            {
                var buscardia = (from asistencia in _context.TAsistencia
                                 join u in _context.TUsuario on asistencia.FkIuDni equals u.PkIuDni
                                 join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario
                                 join sxd in _context.TSemanaxDia on asistencia.FkIsdSemanaxDia equals sxd.PkIsdSemanaxDia
                                 join s in _context.TSemana on sxd.FkIsSemana equals s.PkIsSemana
                                 join d in _context.TDia on sxd.FkIdDia equals d.PkIdDia
                                 where d.VdNombreDia == dia && asistencia.FkIuDni == dni
                                 select new AsistenciaxUsuario1
                                 {
                                     pkasistencia = asistencia.PkIaAsistencia,
                                     FkIuDni = asistencia.FkIuDni,
                                     hora = u.VuHorario,
                                     VaEstadoAsistencia = asistencia.VaEstadoAsistencia,
                                     semana = s.VsNombreSemana,
                                     dia = d.VdNombreDia
                                 }).ToList();

                var diaencontrado = buscardia.ToList();
                return View(diaencontrado);
            }
            else if (dia != null && semana != null && dni != null)
            {
                var buscardiasemana = (from asistencia in _context.TAsistencia
                                       join u in _context.TUsuario on asistencia.FkIuDni equals u.PkIuDni
                                       join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario
                                       join sxd in _context.TSemanaxDia on asistencia.FkIsdSemanaxDia equals sxd.PkIsdSemanaxDia
                                       join s in _context.TSemana on sxd.FkIsSemana equals s.PkIsSemana
                                       join d in _context.TDia on sxd.FkIdDia equals d.PkIdDia
                                       where d.VdNombreDia == dia && s.VsNombreSemana == semana && asistencia.FkIuDni == dni
                                       select new AsistenciaxUsuario1
                                       {
                                           pkasistencia = asistencia.PkIaAsistencia,
                                           FkIuDni = asistencia.FkIuDni,
                                           hora = u.VuHorario,
                                           VaEstadoAsistencia = asistencia.VaEstadoAsistencia,
                                           semana = s.VsNombreSemana,
                                           dia = d.VdNombreDia
                                       }).ToList();

                var semanadiaencontrado = buscardiasemana.ToList();
                return View(semanadiaencontrado);
            }
            var modificaralumnos1 = (from asistencia in _context.TAsistencia
                                     join u in _context.TUsuario on asistencia.FkIuDni equals u.PkIuDni
                                     join v in _context.TTipoUsuario on u.FkItuTipoUsuario equals v.PkItuTipoUsuario
                                     join sxd in _context.TSemanaxDia on asistencia.FkIsdSemanaxDia equals sxd.PkIsdSemanaxDia
                                     join s in _context.TSemana on sxd.FkIsSemana equals s.PkIsSemana
                                     join d in _context.TDia on sxd.FkIdDia equals d.PkIdDia
                                     where asistencia.FkIuDni == dni
                                     select new AsistenciaxUsuario1
                                     {
                                         pkasistencia = asistencia.PkIaAsistencia,
                                         FkIuDni = asistencia.FkIuDni,
                                         hora = u.VuHorario,
                                         VaEstadoAsistencia = asistencia.VaEstadoAsistencia,
                                         semana = s.VsNombreSemana,
                                         dia = d.VdNombreDia
                                     }).ToList();

            var bD_SGIAMTvsActualizar_Datos_AlumnoContext1 = modificaralumnos1.ToList();
            return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext1);
        }

        public class AsistenciaxUsuario1
        {
            public int pkasistencia { get; set; }
            public int FkIuDni { get; set; }
            public string hora { get; set; }
            public string VaEstadoAsistencia { get; set; }
            public string semana { get; set; }
            public string dia { get; set; }

        }
        public class Detalleprogresoview
        {
            public int pkasistencia { get; set; }

            public string nombre { get; set; }
            public string apellidopa { get; set; }
            public string apellidoma { get; set; }
            public int FkIuDni { get; set; }


            public string VupSemana { get; set; }
            public string VupNombreProfesor { get; set; }


            public int DpNotaPasos { get; set; }
            public int DpNotaTecnica { get; set; }
            public int DpNotaInteres { get; set; }
            public int DpNotaHabilidad { get; set; }
            public decimal DpTotalNota { get; set; }
            public string VpObservacion { get; set; }
        }

        public IActionResult HorarioClase()
        {
            var horarioclase = (from progreso in _context.TProgreso
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
                                where u.PkIuDni == 0
                                   select new horarioclaseview
                                   {
                                       pkasistencia = u.PkIuDni,
                                       nombre = u.VuNombre,
                                       apellidopa = u.VuApaterno,
                                       apellidoma = u.VuAmaterno,
                                       semana=s.VsNombreSemana,
                                       dia = d.VdNombreDia,
                                       horario=u.VuHorario,
                                       nivel=n.VnNombreNivel,
                                       tiponivel= tn.ItnNombreTipoNivel,
                                       VupNombreProfesor=up.VupNombreProfesor

                                   }).ToList();
            var llenarview = horarioclase.ToList();
            return View(llenarview);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HorarioClase(string dia, string semana, int? dni)
        {
            if (dia == null && semana != null && dni != null)
            {
                var buscarsemana = (from progreso in _context.TProgreso
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
                                    where u.PkIuDni == dni && s.VsNombreSemana == semana
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

                var semanaecontrado = buscarsemana.ToList();
                return View(semanaecontrado);
            }
            else if (dia != null && semana == null && dni != null)
            {
                var buscardia = (from progreso in _context.TProgreso
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
                                 where u.PkIuDni == dni && d.VdNombreDia == dia
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

                var diaencontrado = buscardia.ToList();
                return View(diaencontrado);
            }
            else if (dia != null && semana != null && dni != null)
            {
                var buscardiasemana = (from progreso in _context.TProgreso
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
                                       where u.PkIuDni == dni && s.VsNombreSemana==semana && d.VdNombreDia==dia
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

                var semanadiaencontrado = buscardiasemana.ToList();
                return View(semanadiaencontrado);
            }
            var modificaralumnos1 = (from progreso in _context.TProgreso
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
                                     where u.PkIuDni == dni
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

            var bD_SGIAMTvsActualizar_Datos_AlumnoContext1 = modificaralumnos1.ToList();
            return View(bD_SGIAMTvsActualizar_Datos_AlumnoContext1);
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