﻿using System;
using System.Collections.Generic;

namespace BD_SGIAMTvsgenerarcomprobante.Models
{
    public partial class TConceptoPago
    {
        public TConceptoPago()
        {
            TPago = new HashSet<TPago>();
        }

        public int PkIcpId { get; set; }
        public string VcpDescripcion { get; set; }
        public decimal? VcpMonto { get; set; }

        public ICollection<TPago> TPago { get; set; }
    }
}
