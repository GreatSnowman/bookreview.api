using bookreview.common.Models;

namespace bookreview.service.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<PublisherModel> AddNewPublisher(PublisherModel publisher);

        Task<PublisherModel> UpdatePublisher(PublisherModel publisher);

        Task<PublisherModel> GetPublisher(int id);

        Task<PublisherModel> PatchProperty(PatchModel model);
    }
}
