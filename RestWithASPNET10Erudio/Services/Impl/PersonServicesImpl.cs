using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        public Person FindById(long id)
        {
            var person = MockPerson((int)id);
            return person;
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new();
            for (int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }

            return persons;
        }
        public Person Create(Person person)
        {
            return new Person();
        }
        public Person Update(Person person)
        {
            return person;
        }

        public void DeleteById(long id)
        {
            // Simulate deletion logic
        }

        private Person MockPerson(int i )
        {
            string gender = (i % 2 == 0) ? "male" : "female";
            string name = (i % 2 == 0) ? "Jully " : "Jhon ";
            return new Person
            {
                Id = new Random().Next(1, 1000),
                FirstName = name + i,
                LastName = "Doe" + i,
                Address = "123 Main Street" + i,
                Gender = gender
            };

        }
    }
}
