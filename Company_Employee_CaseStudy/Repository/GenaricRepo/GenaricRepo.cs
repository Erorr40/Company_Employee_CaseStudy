using Company_Employee_CaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_Employee_CaseStudy.Repository.GenaricRepo
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _db;

        public GenaricRepo(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            _db.Remove(_db.Find(id));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Update(entity);
        }
    }
}
