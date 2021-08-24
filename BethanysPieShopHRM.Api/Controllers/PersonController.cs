using Microsoft.AspNetCore.Mvc;
using PersonRegistrationAPI.Models;
using PersonRegistrationShared;

namespace PersonRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(_personRepository.GetAllPeople());
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            return Ok(_personRepository.GetPersonById(id));
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            if (person.FirstName == string.Empty || person.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPerson = _personRepository.AddPerson(person);

            return Created("person", createdPerson);
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            if (person.FirstName == string.Empty || person.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var personToUpdate = _personRepository.GetPersonById(person.PersonId);

            if (personToUpdate == null)
                return NotFound();

            _personRepository.UpdatePerson(person);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            if (id == 0)
                return BadRequest();

            var personToDelete = _personRepository.GetPersonById(id);
            if (personToDelete == null)
                return NotFound();

            _personRepository.DeletePerson(id);

            return NoContent();//success
        }
    }
}
