using MetaenlaceNet.Entity;

namespace MetaenlaceNet.Repository
{
    public interface IRepository<T>
    {
        T InsertEntity(T entity);//C
        ICollection<T> GetAll();//R
        Task<T> GetEntityById(long id);
        T UpdateEntity(T entity);//U
        T? DeleteEntity(long id);//D
    }
}
