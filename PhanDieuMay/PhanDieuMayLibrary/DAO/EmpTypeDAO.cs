using NguyenThanhDuyLibrary.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDuyLibrary.DAO
{
    public class EmpTypeDAO
    {
        NguyenThanhDuyDBEntities db = null;
        public EmpTypeDAO()
        {
            db = new NguyenThanhDuyDBEntities();
        }
        public List<EmpType> getlist()
        {
            return db.EmpTypes.ToList();
        }
    }
}
