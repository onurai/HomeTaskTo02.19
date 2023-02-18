using HomeTaskTo02._19.Data.Context;
using HomeTaskTo02._19.Data.Entities;
using HomeTaskTo02._19.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeTaskTo02._19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var existedBook = await _bookService.Get(id);
            if (existedBook == null)
            {
                return NotFound("Book was not found");
            }
            return Ok(existedBook);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBook(Book book)
        {
            var isSuccessfullyCreated = await _bookService.Create(book);
            return Ok(isSuccessfullyCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            var isSuccessfullyUpdated = await _bookService.Update(id, book);
            return Ok(isSuccessfullyUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            await _bookService.Remove(id);
            return Ok();
        }
    }
}
