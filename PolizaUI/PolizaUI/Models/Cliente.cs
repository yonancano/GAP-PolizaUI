﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolizaUI.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public IList<Poliza> MisPolizas { get; set; }
    }
}
