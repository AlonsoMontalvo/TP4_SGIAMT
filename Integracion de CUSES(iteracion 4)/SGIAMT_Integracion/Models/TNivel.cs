using System;
using System.Collections.Generic;

namespace SGIAMT_Integracion.Models
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
