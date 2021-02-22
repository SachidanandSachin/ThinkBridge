using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductsApiCrudOperation.Models
{
    public class Product
    {
        [Key]
        public int prodId { get; set; }
        [MaxLength(30)]
        public string prodType { get; set; }
        public int prodPrice { get; set; }
        [MaxLength(30)]
        public string prodManufacturer { get; set; }
        
        public int prodRating { get; set; }
        public int YearOfManuf { get; set; }
    }
}
