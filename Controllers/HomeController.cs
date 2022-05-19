using System;
using System.Collections.Generic;
using System.Linq;
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

            var account = db.nhan_vien.SingleOrDefault(s => s.Ma == username);

            if (account != null)
            {
                if (account.MatKhau == password)
                {
                    var userName = account.Ten.ToString();
                    Session.Add("userSession", userName);

                    var role = account.quyen_Ma.ToString();
                    Session.Add("role", role);

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


    }
}