using API.Application.ViewModel;
using API.Domain.Model.PersonAggregate;

using Microsoft.AspNetCore.Mvc;


namespace API.Controllers {
    [ApiController]
    [Route("api/v1/person")]
    public class PersonController : ControllerBase {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository) {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult GetPersons() {
            List<Person> lstPersons = _personRepository.Get();
            if (!lstPersons.Any() || lstPersons == null) {
                return NotFound();
            }

            return Ok(lstPersons);
        }

        [HttpGet]
        [Route("GetByID/{ID}")]
        public IActionResult GetPerson(int ID) {
            Person person = _personRepository.GetByID(ID);
            if (person == null) {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonViewModel PersonView) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            string filepath = Path.Combine("Storage", PersonView.Photo.FileName);
            using Stream fileStream = new FileStream(filepath, FileMode.Create);
            PersonView.Photo.CopyTo(fileStream);
            Person person = new Person(PersonView.Name, PersonView.Age, filepath, PersonView.Login, PersonView.Password);

            _personRepository.AddPerson(person);
            return Ok();
        }
    }
}
