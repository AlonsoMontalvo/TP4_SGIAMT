using System;
using System.Collections.Generic;

namespace SGIAMT_GESTIONAR_PROGRESO.Models
{
    public partial class TTipoUsuario
    {
        public TTipoUsuario()
        {
            TUsuario = new HashSet<TUsuario>();
        }

        public int PkItuTipoUsuario { get; set; }
        public string VtuNombreTipoUsuario { get; set; }

        public ICollection<TUsuario> TUsuario { get; set; }
    }
}
