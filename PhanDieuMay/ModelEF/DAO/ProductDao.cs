using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private PhanDieuMayContext db;

        public ProductDao()
        {
            db = new PhanDieuMayContext();
        }
        public Product GetById(string name)
        {
            return db.Products.SingleOrDefault(x => x.Name == name);
        }
        public List<Product> ListAll()
        {
            return db.Products.ToList();
        }
        public IEnumerable<Product> ListDetail(int id)
        {
            return db.Products.Where(x => x.Id.Equals(id)).ToList();
        }
        public IEnumerable<Product> ListWhereAll(string key, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(key))
                model.Where(x => x.Name.Contains(key));
            return model.OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToPagedList(page, pagesize);
        }
        public string Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.Name;
        }
        public bool Update(Product entity)
        {
            try
            {
                var sanpham = db.Products.Find(entity.Id);
                sanpham.Name = entity.Name;
                sanpham.UnitCost = entity.UnitCost;
                sanpham.Quantity = entity.Quantity;
                sanpham.Description = entity.Description;
                sanpham.Category_Id = entity.Category_Id;
                sanpham.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Product Find(int id)
        {
            return db.Products.Find(id);
        }
        public Product FindId(int id)
        {
            return db.Products.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
