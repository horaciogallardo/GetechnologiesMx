using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetechnologiesMx.Service.Models
{
    public class Factura
    {
            public int IdFactura { get; set; }

            [Required(ErrorMessage = "Fecha es requerido")]
            public DateTime FechaFactura { get; set; }

            [Required(ErrorMessage = "Monto de Factura es Requerido")]
            [StringLength(20, ErrorMessage = "Monto de Factura no puede ser mayor a 20 caracteres")]
            public double Monto { get; set; }


            [ForeignKey(nameof(Persona))]
            public int IdPersona { get; set; }
            public Persona? Persona { get; set; }
    }
}
