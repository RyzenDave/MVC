using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain;

namespace VROS.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
      Task<T> GetByIdAsync(int id);
      Task<IEnumerable<T>> GetAllAsync();
      Task AddAsync(T entity);
      void Update(T entity);
      void Delete(T entity);
    }
}
