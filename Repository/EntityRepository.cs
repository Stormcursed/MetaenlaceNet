using MetaenlaceNet.Entity;


namespace MetaenlaceNet.Repository
{
    public abstract class EntityRepository<T,C> : IRepository<T>
    where T : class
    where C : EntityContext
    {
        public readonly C _context;
        public EntityRepository(C _context) { 
        this._context = _context;
        }
        public T? DeleteEntity(long id)
        {
            T entity = _context.Set<T>().Find(keyValues: id);
            if (entity == null) { return null;}
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public ICollection<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public async Task<T> GetEntityById(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T InsertEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T UpdateEntity(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

    }
}
