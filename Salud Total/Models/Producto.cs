using System.ComponentModel.DataAnnotations;

namespace Salud_Total.Models
{
    public class Producto
    {
        
        public int ID_Producto { get; set; }

        public int ID_Laboratorio { get; set; }

        [StringLength(30)]
        public string Nombre_Producto { get; set; }


        [Required]
        public float Precio { get; set; }

        [Required]
        public DateTime Vencimiento { get; set; }

        [Required]
        public int Existencias { get; set; }

    }
}
