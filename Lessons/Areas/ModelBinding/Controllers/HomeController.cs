using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lessons.Areas.ModelBinding.Models;

namespace Lessons.Areas.ModelBinding.Controllers
{
    [Area("ModelBinding")]
    public class HomeController : Controller
    {
        private IBindRepository repository;

        public HomeController(IBindRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(int? id)
        {
            PersonBind person;
            if (id.HasValue && (person = repository[id.Value]) != null)
            {
                return View(person);
            }
            else
            {
                return NotFound();
            }
        }

        public ViewResult Create() => View(new PersonBind());

        [HttpPost]
        public ViewResult Create(PersonBind model) => View("Index", model);

        public ViewResult DisplaySummary([Bind(nameof(AddressSummary.City), Prefix = nameof(PersonBind.HomeAddress))]AddressSummary summary) => View(summary);

        //public ViewResult Names(string[] names) => View(names ?? new string[0]);
        public ViewResult Names(IList<string> names) => View(names ?? new List<string>());

        public ViewResult Address(IList<AddressSummary> addresses) => View(addresses ?? new List<AddressSummary>());

        //public string Header([FromHeader(Name = "Accept-Language")]string accept) => $"Header: {accept}";
        public ViewResult Header(HeaderModel model) => View(model);

        public ViewResult Body() => View();

        [HttpPost]
        public PersonBind Body([FromBody]PersonBind model) => model;

    }
}