using RestWithASPNET10Erudio.Data.Converter.Contract;
using RestWithASPNET10Erudio.Data.DTO.V2;
using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Data.Converter.Impl.V2
{
    public class PersonConverter : IParser<Person, PersonDTO>, IParser<PersonDTO, Person>
    {
        public PersonDTO Parse(Person origin)
        {
            if(origin == null) return null;
            return new PersonDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
                BirthDay = DateTime.Now
            };
        }

        public Person Parse(PersonDTO origin)
        {
            if(origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
                //BirthDay = origin.BirthDay
            };
        }

        public List<PersonDTO> ParseList(List<Person> origin)
        {
            if(origin == null) return null;
            var personDTOs = new List<PersonDTO>();
            foreach(var person in origin)
            {
                personDTOs.Add(Parse(person));
            }
            return personDTOs;
        }

        public List<Person> ParseList(List<PersonDTO> origin)
        {
            if(origin == null) return null;
            var persons = new List<Person>();
            foreach(var personDTO in origin)
            {
                persons.Add(Parse(personDTO));
            }
            return persons;
        }
    }
}
