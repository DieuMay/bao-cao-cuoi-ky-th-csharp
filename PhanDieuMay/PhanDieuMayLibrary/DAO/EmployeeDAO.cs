using NguyenThanhDuyLibrary.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDuyLibrary.DAO
{
    
     public class EmployeeDAO
    {
        NguyenThanhDuyDBEntities db = new NguyenThanhDuyDBEntities();
        public EmployeeDAO()
        {            
        }
        public List<Employee> getData()
        {
            return db.Employees.ToList();
        }        
        public int insertdata(Employee entity)
        {

            db.Employees.Add(entity);
            db.SaveChanges();
            return entity.EmployeeId;
        }
    }
}
