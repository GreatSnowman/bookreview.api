using atomic.chicken.common.Models;

namespace atomic.chicken.service.Services.Interfaces
{
    public interface IAuthorService : IPatchService
    {
        Task<AuthorModel> AddNewAuthor(AuthorModel author);

        Task<AuthorModel> UpdateAuthor(AuthorModel author);

        Task<AuthorModel> GetAuthor(int id);

        Task<IEnumerable<AuthorModel>> GetAllAuthors();
    }
}
