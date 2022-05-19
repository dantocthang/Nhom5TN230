using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom5TN230.Controllers.Admin
{

    public class FishController : Controller
    {
        FishMarketEntities db = new FishMarketEntities();

        public ActionResult FishType()
        {
            //var data = from s in db.loai_ca_giong select s;
            return View();
        }

        public ActionResult FishTypes()
        {
            var data = from s in db.loai_ca_giong select s;
            return View(data);
        }

        [HttpPost, ActionName("FishType")]
        [ValidateInput(false)]
        public ActionResult CreateFishType(loai_ca_giong lcg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.loai_ca_giong.Add(lcg);
                    db.SaveChanges();
                    return RedirectToAction("FishType");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
                
            }
            return View("FishType", lcg);
        }


        // Section Cá giống
        public ActionResult ds_Ca_Giong()
        {
            var list = from s in db.ca_giong select s;
            return View(list);
        }

        public ActionResult tao_Ca_Giong()
        {
            return View();
        }

        [HttpPost, ActionName("taoCaGiong")]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult CreateBook(ca_giong ca_giongform)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Them Ca Giong Moi
                    //CA_GIONG(CG_Ma, CG_Ten, CG_MoTa, CG_SoLuong, CG_NgayTuoi, LCG_Ma)
                    ca_giong ca_giong = new ca_giong();

                    ca_giong.Ma = db.ca_giong.Max(p => p.Ma) + 1;
                    ca_giong.Ten = ca_giongform.Ten;
                    ca_giong.MoTa = ca_giongform.MoTa;
                    ca_giong.SoLuong = ca_giongform.SoLuong;
                    ca_giong.NgayTuoi = ca_giongform.NgayTuoi;
                    ca_giong.loai_ca_giong_Ma = ca_giongform.loai_ca_giong_Ma;

                    db.ca_giong.Add(ca_giong);
                    db.SaveChanges();
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Loi khi them");
            }
            //Cập nhật lại danh sách hiển thị
            var list = from s in db.ca_giong select s;
            return RedirectToAction("ds_Ca_Giong");
        }

    }
}