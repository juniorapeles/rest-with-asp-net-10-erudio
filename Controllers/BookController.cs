using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.data;
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
        public IActionResult Post([FromBody] BookDTO dto)
        {
            _logger.LogInformation("Creating new Book: {firstName}", dto.Title);
            var createdBook = _BookService.Create(dto);
            if (dto == null)
            {
                _logger.LogWarning("Failed to create Book: {firstName}", dto.Title);
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookDTO dto)
        {
            _logger.LogInformation("Updating Book with ID: {id}", dto.Id);
            var createdBook = _BookService.Update(dto);
            if (createdBook == null)
            {
                _logger.LogWarning("Failed to update Book with ID: {id}", dto.Id);
                return NotFound();
            }
            _logger.LogDebug("Book with ID: {id} updated successfully: {Title}", dto.Id, dto.Title);
            return Ok(dto);
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
