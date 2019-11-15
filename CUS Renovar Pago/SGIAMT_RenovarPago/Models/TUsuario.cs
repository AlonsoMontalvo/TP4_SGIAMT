using System;
using System.Collections.Generic;

namespace SGIAMT_RenovarPago.Models
{
    public partial class TUsuario
    {
        public TUsuario()
        {
            TPago = new HashSet<TPago>();
        }

        public int PkIuDni { get; set; }
        public string VuNombre { get; set; }
        public string VuApaterno { get; set; }
        public string VuAmaterno { get; set; }
        public int? VuCelular { get; set; }
        public string VuCorreo { get; set; }
        public string VuDireccion { get; set; }
        public DateTime? DuFechaNacimiento { get; set; }
        public string VuSexo { get; set; }
        public string VuContraseña { get; set; }
        public string VuEstado { get; set; }
        public string VuHorario { get; set; }

        public ICollection<TPago> TPago { get; set; }
    }
}
