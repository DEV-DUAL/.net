using System;
using System.Collections.Generic;

namespace WSVenta1.Models
{
    public partial class Producto1
    {
        public Producto1()
        {
            Consepto = new HashSet<Consepto>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Costo { get; set; }

        public virtual ICollection<Consepto> Consepto { get; set; }
    }
}
