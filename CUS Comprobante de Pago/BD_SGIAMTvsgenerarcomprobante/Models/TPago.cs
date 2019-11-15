using System;
using System.Collections.Generic;

namespace BD_SGIAMTvsgenerarcomprobante.Models
{
    public partial class TPago
    {
        public TPago()
        {
            TComprobantePago = new HashSet<TComprobantePago>();
        }

        public int PkIpId { get; set; }
        public DateTime? VpFecha { get; set; }
        public decimal? VpMonto { get; set; }
        public int? VpAño { get; set; }
        public string VpMes { get; set; }
        public string VpEstado { get; set; }
        public int? FkIuDni { get; set; }
        public int? FkIcpId { get; set; }

        public TConceptoPago FkIcp { get; set; }
        public TUsuario FkIuDniNavigation { get; set; }
        public ICollection<TComprobantePago> TComprobantePago { get; set; }
    }
}
