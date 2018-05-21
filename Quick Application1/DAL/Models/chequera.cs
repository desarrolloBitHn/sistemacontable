using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class chequera
    {
        public int ID { get; set; }
        public int idCuenta { get; set; }
        public int numeroChequera { get; set; }
        public DateTime fechaUltimoMovimiento { get; set; }
        public int numeroCheque_Inicial { get; set; }
        public int numeroCheque_final { get; set; }
        public Boolean deleted { get; set; }
    }
}
