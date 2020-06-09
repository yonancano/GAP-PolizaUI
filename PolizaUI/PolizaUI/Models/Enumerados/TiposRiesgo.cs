using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PolizaUI.Models.Enumerados
{
    public enum TiposRiesgo
    {
        [Description("bajo")]
        bajo = 1,
        [Description("medio")]
        medio = 2,
        [Description("medio-alto")]
        medioAlto = 3,
        [Description("alto")]
        alto = 4
    }
}
