namespace TestAlten.Services.Services
{
    using System.Collections.Generic;
    using TestAlten.DataAccess.Interfaces;
    using TestAlten.Domain;
    using TestAlten.Services.Interfaces;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public List<Product> UpdateProduct(int id, Product product)
        {
            return _productRepository.UpdateProduct(id, product);
        }

        public List<Product> DeleteProducts(List<Product> produtcs)
        {
            return _productRepository.DeleteProducts(produtcs);
        }

        public List<Product> DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}
