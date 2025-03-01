using GetechnologiesMx.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetechnologiesMx.Service.Dtos
{
    public class VentasDtos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenta { get; set; }
        public int IdFactura { get; set; } 
        public string Persona { get; set; } 


        //[ForeignKey(nameof(Factura))]
        //public int IdFactura { get; set; }
        //public Factura? Factura { get; set; }
    }
}
