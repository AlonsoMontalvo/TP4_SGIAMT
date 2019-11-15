using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIAMT_RenovarPago.Models
{
    public partial class TPago
    {
        public int PkIpId { get; set; }
        [Required(ErrorMessage = "SELECCIONE UNA FECHA")]
        public DateTime? VpFecha { get; set; }
        [Required(ErrorMessage = "INGRESE EL AÑO CORRESPONDIENTE")]
        public decimal? VpMonto { get; set; }
        public int? VpAño { get; set; }
        public string VpMes { get; set; }
        public string VpEstado { get; set; }
        public int? FkIuDni { get; set; }
        public int? FkIcpId { get; set; }

        public TConceptoPago FkIcp { get; set; }
        public TUsuario FkIuDniNavigation { get; set; }
    }
}
