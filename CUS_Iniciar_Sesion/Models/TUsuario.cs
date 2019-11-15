using System;
using System.Collections.Generic;

namespace CUS_Iniciar_Sesion.Models
{
    public partial class TUsuario
    {
        public int PkIuDni { get; set; }
        public string VuNombre { get; set; }
        public string VuApaterno { get; set; }
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
    }
}
