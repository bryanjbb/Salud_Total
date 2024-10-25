using System.ComponentModel.DataAnnotations;

namespace Salud_Total.Models
{
    public class Presentacion
    {
        [Key]
        public int ID_Presentacion { get; set; }

        [Required]
        [StringLength(20)]
        public string Descripcion { get; set; }

        public int ID_Producto { get; set; }
    }
}
  
