using Contact.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByUUIdAsync(Guid id);
        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
