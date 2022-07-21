using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetId(params object[] variavel);
        Task<T> Add(T objeto);
        Task Update(T objeto);
        Task Delete (params object[] variavel);
    }
}
