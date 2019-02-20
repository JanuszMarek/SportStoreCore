﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.DependencyInjection.Models
{
    //FakeRepo for lesson
    public class MemoryRepository : IRepository
    {
        /* without Storage
        private Dictionary<string, Product> products;

        public MemoryRepository()
        {
            products = new Dictionary<string, Product>();
            new List<Product> {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M }
            }.ForEach(p => AddProduct(p));

        }

        public Product this[string name] => products[name];

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product product) => products[product.Name] = product;

        public void DeleteProduct(Product product) => products.Remove(product.Name);
        */
        private string guid = Guid.NewGuid().ToString();
        private IModelStorage storage;
        public MemoryRepository(IModelStorage modelStore)
        {
            storage = modelStore;
            new List<Product> {
                 new Product { Name = "Kayak", Price = 275M },
                 new Product { Name = "Lifejacket", Price = 48.95M },
                 new Product { Name = "Soccer ball", Price = 19.50M }
             }.ForEach(p => AddProduct(p));
        }
        public IEnumerable<Product> Products => storage.Items;
        public Product this[string name] => storage[name];
        public void AddProduct(Product product) => storage[product.Name] = product;
        public void DeleteProduct(Product product) => storage.RemoveItem(product.Name);

        public override string ToString()
        {
            return guid;
        }

    }
}
