using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStoreCore.Models;
using SportsStoreCore.Models.ViewModels;

namespace SportsStoreCore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // public ViewResult List(int page = 1) => View(repository.Products.OrderBy(p=>p.ProductID).Skip((page-1)*PageSize).Take(PageSize));  
        public ViewResult List(string category, int page = 1)
        {
            var productsList = repository.Products;

            if (!String.IsNullOrEmpty(category))
            {
                productsList = productsList.Where(p => p.Category == null || p.Category == category);
            }

            return View(
                new ProductsListViewModel
                {
                    Products = productsList.OrderBy(p => p.ProductID)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = productsList.Count()
                    },
                    CurrentCategory = category
                });
        }

    }
}