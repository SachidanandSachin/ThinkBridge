using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsApiCrudOperation.Models;

namespace ProductsApiCrudOperation.ProductsData
{
   public  interface IProductsRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        Product EditProduct(Product product);
        string DeleteProduct(int id);
        IEnumerable<Product> AddProduct(Product p);
    }
}
