//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Nhom5TN230.Controllers.Admin
//{
//    public class UserController : Controller
//    {
//        FishMarketEntities db = new FishMarketEntities();
//        public ActionResult ListStaff()
//        {
//            var staff = from s in db.nhan_vien select s;
//            return View(staff);
//        }
//        public ActionResult AddStaff()
//        {
//            var staff = db.quyens.ToList();
//            ViewBag.data = staff;
//            return View();
//        }
//        [HttpPost, ActionName("AddStaff")]
//        [ValidateInput(false)]
//        public ActionResult AddStaff(nhan_vien staff)
//        {

//            if (ModelState.IsValid)
//            {
//                db.nhan_vien.Add(staff);
//                db.SaveChanges();
//                return RedirectToAction("ListStaff");
//            }

//            var staffs = db.quyens.ToList();
//            ViewBag.data = staffs;
//            return View(staff);
//        }




//        public ActionResult EditStaff(string id)
//        {

//            var staff = db.nhan_vien.SingleOrDefault(s => s.Ma == id);
//            var quyen = db.quyens.ToList();
//            ViewBag.data = quyen;
//            return View(staff);
//        }
//        [HttpPost, ActionName("EditStaff")]
//        [ValidateInput(false)]
//        public ActionResult EditStaffPost(string id)
//        {
//            var staff = db.nhan_vien.SingleOrDefault(s => s.Ma == id);
//            if (ModelState.IsValid)
//            {
//                TryUpdateModel(staff, "", new string[] {  "Ten", "SDT", "DiaChi", "quyen_Ma" });
//                db.Entry(staff).State = EntityState.Modified;
//                db.SaveChanges();

//            }


//            return RedirectToAction("ListStaff");
//        }


//        [HttpPost]
//        public ActionResult DeleteStaff(string id)
//        {
//            var staff = db.nhan_vien.SingleOrDefault(s => s.Ma == id);
//            db.nhan_vien.Remove(staff);
//            db.SaveChanges();
//            return RedirectToAction("ListStaff");
//        }

//    }
//}



using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom5TN230.Controllers.Admin
{
    public class UserController : Controller
    {
        public int CheckRole(int nhanvien)
        {
            if (Session["role"] == null) return 0;
            else
            {
                var role = Session["role"].ToString();
                if (role == "Admin") return 1;
                if (nhanvien == 0) return 2;
            }
            return 1;
        }
        FishMarketEntities db = new FishMarketEntities();
        public ActionResult ListStaff()
        {
            if (CheckRole(0) == 1)
            {
                var staff = from s in db.nhan_vien select s;
                return View(staff);
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");

            else
                return RedirectToAction("Index", "Home");
        }
        public ActionResult AddStaff()
        {
            if (CheckRole(0) == 1)
            {
                var staff = db.quyens.ToList();
                ViewBag.data = staff;
                return View();
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");

            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost, ActionName("AddStaff")]
        [ValidateInput(false)]
        public ActionResult AddStaff(nhan_vien staff)
        {
            if (CheckRole(0) == 1)
            {
                if (ModelState.IsValid)
                {
                    db.nhan_vien.Add(staff);
                    db.SaveChanges();
                    return RedirectToAction("ListStaff");
                }

                var staffs = db.quyens.ToList();
                ViewBag.data = staffs;
                return View(staff);
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");

            else
                return RedirectToAction("Index", "Home");


        }




        public ActionResult EditStaff(string id)
        {

            if (CheckRole(0) == 1)
            {
                var staff = db.nhan_vien.SingleOrDefault(s => s.Ma == id);
                var quyen = db.quyens.ToList();
                ViewBag.data = quyen;
                return View(staff);
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");

            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost, ActionName("EditStaff")]
        [ValidateInput(false)]
        public ActionResult EditStaffPost(string id)
        {
            var staff = db.nhan_vien.SingleOrDefault(s => s.Ma == id);
            if (ModelState.IsValid)
            {
                TryUpdateModel(staff, "", new string[] { "Ten", "SDT", "DiaChi", "quyen_Ma" });
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("ListStaff");
        }


        [HttpPost]
        public ActionResult DeleteStaff(string id)
        {
            if (CheckRole(0) == 1)
            {
                var staff = db.nhan_vien.SingleOrDefault(s => s.Ma == id);
                db.nhan_vien.Remove(staff);
                db.SaveChanges();
                return RedirectToAction("ListStaff");
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");

            else
                return RedirectToAction("Index", "Home");
        }

    }
}
