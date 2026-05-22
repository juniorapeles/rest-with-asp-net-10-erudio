using RestWithASPNET10Erudio.Data.DTO.V1;
namespace RestWithASPNET10Erudio.Services
{
    public interface IBookServices
    {
        BookDTO Create(BookDTO dto);
        BookDTO FindById(long id);
        List<BookDTO> FindAll();
        BookDTO Update(BookDTO dto);
        void DeleteById(long id);
    }
}
