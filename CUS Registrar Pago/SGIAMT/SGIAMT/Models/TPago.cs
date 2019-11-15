using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIAMT.Models
{
    public partial class TPago
    {
        public int PkIpId { get; set; }
        public decimal? VpValor { get; set; }
        [Required(ErrorMessage = "SELECCIONE UNA FECHA")]
        public DateTime? VpFecha { get; set; }
        public string VpMes { get; set; }
        [Required(ErrorMessage = "INGRESE EL AÑO CORRESPONDIENTE")]
        [Range(2000, int.MaxValue, ErrorMessage = "INGRESE UN AÑO APARTIR DEL 2000")]
        public int? VpAño { get; set; }
        public byte[] VpPdf { get; set; }
        public int? FkIuDni { get; set; }
        public int? FkIcpId { get; set; }

        public TConceptoPago FkIcp { get; set; }
        public TUsuario FkIuDniNavigation { get; set; }
    }
}
