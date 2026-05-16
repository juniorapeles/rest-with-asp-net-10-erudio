using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Repositories
{
    public interface IBookRepository
    {
        Book Create(Book Book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book Book);
        void DeleteById(long id);
    }
}
