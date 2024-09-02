using atomic.chicken.common.Models;
using atomic.chicken.infrastructure.DataModel;
using atomic.chicken.infrastructure.Repository;
using atomic.chicken.infrastructure.SQL;
using atomic.chicken.infrastructure.SQL.Author;
using atomic.chicken.service.Services.Interfaces;

namespace atomic.chicken.service.Services
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

        public Task<BookModel> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookModel> InsertNewBook(BookModel model)
        {
            try
            {
                var paramaters = BookSqlQueries.BookInsertParameters(model);
                var query = BookSqlQueries.BookInsert();
                var result = await _repository.ExecuteQueryStringSingleAsync<BookModel>(query, paramaters);
                return result;
            }
            catch (Exception ex)
            {
                model.Error.Message = ex.Message;
                return model;
            }
        }

        public Task<BookModel> UpdateBook(BookModel model)
        {
            throw new NotImplementedException();
        }
    }
}
