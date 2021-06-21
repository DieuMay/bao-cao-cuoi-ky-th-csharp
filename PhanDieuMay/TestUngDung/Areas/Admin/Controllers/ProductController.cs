using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        PhanDieuMayContext db = new PhanDieuMayContext();
        public void SetViewBag(long? id = null)
        {
            var dao = new CategoryDao();
            ViewBag.Category_Id = new SelectList(dao.ListAll(), "Id", "Name", id);
        }
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Details(int id)
        {
            ProductDao dao = new ProductDao();
            var result = dao.ListDetail(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            var dao = new ProductDao();
            ViewBag.Product = dao;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase image)
        {
            SetViewBag();
            if (image != null && image.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(image.FileName);
                string url = Server.MapPath("~/Upload/Product/" + fileName);
                image.SaveAs(url);
                product.Image = fileName;
            }
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                if (dao.Find(product.Id) != null)
                {
                    return RedirectToAction("Create", "Product");
                }
                string result = dao.Insert(product);
                if (result == "1")
                {
                    SetAlert("Thông tin sản phẩm đã tồn tại, vui lòng nhập lại", "error");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                }
            }
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            SetViewBag();
            var product = new ProductDao();
            var result = product.FindId(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase editImage)
        {
            SetViewBag();
            if (ModelState.IsValid)
            {
                Product eProduct = db.Products.Find(product.Id);
                if (eProduct != null)
                {
                    if (editImage != null && editImage.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(editImage.FileName);
                        string url = Server.MapPath("~/Upload/Product/" + fileName);
                        editImage.SaveAs(url);

                        eProduct.Image = fileName;
                    }
                }
                db.Entry(eProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Product");
        }
       
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (PhanDieuMayContext db = new PhanDieuMayContext())
                {
                    Product product = db.Products.Where(x => x.Id == id).FirstOrDefault();
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}