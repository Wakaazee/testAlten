namespace TestAlten.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using TestAlten.DataAccess.Interfaces;
    using TestAlten.Domain;
    using Newtonsoft.Json;

    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository(string jsonFilePath)
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            var productsData = JsonConvert.DeserializeObject<ProductsData>(jsonData);
            _products = productsData.Data;
        }

        public List<Product> GetAllProducts()
        {
            return this._products;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> CreateProduct(Product product)
        {
            _products.Add(product);
            return _products;
        }

        public List<Product> UpdateProduct(int id, Product product)
        {
            Product updatedProduct = _products.FirstOrDefault(p => p.Id == id);
            if (updatedProduct != null)
            {
                updatedProduct.Name = product.Name;
                updatedProduct.Description = product.Description;
                updatedProduct.Price = product.Price;

                return _products;
            }
            return null;
        }

        public List<Product> DeleteProduct(int id)
        {
            Product deletedProduct = _products.FirstOrDefault(p => p.Id == id);
            if (deletedProduct != null)
            {
                _products.Remove(deletedProduct);
                return _products;
            }
            return null;
        }

        public List<Product> DeleteProducts(List<Product> products)
        {
            return (List<Product>)_products.Except(products);
        }
    }
}
