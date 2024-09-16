using bookreview.common.Enum;
using bookreview.common.Models;
using bookreview.service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookreview.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        { 
            _bookService = bookService;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<BookViewModel> Get(int id)
        {
            return await _bookService.GetBook(id);
        }

        [HttpPost]
        public async Task<BookModel> Post(BookModel model)
        {
            return await _bookService.InsertNewBook(model);
        }

        [HttpPut]
        public async Task<BookModel> Put(BookModel model)
        {
            return await _bookService.UpdateBook(model);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
