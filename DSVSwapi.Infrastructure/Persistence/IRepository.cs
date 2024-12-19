using System.Linq.Expressions;

namespace DSVSwapi.Repository;
 
public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll(); 
    Task<T?> GetById(int id);
    Task  Save(T entity);
    Task Update(T entity);
    Task Delete(int id);
}