using bookreview.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
