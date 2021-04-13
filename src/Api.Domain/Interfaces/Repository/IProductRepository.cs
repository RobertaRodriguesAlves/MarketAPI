using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Repository
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
         Task<ProductEntity> SelectByName(string name);
         Task<bool> DeleteByName(string name);
         Task<ProductEntity> Update(ProductEntity product);
         Task<bool> Insert(ProductEntity product);
    }
}