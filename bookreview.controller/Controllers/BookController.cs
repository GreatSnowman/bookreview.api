using bookreview.common.Enum;
using bookreview.common.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookreview.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookController() { }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public BookModel Get(int id)
        {
            return new BookModel()
            {
                Id = 1,
                Authors = new List<AuthorModel>() 
                {
                    new AuthorModel()
                    {
                        Id = 1,
                        AuthorType = AuthorType.Book,
                        Forename = "Lemon",
                        Surname = "Snicket"
                    }
                },
                ISBN = "SIBN11",
                Publisher = "MacMillian",
                Synoposis = "It's an unfortunate event",
                Title = "Bad Beginnings",
                YearPublished = "1999"
            };
        }

        [HttpPost]
        public BookModel Post(BookModel model)
        {
            return model;
        }

        [HttpPut]
        public BookModel Put(BookModel model)
        {
            return model;
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
