using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetechnologiesMx.Service.Models
{
    public class Persona
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido")]
        [StringLength(20, ErrorMessage = "Nombre no puede ser mayor a 50 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Apellido Paterno  es Requerido")]
        [StringLength(20, ErrorMessage = "Apellido Paterno no puede ser mayor a 20 caracteres")]
        public string? ApellidoPaterno { get; set; }

        [StringLength(20, ErrorMessage = "Apellido Materno no puede ser mayor a 20 caracteres")]
        public string? ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Identificacion es Requerido")]
        [StringLength(100, ErrorMessage = "Identificacion no puede ser mayo de 100 caracteres")]
        public string? Identificacion { get; set; }


        //[Required]
        //public virtual ICollection<Factura> Factura { get; set; }

    }
}
