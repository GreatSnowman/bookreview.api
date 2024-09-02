using bookreview.common;
using bookreview.infrastructure.Repository.EFCore;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;

namespace bookreview.infrastructure.Repository
{
	public class DapperRepository: IDapperRepository
    {
        private readonly ConnectionStringSettings _connectionString;
        private readonly ILogger<DapperRepository> _logger;

        public DapperRepository(IOptions<ConnectionStringSettings> connectionStringSettings, DatabaseContext context, ILogger<DapperRepository> logger)
        {
            _connectionString = connectionStringSettings.Value ?? throw new NullReferenceException();
            Context = context;
            _logger = logger;
        }

        protected DatabaseContext Context { get; set; }

        private IDbConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(_connectionString.ConnectionString);

                return connection;
            }
        }

        public async Task<IEnumerable<TModel>> ExecuteQueryAsync<TModel>(string queryString, DynamicParameters parameters)
        {
            try
            {
                var connection = Context.Database.GetDbConnection();

                connection.Open();

                var result = await connection.QueryAsync<TModel>(queryString, parameters);

                connection.Close();

                return result;
            }
            catch (SqlException e)
            {
                throw new Exception($"Error in SQL: {queryString}.Insert Message: {e.Message}", e.InnerException);
            }
        }

        public async Task<TModel> ExecuteQueryStringSingleAsync<TModel>(string queryString, DynamicParameters parameters)
        {
            try
            {
                var connection = Context.Database.GetDbConnection();

                connection.Open();

                var result = await connection.QueryFirstOrDefaultAsync<TModel>(queryString, parameters);

                connection.Close();

                return result;

            }
            catch (SqlException e)
            {
                throw new Exception($"Error in SQL: {queryString}.Insert Message: {e.Message}", e.InnerException);
            }
        }


        public Task<dynamic> ExecuteQueryWithMultipleReturns(string queryString, DynamicParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
