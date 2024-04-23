using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAlten.Domain;

namespace TestAlten.Services.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public List<Product> CreateProduct(Product product);
        public List<Product> UpdateProduct(int id, Product product);
        public List<Product> DeleteProducts(List<Product> produtcs);
        public List<Product> DeleteProduct(int id);
    }
}
