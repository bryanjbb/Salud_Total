using System.ComponentModel.DataAnnotations;

namespace Salud_Total.Models
{
    public class Laboratorio
    {
        [Key]
        public int ID_Laboratorio { get; set; }
        public String Descripcion { get; set; }

        [Required]
        public int ID_Producto { get; set; }
    }
}
    
