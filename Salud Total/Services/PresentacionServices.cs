using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Salud_Total.Models;
using System.Data;

namespace Salud_Total.Services
{
    public class PresentacionServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;

        public PresentacionServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;

        }

        public async Task<Presentacion> GetPresentacion(int ID)
        {
            string _queryCommand = "listarPresentacion";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Presentacion", ID, dbType: DbType.Int64);
            using (var con = new SqlConnection(_StringSql))
            {
                var _presentacion = await con.QueryFirstOrDefaultAsync<Presentacion>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _presentacion;
            }
        }
        public async Task<String> PostPresentacion([FromBody] Presentacion _Opresentacion)
        {
            string _queryCommand = "insertarPresentacion";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Presentacion", _Opresentacion.ID_Presentacion, dbType: DbType.Int64);
            parametro.Add("@Descripcion", _Opresentacion.Descripcion, dbType: DbType.String);
            parametro.Add("@ID_Producto", _Opresentacion.ID_Producto, dbType: DbType.Int64);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                commandType: CommandType.StoredProcedure);
                return ("Presentacion registrada");
            }
        }
        public async Task<String> PutPresentacion([FromBody] Presentacion _Opresentacion)
        {
            string _queryCommand = "actualizarPresentacion";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Presentacion", _Opresentacion.ID_Presentacion, dbType: DbType.Int64);
            parametro.Add("@Descripcion", _Opresentacion.Descripcion, dbType: DbType.String);
            parametro.Add("@ID_Producto", _Opresentacion.ID_Producto, dbType: DbType.String);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                commandType: CommandType.StoredProcedure);
                return ("Presentacion Actualizada");
            }
        }
        public async Task<string> DeletePresentacion(int ID)
        {
            string _queryCommand = "eliminarPresentacion";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Presentacion", ID, dbType: DbType.Int32);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return "Presentacion eliminada";
            }

        }
    }
} 
  
