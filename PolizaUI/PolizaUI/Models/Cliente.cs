using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolizaUI.Models
{
    public class Cliente
    {
        [DisplayName("Id")]
        public int IdCliente { get; set; }

        [DisplayName("Nombre Completo")]
        public string Nombre { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public IList<Poliza> MisPolizas { get; set; }
    }
}
