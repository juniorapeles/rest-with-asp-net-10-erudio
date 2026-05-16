using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        
        private IRepository<Person> _personRepository;

        public PersonServicesImpl(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindById(long id)
        {
            return _personRepository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }
        public Person Update(Person person)
        {
            var existingPerson = _personRepository.FindById(person.Id);

            if (existingPerson == null) return null;
            
            _personRepository.Update(person);
            return person;
        }

        public void DeleteById(long id)
        {
            var existingPerson = _personRepository.FindById(id);

            if (existingPerson == null) return;
            _personRepository.DeleteById(id);
        }
    }
}
