using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Data.DTO.V1;
using RestWithASPNET10Erudio.Services;

namespace RestWithASPNET10Erudio.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServices service, ILogger<PersonController> logger)
        {
            _personService = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all persons");
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching person with ID: {id}", id);
            var person = _personService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with ID: {id} not found", id);
                return NotFound();
            }
            
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO dto)
        {
            _logger.LogInformation("Creating new Person: {firstName}", dto.FirstName);
            var createdPerson = _personService.Create(dto);
            if (createdPerson == null)
            {
                _logger.LogWarning("Failed to create Person: {firstName}", dto.FirstName);
                return NotFound();
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonDTO dto)
        {
            _logger.LogInformation("Updating person with ID: {id}", dto.Id);
            var createdPerson = _personService.Update(dto);
            if (createdPerson == null)
            {
                _logger.LogWarning("Failed to update Person with ID: {id}", dto.Id);
                return NotFound();
            }
            _logger.LogDebug("Person with ID: {id} updated successfully: {firstName}", dto.Id, dto.FirstName);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting person with ID: {id}", id);
            _personService.DeleteById(id);
            _logger.LogDebug("Person with ID: {id} deleted successfully", id);
            return NoContent();
        }
    }
}
