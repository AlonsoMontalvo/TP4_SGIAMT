using System;
using System.Collections.Generic;

namespace CUS_Actualizar_Datos_Alumno.Models
{
    public partial class TDistrito
    {
        public TDistrito()
        {
            TUsuario = new HashSet<TUsuario>();
        }

        public int PkIdiCod { get; set; }
        public string VdiNombreDis { get; set; }

        public ICollection<TUsuario> TUsuario { get; set; }
    }
}
