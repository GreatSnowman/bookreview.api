using bookreview.common.Models;
using bookreview.infrastructure.DataModel;
using bookreview.infrastructure.Repository;
using bookreview.infrastructure.SQL;
using bookreview.infrastructure.SQL.Author;
using bookreview.service.Services.Interfaces;
using Dapper;

namespace bookreview.service.Services
{
    public class BookService : IBookService
    {
        private readonly IDapperRepository _repository;

        public BookService(IDapperRepository repository)
        {
            _repository = repository;
        }

        public Task<BookModel> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookViewModel> GetBook(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var query = "SELECT * FROM Books Where Id = @Id";
                var result = await _repository.ExecuteQueryStringSingleAsync<BookViewModel>(query, parameters);
                return result;
            }
            catch (Exception ex)
            {
                var cake = new BookViewModel();
                cake.Error.Message = ex.Message;
                return cake;
            }
        }

        public async Task<BookViewModel> InsertNewBook(BookModel model)
        {
            try
            {
                var paramaters = BookSqlQueries.BookInsertParameters(model);
                var query = BookSqlQueries.BookInsert();
                var result = await _repository.ExecuteQueryStringSingleAsync<BookViewModel>(query, paramaters);
                return result;
            }
            catch (Exception ex)
            {
                var cake = new BookViewModel();
                cake.Error.Message = ex.Message;
                return cake;
            }
        }

        public Task<BookModel> PatchProperty(PatchModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BookModel> UpdateBook(BookModel model)
        {
            throw new NotImplementedException();
        }
    }
}
