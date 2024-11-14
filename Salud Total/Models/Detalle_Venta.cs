using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salud_Total.Models
{
    public class Detalle_Venta
    {
        public long ID_DV { get; set; }  // ID del detalle de venta
        public long N_Factura { get; set; }  // Número de factura
        public long ID_Producto { get; set; }  // ID del producto
        public int Cantidad { get; set; }  // Cantidad de productos
        public decimal PrecioVenta { get; set; }  // Precio de venta por producto
        public decimal SubTotal { get; set; }  // Subtotal de la línea de venta
        public decimal Total { get; set; }  // Total de la venta (que puede ser la suma de varios detalles)
    }
}



