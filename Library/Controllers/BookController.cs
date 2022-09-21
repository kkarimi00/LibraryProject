using Library.Application.Books.Commands;
using Library.Application.Books.Queries;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public BookController(IMediator mediator)
        {
            _mediatR = mediator;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllBookQuery();
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediatR.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            var bookCommand = new CreateBookCommand(book.Title, book.Author, book.Isbn, book.BookTypeId);
            var result = await _mediatR.Send(bookCommand);
            return Ok(result);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Book book)
        {
            var updateCommand = new UpdateBookCommand(book);
            var result = await _mediatR.Send(updateCommand);
            return Ok(result);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delcommand = new DeleteBookCommand(id);
            var result = await _mediatR.Send(delcommand);
            return Ok(result);
        }
    }
}
