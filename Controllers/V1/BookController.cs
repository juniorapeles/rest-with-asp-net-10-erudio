using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Data.DTO.V1;
using RestWithASPNET10Erudio.Services;

namespace RestWithASPNET10Erudio.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]/v1")]
    [Produces("application/json")]
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
        [ProducesResponseType(200, Type = typeof(List<BookDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all Books");
            return Ok(_BookService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
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
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] BookDTO dto)
        {
            _logger.LogInformation("Creating new Book: {firstName}", dto.Title);
            var createdBook = _BookService.Create(dto);
            if (createdBook == null)
            {
                _logger.LogWarning("Failed to create Book: {Title}", dto.Title);
                return NotFound();
            }
            Response.Headers.Add("X-API-Deprecated", "true");
            Response.Headers.Add("X-API-Deprecation-Date", "2026-12-31");
            return Ok(createdBook);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
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
        [ProducesResponseType(204, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting Book with ID: {id}", id);
            _BookService.DeleteById(id);
            _logger.LogDebug("Book with ID: {id} deleted successfully", id);
            return NoContent();
        }
    }
}
