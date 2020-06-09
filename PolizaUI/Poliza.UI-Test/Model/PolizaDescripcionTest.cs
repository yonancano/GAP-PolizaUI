using PolizaUI.Models;
using PolizaUI.Models.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Poliza.UI_Test
{
    public class PolizaDescripcionTest
    {
        private readonly PolizaUI.Models.Poliza Poliza;

        public PolizaDescripcionTest()
        {
            Poliza = new PolizaUI.Models.Poliza();
        }     

        [Fact]
        public void Regla_Descipcion_Requerido()
        {
            Poliza.Nombre = "Johnas Brothers";
            Poliza.PorcentajeCobertura = 20;
            Poliza.TipoRiesgo = TiposRiesgo.alto;

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Poliza, new ValidationContext(Poliza), validationResults, true);

            Assert.Equal("Descripción es requerida", validationResults.Single().ErrorMessage);
        }

        [Fact]
        public void Regla_Descipcion_MenosMinimo()
        {
            Poliza.Nombre = "Johnas Brothers";
            Poliza.Descripcion = "La desc";
            Poliza.PorcentajeCobertura = 10;
            Poliza.TipoRiesgo = TiposRiesgo.medio;

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Poliza, new ValidationContext(Poliza), validationResults, true);

            Assert.Equal("The field Descripcion must be a string with a minimum length of 15 and a maximum length of 200.", validationResults.Single().ErrorMessage);
        }

        [Fact]
        public void Regla_Descipcion_True()
        {
            Poliza.Nombre = "Johnas Brothers";
            Poliza.Descripcion = "La descripcion debe ser larga suficientemente.";
            Poliza.PorcentajeCobertura = 20;
            Poliza.TipoRiesgo = TiposRiesgo.medio;

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Poliza, new ValidationContext(Poliza), validationResults, true);

            Assert.False(validationResults.Any());
        }

        [Fact]
        public void Regla_Descipcion_MasMaximo()
        {
            Poliza.Nombre = "Mi nombre es Juan";
            Poliza.Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi vel ex id tortor facilisis viverra. Mauris faucibus massa eu dolor porta sagittis. Nunc non tincidunt velit. Aliquam dignissim leo turpis, non imperdiet sem vestibulum eu.";
            Poliza.PorcentajeCobertura = 10;
            Poliza.TipoRiesgo = TiposRiesgo.alto;

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Poliza, new ValidationContext(Poliza), validationResults, true);

            Assert.Equal("The field Descripcion must be a string with a minimum length of 15 and a maximum length of 200.", validationResults.Single().ErrorMessage);
        }
    }
}


