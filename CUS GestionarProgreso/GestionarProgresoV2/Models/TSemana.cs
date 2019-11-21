using System;
using System.Collections.Generic;

namespace GestionarProgresoV2.Models
{
    public partial class TSemana
    {
        public TSemana()
        {
            TSemanaxDia = new HashSet<TSemanaxDia>();
        }

        public int PkIsSemana { get; set; }
        public string VsNombreSemana { get; set; }

        public ICollection<TSemanaxDia> TSemanaxDia { get; set; }
    }
}
