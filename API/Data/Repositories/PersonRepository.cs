using API.Domain.Model.PersonAggregate;

namespace API.Data.Repositories {
    public class PersonRepository : IPersonRepository {

        private readonly ConnectionContext _context;
        public PersonRepository(ConnectionContext context) {
            _context = context;
        }

        public void AddPerson(Person person) {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public List<Person> Get() {
           return _context.Persons.ToList();
        }

        public Person GetByID(int ID) {
            return _context.Persons.Find(ID)!;
        }
    }
}
