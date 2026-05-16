using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Model.Context;

namespace RestWithASPNET10Erudio.Repositories.Impl
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(MSSQLContext context)
        {
            _context = context;
        }


        private MSSQLContext _context;



        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.Find(id);
        }

        public Book Create(Book Book)
        {
            _context.Books.Add(Book);
            _context.SaveChanges();
            return Book;
        }
        public Book Update(Book Book)
        {
            var existingBook = _context.Books.Find(Book.Id);

            if (existingBook == null) return null;

            _context.Books.Entry(existingBook).CurrentValues.SetValues(Book);
            _context.SaveChanges();

            return Book;
        }

        public void DeleteById(long id)
        {
            var existingBook = _context.Books.Find(id);

            if (existingBook == null) return;
            _context.Remove(existingBook);
            _context.SaveChanges();
        }
    }
}
