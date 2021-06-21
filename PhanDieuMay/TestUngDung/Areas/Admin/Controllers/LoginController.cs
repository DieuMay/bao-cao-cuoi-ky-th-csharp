using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;
using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(login.UserName, Common.Encryptor.EncryptMD5(login.Password));
                if (result == 1)
                {
                    // ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, login.UserName);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Please enter the correct information");
                }
            }
            return View("Index");
        }
    }
}