using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lessons.Areas.CV.Models;
using Lessons.Areas.CV.Models.ViewModels;
using System.Web;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using jsreport.AspNetCore;
using jsreport.Types;

namespace Lessons.Areas.CV.Controllers
{
    [Area("CV")]
    public class HomeController : Controller
    {
        //[MiddlewareFilter(typeof(JsReportPipeline))]
        public IActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.PersonalInfo = new PersonalInfo();
            viewModel.PersonalInfo.FirstName = "Janusz";
            viewModel.PersonalInfo.LastName = "Marek";
            viewModel.PersonalInfo.Birthdate = DateTime.Parse("09-05-1992");
            viewModel.PersonalInfo.PhoneNo = "+48 5055543857";
            viewModel.PersonalInfo.Email = "janusz.marek92@gmail.com";
            viewModel.PersonalInfo.GitHub = "github.com/JanuszMarek";
            viewModel.PersonalInfo.LinkedIn = "linkedin.com/in/janusz-marek/";
            viewModel.PersonalInfo.StreetNo = "ul. Odrowążów 93a/5";
            viewModel.PersonalInfo.ZipCode = "44-103 Gliwice";
            viewModel.PersonalInfo.PhotoURL = "\\images\\Marek_fin2.jpg";

            viewModel.Categories = new List<Category>();
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
                        PhotoUrl = "\\images\\polsl.png",
                        Years = new[] { "2016 – 2017" }
                    },
                    new CategoryItem
                    {
                        Title = "Politechnika Śląska w Gliwicach",
                        SubTitle = "Wydz. Automatyki Informatyki i Elektroniki",
                        Description = "Automatyka i Robotyka Inżynier (Inż.)",
                        PhotoUrl = "\\images\\polsl.png",
                        Years = new[] {"2012 – 2016" }
                    },
                    new CategoryItem
                    {
                        Title = "Technikum nr 1 w Cieszynie ",
                        SubTitle = String.Empty,
                        Description = "Technik Informatyk",
                        PhotoUrl = "\\images\\szybin.png",
                        Years = new[] {"2008 – 2012" }
                    },
                }
            });

            viewModel.Categories.Add(new Category
            {
                Name = "Doświadczenie",
                CategoryItems = new List<CategoryItem>()
                {
                    new CategoryItem
                    {
                        Title = "Programista PLC",
                        SubTitle = "RW Swiss Automation Sp. z o.o. ",
                        Description = String.Empty,
                        PhotoUrl = "\\images\\swiss.png",
                        Years = new[] {"01.2017 – 12.2018" }
                    },
                    new CategoryItem
                    {
                        Title = "Stażysta Automatyk/Robotyk",
                        SubTitle = "AIUT Inc.",
                        Description = String.Empty,
                        PhotoUrl = "\\images\\aiut.png",
                        Years = new[] {"06.2015 – 09.2015 " }
                    },
                }
            });

            viewModel.Categories.Add(new Category
            {
                Name = "Projekty zawodowe",
                CategoryItems = new List<CategoryItem>()
                {
                    new CategoryItem
                    {
                        Title = "Mercedes-Benz BR167 M-klasa",
                        SubTitle = "Tuscaloosa, USA",
                        Description = String.Empty,
                        PhotoUrl = "\\images\\merc.png",
                        Years = new[] {"offline – 01.2017 – 08.2017","online – 08.2017 – 06.2018" }

                    },
                    new CategoryItem
                    {
                        Title = "Mercedes-Benz MFA2 A-klasa ",
                        SubTitle = "Kesckemet, HUN",
                        Description = String.Empty,
                        PhotoUrl = "\\images\\merc.png",
                        Years = new[] {"online – 08.2018 – 12.2018" }
                    },
                }
            });

            viewModel.Skills = new Dictionary<string, string[]>();
            viewModel.Skills["Framework"] = new[] { "ASP.NET MVC5", "ASP.NET Core 2.1" };
            viewModel.Skills["Technologie"] = new[] { "HTML/CSS", "JavaScript" };
            viewModel.Skills["Biblioteki"] = new[] { "Bootstrap", "JQuery" };
            viewModel.Skills["PLC"] = new[] { "STEP7", "TIA Portal" };
            viewModel.Skills["SCADA/HMI"] = new[] { "WinCC 8", "IFIX", "Wonderware InTouch"};
            viewModel.Skills["Falowniki"] = new[] { "Lenze" };
            viewModel.Skills["Pozostałe"] = new[] { "j. angielski – poziom (B2)" ,"prawo jazdy kat. B" };


            //HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);
            return View(viewModel);
        }
    }
}