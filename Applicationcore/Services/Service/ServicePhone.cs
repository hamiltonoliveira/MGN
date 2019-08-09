using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Applicationcore.Entities;
using Applicationcore.Services.IService;

namespace Applicationcore.Services.Service
{
    public class ServicePhone : IServices<Phone>
    {
        private IRepository<Phone> _repository;
        public ServicePhone(IRepository<Phone> repository)
        {
            _repository = repository;
        }

        public Task DeleteAsync(Phone entity)
        {
            return _repository.DeleteAsync(entity);
        }

        public Task<List<Phone>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Phone> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task InsertAsync(Phone entity)
        {
            return _repository.InsertAsync(entity);
        }

        public Task UpdateAsync(Phone entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public IEnumerable<Phone> Where(Expression<Func<Phone, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
