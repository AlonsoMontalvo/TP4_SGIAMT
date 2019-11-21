using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SGIAMT.Models
{
    public partial class TProgreso
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Codigo:")]
        public int PkIpProgreso { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Nombre de Progreso:")]
        public string VpNombreProgreso { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Puntaje para progreso de pasos:")]
        [Range(1, 20, ErrorMessage = "Ingrese una nota valida entre 1 al 20")]
        public int DpNotaPasos { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Puntaje para progreso de tecnica de baile:")]
        [Range(1, 20, ErrorMessage = "Ingrese una nota valida entre 1 al 20")]
        public int DpNotaTecnica { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Puntaje para el interes mostrado en clases:")]
        [Range(1, 20, ErrorMessage = "Ingrese una nota valida entre 1 al 20")]
        public int DpNotaInteres { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Puntaje para la habilidad mostrada en clases:")]
        [Range(1, 20, ErrorMessage = "Ingrese una nota valida entre 1 al 20")]
        public int DpNotaHabilidad { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Puntaje total del progreso:")]
        public decimal DpTotalNota { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Observacion:")]
        public string VpObservacion { get; set; }


        public int FkIuDni { get; set; }


        public int FkIsdSemanaxDia { get; set; }


        public TSemanaxDia FkIsdSemanaxDiaNavigation { get; set; }

        public TUsuario FkIuDniNavigation { get; set; }
    }
}
