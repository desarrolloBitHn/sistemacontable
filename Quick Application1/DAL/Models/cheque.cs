using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class cheque
    {
        public int ID { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public Boolean estado { get; set; }
        public string concepto { get; set; }
        public string beneficiario { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaTransaccion { get; set; }
        public Boolean deleted { get; set; }
    }
}
