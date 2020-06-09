using PolizaUI.Models;
using PolizaUI.Models.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Poliza.UI_Test
{
    public class PolizaNombreTest
    {
        private readonly PolizaUI.Models.Poliza Poliza;

        public PolizaNombreTest()
        {
            Poliza = new PolizaUI.Models.Poliza();
        }     

        [Fact]
        public void Regla_Nombre_Requerido()
        {
            Poliza.Descripcion = "La descripcion debe ser larga suficientemente.";
            Poliza.PorcentajeCobertura = 70;
            Poliza.TipoRiesgo = TiposRiesgo.alto;

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Poliza, new ValidationContext(Poliza), validationResults, true);

            Assert.Equal("Nombre es requerido", validationResults.Single().ErrorMessage);
        }

        [Fact]
        public void Regla_Nombre_MenosMinimo()
        {
            Poliza.Nombre = "Johnas";
            Poliza.Descripcion = "La descripcion debe ser larga suficientemente.";
            Poliza.PorcentajeCobertura = 70;
            Poliza.TipoRiesgo = TiposRiesgo.alto;

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Poliza, new ValidationContext(Poliza), validationResults, true);

            Assert.Equal("The field Nombre must be a string with a minimum length of 8 and a maximum length of 60.", validationResults.Single().ErrorMessage);
        }

        [Fact]
        public void Regla_Nombre_True()
        {
            Poliza.Nombre = "Johnas Brothers";
            Poliza.Descripcion = "La descripcion debe ser larga suficientemente.";
            Poliza.PorcentajeCobertura = 20;
            Poliza.TipoRiesgo = TiposRiesgo.alto;

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Poliza, new ValidationContext(Poliza), validationResults, true);

            Assert.False(validationResults.Any());
        }

        [Fact]
        public void Regla_Nombre_MasMaximo()
        {
            Poliza.Nombre = "Mi nombre es Juan de Jesus de los Santos de los ultimos dias segundo";
            Poliza.Descripcion = "La descripcion debe ser larga suficientemente.";
            Poliza.PorcentajeCobertura = 70;
            Poliza.TipoRiesgo = TiposRiesgo.alto;

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Poliza, new ValidationContext(Poliza), validationResults, true);

            Assert.Equal("The field Nombre must be a string with a minimum length of 8 and a maximum length of 60.", validationResults.Single().ErrorMessage);
        }
    }
}


