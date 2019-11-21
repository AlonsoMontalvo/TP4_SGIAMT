
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGIAMT.Models.Auxiliar
{
    public class login
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Dni")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Contra { get; set; }
    }
}
