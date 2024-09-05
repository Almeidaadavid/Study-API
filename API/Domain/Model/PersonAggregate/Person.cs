namespace API.Domain.Model.PersonAggregate {
    public class Person {
        public  int id { get; set; }
        public string name { get; private set; }
        public int age { get; private set; }
        public string? photo { get; private set; }
        public string login { get; private set; }
        public string password { get; private set; }

        public Person(string name, int age, string? photo, string login, string password) {
            this.name = name;
            this.age = age;
            this.photo = photo;
            this.login = login;
            this.password = password;
        }

        public Person() { }
    }
}
