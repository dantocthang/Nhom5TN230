﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Nhom5TN230.Controllers
{
    public class HomeController : Controller
    {
        FishMarketEntities db = new FishMarketEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(string username, string password)
        //{

        //    if (Regex.IsMatch(username, "^[0-9]{4,20}$"))
        //    {
        //        var account = db.nhan_vien.SingleOrDefault(s => s.Ma == username);
        //        if (account != null)
        //        {
        //            if (account.MatKhau == password)
        //            {
        //                var userName = account.Ten.ToString();
        //                Session.Add("userSession", userName);

        //                var role = account.quyen_Ma.ToString();
        //                Session.Add("role", role);

        //                return Redirect("/Admin");
        //            }
        //            else
        //            {
        //                ViewBag.errorPassword = "Mật khẩu không đúng.";
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.errorUsername = "Tên đăng nhập không đúng.";
        //        }
        //    }
        //    else
        //    {
        //        var account = db.khach_hang.SingleOrDefault(s => s.TenTK == username);
        //        if (account != null)
        //        {
        //            if (account.MatKhau == password)
        //            {
        //                var userName = account.TenTK.ToString();
        //                Session.Add("userSession", userName);
        //                return Redirect("/");
        //            }
        //            else
        //            {
        //                ViewBag.errorPassword = "Mật khẩu không đúng.";
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.errorUsername = "Tên đăng nhập không đúng.";
        //        }
        //    }



        //    return View("Login");
        //}
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            if (Regex.IsMatch(username, "^[0-9]{4,20}$"))
            {
                var account = db.nhan_vien.SingleOrDefault(s => s.Ma == username);
                if (account != null)
                {
                    if (account.MatKhau == password)
                    {
                        var userName = account.Ten.ToString();
                        Session.Add("username", account.Ma.ToString());
                        Session.Add("name", userName);
                        var role = account.quyen_Ma.ToString();
                        Session.Add("role", role);

                        return Redirect("/Admin");
                    }
                    else
                    {
                        ViewBag.errorPassword = "Mật khẩu không đúng.";
                    }
                }
                else
                {
                    ViewBag.errorUsername = "Tên đăng nhập không đúng.";
                }
            }
            else
            {
                var account = db.khach_hang.SingleOrDefault(s => s.TenTK == username);
                if (account != null)
                {
                    if (account.MatKhau == password)
                    {
                        var userName = account.TenTK.ToString();
                        Session.Add("username", userName);
                        Session.Add("name", userName);

                        return Redirect("/");
                    }
                    else
                    {
                        ViewBag.errorPassword = "Mật khẩu không đúng.";
                    }
                }
                else
                {
                    ViewBag.errorUsername = "Tên đăng nhập không đúng.";
                }
            }
            return View("Login");
        }


        public ActionResult Logout()
        {
            Session["userSession"] = null;
            Session["role"] = null;
            return Redirect("/");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(khach_hang kh, string NhapLaiMatKhau, string MatKhau)
        {
            if (ModelState.IsValid)
            {
                var check = db.khach_hang.FirstOrDefault(k => k.TenTK == kh.TenTK);
                if (check == null)
                {
                    if (NhapLaiMatKhau == MatKhau)
                    {
                        db.khach_hang.Add(kh);
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.success = "Bạn đã đăng ký thành công";
                        return RedirectToAction("Login");
                    }
                    ViewBag.errorNhapLaiMatKhau = "Mật khẩu nhập lại không khớp";
                    return View();
                }

                ViewBag.errorTenTK = "Tên tài khoản đã tồn tại";
            }
            return View();
        }

        public ActionResult Profile(string username)
        {
            if (Regex.IsMatch(username, "^[0-9]{4,20}$"))
            {
                return RedirectToAction("StaffProfile");
            }
            else
            {
                return RedirectToAction("CustomerProfile");
            }
        }

        public ActionResult StaffProfile()
        {
            var username = Session["username"].ToString() ?? "";
            var account = db.nhan_vien.SingleOrDefault(s => s.Ma == username);
            return View(account);
        }

        public ActionResult CustomerProfile()
        {
            var username = Session["username"].ToString() ?? "";
            var account = db.khach_hang.SingleOrDefault(kh => kh.TenTK == username);
            return View(account);
        }

        public ActionResult EditStaffProfile(string id)
        {
            var account = db.nhan_vien.SingleOrDefault(s => s.Ma == id);
            return View(account);

        }

        [HttpPost, ActionName("EditStaffProfile")]
        public ActionResult SaveEditStaffProfile(string id)
        {
            var staff = db.nhan_vien.SingleOrDefault(s => s.Ma == id);
            if (ModelState.IsValid)
            {
                TryUpdateModel(staff, "", new string[] { "Ma", "Ten", "SDT", "DiaChi" });
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("StaffProfile");
        }

        public ActionResult EditCustomerProfile(string id)
        {
            var account = db.khach_hang.SingleOrDefault(s => s.TenTK == id);
            return View(account);

        }

        [HttpPost, ActionName("EditCustomerProfile")]
        public ActionResult SaveEditCustomerProfile(string id)
        {
            var customer = db.khach_hang.SingleOrDefault(s => s.TenTK == id);
            if (ModelState.IsValid)
            {
                TryUpdateModel(customer, "", new string[] { "Ma", "Ten", "SDT", "DiaChi" });
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("CustomerProfile");
        }



        public ActionResult FishsByType(int? id)
        {
            if (id == null) id = 8;
            var name = db.loai_ca_giong.Find(id).Ten;
            ViewBag.displayName = name;
            var viewModel = db.ca_giong.Where(s => s.loai_ca_giong_Ma == id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult FishTypes()
        {
            var data = from s in db.loai_ca_giong select s;
            return View(data);
        }

        public ActionResult DetailFish(int id)
        {
            ca_giong data = db.ca_giong.SingleOrDefault(s => s.Ma == id);
            return View(data);
        }


        public ActionResult SearchFish()
        {
            var data = from s in db.ca_giong select s;
            return View(data);
        }

        [HttpPost]
        public ActionResult SearchFish(string search)
        {
            var data = from s in db.ca_giong select s;
            if (search != "")
            {
                data = data.Where(s => s.Ten.Contains(search));
            }
            return View(data);
        }


        [HttpPost]
        public ActionResult SearchFishes(string search)
        {

            if (search != "")
            {
                var data = from c in db.ca_giong select c;
                data = data.Where(s => s.Ten.Contains(search));
                return View(data);
            }

            return View();
        }



    }
}