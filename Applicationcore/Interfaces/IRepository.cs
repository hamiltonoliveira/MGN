using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Applicationcore.Services.IService
{
    public interface IRepository<Tentity> where Tentity : class
    {
        Task<Tentity> GetByIdAsync(int id);
        Task<List<Tentity>> GetAllAsync();
        Task InsertAsync(Tentity entity);
        Task UpdateAsync(Tentity entity);
        Task DeleteAsync(Tentity entity);
        IEnumerable<Tentity> Where(Expression<Func<Tentity, bool>> expression);
    }
}
