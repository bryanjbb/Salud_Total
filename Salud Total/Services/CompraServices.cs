using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Salud_Total.Models;
using System.Data;

namespace Salud_Total.Services
{
    public class CompraServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;

        public CompraServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;

        }

        public async Task<Compra> GetCompra(int ID)
        {
            string _queryCommand = "listarCompra";
            var parametro = new DynamicParameters();
            parametro.Add("@N_Compra", ID, dbType: DbType.Int64);
            using (var con = new SqlConnection(_StringSql))
            {
                var _compra = await con.QueryFirstOrDefaultAsync<Compra>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _compra;
            }
        }
        public async Task<String> PostCompra([FromBody] Compra _OCompra)
        {
            string _queryCommand = "insertarCompra";
            var parametro = new DynamicParameters();
            parametro.Add("@N_Compra", _OCompra.N_Compra, dbType: DbType.Int64);
            parametro.Add("@ID_CP", _OCompra.ID_CP, dbType: DbType.Int64);
            parametro.Add("@Fecha", _OCompra.Fecha, dbType: DbType.DateTime);
            parametro.Add("@Total", _OCompra.Total, dbType: DbType.Int64);
            
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                commandType: CommandType.StoredProcedure);
                return ("Compra registrado");
            }
        }
        public async Task<String> PutCompra([FromBody] Compra _OCompra)
        {
            string _queryCommand = "actualizarCompra";
            var parametro = new DynamicParameters();
            parametro.Add("@N_Compra", _OCompra.N_Compra, dbType: DbType.Int64);
            parametro.Add("@ID_CP", _OCompra.ID_CP, dbType: DbType.Int64);
            parametro.Add("@Fecha", _OCompra.Fecha, dbType: DbType.DateTime);
            parametro.Add("@Total", _OCompra.Total, dbType: DbType.Int64);
            
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                commandType: CommandType.StoredProcedure);
                return ("Compra Actualizada");
            }
        }

    }
}
 
    

