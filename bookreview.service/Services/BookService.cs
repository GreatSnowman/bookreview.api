using bookreview.common.Models;
using bookreview.infrastructure.DataModel;
using bookreview.infrastructure.Repository;
using bookreview.infrastructure.SQL;
using bookreview.infrastructure.SQL.Author;
using bookreview.service.Services.Interfaces;

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
