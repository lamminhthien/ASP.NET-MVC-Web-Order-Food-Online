using DoAnWeb_Nhom3.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb_Nhom3.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private DoAnWeb_Nhom_3Entities1 db = new DoAnWeb_Nhom_3Entities1();
        // GET: Admin/Home
        public ActionResult Index(int? page)
        {
            if (Session["Admin"] == null) return RedirectToAction("Index", "Home");
            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.SANPHAMs.OrderBy(x => x.MASP);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 5;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult Details(int id)
        {
            var dt = db.SANPHAMs.Find(id);
            return View(dt);
        }

        // Tạo sản phẩm mới phương thức GET: Admin/Home/Create
        public ActionResult Create()
        {
            if (Session["Admin"] == null) return RedirectToAction("Index", "Home");
            //Để tạo dropdownList bên view
            var loaispselected = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP");
            ViewBag.Mahang = loaispselected;
            return View();
        }

        // Tạo sản phẩm mới phương thức POST: Admin/Home/Create
        [HttpPost]
        public ActionResult Create(SANPHAM sanpham)
        {
            try
            {
                //Thêm  sản phẩm mới
                db.SANPHAMs.Add(sanpham);
                // Lưu lại
                db.SaveChanges();
                // Thành công chuyển đến trang index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}