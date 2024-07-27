using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();

        Task<T> Add(T entity);
        Task Update(T Entity);

        Task Delete(T Entity);

        
    }
}
