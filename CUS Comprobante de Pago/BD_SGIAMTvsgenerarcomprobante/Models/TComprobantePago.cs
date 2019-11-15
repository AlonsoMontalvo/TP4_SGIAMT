using System;
using System.Collections.Generic;

namespace BD_SGIAMTvsgenerarcomprobante.Models
{
    public partial class TComprobantePago
    {
        public int PkIcpId { get; set; }
        public string VcpNombre { get; set; }
        public string VcpApaterno { get; set; }
        public string VcpAmaterno { get; set; }
        public decimal? VcpMonto { get; set; }
        public DateTime? VcpFecha { get; set; }
        public byte[] VcpPdf { get; set; }
        public int? FkIpId { get; set; }

        public TPago FkIp { get; set; }
    }
}
