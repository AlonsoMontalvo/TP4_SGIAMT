using System;
using System.Collections.Generic;

namespace SGIAMT.Models
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
