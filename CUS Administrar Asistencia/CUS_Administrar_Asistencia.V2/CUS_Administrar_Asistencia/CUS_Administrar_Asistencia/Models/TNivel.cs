using System;
using System.Collections.Generic;

namespace CUS_Administrar_Asistencia.Models
{
    public partial class TNivel
    {
        public TNivel()
        {
            TNivelxTipoNivel = new HashSet<TNivelxTipoNivel>();
        }

        public int PkInCod { get; set; }
        public string VnNombreNivel { get; set; }

        public ICollection<TNivelxTipoNivel> TNivelxTipoNivel { get; set; }
    }
}
