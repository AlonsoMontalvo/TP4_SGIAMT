using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SGIAMT_Integracion.Models
{
    public partial class TSemanaxDia
    {
        public TSemanaxDia()
        {
            TAsistencia = new HashSet<TAsistencia>();
        }

        public int PkIsdSemanaxDia { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Semana")]
        public int FkIsSemana { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Día")]
        public int FkIdDia { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Día")]
        public TDia FkIdDiaNavigation { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Semana")]
        public TSemana FkIsSemanaNavigation { get; set; }
        public ICollection<TAsistencia> TAsistencia { get; set; }
    }
}
