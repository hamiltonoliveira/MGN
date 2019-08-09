using System.Threading.Tasks;
using Applicationcore.Entities;
using Applicationcore.Services.IService;

namespace Applicationcore.Services.Service
{
    public class ServiceAdress : IServices<Adress>
    {
        private IRepository<Adress> _repository;
        public ServiceAdress(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public Task DeleteAsync(Adress entity)
        {
            return _repository.DeleteAsync(entity);
        }

        public Task<System.Collections.Generic.List<Adress>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Adress> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task InsertAsync(Adress entity)
        {
            return _repository.InsertAsync(entity);
        }

        public Task UpdateAsync(Adress entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public System.Collections.Generic.IEnumerable<Adress> Where(System.Linq.Expressions.Expression<System.Func<Adress, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
