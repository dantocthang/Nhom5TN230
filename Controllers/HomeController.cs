using System;
using System.Collections.Generic;
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
                        Session.Add("userSession", userName);

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
                        Session.Add("userSession", userName);
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



    }
}