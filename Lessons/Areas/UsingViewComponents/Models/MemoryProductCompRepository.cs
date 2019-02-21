using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.UsingViewComponents.Models
{
    public class MemoryProductCompRepository : IProductCompRepository
    {
        private List<ProductComp> products = new List<ProductComp> {
                 new ProductComp { Name = "Kayak", Price = 275M },
                 new ProductComp { Name = "Lifejacket", Price = 48.95M },
                 new ProductComp { Name = "Soccer ball", Price = 19.50M }
         };
        public IEnumerable<ProductComp> Products => products;

        public void AddProduct(ProductComp newProduct)
        {
            products.Add(newProduct);
        }
    }
}
