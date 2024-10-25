using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salud_Total.Models
{
    public class Venta
    {
        [Key]
        public int N_Factura { get; set; }


        [Required]
        public DateTime Fecha { get; set; }

    }
}


