using ProductsApiCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ProductsApiCrudOperation.ProductsData
{
    public class ProductRepository : IProductsRepository
    {
        private  ProductsDbContext _productsDbContext;
        public ProductRepository(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }
        public IEnumerable<Product> AddProduct(Product p)
        {
            _productsDbContext.Products.Add(p);
            _productsDbContext.SaveChanges();
            return _productsDbContext.Products;
        }

        public string DeleteProduct(int id)
        {
            var product = GetProduct(id);
            _productsDbContext.Products.Remove(product);
            _productsDbContext.SaveChanges();
            return "Product deleted !!";
        }

        public Product EditProduct(Product product)
        {
            var existingprod = GetProduct(product.prodId);
            _productsDbContext.Products.Remove(existingprod);
            _productsDbContext.Products.Add(product);
            _productsDbContext.SaveChanges();
            return product;

        }

        public Product GetProduct(int id)
        {
            Product product = _productsDbContext.Products.SingleOrDefault(x => x.prodId == id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productsDbContext.Products.ToList();
        }
    }
}
