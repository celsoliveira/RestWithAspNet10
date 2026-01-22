using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Model;
using RestWithAspNet10.Services;

namespace RestWithAspNet10.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        
        private readonly IPersonServices _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServices personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }


        // http://localhost:7131/api/person
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetch all people");
            return Ok(_personService.FindAll());
        }

        //http://localhost:7131/api/person/1

        [HttpGet("{id}")]
        public ActionResult Get(long id) {
            _logger.LogInformation("Fetch person with ID {id}", id);

            var person = _personService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with ID {id} not found.", id);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _logger.LogInformation("Creating new Person: {firstName}", person.FirstName);
            var createdPerson = _personService.Create(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to create person with name {firsName}.", person.FirstName);
                return NotFound();
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            _logger.LogInformation("Updating person with ID: {id}", person.Id);
            var updatedPerson = _personService.Update(person);
            if (updatedPerson == null)
            {
                _logger.LogError("Failed to update person with id {id}.", person.Id);
                return NotFound();
            }
            _logger.LogDebug("Person updated successtully: {firstName}.", person.FirstName);
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting person with ID: {id}", id);
            _personService.Delete(id);
            _logger.LogDebug("Person with ID {id} deleted successtully.", id);
            return NoContent();
        }

    }
}
