using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.Repositories;
using Entitiy;

namespace Sightseeing.Controllers
{
    public class ActivitiyController : Controller
    {
        UnitOfWork _uow = new UnitOfWork();

        // GET: Activitiy
        public ActionResult Index()
        {
            return View(_uow._activityRepository.GetAllActivities());
        }
        public ActivitiyController()
        {
            ViewBag.ActivitiySelected = "selected";
        }
        // GET: Activitiy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = _uow._activityRepository.FindByActivityId(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activitiy/Create
        public ActionResult Create()
        {
            ViewBag.refCategoryId = new SelectList(_uow._categoryRepository.GetAllCategories(), "CategoryId", "CategoryName");
            return View();

        }

        // POST: Activitiy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Activity activity)
        {
            if (ModelState.IsValid)
            {
                _uow._activityRepository.CreateActivity(activity);
                _uow.Save();
                return RedirectToAction("Index");
            }

            ViewBag.refCategoryId = new SelectList(_uow._categoryRepository.GetAllCategories(), "CategoryId", "CategoryName", activity.refCategoryId);
            return View(activity);
        }

        // GET: Activitiy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = _uow._activityRepository.FindByActivityId(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.refCategoryId = new SelectList(_uow._categoryRepository.GetAllCategories(), "CategoryId", "CategoryName", activity.refCategoryId);
            return View(activity);
        }

        // POST: Activitiy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                _uow._activityRepository.EditActivity(activity);
                _uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.refCategoryId = new SelectList(_uow._categoryRepository.GetAllCategories(), "CategoryId", "CategoryName", activity.refCategoryId);
            return View(activity);
        }

        // GET: Activitiy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = _uow._activityRepository.FindByActivityId(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activitiy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = _uow._activityRepository.FindByActivityId(id);
            _uow._activityRepository.DeleteActivity(activity);
            _uow.Save();
            return RedirectToAction("Index");
        }

    }
}
