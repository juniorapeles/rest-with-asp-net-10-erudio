using RestWithASPNET10Erudio.data;
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
