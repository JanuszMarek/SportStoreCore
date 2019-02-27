using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Lessons.Areas.Identity.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Lessons.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;

        public HomeController(UserManager<AppUser> user)
        {
            userManager = user;
        }

        [Authorize]
        public ViewResult Index()
        {
            return View(GetData(nameof(Index)));
        }

        //[Authorize(Roles = "Users")]
        [Authorize(Policy = "JoeUsers")]
        public IActionResult OtherAction() => View("Index",GetData(nameof(OtherAction)));

        private Dictionary<string, object> GetData(string actionName)
        {
            return new Dictionary<string, object>
            {
                ["Action"] = actionName,
                ["User"] = HttpContext.User.Identity.Name,
                ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["In Users Role"] = HttpContext.User.IsInRole("Users"),
                ["City"] = CurrentUser.Result.City,
                ["Qualification"] = CurrentUser.Result.Qualifications
          };
        }

        [Authorize]
        public async Task<IActionResult> UserProps()
        {
            return View(await CurrentUser);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserProps([Required]Cities city, [Required]QualificationLevels qualifications)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await CurrentUser;
                user.City = city;
                user.Qualifications = qualifications;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(await CurrentUser);
        }

        private Task<AppUser> CurrentUser => userManager.FindByNameAsync(HttpContext.User.Identity.Name);

        [Authorize(Policy = "NotBob")]
        public IActionResult NotBob() => View("Index", GetData(nameof(NotBob)));

    }
}