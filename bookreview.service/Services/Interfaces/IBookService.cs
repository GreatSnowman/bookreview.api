using bookreview.common.Models;

namespace bookreview.service.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookModel> GetBook(int id);

        Task<BookModel> InsertNewBook(BookModel model);

        Task<BookModel> DeleteBook(int id);

        Task<BookModel> UpdateBook(BookModel model);

        Task<BookModel> PatchProperty(PatchModel model);
    }
}
