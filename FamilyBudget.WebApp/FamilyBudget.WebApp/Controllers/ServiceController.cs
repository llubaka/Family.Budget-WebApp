namespace FamilyBudget.WebApp.Controllers
{
    using System;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using FamilyBudget.WebApp.Models;

    public class ServiceController : Controller
    {
        private readonly Services.Service _service = new Services.Service(new ApplicationDbContext());

        // GET: Service
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddIE(decimal value, string date, IEType ieType)
        {
            string userId = User.Identity.GetUserId();
            ViewData["ieType"] = ieType;

            _service.AddIE(userId, value, Convert.ToDateTime(date), ieType);

            return View();
        }

        [HttpGet]
        public ActionResult AddDuplicateIE(decimal value, int day, IEType ieType)
        {
            string userId = User.Identity.GetUserId();
            ViewData["ieType"] = ieType;

            _service.AddDuplicateIE(userId, value, day, ieType);

            return View();
        }
    }
}