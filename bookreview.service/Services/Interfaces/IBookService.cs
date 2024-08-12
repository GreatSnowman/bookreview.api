using atomic.chicken.common.Models;

namespace atomic.chicken.service.Services.Interfaces
{
    public interface IBookService
    {
        BookModel GetBook(int id);

        BookModel InsertNewBook(BookModel model);

        BookModel DeleteBook(int id);

        BookModel UpdateBook(BookModel model);
    }
}
