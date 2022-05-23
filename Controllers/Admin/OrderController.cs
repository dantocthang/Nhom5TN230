using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom5TN230.Controllers.Admin
{
    public class OrderController : Controller
    {
        FishMarketEntities db = new FishMarketEntities();
        // GET: Order
        public ActionResult OrderList()
        {
            var data = from s in db.don_dat select s;
            return View(data);
        }

        public ActionResult OrderDetail(int id)
        {
            var data = db.chi_tiet_don_dat.Where(s => s.don_dat_Ma == id);
            return View(data);
        }

        public ActionResult OrderProcess()
        {
            int ma_don = int.Parse(Request.QueryString["ma_don"]);
            int ma_trang_thai = int.Parse(Request.QueryString["ma_trang_thai"]);
            var don_hang = db.don_dat.Find(ma_don);
            //var chi_tiet_don = db.chi_tiet_don_dat.Where(s => s.don_dat_Ma == ma_don);
            if (don_hang != null)
            {
                if (ma_trang_thai == 2)
                {
                    don_hang.trang_thai_Ma = 2;
                    don_hang.nhan_vien_Ma = Session["username"].ToString();
                    db.Entry(don_hang).State = EntityState.Modified;
                    db.SaveChanges();
                    foreach (var item in don_hang.chi_tiet_don_dat.ToList())
                    {
                        var ca = item.ca_giong;
                        ca.SoLuong -= item.SoLuongDat;
                        db.Entry(ca).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                if (ma_trang_thai == 3)
                {
                    don_hang.trang_thai_Ma = 3;
                    don_hang.nhan_vien_Ma = Session["username"].ToString();
                    db.Entry(don_hang).State = EntityState.Modified;
                    db.SaveChanges();

                    hoa_don hd = new hoa_don();
                    hd.NgayLap = DateTime.Today;
                    hd.don_dat_Ma = don_hang.Ma;
                    db.hoa_don.Add(hd);
                    db.SaveChanges();
                }

                if (ma_trang_thai == 4)
                {
                    don_hang.trang_thai_Ma = 4;
                    don_hang.nhan_vien_Ma = Session["username"].ToString();
                    db.Entry(don_hang).State = EntityState.Modified;
                    db.SaveChanges();

                }

            }
            return RedirectToAction("OrderList");
        }
    }
}
