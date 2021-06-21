using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private PhanDieuMayContext db = null;
        public CategoryDao()
        {
            db = new PhanDieuMayContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
    }
}
