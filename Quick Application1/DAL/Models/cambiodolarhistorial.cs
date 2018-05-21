using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class cambiodolarhistorial
    {
        public int ID { get; set; }
        public DateTime fecha { get; set; }
        public decimal compra { get; set; }
        public decimal venta { get; set; }
    }
}
