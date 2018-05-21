using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class moneda
    {
        public int ID { get; set; }
        public string descripcion { get; set; }
        public decimal venta { get; set; }
        public decimal compra { get; set; }
        public string simbolo { get; set; }
        public string cambiadoa { get; set; }
        public Boolean deleted { get; set; }
    }
}
