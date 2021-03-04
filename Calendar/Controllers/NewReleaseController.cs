using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calendar.Controllers
{
    public class NewReleaseController : Controller
    {
        private ApplicationDbContext _context;

        public NewReleaseController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public JsonResult GetEvents()
        {
            var releases = _context.NewReleases.ToList();
            return new JsonResult { Data = releases, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult Add(NewRelease newRelease)
        {
            if (ModelState.IsValid && newRelease.StartDate != null && newRelease.EndDate != null)
            {
                if (newRelease.StartDate < newRelease.EndDate)
                {
                    _context.NewReleases.Add(new NewRelease
                    {
                        Title = newRelease.Title,
                        Description = newRelease.Description,
                        StartDate = newRelease.StartDate,
                        EndDate = newRelease.EndDate
                    });

                    _context.SaveChanges();
                }
            }

            newRelease = null;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(NewRelease newRelease)
        {
            var update = _context.NewReleases.Where(i => i.Id == newRelease.Id).FirstOrDefault();

            if (ModelState.IsValid && newRelease.StartDate != null && newRelease.EndDate != null)
            {
                if (newRelease.StartDate < newRelease.EndDate && update != null)
                {
                    update.Title = newRelease.Title;
                    update.Description = newRelease.Description;
                    update.StartDate = newRelease.StartDate;
                    update.EndDate = newRelease.EndDate;

                    _context.SaveChanges();
                }
            }

            newRelease = null;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var selectedEvent = _context.NewReleases.Where(i => i.Id == Id);

            if (selectedEvent != null && selectedEvent != null)
            {
                _context.NewReleases.RemoveRange(selectedEvent);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}