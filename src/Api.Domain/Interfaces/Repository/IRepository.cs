using Api.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Api.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> InsertAsync(T item);
        Task<IEnumerable<T>> SelectAsync();
    }
}