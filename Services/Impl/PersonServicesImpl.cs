using RestWithASPNET10Erudio.data;
using RestWithASPNET10Erudio.Data.Converter.Impl;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        
        private IRepository<Person> _personRepository;
        private readonly PersonConverter _personConverter;

        public PersonServicesImpl(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            _personConverter = new PersonConverter();
        }

        public List<PersonDTO> FindAll()
        {
            return _personConverter.ParseList(_personRepository.FindAll());
        }

        public PersonDTO FindById(long id)
        {
            return _personConverter.Parse(_personRepository.FindById(id));
        }

        public PersonDTO Create(PersonDTO personDTO)
        {
            var person = _personConverter.Parse(personDTO);
            var createdPerson = _personRepository.Create(person);
            return _personConverter.Parse(createdPerson);
        }
        public PersonDTO Update(PersonDTO personDTO)
        {
            var existingPerson = _personRepository.FindById(personDTO.Id);

            if (existingPerson == null) return null;
            
            _personRepository.Update(_personConverter.Parse(personDTO));
            return _personConverter.Parse(existingPerson);
        }

        public void DeleteById(long id)
        {
            var existingPerson = _personRepository.FindById(id);

            if (existingPerson == null) return;
            _personRepository.DeleteById(id);
        }
    }
}
