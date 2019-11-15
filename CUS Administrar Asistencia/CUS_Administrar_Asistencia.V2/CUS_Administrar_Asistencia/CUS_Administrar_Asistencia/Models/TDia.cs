using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CUS_Administrar_Asistencia.Models
{
    public partial class TDia
    {
        public TDia()
        {
            TSemanaxDia = new HashSet<TSemanaxDia>();
        }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Id")]
        public int PkIdDia { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Día")]
        public string VdNombreDia { get; set; }

        public ICollection<TSemanaxDia> TSemanaxDia { get; set; }
    }
}
