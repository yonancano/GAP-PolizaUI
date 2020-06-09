using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PolizaUI.Models
{
    public class Poliza
    {
        public int IdPoliza { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripción es requerida")]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Tipo de cubrimiento es requerido")]
        [DisplayName("Cubrimiento")]
        public byte TipoCubrimiento { get; set; }

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
        public byte TipoRiesgo { get; set; }

        [Required(ErrorMessage = "Id del cliente es requerido")]
        [DisplayName("Id del cliente")]
        public int IdCliente { get; set; }
    }
}
