using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class BookServicesImpl : IBookServices
    {
        
        private IRepository<Book> _BookRepository;

        public BookServicesImpl(IRepository<Book> BookRepository)
        {
            _BookRepository = BookRepository;
        }

        public List<Book> FindAll()
        {
            return _BookRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _BookRepository.FindById(id);
        }

        public Book Create(Book Book)
        {
            return _BookRepository.Create(Book);
        }
        public Book Update(Book Book)
        {
            var existingBook = _BookRepository.FindById(Book.Id);

            if (existingBook == null) return null;
            
            _BookRepository.Update(Book);
            return Book;
        }

        public void DeleteById(long id)
        {
            var existingBook = _BookRepository.FindById(id);

            if (existingBook == null) return;
            _BookRepository.DeleteById(id);
        }
    }
}
