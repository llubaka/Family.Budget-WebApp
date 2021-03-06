﻿namespace FamilyBudget.WebApp.Controllers
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

            ViewData["result"] = "Successfully added " + ieType.ToString();

            _service.AddIE(userId, value, Convert.ToDateTime(date), ieType);

            return RedirectToAction("Index", "Result");
        }

        [HttpGet]
        public ActionResult AddDuplicateIE(decimal value, int day, IEType ieType)
        {
            string userId = User.Identity.GetUserId();

            ViewData["result"] = "Successfully added " + ieType.ToString();

            _service.AddDuplicateIE(userId, value, day, ieType);

            return RedirectToAction("Index", "Result");
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

            ViewData["result"] = "Successfully removed.";

            return RedirectToAction("EditRemoveIE", "Service");
        }

        public ActionResult RemoveDuplicateIE(int id)
        {
            _service.RemoveDuplicateIE(id);

            ViewData["result"] = "Successfully removed.";

            return RedirectToAction("EditRemoveIE", "Service");
        }

        public ActionResult EditIE(int id, decimal value, string date)
        {
            _service.EditIE(id,value,Convert.ToDateTime(date));

            ViewData["result"] = "Successfully updated.";

            return RedirectToAction("EditRemoveIE", "Service");
        }

        public ActionResult EditDuplicateIE(int id, decimal value, int day)
        {
            _service.EditDuplicateIE(id, value, day);

            ViewData["result"] = "Successfully updated.";

            return RedirectToAction("EditRemoveIE", "Service");
        }
    }
}