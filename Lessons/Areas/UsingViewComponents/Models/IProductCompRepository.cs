using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.UsingViewComponents.Models
{
    public interface IProductCompRepository
    {
        IEnumerable<ProductComp> Products { get; }
        void AddProduct(ProductComp newProduct);

    }
}
