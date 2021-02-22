using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductsApiCrudOperation.Models;
using ProductsApiCrudOperation.ProductsData;

namespace ProductsApiCrudOperation.Controllers
{
    [EnableCors("ProductsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private  IProductsRepository _products;
        public ProductsController(IProductsRepository products)
        {
            _products = products;
        }

        [HttpGet]
        public IActionResult GetProductsList()
        {
            return Ok(_products.GetProducts());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _products.GetProduct(id);
            if(product != null)
            {
                return Ok(product);
            }
            return Ok( "Products with id:  " + id.ToString() + "  could not be found");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.GetProduct(id);
            if(product != null)
            {
               return Ok(_products.GetProducts());
            }
            var response = new { message = "The product with the id" + id.ToString() + "does not exists" };
            return NotFound(response);
        }

        [HttpPost]
        public IActionResult AddProduct( Product product )
        {
            if(product != null)
            {           
                return Ok(_products.AddProduct(product));
            }
            else
            {
                return BadRequest("Please enter the product to add");
            }
        }
        
        [HttpPut]
        [Route("{id}")]
        public IActionResult EditProduct(int id , Product product)
        {
            var product1 = _products.GetProduct(id);
            if (product1 != null)
            {
                product.prodId = id;
                return Ok(_products.EditProduct(product));
            }
            var response = new { message = "Could not find the product with id  " + id.ToString() + " !!" };
            return NotFound(response);
        }
    }
}