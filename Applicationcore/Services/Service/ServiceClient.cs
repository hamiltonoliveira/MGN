using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Applicationcore.Entities;
using Applicationcore.Services.IService;

namespace Applicationcore.Services.Service
{
    public class ServiceClient: IServices<Client>
    {
        private IRepository<Client> _repository;
        public ServiceClient(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public Task DeleteAsync(Client entity)
        {
            return _repository.DeleteAsync(entity);
        }

        public Task<List<Client>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Client> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task InsertAsync(Client entity)
        {
            return _repository.InsertAsync(entity);
        }

        public Task UpdateAsync(Client entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public IEnumerable<Client> Where(Expression<Func<Client, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
