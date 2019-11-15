using System;
using System.Collections.Generic;

namespace SGIAMT_GESTIONAR_PROGRESO.Models
{
    public partial class TNivelxTipoNivel
    {
        public int PkIntnCod { get; set; }
        public int FkInCod { get; set; }
        public int FkItnCod { get; set; }
        public int NroAlumno { get; set; }
        public int FkIuDni { get; set; }

        public TNivel FkInCodNavigation { get; set; }
        public TTipoNivel FkItnCodNavigation { get; set; }
        public TUsuario FkIuDniNavigation { get; set; }
    }
}
