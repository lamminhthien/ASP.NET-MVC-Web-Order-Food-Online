using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnWeb_Nhom3.Models;

namespace DoAnWeb_Nhom3.Controllers
{
    public class UserController : Controller
    {
        private DoAnWeb_Nhom_3Entities1 db = new DoAnWeb_Nhom_3Entities1();

        // GET: User
        public ActionResult Dangky()
        {
            return View();
        }


        // ĐĂNG KÝ PHƯƠNG THỨC POST
        [HttpPost]
        public ActionResult Dangky(NGUOIDUNG nguoidung)
        {
            //Tăng mã người dùng lên
            var maMax = db.NGUOIDUNGs.ToList().Select(n => n.MANGUOIDUNG).Max();
            //Nếu chưa có người dùng nào, nghĩa là maMax = null
            if (maMax == null) maMax = 1;
            nguoidung.MANGUOIDUNG = maMax + 1;

            //Mặc định vi^^ệc đk t``ai khoản chỉ l``a đk t``ai khoản khach, neu muon cap quyen admin
            //phai vo trang admin cap quyen rieng, hoac cap quyen admin qua d^^atabase sql
            nguoidung.IDQUYEN = 1;

            // Thêm người dùng  mới
            db.NGUOIDUNGs.Add(nguoidung);
                // Lưu lại vào cơ sở dữ liệu
                db.SaveChanges();
                // Nếu dữ liệu đúng thì trả về trang đăng nhập
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Dangnhap");
                }
                return View("Dangky");

            


        }

        public ActionResult Dangnhap()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Dangnhap(FormCollection userlog)
        {
            string userMail = userlog["EMAIL"].ToString();
            string password = userlog["MATKHAU"].ToString();
            var islogin = db.NGUOIDUNGs.SingleOrDefault(x => x.EMAIL.Equals(userMail) && x.MATKHAU.Equals(password));

            if (islogin != null && islogin.IDQUYEN ==2)
            {  
                    Session["Admin"] = islogin;
                    return RedirectToAction("Index", "Admin/SANPHAMs");
            }
            //Khách phải có id quyền =1
            //ông lưu ý cái này nhan
            if (islogin != null && islogin.IDQUYEN == 1)
            {
                Session["use"] = islogin;
                return RedirectToAction("Index", "Home");
                // ViewBag.Fail = "Đăng nhập thất bại";
                // return View("Dangnhap");
            }
            else
            {
                 ViewBag.Fail = "Đăng nhập thất bại";
                 return View("Dangnhap");
            }
          

        }
        public ActionResult DangXuat()
        {
            Session["use"] = null;
            Session["GioHang"] = null;
            return RedirectToAction("Index", "Home");

        }
      
    }
}
