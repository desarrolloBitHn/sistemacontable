using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class cuentacontable
    {
        public int ID { get; set; }
        public int version { get; set; }
        public DateTime inicioVigencia { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int idMoneda { get; set; }
        public int idCuentaPadre { get; set; }
        public int idnivel { get; set; }
        public string prefijo { get; set; }
        public int idCategoria { get; set; }
        public Boolean deleted { get; set; }
        public int idNaturaleza { get; set; }
    }
}
