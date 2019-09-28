using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int productId);
        Task InsertProduct(Product product);
        Task DeleteProduct(int productId);
        Task UpdateProduct(Product product);
        Task Save();
    }
}
