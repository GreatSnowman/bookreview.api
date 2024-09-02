using AutoFixture;
using atomic.chicken.common.Models;
using atomic.chicken.infrastructure.Repository;
using atomic.chicken.infrastructure.SQL.Author;
using atomic.chicken.service.Services.Interfaces;
using Dapper;
using atomic.chicken.infrastructure.DataModel;

namespace atomic.chicken.service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IDapperRepository _repository;

        public AuthorService(IDapperRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthorModel> AddNewAuthor(AuthorModel author)
        {
            try
            {
                var paramaters = AuthorSQLQueries.InsertParameters(author);
                var query = AuthorSQLQueries.Insert();
                var result = await _repository.ExecuteQueryStringSingleAsync<AuthorModel>(query, paramaters);
                return result;
            }
            catch (Exception ex)
            {
                author.Error.Message = ex.Message;

                return author;
            }
        }

        public async Task<IEnumerable<AuthorModel>> GetAllAuthors()
        {
            try
            {
                var result = await _repository.ExecuteQueryAsync< AuthorModel>($"SELECT * FROM Author", new DynamicParameters());
                return result;
            }
            catch (Exception ex)
            {
                var list = new List<AuthorModel>() {
                    new AuthorModel() {
                        Forename = ex.Message
                    }
                };
                return list;
            }
}

        public async Task<AuthorModel> PatchProperty(PatchModel model)
        {
            try
            {
                var paramaters = AuthorSQLQueries.PatchParameter(model);
                var query = AuthorSQLQueries.PatchQuery(model.PropertyName);
                await _repository.ExecuteQueryStringSingleAsync<AuthorModel>(query, paramaters);
            }
            catch (Exception ex)
            {
                var author = new AuthorModel();
                author.Error.Message = ex.Message;

                return author;
            }
        }

        public async Task<AuthorModel> UpdateAuthor(AuthorModel author)
        {
            var paramaters = AuthorSQLQueries.UpdateParameters(author);
            var query = AuthorSQLQueries.SqlServerUpdate();
            var result = await _repository.ExecuteQueryStringSingleAsync<AuthorModel>(query, paramaters);
            return result;
        }

        public async Task<AuthorModel> GetAuthor(int id)
		{
			var paramaters = AuthorSQLQueries.GetByIdParameters(id);
			var query = AuthorSQLQueries.GetByIdQuery();

			var result = await _repository.ExecuteQueryStringSingleAsync<AuthorModel>(query, paramaters);

            return result;
        }
    }
}
