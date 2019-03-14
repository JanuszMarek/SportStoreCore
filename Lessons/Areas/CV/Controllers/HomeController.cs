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


namespace Lessons.Areas.CV.Controllers
{
    [Area("CV")]
    public class HomeController : Controller
    {
        public IActionResult Index(bool pdf = false)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.PersonalInfo = new PersonalInfo();
            viewModel.PersonalInfo.FirstName = "Janusz";
            viewModel.PersonalInfo.LastName = "Marek";
            viewModel.PersonalInfo.Birthdate = DateTime.Parse("09-05-1992");
            viewModel.PersonalInfo.PhoneNo = "(+48) 505-543-857";
            viewModel.PersonalInfo.Email = "janusz.marek92@gmail.com";
            viewModel.PersonalInfo.GitHub = "github.com/JanuszMarek";
            viewModel.PersonalInfo.LinkedIn = "linkedin.com/in/janusz-marek";
            viewModel.PersonalInfo.StreetNo = "Gliwice";
            //viewModel.PersonalInfo.ZipCode = "44-103 Gliwice";
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
                        Years = new[] { "2016 – 2017" },
                        Responsibility = new[] {""},

                    },
                    new CategoryItem
                    {
                        Title = "Politechnika Śląska w Gliwicach",
                        SubTitle = "Wydz. Automatyki Informatyki i Elektroniki",
                        Description = "Automatyka i Robotyka Inżynier (Inż.)",
                        PhotoUrl = "\\images\\polsl.png",
                        Years = new[] {"2012 – 2016" },
                        Responsibility = new[] {""},
                    },
                    /*
                    new CategoryItem
                    {
                        Title = "Technikum nr 1 w Cieszynie ",
                        SubTitle = String.Empty,
                        Description = "Technik Informatyk",
                        PhotoUrl = "\\images\\szybin.png",
                        Years = new[] {"2008 – 2012" },
                        Responsibility = new[] {""},
                    },
                    */
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
                        Years = new[] {"01.2017 – 12.2018" },
                        Responsibility = new[] 
                        {
                            "tworzenie programu PLC na podstawie e-planu i wytycznych klienta",
                            "tworzenie programu safety w sterowniku na podstawie wytycznych klienta",
                            "tworzenie wizualizacji panelów operatorskich",
                            "wirtualne uruchomienie tworzonej linii oraz prezentacja klientowi",
                            "konfiguracja falowników",
                            "konfiguracja urządzeń safety",
                            "konfiguracja kamer do QR code i czytników RFID",
                            "szkolenie personelu"
                        },
                    },
                    new CategoryItem
                    {
                        Title = "Stażysta Automatyk/Robotyk",
                        SubTitle = "AIUT Inc.",
                        Description = String.Empty,
                        PhotoUrl = "\\images\\aiut.png",
                        Years = new[] {"06.2015 – 09.2015 " },
                        Responsibility = new[]
                        {
                            "tworzenie programu PLC na podstawie e-planu i wytycznych klienta",
                            "tworzenie wizualizacji panelów operatorskich",
                            "konfiguracja i oprogramowanie przemysłowych kamer wizji komputerowej"
                        },
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
                        Years = new[] {"offline – 01.2017 – 08.2017","online – 08.2017 – 06.2018" },
                        Responsibility = new[] {""},

                    },
                    new CategoryItem
                    {
                        Title = "Mercedes-Benz MFA2 A-klasa ",
                        SubTitle = "Kesckemet, HUN",
                        Description = String.Empty,
                        PhotoUrl = "\\images\\merc.png",
                        Years = new[] {"online – 08.2018 – 12.2018" },
                        Responsibility = new[] {""},
                    },
                }
            });

            viewModel.Categories.Add(new Category
            {
                Name = "Projekty dodatkowe",
                CategoryItems = new List<CategoryItem>()
                {
                    new CategoryItem
                    {
                        Title = "FilmoweJanusze",
                        SubTitle = "ASP.NET MVC5",
                        Description = "Serwis filmowy, w którym użytkownicy mogą dodawać, edytować jaki i oceniać filmy, aktorów, reżyserów",
                        PhotoUrl = "\\images\\mvc5.jpg",
                        Years = new[] {"" },
                        Responsibility = new[] {""},

                    },
                    new CategoryItem
                    {
                        Title = "SportStoreCore",
                        SubTitle = "ASP.NET Core 2.1",
                        Description = "Kompedium wiedzy zdobytej z książki, zawiera prostą aplikację sklepu internetowego",
                        PhotoUrl = "\\images\\core.png",
                        Years = new[] {"" },
                        Responsibility = new[] {""},
                    },
                    new CategoryItem
                    {
                        Title = "UsingAPIs",
                        SubTitle = "ASP.NET Core 2.1",
                        Description = "Aplikacja pobierająca i wyświetlająca informacje z zewnętrznych API",
                        PhotoUrl = "\\images\\core.png",
                        Years = new[] {"" },
                        Responsibility = new[] {""},
                    },
                }
            });

            viewModel.Skills = new Dictionary<string, string[]>();
            viewModel.Skills["Framework"] = new[] { "ASP.NET MVC 5 (C#)", "ASP.NET Core 2.1 (C#)", "Entity Framework (Code First)" };
            viewModel.Skills["Technologie"] = new[] { "HTML/CSS", "JavaScript" };
            viewModel.Skills["Biblioteki"] = new[] { "Bootstrap", "LINQ", "JQuery" };
            viewModel.Skills["PLC"] = new[] { "Siemens S7", "STEP7" ,"TIA Portal"};
            viewModel.Skills["SCADA/HMI"] = new[] { "WinCC 8", "IFIX", "Wonderware InTouch"};
            
            viewModel.Skills["Pozostałe"] = new[] { "j. angielski – poziom B2" ,"prawo jazdy kat. B" };
            //viewModel.Skills["Falowniki"] = new[] { "Lenze" };

            return View(viewModel);
        }


    }
}