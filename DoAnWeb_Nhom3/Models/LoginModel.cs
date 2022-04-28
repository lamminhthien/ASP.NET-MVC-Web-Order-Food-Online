using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAnWeb_Nhom3.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "EMAIL")]
        public string EMAIL { get; set; }
        [Display(Name = "MATKHAU")]
        public string MATKHAU { get; set; }
    }
}