using System;
using System.Collections.Generic;

namespace SGIAMT.Models
{
    public partial class TTipoNivel
    {
        public TTipoNivel()
        {
            TNivelxTipoNivel = new HashSet<TNivelxTipoNivel>();
        }

        public int PkItnCod { get; set; }
        public string ItnNombreTipoNivel { get; set; }

        public ICollection<TNivelxTipoNivel> TNivelxTipoNivel { get; set; }
    }
}
