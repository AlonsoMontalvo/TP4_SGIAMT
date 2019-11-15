using System;
using System.Collections.Generic;

namespace SGIAMT.Models
{
    public partial class TConceptoPago
    {
        public TConceptoPago()
        {
            TPago = new HashSet<TPago>();
        }

        public int PkIcpId { get; set; }
        public string VcpDescripcion { get; set; }
        public decimal? VcpValor { get; set; }

        public ICollection<TPago> TPago { get; set; }
    }
}
