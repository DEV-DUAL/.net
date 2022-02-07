﻿using System;
using System.Collections.Generic;

namespace WSVenta1.Models
{
    public partial class Consepto
    {
        public long Id { get; set; }
        public long IdVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public long IdProducto { get; set; }

        public virtual Producto1 IdProductoNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
    }
}
