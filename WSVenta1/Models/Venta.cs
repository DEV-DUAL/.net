using System;
using System.Collections.Generic;

namespace WSVenta1.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Consepto = new HashSet<Consepto>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdCliente { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Consepto> Consepto { get; set; }
    }
}
