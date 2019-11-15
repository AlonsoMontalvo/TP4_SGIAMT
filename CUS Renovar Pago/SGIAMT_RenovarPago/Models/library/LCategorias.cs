using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGIAMT_RenovarPago.Models;

namespace SGIAMT_RenovarPago.Models.library
{
    public class LCategorias
    {
        private BD_SGIAMTvsRenovarPagoContext context;

        public LCategorias(BD_SGIAMTvsRenovarPagoContext context)
        {
            this.context = context;
        }
    }
}
