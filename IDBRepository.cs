using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpImplementation
{
    internal interface IDBRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllSync();
        Task<T> GetById(string id);
        Task Add(T Entity);
        Task Update(string id, T Entity);
        Task DeleteById(string id);
    }
}
