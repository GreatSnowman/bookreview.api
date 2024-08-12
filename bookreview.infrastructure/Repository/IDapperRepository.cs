using Dapper;

namespace atomic.chicken.infrastructure.Repository
{
    public interface IDapperRepository
    {
        public Task<TModel> ExecuteQueryStringSingleAsync<TModel>(string queryString, DynamicParameters parameters);

        Task<dynamic> ExecuteQueryWithMultipleReturns(string queryString, DynamicParameters parameters);

        Task<IEnumerable<TModel>> ExecuteQueryAsync<TModel>(string queryString, DynamicParameters parameters);
    }
}