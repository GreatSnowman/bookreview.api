using atomic.chicken.common.Models;

namespace atomic.chicken.service.Services.Interfaces
{
    public interface IPatchService
    {
        Task PatchProperty(PatchModel model);
    }
}
