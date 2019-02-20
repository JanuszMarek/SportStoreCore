using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.DependencyInjection.Models
{
    public interface IModelStorage
    {
        //    This interface defines the behavior of a simple storage mechanism for  Product  objects

        IEnumerable<Product> Items { get; }
        Product this[string key] { get; set; }
        bool ContainsKey(string key);
        void RemoveItem(string key);
    }
}
