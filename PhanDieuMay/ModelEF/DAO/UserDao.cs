using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private PhanDieuMayContext db;

        public UserDao()
        {
            db = new PhanDieuMayContext();
        }

        public int login(string userName, string password)
        {
            var result = db.UserAccounts.Where(x => x.UserName.Contains(userName) && x.Password.Contains(password)).FirstOrDefault();
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public UserAccount GetById(string userName)
        {
            return db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
        }
        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public string Insert(UserAccount entity)
        {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.UserName;
        }
        public UserAccount Find(string user)
        {
            return db.UserAccounts.Find(user);
        }

        public string Edit(UserAccount entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity.UserName;
        }
        public UserAccount FindId(string id)
        {
            return db.UserAccounts.Find(id);
        }
        public IEnumerable<UserAccount> ListWhereAll(string key, int page, int pagesize)
        {
            IEnumerable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(key))
            {
                return model.Where(x => x.UserName.Contains(key)).ToPagedList(page, pagesize);
            }
            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
    }
}
