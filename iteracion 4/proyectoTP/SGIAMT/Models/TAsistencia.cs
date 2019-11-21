using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGIAMT.Models
{
    public partial class TAsistencia
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Id")]
        public int PkIaAsistencia { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Horario")]
        public string TaHora { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Estado de Asistencia")]
        public string VaEstadoAsistencia { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Nombre")]
        public int FkIuDni { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Semana x Día")]
        public int FkIsdSemanaxDia { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Semana x Día")]
        public TSemanaxDia FkIsdSemanaxDiaNavigation { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Nombre")]
        public TUsuario FkIuDniNavigation { get; set; }
    }
}
