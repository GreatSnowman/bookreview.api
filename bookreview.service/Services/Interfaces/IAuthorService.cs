using bookreview.common.Models;

namespace bookreview.service.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorModel> AddNewAuthor(AuthorModel author);

        Task<AuthorModel> UpdateAuthor(AuthorModel author);

        Task<AuthorModel> GetAuthor(int id);

        Task<IEnumerable<AuthorModel>> GetAllAuthors();

        Task<AuthorModel> PatchProperty(PatchModel model);
    }
}
