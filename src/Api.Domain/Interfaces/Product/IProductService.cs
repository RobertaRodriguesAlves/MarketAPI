using System.Threading.Tasks;
using Api.Domain.DTO.Product;
using System.Collections.Generic;

namespace Api.Domain.Interfaces.Product
{
    public interface IProductService
    {
         Task<ProductDTOResult> Get(string name);
         Task<IEnumerable<ProductDTOResult>> GetAll();
         Task<bool> Post(ProductDTO product);
         Task<ProductDTOResult> Put(ProductDTO product);
         Task<bool> Delete(string name);
    }
}