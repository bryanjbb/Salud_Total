using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salud_Total.Models
{
    public class Compra
    {
        [Key]
        public int N_Compra { get; set; }


        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public int ID_CP { get; set; }
    }
}
    

