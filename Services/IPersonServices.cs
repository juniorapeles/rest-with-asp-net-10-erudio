

using RestWithASPNET10Erudio.data;

namespace RestWithASPNET10Erudio.Services
{
    public interface IPersonServices
    {
        PersonDTO Create(PersonDTO PersonDTO);
        PersonDTO FindById(long id);
        List<PersonDTO> FindAll();
        PersonDTO Update(PersonDTO PersonDTO);
        void DeleteById(long id);
    }
}
