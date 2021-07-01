using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroCobros.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }
        public double Cobrado { get; set; }
        public bool Pagado { get; set; }
    }
}
