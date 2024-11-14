using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Salud_Total.Models;
using System.Data;

namespace Salud_Total.Services
{
    public class VentaServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;

        public VentaServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;

        }

        public async Task<Venta> GetVenta(int ID)
        {
            string _queryCommand = "listarVenta";
            var parametro = new DynamicParameters();
            parametro.Add("@N_Factura", ID, dbType: DbType.Int64);
            using (var con = new SqlConnection(_StringSql))
            {
                var _venta = await con.QueryFirstOrDefaultAsync<Venta>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _venta;
            }
        }
        public async Task<String> PostVenta([FromBody] Venta _Oventa)
        {
            string _queryCommand = "insertarVenta";
            var parametro = new DynamicParameters();
            parametro.Add("@N_Factura", _Oventa.N_Factura, dbType: DbType.Int64);
            parametro.Add("@Fecha", _Oventa.Fecha, dbType: DbType.DateTime);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                commandType: CommandType.StoredProcedure);
                return ("Venta registrada");
            }
        }
    }
}
