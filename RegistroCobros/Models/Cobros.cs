using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroCobros.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }

        [Required(ErrorMessage = "Seleccione una fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Seleccione un cliente")]
        public int ClienteId { get; set; }

        public string Observaciones { get; set; }

        public virtual List<CobrosDetalle> Detalle { get; set; } = new List<CobrosDetalle>();
    }
}
