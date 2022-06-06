using Lessons.Areas.CV.Models;
using Lessons.Areas.CV.Models.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace Lessons.Areas.CV.Controllers
{
    [Area("CV")]
    public class HomeController : Controller
    {
        public IActionResult Index(string person)
        {
            ViewModel janusz = new ViewModel()
            {
                PersonalInfo = new PersonalInfo()
                {
                    FirstName = "Janusz",
                    LastName = "Marek",
                    Birthdate = DateTime.Parse("09-05-1992"),
                    PhoneNo = "(+48) 505-543-857",
                    Email = "janusz.marek92@gmail.com",
                    GitHub = "github.com/JanuszMarek",
                    LinkedIn = "linkedin.com/in/janusz-marek",
                    StreetNo = "Gliwice",
                    //ZipCode = "44-103 Gliwice",
                    PhotoURL = "\\images\\Janusz3.jpg",
                },
                Categories = new List<Category>()
                {
                    new Category()
                    {
                        Name = "Wykształcenie",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "Politechnika Śląska w Gliwicach",
                                "Wydz. Automatyki Informatyki <br>i Elektroniki",
                                "Magister Automatyk i Robotyk",
                                "\\images\\polsl.png",
                                new[] { "2016 – 2017" },
                                new[] {""}
                            ),
                            new CategoryItem
                            (
                                "Politechnika Śląska w Gliwicach",
                                "Wydz. Automatyki Informatyki <br>i Elektroniki",
                                "Inżynier Automatyk i Robotyk",
                                "\\images\\polsl.png",
                                new[] {"2012 – 2016" },
                                new[] {""}
                            ),

                            new CategoryItem
                            (
                                "Technikum nr 1 w Cieszynie ",
                                String.Empty,
                                "Technik Informatyk",
                                "\\images\\szybin.png",
                                new[] {"2008 – 2012" },
                                new[] {""}
                            )

                        }
                    },
                    new Category()
                    {
                        Name = "Doświadczenie",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "Fullstack Software Developer",
                                "KLDiscovery Ontrack Poland",
                                String.Empty,
                                "\\images\\kld.jpg",
                                new[] {"12.2019 – obecnie"},
                                new[]
                                {
                                   "tworzenie aplikacji webowych (REST Web Api) w .Net Core 3.1/.Net 5",
                                   "tworzenie aplikacji frontendowych w Angular 2+ (głównie Angular 9/11)",
                                   "mapowanie obiektowo-relacyjne przy użyciu Entity Framework",
                                   "baza danych MS SQL tworzona metodyką Code First (migracje)",
                                   "hostowanie i wykorzystanie technologii chmurowych MS Azure",
                                   "edycja i tworzenie infrastruktury, pipelines i realeases w Azure DevOps",
                                }
                            ),
                            new CategoryItem
                            (
                                "Junior .NET Developer",
                                "FIS-SST Sp. z o.o.",
                                String.Empty,
                                "\\images\\fiss.png",
                                new[] {"04.2019 – 12.2019"},
                                new[]
                                {
                                    "naprawa zgłaszanych błędów w programie (JIRA)",
                                    "naprawa problemów z danymi (skrypty Transact-SQL)",
                                    "dodawanie nowych funkcjonalności",
                                    "utrzymanie aplikacji, bazy danych, serwisów, serwerów (IIS)",
                                    "modyfikacje automatycznych wdrożeń (skrypty PowerShell, tworzenie nowych projektów) w Octopus Deploy",
                                    "tworzenie paczek w TeamCity",
                                    "tworzenie nowych testów automatycznych (Selenium WebDriver)",
                                }
                            ),
                            new CategoryItem
                            (
                                "Programista PLC",
                                "RW Swiss Automation Sp. z o.o. ",
                                String.Empty,
                                "\\images\\swiss.png",
                                new[] {"01.2017 – 12.2018"},
                                new[]
                                {
                                    "tworzenie programu PLC na podstawie e-planu <br>i wytycznych klienta",
                                    "tworzenie programu safety w sterowniku na podstawie wytycznych klienta",
                                    "tworzenie wizualizacji panelów operatorskich",
                                    "wirtualne uruchomienie tworzonej linii oraz prezentacja klientowi",
                                    "konfiguracja falowników",
                                    "konfiguracja urządzeń safety",
                                    "konfiguracja kamer do QR code i czytników RFID",
                                    "szkolenie personelu"
                                }
                            ),
                            new CategoryItem
                            (
                                "Stażysta Automatyk/Robotyk",
                                "AIUT Inc.",
                                String.Empty,
                                "\\images\\aiut.png",
                                new[] {"06.2015 – 09.2015"},
                                new[]
                                {
                                    "tworzenie programu PLC na podstawie e-planu i wytycznych klienta",
                                    "tworzenie wizualizacji panelów operatorskich",
                                    "konfiguracja i oprogramowanie przemysłowych kamer wizji komputerowej"
                                }
                            ),
                        }
                    },
                    new Category
                    {
                        Name = "Projekty zawodowe",
                        CategoryItems = new List<CategoryItem>()
                        {
                            //new CategoryItem
                            //{
                            //    Title = "Mercedes-Benz BR167 M-klasa",
                            //    SubTitle = "Tuscaloosa, USA",
                            //    Description = String.Empty,
                            //    PhotoUrl = "\\images\\merc.png",
                            //    Years = new[] {"offline – 01.2017 – 08.2017","online – 08.2017 – 06.2018" },
                            //    Responsibility = new[] {""},

                            //},
                            //new CategoryItem
                            //{
                            //    Title = "Mercedes-Benz MFA2 A-klasa ",
                            //    SubTitle = "Kesckemet, HUN",
                            //    Description = String.Empty,
                            //    PhotoUrl = "\\images\\merc.png",
                            //    Years = new[] {"online – 08.2018 – 12.2018" },
                            //    Responsibility = new[] {""},
                            //},
                            new CategoryItem
                            (
                                "Aplikacja wymiany plików z klientami firmy",
                                string.Empty,
                                "Aplikacja dla klientów firmy:",
                                "\\images\\core&angular.png",
                                new[] {""},
                                new[] { ".Net 5 + Angular 11",
                                "aplikacja webowa hostowana w Azure wraz z Azure Functions, logowaniem do AppInsights,",
                                "przechowywaniem i przenoszeniem plików pomiędzy różnymi Azure Storages, autoryzacja przy użyciu Azure B2C",
                                "frontend tworzony w Angular 9 wraz z użyciem biblioteki kontrolek NgPrime"}
                            ),
                            new CategoryItem
                            (
                                "Aplikacja organizacji pracy i zadań w KLDiscovery",
                                string.Empty,
                                "Projekt wewnątrzny:",
                                "\\images\\core&angular.png",
                                new[] {""},
                                new[] { ".Net Core 3.1 + Angular 9",
                                "aplikacja webowa hostowana w Azure wraz z użyciem WebJobs, Azure Functions, logowaniem do AppInsights,",
                                "przechowywaniem plików w Azure Storage, autoryzacja przy użyciu Azure AD",
                                "frontend tworzony w Angular 9 wraz z użyciem biblioteki kontrolek NgPrime"}
                            ),
                            new CategoryItem
                            (
                                "Projekt komercyjny w FIS-SST",
                                string.Empty,
                                "Projekt dla klienta w skład którego wchodzą:",
                                "\\images\\knockout&mvc.png",
                                new[] {""},
                                new[] { "aplikacja ASP.NET MVC z wykorzystaniem Knockout JS",
                                "serwisy Windows do przetwarzania plików otrzymanych od klienta/SAPa oraz czyszczenia bazy danych",
                                "aplikacje desktopowe (m.in aplikacja do testów automatycznych)"}
                            ),
                            new CategoryItem
                            (
                                "Projekt wewnętrzny w FIS-SST",
                                string.Empty,
                                "Projekt wewnętrzny firmy do zarządzania zasobami:",
                                "\\images\\core&angular.png",
                                new[] {""},
                                new[] { "backend REST API ASP.NET Core",
                                "frontend Angular 6 z wykorzystaniem biblioteki PrimeNG"}
                            ),
                            new CategoryItem
                            (
                                "Projekty własne",
                                string.Empty,
                                "Własne projekty stworzone na potrzeby nauki można odnaleść na moim profilu GitHub. Link podany <br>w nagłówku dokumentu.",
                                "\\images\\git.png",
                                new[] {""},
                                new[] { ""}
                            ),
                        }
                    }
                },
                Skills = new Dictionary<string, string[]>()
                {
                    { "Techniczne", new[] { "<b>ASP.NET Core 3.1</b>", "<b>ASP.NET 5</b>", "ASP.NET MVC", "Entity Framework","MS Azure","Azure DevOps", "Transact-SQL", "MS SQL", "Git", "<b>Angular 2+</b>", "TypeScript", "HTML", "CSS" } },
                    { "Pozostałe", new[] { "j. angielski – poziom B2", "prawo jazdy kat. B" }}
                },
                Color = "#1561bf"
            };

            ViewModel januszENG = new ViewModel()
            {
                PersonalInfo = new PersonalInfo()
                {
                    FirstName = "Janusz",
                    LastName = "Marek",
                    Birthdate = DateTime.Parse("09-05-1992"),
                    PhoneNo = "(+48) 505-543-857",
                    Email = "janusz.marek92@gmail.com",
                    GitHub = "github.com/JanuszMarek",
                    LinkedIn = "linkedin.com/in/janusz-marek",
                    StreetNo = "Żory",
                    PhotoURL = "\\images\\Janusz3.jpg",
                },
                Categories = new List<Category>()
                {
                    new Category()
                    {
                        Name = "Education",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "Silesian University of Technology",
                                "Faculty of Automatic Control, Electronics and Computer Science",
                                "Master’s Degree of  Automatic Control and Robotics",
                                "\\images\\polsl.png",
                                new[] { "2016 – 2017" },
                                new[] {""}
                            ),
                            new CategoryItem
                            (
                                "Silesian University of Technology",
                                "Faculty of Automatic Control, Electronics and Computer Science",
                                "University Degree of Automatic Control and Robotics",
                                "\\images\\polsl.png",
                                new[] {"2012 – 2016" },
                                new[] {""}
                            ),

                            new CategoryItem
                            (
                                "Technical College no. 1 in Cieszyn",
                                String.Empty,
                                "High School degree of Computer Science",
                                "\\images\\szybin.png",
                                new[] {"2008 – 2012" },
                                new[] {""}
                            )

                        }
                    },
                    new Category()
                    {
                        Name = "Professional Experience",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "Fullstack Software Developer",
                                "KLDiscovery Ontrack Poland",
                                String.Empty,
                                "\\images\\kld.jpg",
                                new[] {"12.2019 – now"},
                                new[]
                                {
                                   "backend web application (REST Web Api) in .Net Core 3.1/.Net 5",
                                   "frontend web application in Angular 2+ (mostly Angular 9/11)",
                                   "ORM - Entity Framework",
                                   "MS SQL Database using Code First",
                                   "cloud hosting using MS Azure",
                                   "infrastructure, pipeline and realeases using Azure DevOps",
                                   "unit tests (xUnit)"
                                }
                            ),
                            new CategoryItem
                            (
                                "Junior .NET Developer",
                                "FIS-SST Sp. z o.o.",
                                String.Empty,
                                "\\images\\fiss.png",
                                new[] {"04.2019 – 12.2019"},
                                new[]
                                {
                                    "bug fixing (JIRA)",
                                    "data fixing (using Transact-SQL scripts)",
                                    "new features",
                                    "release pipelines in Octopus Deploy and TeamCity",
                                    "automation tests (Selenium WebDriver)",
                                }
                            ),
                            new CategoryItem
                            (
                                "Automation Control - PLC Programmer",
                                "RW Swiss Automation Sp. z o.o. ",
                                String.Empty,
                                "\\images\\swiss.png",
                                new[] {"01.2017 – 12.2018"},
                                new[]
                                {
                                    "PLC programming",
                                    "creating SCADA systems",
                                    "VIBN  - Virtual Commissioning",
                                    "Drivers, Safety Devices, RFID, QR Scanners configuration",
                                }
                            ),
                            //new CategoryItem
                            //(
                            //    "Stażysta Automatyk/Robotyk",
                            //    "AIUT Inc.",
                            //    String.Empty,
                            //    "\\images\\aiut.png",
                            //    new[] {"06.2015 – 09.2015"},
                            //    new[]
                            //    {
                            //        "PLC programming",
                            //        "creating SCADA systems",
                            //        "industrial vision cameras"
                            //    }
                            //),
                        }
                    },
                    new Category
                    {
                        Name = "Projects",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "File Exchange Web App",
                                string.Empty,
                                "Web App for Company Clients:",
                                "\\images\\core&angular.png",
                                new[] {""},
                                new[] { ".Net 5 + Angular 11",
                                "hosted in Azure with Azure Functions, AppInsights, Azure Storage",
                                "web app to share files with clients, authorization using Azure B2C",
                                "frontend made in Angular 11 with PrimeNg lib"}
                            ),
                            new CategoryItem
                            (
                                "Work Organization Web App",
                                string.Empty,
                                "Web App for Internal Employees:",
                                "\\images\\core&angular.png",
                                new[] {""},
                                new[] { ".Net Core 3.1 + Angular 9",
                                "hosted in Azure with Azure Functions, WebJobs, AppInsights, Azure Storage",
                                "web app for internal work management, authorization using Azure AD",
                                "frontend made in Angular 9 with PrimeNg lib"}
                            ),
                            new CategoryItem
                            (
                                "Own Projects",
                                string.Empty,
                                "My own projects could be found on GitHub. Created for learning purpose. Link at the top.",
                                "\\images\\git.png",
                                new[] {""},
                                new[] { ""}
                            ),
                        }
                    }
                },
                Skills = new Dictionary<string, string[]>()
                {
                    { "Technologies", new[] { "<b>ASP.NET Core 3.1</b>", "<b>ASP.NET 5</b>", "ASP.NET MVC", "Entity Framework","MS Azure","Azure DevOps", "Transact-SQL", "MS SQL", "Git", "<b>Angular 2+</b>", "TypeScript", "HTML", "CSS" } },
                    { "Languages", new[] { "English - B2" } },
                    { "Others", new[] { "Driving license. B" } }
                },
                IsEnglish = true,
                Color = "#1561bf"
            };

            ViewModel basia = new ViewModel()
            {
                PersonalInfo = new PersonalInfo()
                {
                    FirstName = "Barbara",
                    LastName = "Marek",
                    Birthdate = DateTime.Parse("02-07-1994"),
                    PhoneNo = "(+48) 691-033-721",
                    Email = "barbara.broy94@gmail.com",
                    GitHub = "",
                    LinkedIn = "",
                    StreetNo = "Gliwice, Żory",
                    //ZipCode = "",
                    PhotoURL = "\\images\\Basia2.jpg",
                },
                Categories = new List<Category>()
                {
                    new Category()
                    {
                        Name = "Wykształcenie",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "Politechnika Śląska w Gliwicach",
                                "Wydz. Mechaniczny Technologiczny",
                                "Kierunek: Zarządzanie i Inżynieria Produkcji <br/> <br/>" +
                                "Specjalizacja: Organizacja Produkcji - studia magisterskie",
                                "\\images\\logoMT_word.png",
                                new[] { "2017 - 2018" },
                                new[] {""}
                            ),
                            new CategoryItem
                            (
                                "Politechnika Śląska w Gliwicach",
                                "Wydz. Organizacji i Zarządzania",
                                "Kierunek: Logistyka <br/> <br/>" + 
                                "Specjalizacja: Zarządzanie Łańcuchem Dostaw - studia inżynierskie",
                                "\\images\\LogoWOiZ.png",
                                new[] {"2013 – 2017" },
                                new[] {""}
                            ),
                            
                            new CategoryItem()
                            {
                                Title = new HtmlString("I Liceum Ogólnokształcące <br/>im. Karola Miarki w Żorach"),
                                SubTitle = new HtmlString("Profil matematyczno-fizyczny"),
                                Description = new HtmlString("Wykształcenie średnie"),
                                PhotoUrl = "\\images\\Miarka.jpg",
                                Years = new[] {"2010 – 2013" },
                                Responsibility = new[] {""},
                            },
                        }
                    },
                    new Category()
                    {
                        Name = "Doświadczenie",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "Asystentka Inżyniera Procesu",
                                "Johnson Matthey Battery Systems <br/>Sp. z o.o. w Gliwicach",
                                String.Empty,
                                "\\images\\JMBS.jpg",
                                new[] {"08.2018 – 09.2019"},
                                new[]
                                {
                                    "Wspieranie inżynierów procesu w ich codziennych obowiązkach",
                                    "Balansowanie linii produkcyjnych",
                                    "Wprowadzanie usprawnień na liniach produkcyjnych",
                                    "Czynny udział w wewnętrznym projekcie Six Sigma",
                                    "Tworzenie instrukcji stanowiskowych",
                                    "Wspieranie działu Zakupów - kontakt z dostawcami, tworzenie bazy danych dostawców",
                                    "Praca w programach MS Office i systemie SAP",
                                }
                            ),
                            new CategoryItem
                            (
                                "Stażysta w Dziale Logistyki",
                                "Kirchhoff Polska Sp. z o.o. ",
                                String.Empty,
                                "\\images\\kirchhoff.png",
                                new[] {"08.2016 – 10.2016"},
                                new[]
                                {
                                    "Wspieranie działu Logistyki w codziennych obowiązkach",
                                    "Sprawdzanie stanów magazynowych i uzupełnianie raportów",
                                    "Wprowadzanie danych do systemu SAP",
                                    "Wspieranie działu Zakupów w tworzeniu baz danych"
                                }
                            ),
                           
                        }
                    },
                    new Category
                    {
                        Name = "Organizacje",
                        CategoryItems = new List<CategoryItem>()
                            {
                                new CategoryItem
                                (
                                    "Europejskie Koło Logistyczne FENIKS",
                                    string.Empty,
                                    "Politechnika Śląska",
                                    "\\images\\Feniks.png",
                                    new[] {"11.2013 - 01.2017"},
                                    new[] { ""}
                                ),
                        }
                    },
                    new Category
                    {
                        Name = "Kursy, szkolenia, warsztaty",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "<b>Certyfikat: ISTQB poziom podstawowy</b>",
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                new[] {"13.01.2021"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Szkolenie: Dyrektywa RoHS, powiązanie z CE, elementy REACH oraz analiza wyrobów",
                                string.Empty,
                                "KONSIGLIO",
                                string.Empty,
                                new[] {"06.2019"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Kurs Excela na Politechnice Śląskiej",
                                "(tabele przestawne, funkcja wyszukaj pionowo)",
                                "evenea",
                                string.Empty,
                                new[] {"02.2018"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Warsztaty z Lean Management",
                                string.Empty,
                                "SKN Lean Team",
                                string.Empty,
                                new[] {"04.2017"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Warsztaty: W jaki sposób sprostać wymaganiom klienta w branży motoryzacyjnej oraz uniknąć reklamacji?",
                                string.Empty,
                                "Saint Gobain",
                                string.Empty,
                                new[] {"04.2017"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Warsztaty: Lean Management",
                                string.Empty,
                                "FM Logistics",
                                string.Empty,
                                new[] {"01.2017"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Warsztaty: Zarządzanie konfliktem i budowanie współpracy",
                                string.Empty,
                                "EDF",
                                string.Empty,
                                new[] {"04.2015"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Znaczenie logistyki w sukcesie marki Snickers",
                                "Od pomysłu do realizacji - wyzwania logistyczne związane z wykorzystywaniem okazji rynkowych",
                                "Akademia Wiedzy Praktycznej MARS",
                                string.Empty,
                                new[] {"12.2013"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Konferencje logistyczne",
                                string.Empty,
                                "Politechnika Śląska (EKL Feniks), Politechnika Poznańska",
                                string.Empty,
                                new[] {"2013-2017"},
                                new[] { ""}
                            ),
                        }
                    },
                },
                Skills = new Dictionary<string, string[]>()
                {
                    { "Technologie", new [] { "SQL/T-SQL", "HTML", "CSS", "GIT", } },
                    { "Programy", new[] { "MS SQL Server Management Studio", "Postman", "Swagger", "MS Office", "MS Visio", "MS Project", "SAP", "NX" } },
                    { "Języki", new[] { "j. angielski – dobry (B2)", "j. niemiecki - podstawowy (A1)" }},
                    { "Umiejętności miękkie", new[] { "umiejętność pracy w grupie", "dobra organizacja pracy własnej", "sumienność, dokładność" }},
                    { "Pozostałe", new[] { "prawo jazdy kat. B" }},
                },
                Color = "#2c7d49",
            };

            ViewModel basiaENG = new ViewModel()
            {
                PersonalInfo = new PersonalInfo()
                {
                    FirstName = "Barbara",
                    LastName = "Marek",
                    Birthdate = DateTime.Parse("02-07-1994"),
                    PhoneNo = "(+48) 691-033-721",
                    Email = "barbara.broy94@gmail.com",
                    GitHub = "",
                    LinkedIn = "",
                    StreetNo = "Gliwice",
                    //ZipCode = "",
                    PhotoURL = "\\images\\Basia2.jpg",
                },
                Categories = new List<Category>()
                {
                    new Category()
                    {
                        Name = "Education",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "Silesian University of Technology",
                                "Faculty of Mechanical Engineering",
                                "Branch of studies: Management and Production Engineering <br/> <br/>" +
                                "Specialisation: Production organisation - master degree",
                                "\\images\\logoMT_word.png",
                                new[] { "2017 - 2018" },
                                new[] {""}
                            ),
                            new CategoryItem
                            (
                                "Silesian University of Technology",
                                "Faculty of Organization and Management",
                                "Branch of studies: Logistics <br/> <br/>" +
                                "Specialisation: Supply chain management - engineer degree",
                                "\\images\\LogoWOiZ.png",
                                new[] {"2013 – 2017" },
                                new[] {""}
                            ),

                            //new CategoryItem()
                            //{
                            //    Title = new HtmlString("Karol's Miarka 1st High School in Żory <br/>"),
                            //    SubTitle = new HtmlString("Math-physic profile"),
                            //    Description = new HtmlString("secondary education"),
                            //    PhotoUrl = "\\images\\Miarka.jpg",
                            //    Years = new[] {"2010 – 2013" },
                            //    Responsibility = new[] {""},
                            //},
                        }
                    },
                    new Category()
                    {
                        Name = "Experience",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem
                            (
                                "Process engineer assistant",
                                "Johnson Matthey Battery Systems <br/>Sp. z o.o. in Gliwice",
                                String.Empty,
                                "\\images\\JMBS.jpg",
                                new[] {"08.2018 – 09.2019"},
                                new[]
                                {
                                    "Supporting process engineers in their daily duties",
                                    "Balancing production lines",
                                    "Introducing improvements on production lines",
                                    "Active participation in the internal Six Sigma project",
                                    "Creating work instructions",
                                    "Supporting the Purchasing Department - contact with suppliers, creating a supplier database",
                                    "Work in the MS Office and the SAP system",
                                }
                            ),
                            new CategoryItem
                            (
                                "Intern in the Logistics Department",
                                "Kirchhoff Polska Sp. z o.o. in Gliwice ",
                                String.Empty,
                                "\\images\\kirchhoff.png",
                                new[] {"08.2016 – 10.2016"},
                                new[]
                                {
                                    "Supporting the Logistics Department in their daily duties",
                                    "Checking stock levels and completing reports",
                                    "Data input into the SAP system",
                                    "Supporting the Purchasing Department in creating databases"
                                }
                            ),

                        }
                    },
                    new Category
                    {
                        Name = "Organizations",
                        CategoryItems = new List<CategoryItem>()
                            {
                                new CategoryItem
                                (
                                    "FENIKS European Logistics Club",
                                    string.Empty,
                                    "Silesian University of Technology",
                                    "\\images\\Feniks.png",
                                    new[] {"11.2013 - 01.2017"},
                                    new[] { ""}
                                ),
                        }
                    },
                    new Category
                    {
                        Name = "Courses, trainings, workshops",
                        CategoryItems = new List<CategoryItem>()
                        {
                            new CategoryItem(
                                "<b>ISTQB Certified Tester Foundation Level</b>",
                                string.Empty,
                                "ISTQB, SJSI",
                                string.Empty,
                                new[] {"01.2021"},
                                new[] {""}
                                ),
                            new CategoryItem
                            (
                                "Training: RoHS directive, CE related, REACH elements and product analysis",
                                string.Empty,
                                "KONSIGLIO",
                                string.Empty,
                                new[] {"06.2019"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Excel course at the Silesian University of Technology",
                                "(pivot tables, vertical search function)",
                                "Evenea",
                                string.Empty,
                                new[] {"02.2018"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Lean Management Workshops",
                                string.Empty,
                                "SKN Lean Team",
                                string.Empty,
                                new[] {"04.2017"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Workshops: How to meet customer requirements in the automotive industry and avoid complaints?",
                                string.Empty,
                                "Saint Gobain",
                                string.Empty,
                                new[] {"04.2017"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Lean Management Workshops",
                                string.Empty,
                                "FM Logistics",
                                string.Empty,
                                new[] {"01.2017"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "Workshops: Conflict management and building cooperation",
                                string.Empty,
                                "EDF",
                                string.Empty,
                                new[] {"04.2015"},
                                new[] { ""}
                            ),
                            new CategoryItem
                            (
                                "The importance of logistics in the success of the Snickers brand",
                                "From idea to implementation - logistic challenges related to taking advantage of market opportunities",
                                "The Academy of Practical Knowledge MARS",
                                string.Empty,
                                new[] {"12.2013"},
                                new[] { ""}
                            ),
                            //new CategoryItem
                            //(
                            //    "Logistics conferences",
                            //    string.Empty,
                            //    "Silesian University of Technology (EKL Feniks), Poznan University of Technology",
                            //    string.Empty,
                            //    new[] {"2013-2017"},
                            //    new[] { ""}
                            //),
                        }
                    },
                },
                Skills = new Dictionary<string, string[]>()
                {
                    { "Technologies", new [] { "SQL/T-SQL", "HTML", "CSS", "GIT", } },
                    { "Computer programs", new[] { "MS SQL Server Management Studio", "Postman", "Swagger", "MS Office", "MS Visio", "MS Project", "SAP", "NX" } },
                    { "Languages", new[] { "English - B1/B2", "German - A1/A2" }},
                    { "Others", new[] { "Driving license. B" }},
                    { "Soft skills", new[] { "ability to work in a group", "good organization of own work", "scrupulousness, accuracy" }},
                },
                IsEnglish = true,
                Color = "#2c7d49",
            };

            switch (person)
            {
                case "janusz": return View(janusz);
                case "basia": return View(basia);
                case "basiaENG": return View(basiaENG);
                default: return View(januszENG);
            }
        }
    }
}