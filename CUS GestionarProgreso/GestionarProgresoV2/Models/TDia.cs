using System;
using System.Collections.Generic;

namespace GestionarProgresoV2.Models
{
    public partial class TDia
    {
        public TDia()
        {
            TSemanaxDia = new HashSet<TSemanaxDia>();
        }

        public int PkIdDia { get; set; }
        public string VdNombreDia { get; set; }

        public ICollection<TSemanaxDia> TSemanaxDia { get; set; }
    }
}
