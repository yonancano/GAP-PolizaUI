using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolizaUI.Models
{
    public class Poliza
    {
        public int IdPoliza { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public byte TipoCubrimiento { get; set; }

        public byte PorcentajeCobertura { get; set; }

        public DateTime InicioVigencia { get; set; }

        public byte PeriodoCobertura { get; set; }

        public decimal Precio { get; set; }

        public byte TipoRiesgo { get; set; }
    }
}
