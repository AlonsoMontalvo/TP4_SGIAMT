using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGIAMT_GESTIONAR_PROGRESO.Models
{
    public partial class TProgreso
    {
        public TProgreso()
        {
            TUsuarioxProgreso = new HashSet<TUsuarioxProgreso>();
        }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Codigo:")]
        public int PkIpCod { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Nombre:")]
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

        public ICollection<TUsuarioxProgreso> TUsuarioxProgreso { get; set; }

    }
}
