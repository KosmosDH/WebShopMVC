using WebShopMVC.Data.Models;

namespace WebShopMVC.Data.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IList<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
    }
}
