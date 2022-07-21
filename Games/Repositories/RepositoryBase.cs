using Games.DATA;
using Games.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        protected AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T objeto)
        {
            _context.Set<T>().Add(objeto);
            await _context.SaveChangesAsync();
            return objeto;
        }

        public async Task Delete(params object[] variavel)
        {
            var delete = await _context.Set<T>().FindAsync(variavel);
            _context.Set<T>().Remove(delete);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetId(params object[] variavel)
        {
            return await _context.Set<T>().FindAsync(variavel);
        }

        public async Task Update(T objeto)
        {
            _context.Entry(objeto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
