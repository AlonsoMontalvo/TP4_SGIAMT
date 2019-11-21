using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace SGIAMT.Models
{
    public partial class TUsuario
    {
        public TUsuario()
        {
            TAsistencia = new HashSet<TAsistencia>();
            TNivelxTipoNivel = new HashSet<TNivelxTipoNivel>();
            TPago = new HashSet<TPago>();
            TProgreso = new HashSet<TProgreso>();
        }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("DNI")]
        [Range(10000000, 99999999, ErrorMessage = "el dni no tiene 8 caracteres ")]
        public int PkIuDni { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Nombre")]
        [StringLength(30, MinimumLength = 0, ErrorMessage = "Ingrese el nombre")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Solo letras")]
        public string VuNombre { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Apellido Paterno")]
        [StringLength(30, MinimumLength = 0, ErrorMessage = "Ingrese el apellido paterno")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Solo letras")]
        public string VuApaterno { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Apellido Materno")]
        [StringLength(30, MinimumLength = 0, ErrorMessage = "Ingrese el apellido materno")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Solo letras")]
        public string VuAmaterno { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Celular")]
        [Range(100000000, 999999999, ErrorMessage = "el Celular tiene 9 caracteres")]
        public int VuCelular { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "invalido correo ")]
        public string VuCorreo { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Direccion")]
        [StringLength(30, MinimumLength = 0, ErrorMessage = "Ingrese el Direccion")]
        public string VuDireccion { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DuFechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Sexo")]
        public string VuSexo { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("contraseña")]
        [DataType(DataType.Password)]
        public string VuContraseña { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Estado")]
        public string VuEstado { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Horario")]
        [StringLength(30, MinimumLength = 0, ErrorMessage = "ingrese Horario")]
        public string VuHorario { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Tipo de Usuario")]
        public int FkItuTipoUsuario { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Categoria")]
        public int FkIcId { get; set; }


        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Distrito")]
        public int FkIdiCod { get; set; }



        public TCategoría FkIcIdNavigation { get; set; }
        public TDistrito FkIdiCodNavigation { get; set; }
        public TTipoUsuario FkItuTipoUsuarioNavigation { get; set; }
        public ICollection<TAsistencia> TAsistencia { get; set; }
        public ICollection<TNivelxTipoNivel> TNivelxTipoNivel { get; set; }
        public ICollection<TPago> TPago { get; set; }
        public ICollection<TProgreso> TProgreso { get; set; }
    }
}
