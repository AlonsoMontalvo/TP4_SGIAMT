using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CUS_Administrar_Asistencia.Models
{
    public partial class TUsuario
    {
        public TUsuario()
        {
            TAsistencia = new HashSet<TAsistencia>();
            TNivelxTipoNivel = new HashSet<TNivelxTipoNivel>();
        }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("DNI")]
        public int PkIuDni { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Nombre")]
        public string VuNombre { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Apellidos Paterno")]
        public string VuApaterno { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Apellido Materno")]


        public string VuAmaterno { get; set; }
        public int VuCelular { get; set; }
        public string VuCorreo { get; set; }
        public string VuDireccion { get; set; }
        public DateTime DuFechaNacimiento { get; set; }
        public string VuSexo { get; set; }
        public string VuContraseña { get; set; }
        public string VuEstado { get; set; }
        public string VuHorario { get; set; }
        public int FkItuTipoUsuario { get; set; }

        public TTipoUsuario FkItuTipoUsuarioNavigation { get; set; }
        public ICollection<TAsistencia> TAsistencia { get; set; }
        public ICollection<TNivelxTipoNivel> TNivelxTipoNivel { get; set; }
    }
}
