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

        public ActionResult EditRemoveIE()
        {
            string userId = User.Identity.GetUserId();
            ProjectModels.ProjectModels.IEs_DuplicateIEs ies_DuplicateIEs = new ProjectModels.ProjectModels.IEs_DuplicateIEs();

            ies_DuplicateIEs.IEs = _service.GetIEs(userId);
            ies_DuplicateIEs.DuplicateIEs = _service.GetDuplicateIEs(userId);

            return View(ies_DuplicateIEs);
        }

        public ActionResult RemoveIE(int id)
        {
            _service.RemoveIE(id);

            return RedirectToAction("Index", "Result");
        }

        public ActionResult RemoveDuplicateIE(int id)
        {
            _service.RemoveDuplicateIE(id);

            return RedirectToAction("Index", "Result");
        }
    }
}