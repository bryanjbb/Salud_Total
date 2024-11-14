using Dapper;
using Salud_Total.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;


namespace Salud_Total.Services
{
    public class Detalle_CompraServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;


        public Detalle_CompraServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;

        }

        public async Task<IEnumerable<Detalle_Compra>> GetDetallesCompra(long N_Compra)
        {
            string _queryCommand = "listarDetalle_Compra";  // Supongo que tienes un SP para obtener los detalles de una venta.
            var parametro = new DynamicParameters();
            parametro.Add("@N_Compra", N_Compra, dbType: DbType.Int64);

            using (var con = new SqlConnection(_StringSql))
            {
                var detallesCompra = await con.QueryAsync<Detalle_Compra>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return detallesCompra;
            }
        }


        public async Task<string> InsertarDetalleCompra(Detalle_Compra detalleCompra)
        {
            string queryCommand = "insertarDetalle_Compra";  // Nombre del procedimiento almacenado
            var parametro = new DynamicParameters();

            // Añadir parámetros al procedimiento almacenado
            parametro.Add("@N_Compra", detalleCompra.N_Compra, dbType: DbType.Int64);
            parametro.Add("@ID_Producto", detalleCompra.ID_Producto, dbType: DbType.Int64);
            parametro.Add("@Cantidad", detalleCompra.Cantidad, dbType: DbType.Int64);
            parametro.Add("@Total", detalleCompra.Total, dbType: DbType.Single);

            using (var con = new SqlConnection(_StringSql))
            {
                // Ejecutamos el procedimiento almacenado
                await con.ExecuteAsync(queryCommand, parametro, commandType: CommandType.StoredProcedure);

                return "Detalle de compra guardado correctamente";
            }
        }
    }




}











