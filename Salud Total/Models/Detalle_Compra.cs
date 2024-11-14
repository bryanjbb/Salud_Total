using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salud_Total.Models
{
    public class Detalle_Compra
    {
        public long ID_CP { get; set; }          // ID del detalle de compra
        public long N_Compra { get; set; }      // Número de compra
        public long ID_Producto { get; set; }    // ID del producto
        // Nombre del producto (opcional, si se necesita)
        public int Cantidad { get; set; }        // Cantidad de productos
        public float Total { get; set; }       // Total de la compra (cantidad * precio)
    }
}




