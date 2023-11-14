using ImageTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTask.Core
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
        Task<List<T>> GetAllAsync();
        int Add(T entity);
    }
}
