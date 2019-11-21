using System;
using System.Collections.Generic;

namespace GestionarProgresoV2.Models
{
    public partial class TSemanaxDia
    {
        public TSemanaxDia()
        {
            TProgreso = new HashSet<TProgreso>();
        }

        public int PkIsdSemanaxDia { get; set; }
        public int FkIsSemana { get; set; }
        public int FkIdDia { get; set; }

        public TDia FkIdDiaNavigation { get; set; }
        public TSemana FkIsSemanaNavigation { get; set; }
        public ICollection<TProgreso> TProgreso { get; set; }
    }
}
