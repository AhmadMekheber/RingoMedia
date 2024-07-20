using Departments.Migrations.Data;
using EFCore.BulkExtensions;

namespace Departments.DAL.BaseRepository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;

        public EFRepository(DataContext context)
        {
            _context = context;
        }
        
        protected DataContext DbContext => _context;

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void BulkSaveChanges()
        {
            _context.BulkSaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}