using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        PhanDieuMayContext db = new PhanDieuMayContext();
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var session = Session[Constants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var result = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(result); 
        }
        // GET: AdminArea/User/Details/5
        public ActionResult Details(string id)
        {
            UserDao model = new UserDao();
            return View(model.FindId(id));
        }

        // GET: AdminArea/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminArea/User/Create
        [HttpPost]
        public ActionResult Create(UserAccount entity)
        {
            try
            {
                UserDao model = new UserDao();
                var x = model.Insert(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminArea/User/Edit/5
        public ActionResult Edit(string id)
        {
            UserDao model = new UserDao();
            return View(model.FindId(id));
        }

        // POST: AdminArea/User/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UserAccount u)
        {
            try
            {
                // TODO: Add update logic here
                using (PhanDieuMayContext db = new PhanDieuMayContext())
                {
                    db.Entry(u).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminArea/User/Delete/5
        public ActionResult Delete(int id)
        {
            using (PhanDieuMayContext db = new PhanDieuMayContext())
            {
                return View(db.UserAccounts.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: AdminArea/User/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (PhanDieuMayContext db = new PhanDieuMayContext())
                {
                    UserAccount u = db.UserAccounts.Where(x => x.UserName == id).FirstOrDefault();
                    db.UserAccounts.Remove(u);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteComments(int id)
        {
            var u = db.UserAccounts.Where(x => x.Id == id).FirstOrDefault();
            if (u != null)
            {
                db.UserAccounts.Remove(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}