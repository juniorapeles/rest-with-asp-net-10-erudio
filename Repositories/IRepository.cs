using RestWithASPNET10Erudio.Model.Base;

namespace RestWithASPNET10Erudio.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void DeleteById(long id);
        bool Exists(long id);
    }
}
