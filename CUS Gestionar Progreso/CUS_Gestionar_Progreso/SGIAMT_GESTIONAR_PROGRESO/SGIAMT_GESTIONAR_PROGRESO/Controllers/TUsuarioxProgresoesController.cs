using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGIAMT_GESTIONAR_PROGRESO.Models;
using System.Runtime.Serialization;

namespace SGIAMT_GESTIONAR_PROGRESO.Controllers
{
    public class TUsuarioxProgresoesController : Controller
    {
        private readonly BD_SGIAMT_GESTIONAR_PROGRESOContext _context;

        public TUsuarioxProgresoesController(BD_SGIAMT_GESTIONAR_PROGRESOContext context)
        {
            _context = context;
        }

        // GET: TUsuarioxProgresoes
        public async Task<IActionResult> Index()
        {
            var bD_SGIAMT_GESTIONAR_PROGRESOContext = _context.TUsuarioxProgreso.Include(t => t.FkIpCodNavigation).Include(t => t.FkIuDniNavigation);
            return View(await bD_SGIAMT_GESTIONAR_PROGRESOContext.ToListAsync());
        }


        //prueba de comboBox de nivel y tipoNivel

        [HttpGet]
        public IActionResult GetComboBox()
        {

            var nnivel = _context.TNivel.ToList();
            var tnivel = _context.TTipoNivel.ToList();

            return Json(new { nivel = nnivel, tiponivel = tnivel });//dos listas vacias
        }

        [HttpGet]
        public IActionResult GetUsersPagination2(int idnivel, int idtiponivel)
        {

            var usuarioxprog = (from pr in _context.TProgreso 
                           join pu in _context.TUsuarioxProgreso on pr.PkIpCod equals pu.FkIpCod
                           join tu in _context.TUsuario on pu.FkIuDni equals tu.PkIuDni
                           join ntn in _context.TNivelxTipoNivel on tu.PkIuDni equals ntn.FkIuDni
                           join n in _context.TNivel on ntn.FkInCod equals n.PkInCod
                           join tn in _context.TTipoNivel on ntn.FkItnCod equals tn.PkItnCod
                           where (idnivel == 0 ? true : ntn.FkInCod == idnivel) &&
                                 (idtiponivel == 0 ? true : ntn.FkItnCod == idtiponivel)
                           select new TUsuarioxTipo
                           {
                               dni = tu.PkIuDni,
                               nombre = tu.VuNombre,
                               apellidoP = tu.VuApaterno,
                               apellidoM = tu.VuAmaterno,
                               nivel = n.VnNombreNivel,
                               tnivel = tn.ItnNombreTipoNivel,
                               nombrep= pu.VupNombreProfesor,
                               codigop= pr.VpNombreProgreso,
                               semana=pu.VupSemana

                           }).ToList();

            return Json(new { usuarioXprogreso = usuarioxprog });
        }


        // GET: TUsuarioxProgresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tUsuarioxProgreso = await _context.TUsuarioxProgreso
                .Include(t => t.FkIpCodNavigation)
                .Include(t => t.FkIuDniNavigation)
                .FirstOrDefaultAsync(m => m.PkIuxPCod == id);
            if (tUsuarioxProgreso == null)
            {
                return NotFound();
            }

            return View(tUsuarioxProgreso);
        }

        // GET: TUsuarioxProgresoes/Create
        public IActionResult Create()
        {
            var usuario = from u in _context.TUsuario
                          where u.FkItuTipoUsuario == 1
                          select u;


            ViewData["FkIpCod"] = new SelectList(_context.TProgreso, "PkIpCod", "VpNombreProgreso");
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "VuPaterno");

            ViewData["FkIuDni"] = new SelectList(usuario, "PkIuDni", "VuNombre");

            return View();
        }

        // POST: TUsuarioxProgresoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIuxPCod,VupSemana,VupNombreProfesor,FkIuDni,FkIpCod")] TUsuarioxProgreso tUsuarioxProgreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tUsuarioxProgreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIpCod"] = new SelectList(_context.TProgreso, "PkIpCod", "VpNombreProgreso", tUsuarioxProgreso.FkIpCod);
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "VuNombre", tUsuarioxProgreso.FkIuDni);

            return View(tUsuarioxProgreso);
        }

        // GET: TUsuarioxProgresoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tUsuarioxProgreso = await _context.TUsuarioxProgreso.FindAsync(id);
            if (tUsuarioxProgreso == null)
            {
                return NotFound();
            }
            ViewData["FkIpCod"] = new SelectList(_context.TProgreso, "PkIpCod", "VpNombreProgreso", tUsuarioxProgreso.FkIpCod);
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "VuNombre", tUsuarioxProgreso.FkIuDni);
            return View(tUsuarioxProgreso);
        }

        // POST: TUsuarioxProgresoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIuxPCod,VupSemana,VupNombreProfesor,FkIuDni,FkIpCod")] TUsuarioxProgreso tUsuarioxProgreso)
        {
            if (id != tUsuarioxProgreso.PkIuxPCod)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tUsuarioxProgreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TUsuarioxProgresoExists(tUsuarioxProgreso.PkIuxPCod))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIpCod"] = new SelectList(_context.TProgreso, "PkIpCod", "VpNombreProgreso", tUsuarioxProgreso.FkIpCod);
            ViewData["FkIuDni"] = new SelectList(_context.TUsuario, "PkIuDni", "VuNombre", tUsuarioxProgreso.FkIuDni);
            return View(tUsuarioxProgreso);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteUsuarioProgreso tUsuarioProgreso)
        {
            var model = await _context.TUsuarioxProgreso .FirstOrDefaultAsync(s => s.PkIuxPCod == tUsuarioProgreso.idUsuarioxProgreso);
            _context.TUsuarioxProgreso.Remove(model);
            await _context.SaveChangesAsync();
            var isDelete = await _context.TUsuarioxProgreso.AnyAsync(s => s.PkIuxPCod == tUsuarioProgreso.idUsuarioxProgreso);
            var result = isDelete ? false : true;
            return Json(new { result = result });
        }

        
        private bool TUsuarioxProgresoExists(int id)
        {
            return _context.TUsuarioxProgreso.Any(e => e.PkIuxPCod == id);
        }
    }
    public class TUsuarioxTipo
    {
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string nivel { get; set; }
        public string tnivel { get; set; }
        public string nombrep { get; set; }
        public string codigop { get; set; }
        public string semana { get; set; }

    }

    [DataContract]
    public class DeleteUsuarioProgreso
    {
        [DataMember]
        public int idUsuarioxProgreso { get; set; }
    }
}
