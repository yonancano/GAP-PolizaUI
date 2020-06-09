using PolizaUI.Models.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PolizaUI.Models
{
    public class Poliza : IValidatableObject
    {
        public int IdPoliza { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [DisplayName("Nombre")]
        [StringLength(60, MinimumLength = 8)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripción es requerida")]
        [DisplayName("Descripción")]
        [StringLength(200, MinimumLength = 15)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Tipo de cubrimiento es requerido")]
        [DisplayName("Cubrimiento")]
        public TiposCubrimiento TipoCubrimiento { get; set; }

        [Required(ErrorMessage = "% de Cobertura es requerida")]
        [DisplayName("% Cobertura")]
        public byte PorcentajeCobertura { get; set; }

        [Required(ErrorMessage = "Vigencia es requerida")]
        [DisplayName("Inicio Vigencia")]
        public DateTime InicioVigencia { get; set; }

        [Required(ErrorMessage = "Periódo de cobertura es requerido")]
        [DisplayName("Periódo (Meses)")]
        public byte PeriodoCobertura { get; set; }

        [Required(ErrorMessage = "Precio es requerido")]
        [DisplayName("Precio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Tipo de riesgo es requerido")]
        [DisplayName("Riesgo")]
        public TiposRiesgo TipoRiesgo { get; set; }

        [Required(ErrorMessage = "Id del cliente es requerido")]
        [DisplayName("Id del cliente")]
        public int IdCliente { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();
            if (TipoRiesgo == TiposRiesgo.alto)
            {
                if (PorcentajeCobertura > 50)
                {
                    errores.Add(new ValidationResult("Riesgo alto, el porcentaje de cobertura no puede ser superior al 50%", new [] { "PorcentajeCobertura" }));
                }
                
            }

            return errores;
        }
    }
}
