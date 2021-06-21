using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Common
{
    [Serializable] 
    public class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}