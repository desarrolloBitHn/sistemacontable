﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class documento
    {
        public int ID { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public Boolean deleted { get; set; }
    }
}
