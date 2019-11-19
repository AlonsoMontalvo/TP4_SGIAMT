using System;
using System.Collections.Generic;

namespace SGIAMT_Integracion.Models
{
    public partial class TComprobantePago
    {
        public int PkIcpId { get; set; }
        public DateTime? VcpFecha { get; set; }
        public string VcpNombre { get; set; }
        public string VcpApaterno { get; set; }
        public string VcpAmaterno { get; set; }
        public string VcpConcepto { get; set; }
        public decimal? VcpMonto { get; set; }
        public int? VcpAño { get; set; }
        public string VcpMes { get; set; }
        public byte[] VcpDocumento { get; set; }
        public int? FkIpId { get; set; }

        public TPago FkIp { get; set; }
    }
}
