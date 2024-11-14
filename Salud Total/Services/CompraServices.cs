﻿using Dapper;
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
        public async Task<String> PostCompra([FromBody] Compra _Ocompra)
        {
            string _queryCommand = "insertarCompra";
            var parametro = new DynamicParameters();
            parametro.Add("@N_Compra", _Ocompra.N_Compra, dbType: DbType.Int64);
            parametro.Add("@Fecha", _Ocompra.Fecha, dbType: DbType.DateTime);
                using (var con = new SqlConnection(_StringSql))
                {
                    await con.ExecuteAsync(_queryCommand, parametro,
                    commandType: CommandType.StoredProcedure);
                    return ("Compra registrada");
                }
            }
        }
}
