using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGIAMT_Integracion.Models
{
    public partial class TUsuarioxProgreso
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Codigo:")]
        public int PkIuxPCod { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Semana:")]
        public string VupSemana { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Nombre del Profesor:")]
        public string VupNombreProfesor { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("DNI Alumno:")]
        public int FkIuDni { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Codigo del Progreso:")]
        public int FkIpCod { get; set; }

        public TProgreso FkIpCodNavigation { get; set; }
        public TUsuario FkIuDniNavigation { get; set; }
    }
}
