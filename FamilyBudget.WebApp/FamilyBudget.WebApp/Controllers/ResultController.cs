using FamilyBudget.WebApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyBudget.WebApp.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();

            ViewData["list"] = new Services.Service(new ApplicationDbContext()).GetIncomes(userId);

            return View();
        }
    }
}