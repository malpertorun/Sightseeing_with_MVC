using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.Repositories;
using DataAccessLayer;
using Entitiy;

namespace Sightseeing.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        UnitOfWork _uow = new UnitOfWork();

        // GET: ToDoLists
        public ActionResult Index()
        {
            if (User.Identity.Name != null)
            {
                if ((_uow._toDoListManager.FindActiveToDoListForUser(User.Identity.Name)) == null)
                {
                    return RedirectToAction("Create");
                }

                return View(_uow._toDoListManager.FindActiveToDoListForUser(User.Identity.Name));
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string toDoListName)
        {
            _uow._toDoListManager.CreateToDoListForUser(User.Identity.Name,toDoListName);
            _uow.Save();
            return Redirect("Index");
        }


    }
}
