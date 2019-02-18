using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessons.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lessons.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index() => View("Result",
            new Result
            {
                Controller = nameof(AdminController),
                Action = nameof(Index)
            });

    }
}