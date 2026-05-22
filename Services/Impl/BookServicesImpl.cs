using Mapster;
using RestWithASPNET10Erudio.Data.DTO.V1;
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

        public List<BookDTO> FindAll()
        {
            return _BookRepository.FindAll().Adapt<List<BookDTO>>();
        }

        public BookDTO FindById(long id)
        {
            return _BookRepository.FindById(id).Adapt<BookDTO>();
        }

        
        public BookDTO Create(BookDTO dto)
        {
            return _BookRepository.Create(dto.Adapt<Book>()).Adapt<BookDTO>();
        }


        public BookDTO Update(BookDTO dto)
        {
            var existingBook = _BookRepository.FindById(dto.Id);

            if (existingBook == null) return null;
            
            _BookRepository.Update(dto.Adapt<Book>());
            return dto;
        }

        public void DeleteById(long id)
        {
            var existingBook = _BookRepository.FindById(id);

            if (existingBook == null) return;
            _BookRepository.DeleteById(id);
        }
    }
}
