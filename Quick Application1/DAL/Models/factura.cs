using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class factura
    {
        public int ID { get; set; }
        public int idCuenta { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal cantidad { get; set; }
        public decimal valorUnitario { get; set; }
        public decimal descuento { get; set; }
        public decimal impuesto { get; set; }
        public Boolean exento { get; set; }
        public decimal otrosCargos { get; set; }
        public decimal subTotal { get; set; }
        public decimal valor { get; set; }
        public Boolean concepto { get; }
        public int idUsuario { get; set; }
        public Boolean deleted { get; set; }
    }
}
