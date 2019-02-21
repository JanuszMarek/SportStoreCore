using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lessons.Areas.CV.Models;
using Lessons.Areas.CV.Models.ViewModels;

namespace Lessons.Areas.CV.Controllers
{
    [Area("CV")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.PersonalInfo.FirstName = "Janusz";
            viewModel.PersonalInfo.LastName = "Marek";
            viewModel.PersonalInfo.Birthdate = DateTime.Parse("09-05-1992");
            viewModel.PersonalInfo.Email = "janusz.marek92@gmail.com";
            viewModel.PersonalInfo.GitHub = "https://github.com/JanuszMarek";
            viewModel.PersonalInfo.LinkedIn = "https://www.linkedin.com/in/janusz-marek/";
            viewModel.PersonalInfo.StreetNo = "ul. Odrowążów 93a/5";
            viewModel.PersonalInfo.ZipCode = "44-103 Gliwice";

            viewModel.Categories.Add(new Category
            {
                Name = "Wykształcenie",
                CategoryItems = new List<CategoryItem>()
                {
                    new CategoryItem
                    {
                        Title = "Politechnika Śląska w Gliwicach",
                        SubTitle = "Wydz. Automatyki Informatyki i Elektroniki",
                        Description = "Automatyka i Robotyka Magister (Mgr)",
                        PhotoUrl = "",
                        Years = "2016 – 2017"
                    },
                    new CategoryItem
                    {
                        Title = "Politechnika Śląska w Gliwicach",
                        SubTitle = "Wydz. Automatyki Informatyki i Elektroniki",
                        Description = "Automatyka i Robotyka Inżynier (Inż.)",
                        PhotoUrl = "",
                        Years = "2012 – 2016"
                    },
                }
            });



            return View();
        }
    }
}