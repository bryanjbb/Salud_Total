using System.ComponentModel.DataAnnotations;

namespace Salud_Total.Models
{
    public class Producto
    {
        [Key]
        public int ID_Producto { get; set; }

        [StringLength(30)]
        public string Nombre_Producto { get; set; }


        [Required]
        public int Precio_U { get; set; }

        [Required]
        public DateTime Vencimiento { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}
