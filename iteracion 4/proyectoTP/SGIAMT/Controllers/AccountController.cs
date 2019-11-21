using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SGIAMT.Models;

using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SGIAMT_Integracion.Controllers
{
    public class AccountController : Controller
    {
        private readonly BD_SGIAMTIntegracionfinalContext _context;
        public AccountController(BD_SGIAMTIntegracionfinalContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {

            return View();

        }
        public class usr
        {
            public int dniusr { get; set; }
            public string passusr { get; set; }
            public int? tipousr { get; set; }
            public string estado { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(int Dni, string Contra)
        {
            //    bool dni = _context.TUsuario.Any(x => x.PkIuDni == user.Dni);
            //    bool contra = _context.TUsuario.Any(con => con.VuContraseña == user.Contra);


            var us = (from c in _context.TUsuario
                      where c.PkIuDni == Dni && c.VuContraseña == Contra
                      select new usr()
                      {
                          dniusr = c.PkIuDni,



                      }).FirstOrDefault();
            var us1 = (from c in _context.TUsuario
                       where c.PkIuDni == Dni && c.VuContraseña == Contra
                       select new usr()
                       {
                           passusr = c.VuContraseña,


                       }).FirstOrDefault();
            var us2 = (from c in _context.TUsuario
                       where c.PkIuDni == Dni && c.VuContraseña == Contra
                       select new usr()
                       {
                           tipousr = c.FkItuTipoUsuario


                       }).FirstOrDefault();
            var estado = (from c in _context.TUsuario
                       where c.PkIuDni == Dni && c.VuContraseña == Contra
                       select new usr()
                       {
                           estado = c.VuEstado


                       }).FirstOrDefault();


            if (us == null && us1 == null && us2 == null )
            {
                ModelState.AddModelError("Dni", "Los datos son incorrectos");
                ModelState.AddModelError("Contra", "Los datos son incorrectos");
                return View();

            }

            else
            {
                bool dni = _context.TUsuario.Any(x => x.PkIuDni == us.dniusr);
                bool contra = _context.TUsuario.Any(con => con.VuContraseña == us1.passusr);

                if (dni == true && contra == true && us2.tipousr == 1 && estado.estado == "Activo")
                {

                    var nombreusu = (from c in _context.TUsuario
                                     where c.PkIuDni == Dni
                                     select new
                                     {
                                         c.VuNombre
                                     }).FirstOrDefault();
                    var apellidopaus = (from c in _context.TUsuario
                                        where c.PkIuDni == Dni
                                        select new
                                        {
                                            c.VuApaterno
                                        }).FirstOrDefault();
                    var apellidomaus = (from c in _context.TUsuario
                                        where c.PkIuDni == Dni
                                        select new
                                        {
                                            c.VuAmaterno
                                        }).FirstOrDefault();
                    var correousu = (from c in _context.TUsuario
                                     where c.PkIuDni == Dni
                                     select new
                                     {
                                         c.VuCorreo
                                     }).FirstOrDefault();
                    Alumno.Dni = Dni;
                    String[] nombres = Convert.ToString(nombreusu).Split(" ");
                    String[] apellidospas = Convert.ToString(apellidopaus).Split(" ");
                    String[] apellidosmas = Convert.ToString(apellidomaus).Split(" ");
                    String[] correos = Convert.ToString(correousu).Split(" ");

                    Alumno.nombre = "" + nombres[3];
                    Alumno.apellidopa = "" + apellidospas[3];
                    Alumno.apellidoma = "" + apellidosmas[3];
                    Alumno.correo = "" + correos[3];

                    //await Task.Delay(100);
                    //var dnip = us.dniusr;
                    //var contrap = us.passusr;
                    //var tp = us.tipousr;
                    await Task.Delay(200);
                    //return Json(new { dni = dnip, contra = contrap, tipo=tp });
                    return RedirectToAction("Alumno", "Alumnohome");
                }
                else if (dni == true && contra == true && us2.tipousr == 2 && estado.estado == "Activo")//ariana
                {
                    var nombrerec = (from c in _context.TUsuario
                                      where c.PkIuDni == Dni
                                      select new
                                      {
                                          c.VuNombre
                                      }).FirstOrDefault();
                    var apellidoparec = (from c in _context.TUsuario

                                         where c.PkIuDni == Dni
                                         select new
                                         {
                                             c.VuApaterno
                                         }).FirstOrDefault();
                    var apellidomarec = (from c in _context.TUsuario
                                         where c.PkIuDni == Dni
                                         select new
                                         {
                                             c.VuAmaterno
                                         }).FirstOrDefault();
                    var correorec = (from c in _context.TUsuario
                                     where c.PkIuDni == Dni
                                     select new
                                     {
                                         c.VuCorreo
                                     }).FirstOrDefault();
                    var tipousuarec = (from c in _context.TUsuario
                                       join tp in _context.TTipoUsuario on c.FkItuTipoUsuario equals tp.PkItuTipoUsuario
                                       where c.PkIuDni == Dni
                                       select new
                                       {
                                           tp.VtuNombreTipoUsuario
                                       }).FirstOrDefault();
                    Recepcionista.Dni = Dni;
                    String[] nombres = Convert.ToString(nombrerec).Split(" ");
                    String[] apellidospas = Convert.ToString(apellidoparec).Split(" ");
                    String[] apellidosmas = Convert.ToString(apellidomarec).Split(" ");
                    String[] correos = Convert.ToString(correorec).Split(" ");
                    String[] tipousuarios = Convert.ToString(tipousuarec).Split(" ");
                    Recepcionista.nombre = "" + nombres[3];
                    Recepcionista.apellidopa = "" + apellidospas[3];
                    Recepcionista.apellidoma = "" + apellidosmas[3];
                    Recepcionista.correo = "" + correos[3];
                    Recepcionista.tipousuario = "" + tipousuarios[3];
                    //var dnip = us.dniusr;
                    //var contrap = us.passusr;
                    //var tp = us.tipousr;
                    await Task.Delay(200);
                    return RedirectToAction("Recepcionista", "Recepcionistahome");
                    //return Json(new { dni = dnip, contra = contrap, tipo = tp });
                }
                else if (dni == true && contra == true && us2.tipousr == 3 && estado.estado == "Activo") //ariana
                {
                    var nombreprof = (from c in _context.TUsuario
                                      where c.PkIuDni == Dni
                                      select new
                                      {
                                          c.VuNombre
                                      }).FirstOrDefault();
                    var apellidopapro = (from c in _context.TUsuario
                                      
                                         where c.PkIuDni == Dni
                                         select new
                                         {
                                             c.VuApaterno
                                         }).FirstOrDefault();
                    var apellidomapro = (from c in _context.TUsuario
                                         where c.PkIuDni == Dni
                                         select new
                                         {
                                             c.VuAmaterno
                                         }).FirstOrDefault();
                    var correopro = (from c in _context.TUsuario
                                     where c.PkIuDni == Dni
                                     select new
                                     {
                                         c.VuCorreo
                                     }).FirstOrDefault();
                    var tipousuario = (from c in _context.TUsuario
                                       join tp in _context.TTipoUsuario on c.FkItuTipoUsuario equals tp.PkItuTipoUsuario
                                       where c.PkIuDni == Dni
                                     select new
                                     {
                                        tp.VtuNombreTipoUsuario
                                     }).FirstOrDefault();
                    Profesor.Dni = Dni;
                    String[] nombres = Convert.ToString(nombreprof).Split(" ");
                    String[] apellidospas = Convert.ToString(apellidopapro).Split(" ");
                    String[] apellidosmas = Convert.ToString(apellidomapro).Split(" ");
                    String[] correos = Convert.ToString(correopro).Split(" ");
                    String[] tipousuarios = Convert.ToString(tipousuario).Split(" ");
                    Profesor.nombre = "" + nombres[3];
                    Profesor.apellidopa = "" + apellidospas[3];
                    Profesor.apellidoma = "" + apellidosmas[3];
                    Profesor.correo = "" + correos[3];
                    Profesor.tipousuario = "" + tipousuarios[3];
                    //var dnip = us.dniusr;
                    //var contrap = us.passusr;
                    //var tp = us.tipousr;
                    await Task.Delay(200);
                    return RedirectToAction("Profesor", "Profesorhome");
                    // return Json(new { dni = dnip, contra = contrap, tipo = tp });
                }
                else if (dni == false && contra == false) //ariana
                {
                    //var dnip = us.dniusr;
                    //var contrap = us.passusr;
                    //var tp = us.tipousr;
                    await Task.Delay(200);
                    return RedirectToAction("login", "Account");
                    // return Json(new { dni = dnip, contra = contrap, tipo = tp });
                }

                else
                {
                    await Task.Delay(200);
                    return RedirectToAction("login", "Account");
                }
            }

        }

    }
    public class Alumno
    {
        public static int Dni;
        public static string nombre;
        public static string apellidopa;
        public static string apellidoma;
        public static string correo;
    }
    public class Profesor
    {
        public static int Dni;
        public static string nombre;
        public static string apellidopa;
        public static string apellidoma;
        public static string correo;
        public static string tipousuario;
    }
    public class Recepcionista
    {
        public static int Dni;
        public static string nombre;
        public static string apellidopa;
        public static string apellidoma;
        public static string correo;
        public static string tipousuario;
    }
}