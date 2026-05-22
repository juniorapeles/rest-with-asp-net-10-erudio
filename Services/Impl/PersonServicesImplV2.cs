using RestWithASPNET10Erudio.Data.Converter.Impl.V2;
using RestWithASPNET10Erudio.Data.DTO.V2;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class PersonServicesImplV2 : IPersonServicesV2
    {
        private readonly IRepository<Person> _personRepository;
        private readonly PersonConverter _personConverter;

        public PersonServicesImplV2(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            _personConverter = new PersonConverter();
        }

        public PersonDTO Create(PersonDTO personDTO)
        {
            var person = _personConverter.Parse(personDTO);
            var createdPerson = _personRepository.Create(person);
            return _personConverter.Parse(createdPerson);
        }

        public PersonDTO FindById(long id)
        {
            return _personConverter.Parse(_personRepository.FindById(id));
        }

        public List<PersonDTO> FindAll()
        {
            return _personConverter.ParseList(_personRepository.FindAll());
        }

        public PersonDTO Update(PersonDTO personDTO)
        {
            var existingPerson = _personRepository.FindById(personDTO.Id);
            if (existingPerson == null) return null;
            _personRepository.Update(_personConverter.Parse(personDTO));
            return personDTO;
        }

        public void DeleteById(long id)
        {
            var existingPerson = _personRepository.FindById(id);
            if (existingPerson == null) return;
            _personRepository.DeleteById(id);
        }
    }
}
