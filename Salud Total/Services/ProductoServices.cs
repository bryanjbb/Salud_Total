using Dapper;
using Salud_Total.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;


namespace Salud_Total.Services
{
    public class ProductoServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;

        public ProductoServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;

        }

        public async Task<Producto> GetProducto(int ID)
        {
            string _queryCommand = "listarProducto";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Producto", ID, dbType: DbType.Int64);
            using (var con = new SqlConnection(_StringSql))
            {
                var _producto = await con.QueryFirstOrDefaultAsync<Producto>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _producto;
            }
        }
            public async Task<String> PostProducto([FromBody] Producto _Oproducto)
            {
                string _queryCommand = "insertarProducto";
                var parametro = new DynamicParameters();
                parametro.Add("@ID_Producto", _Oproducto.ID_Producto, dbType: DbType.Int64);
                parametro.Add("@Nombre_Producto", _Oproducto.Nombre_Producto, dbType: DbType.String);
                parametro.Add("@Precio_U", _Oproducto.Precio_U, dbType: DbType.String);
                parametro.Add("@Vencimiento", _Oproducto.Vencimiento, dbType: DbType.DateTime);
                parametro.Add("@Cantidad", _Oproducto.Cantidad, dbType: DbType.Int64);
                using (var con = new SqlConnection(_StringSql))
                {
                    await con.ExecuteAsync(_queryCommand, parametro,
                    commandType: CommandType.StoredProcedure);
                    return ("Producto registrado");
                }
            }
        public async Task<String> PutProducto([FromBody] Producto _Oproducto)
        {
            string _queryCommand = "actualizarProducto";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Producto", _Oproducto.ID_Producto, dbType: DbType.Int64);
            parametro.Add("@Nombre_Producto", _Oproducto.Nombre_Producto, dbType: DbType.String);
            parametro.Add("@Precio_U", _Oproducto.Precio_U, dbType: DbType.String);
            parametro.Add("@Vencimiento", _Oproducto.Vencimiento, dbType: DbType.DateTime);
            parametro.Add("@Cantidad", _Oproducto.Cantidad, dbType: DbType.Int64);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro,
                commandType: CommandType.StoredProcedure);
                return ("Producto Actualizado");
            }
        }
        public async Task<string> DeleteProducto(int ID)
        {
            string _queryCommand = "eliminarProducto";
            var parametro = new DynamicParameters();
            parametro.Add("@ID_Producto", ID, dbType: DbType.Int32);
            using (var con = new SqlConnection(_StringSql))
            {
                await con.ExecuteAsync(_queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return "Producto eliminado";
            }

        }
        }
    } 

