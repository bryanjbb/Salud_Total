using Dapper;
using Salud_Total.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;


namespace Salud_Total.Services
{
    public class Detalle_VentaServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;
     

        public Detalle_VentaServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;

        }

        public async Task<IEnumerable<Detalle_Venta>> GetDetallesVenta(long N_Factura)
        {
            string _queryCommand = "listarDetalle_Venta";  // Supongo que tienes un SP para obtener los detalles de una venta.
            var parametro = new DynamicParameters();
            parametro.Add("@N_Factura", N_Factura, dbType: DbType.Int64);

            using (var con = new SqlConnection(_StringSql))
            {
                var detallesVenta = await con.QueryAsync<Detalle_Venta>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return detallesVenta;
            }
        }


        public async Task<string> PostDetalle_Venta([FromBody] Detalle_Venta _Odetalle_venta)
        {
            try
            {
                string _queryCommand = "insertarDetalle_Venta";
                var parametro = new DynamicParameters();
                parametro.Add("@N_Factura", _Odetalle_venta.N_Factura, dbType: DbType.Int64);
                parametro.Add("@ID_Producto", _Odetalle_venta.ID_Producto, dbType: DbType.Int64);
                parametro.Add("@Cantidad", _Odetalle_venta.Cantidad, dbType: DbType.Int64);
                parametro.Add("@PrecioVenta", _Odetalle_venta.PrecioVenta, dbType: DbType.Single);
                parametro.Add("@SubTotal", _Odetalle_venta.SubTotal, dbType: DbType.Single);
                parametro.Add("@Total", _Odetalle_venta.Total, dbType: DbType.Single);

                using (var con = new SqlConnection(_StringSql))
                {
                    await con.ExecuteAsync(_queryCommand, parametro, commandType: CommandType.StoredProcedure);
                    return "Venta guardada correctamente";
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return $"Error al guardar el detalle de venta: {ex.Message}";
            }
        }

            
    }








}


