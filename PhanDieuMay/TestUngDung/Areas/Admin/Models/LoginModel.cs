using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}