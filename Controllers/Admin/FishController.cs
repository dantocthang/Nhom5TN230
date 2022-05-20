using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        //public ActionResult CreateFishType()
        //{
        //    return View();
        //}

        [HttpPost, ActionName("FishType")]
        [ValidateInput(true)]
        public ActionResult CreateFishType(String Ten)
        {
            var data = new loai_ca_giong();
            try
            {
                if (ModelState.IsValid)
                {
                    data.Ten = Ten;
                    var loaiCa = db.loai_ca_giong.SingleOrDefault(s => s.Ten.Equals(Ten));
                    if (loaiCa == null)
                    {
                        db.loai_ca_giong.Add(data);
                        db.SaveChanges();
                        return RedirectToAction("FishType");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đã có loại cá này");
                    }
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");

            }
            return View("CreateFishType", data);
        }

        public ActionResult EditFishType(int Ma)
        {
            var ft = db.loai_ca_giong.Find(Ma);
            return View(ft);
        }

        [HttpPost, ActionName("EditFishType")]
        public ActionResult EditFishTypePost(int Ma)
        {
            var data = new loai_ca_giong();
            try
            {
                if (ModelState.IsValid)
                {
                    data = db.loai_ca_giong.Find(Ma);
                    if (TryUpdateModel(data, "", new string[] { "Ma", "Ten" }))
                    {
                        db.Entry(data).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("FishType");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error Save Data");
                    }
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");

            }
            return View("EditFishType", data);
        }


        
        public ActionResult DeleteFishType(int Ma)
        {
            var data = db.loai_ca_giong.Find(Ma);

            if (data != null)
            {
                var ca = db.ca_giong.SingleOrDefault(s => s.loai_ca_giong_Ma == Ma);
                if (ca == null)
                {
                    db.loai_ca_giong.Remove(data);
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi ràng buộc khoá ngoại");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error Delete Data");
            }
            return RedirectToAction("FishType");
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

        public ActionResult EditFish(int? Ma)
        {
            var list = db.ca_giong.SingleOrDefault(s => s.Ma == Ma);
            if (list == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var item = db.loai_ca_giong.ToList();
            ViewBag.data = item;
            return View(list);
        }

        [HttpPost, ActionName("EditFish")]
        [ValidateInput(false)]
        public ActionResult EditFish(int Ma)
        {
            var cas = db.ca_giong.Find(Ma);
            if (ModelState.IsValid)
            {
                TryUpdateModel(cas, "", new string[] { "Ten", "MoTa", "SoLuong", "NgayTuoi", "loai_ca_giong_Ma" });
                db.Entry(cas).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ds_Ca_Giong");
        }

        public ActionResult DeleteFish(int? Ma)
        {
            ca_giong ca = db.ca_giong.SingleOrDefault(n => n.Ma == Ma);

            if (ca == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ca);
        }

        [HttpPost, ActionName("DeleteFish")]
        public ActionResult DeleteConfirm(int Ma)
        {
            ca_giong ca = db.ca_giong.SingleOrDefault(n => n.Ma == Ma);
            db.ca_giong.Remove(ca);
            db.SaveChanges();
            return RedirectToAction("ds_Ca_Giong");
        }

    }
}