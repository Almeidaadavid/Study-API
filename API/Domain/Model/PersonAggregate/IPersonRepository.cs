namespace API.Domain.Model.PersonAggregate {
    public interface IPersonRepository {

        void AddPerson(Person person);

        Person GetByID(int ID);
        List<Person> Get();
    }
}
