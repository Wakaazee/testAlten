namespace TestAlten.DataAccess.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TestAlten.Domain;

    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public List<Product> CreateProduct(Product product);
        public List<Product> UpdateProduct(int id, Product product);
        public List<Product> DeleteProduct(int id);
        public List<Product> DeleteProducts(List<Product> produtcs);
    }
}
