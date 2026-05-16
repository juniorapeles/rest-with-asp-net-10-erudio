using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Services;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IActionResult Post([FromBody] Person person)
        {
            _logger.LogInformation("Creating new Person: {firstName}", person.FirstName);
            var createdPerson = _personService.Create(person);
            if (person == null)
            {
                _logger.LogWarning("Failed to create Person: {firstName}", person.FirstName);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            _logger.LogInformation("Updating person with ID: {id}", person.Id);
            var createdPerson = _personService.Update(person);
            if (createdPerson == null)
            {
                _logger.LogWarning("Failed to update Person with ID: {id}", person.Id);
                return NotFound();
            }
            _logger.LogDebug("Person with ID: {id} updated successfully: {firstName}", person.Id, person.FirstName);
            return Ok(person);
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
