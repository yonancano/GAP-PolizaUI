using PolizaUI.Models;
using PolizaUI.Models.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Poliza.UI_Test
{
    public class ReglaPorcentajeTest
    {
        private readonly PolizaUI.Models.Poliza Poliza;

        public ReglaPorcentajeTest()
        {
            Poliza = new PolizaUI.Models.Poliza();
        }

        [Fact]
        public void Regla_RiesgoAlto_PorcentajeBajo()
        {
            Poliza.PorcentajeCobertura = 20;
            Poliza.TipoRiesgo = TiposRiesgo.alto;

            var validationContext = new ValidationContext(Poliza);

            var results = Poliza.Validate(validationContext);

            Assert.False(results.Any());
        }

        [Fact]
        public void Regla_RiesgoAlto_PorcentajeAlto()
        {
            Poliza.PorcentajeCobertura = 70;
            Poliza.TipoRiesgo = TiposRiesgo.alto;

            var validationContext = new ValidationContext(Poliza);

            var results = Poliza.Validate(validationContext);            

            Assert.Equal("Riesgo alto, el porcentaje de cobertura no puede ser superior al 50%", results.Single().ErrorMessage);
        }
       
    }
}


