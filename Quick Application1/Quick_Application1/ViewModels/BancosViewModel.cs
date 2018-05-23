using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quick_Application1.ViewModels
{
    public class BancosViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre del banco es requerido")]
        public string descripcion { get; set; }

        public Boolean deleted { get; set; }
    }
}
