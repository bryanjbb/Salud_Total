using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Salud_Total.Models;
using System.Data;

namespace Salud_Total.Services
{
    public class LaboratorioServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;

        public LaboratorioServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;

        }

        public async Task<Laboratorio> GetLaboratorio(int ID)
        {
            string _queryCommand = "listarLaboratorio";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Laboratorio", ID, dbType: DbType.Int64);
            using (var con = new SqlConnection(_StringSql))
            {
                var _laboratorio = await con.QueryFirstOrDefaultAsync<Laboratorio>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _laboratorio;
            }
        }
        public async Task<String> PostLaboratorio([FromBody] Laboratorio _Olaboratorio)
        {
            string _queryCommand = "insertarLaboratorio";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Laboratorio", _Olaboratorio.ID_Laboratorio, dbType: DbType.Int64);
            parametro.Add("@Descripcion", _Olaboratorio.Descripcion, dbType: DbType.String);
            parametro.Add("@ID_Producto", _Olaboratorio.ID_Producto, dbType: DbType.Int64);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                commandType: CommandType.StoredProcedure);
                return ("Laboratorio registrado");
            }
        }
        public async Task<String> PutLaboratorio([FromBody] Laboratorio _Olaboratorio)
        {
            string _queryCommand = "actualizarLaboratorio";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Laboratorio", _Olaboratorio.ID_Laboratorio, dbType: DbType.Int64);
            parametro.Add("@Descripcion", _Olaboratorio.Descripcion, dbType: DbType.String);
            parametro.Add("@ID_Producto", _Olaboratorio.ID_Producto, dbType: DbType.String);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                commandType: CommandType.StoredProcedure);
                return ("Laboratorio Actualizado");
            }
        }
        public async Task<string> DeleteLaboratorio(int ID)
        {
            string _queryCommand = "eliminarLaboratorio";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Laboratorio", ID, dbType: DbType.Int32);

            try
            {
                using (var con = new SqlConnection(_StringSql))
                {
                    await con.ExecuteAsync(_queryCommand, parametro, commandType: CommandType.StoredProcedure);
                    return "Laboratorio eliminado";
                }
            }
            catch (SqlException ex)
            {
                return $"Error al eliminar laboratorio: {ex.Message}";
            }
        }


    }
}


    
