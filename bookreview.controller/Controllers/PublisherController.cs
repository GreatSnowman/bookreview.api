using atomic.chicken.common.Models;
using atomic.chicken.service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace atomic.chicken.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _service;

        public PublisherController(IPublisherService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<PublisherModel> AddNewPublisher(PublisherModel author)
        {
            return await _service.AddNewPublisher(author);
        }

        [HttpPut]
        public async Task<PublisherModel> UpdatePublisher(PublisherModel author)
        {
            return await _service.UpdatePublisher(author);
        }

        [HttpGet]
        public async Task<PublisherModel> GetPublisher(int id)
        {
            return await _service.GetPublisher(id);
        }
    }
}
