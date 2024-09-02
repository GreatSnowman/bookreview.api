

using bookreview.common.Models;
using bookreview.service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookreview.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<AuthorModel>> GetAllAuthors()
        {
            return await _service.GetAllAuthors();
        }

        [HttpGet]
        public async Task<AuthorModel> GetAuthor(int id)
        {
            return await _service.GetAuthor(id);
        }

        [HttpPost]
        public async Task<AuthorModel> AddNewAuthor(AuthorModel author)
        {
            return await _service.AddNewAuthor(author);
        }

        [HttpPut]
        public async Task<AuthorModel> UpdateAuthor(AuthorModel author)
        {
            return await _service.UpdateAuthor(author);
        }

        [HttpPatch]
        public ActionResult PatchAuthorProperty(PatchModel model)
        {
            try
            {
                _service.PatchProperty(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
