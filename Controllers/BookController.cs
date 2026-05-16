using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Services;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _BookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookServices service, ILogger<BookController> logger)
        {
            _BookService = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all Books");
            return Ok(_BookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching Book with ID: {id}", id);
            var Book = _BookService.FindById(id);
            if (Book == null)
            {
                _logger.LogWarning("Book with ID: {id} not found", id);
                return NotFound();
            }
            
            return Ok(Book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book Book)
        {
            _logger.LogInformation("Creating new Book: {firstName}", Book.Title);
            var createdBook = _BookService.Create(Book);
            if (Book == null)
            {
                _logger.LogWarning("Failed to create Book: {firstName}", Book.Title);
                return NotFound();
            }
            return Ok(Book);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book Book)
        {
            _logger.LogInformation("Updating Book with ID: {id}", Book.Id);
            var createdBook = _BookService.Update(Book);
            if (createdBook == null)
            {
                _logger.LogWarning("Failed to update Book with ID: {id}", Book.Id);
                return NotFound();
            }
            _logger.LogDebug("Book with ID: {id} updated successfully: {Title}", Book.Id, Book.Title);
            return Ok(Book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting Book with ID: {id}", id);
            _BookService.DeleteById(id);
            _logger.LogDebug("Book with ID: {id} deleted successfully", id);
            return NoContent();
        }
    }
}
