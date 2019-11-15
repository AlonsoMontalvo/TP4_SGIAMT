using System;
using System.Collections.Generic;

namespace CUS_Actualizar_Datos_Alumno.Models
{
    public partial class TCategoría
    {
        public TCategoría()
        {
            TUsuario = new HashSet<TUsuario>();
        }

        public int PkIcId { get; set; }
        public string VcNombreCat { get; set; }

        public ICollection<TUsuario> TUsuario { get; set; }
    }
}
