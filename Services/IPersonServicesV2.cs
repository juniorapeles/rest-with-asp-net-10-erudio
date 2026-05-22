using RestWithASPNET10Erudio.Data.DTO.V2;

namespace RestWithASPNET10Erudio.Services
{
    public interface IPersonServicesV2
    {
        PersonDTO Create(PersonDTO personDTO);
        PersonDTO FindById(long id);
        List<PersonDTO> FindAll();
        PersonDTO Update(PersonDTO personDTO);
        void DeleteById(long id);
    }
}
