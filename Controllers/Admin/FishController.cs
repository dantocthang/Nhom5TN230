﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text.RegularExpressions;
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
        public ActionResult ListFish()
        {
            var list = from s in db.ca_giong select s;
            return View(list);
        }


        public ActionResult CreateFish()
        {
            var item = db.loai_ca_giong.ToList();
            ViewBag.data = item;
            return View();
        }

        [HttpPost, ActionName("CreateFish")]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult CreateFish(ca_giong ca_giongform)
        {
            var count = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    // loi chua nhap ten 
                    if (ca_giongform.Ten == null)
                    {
                        ViewBag.errorTen = "Bạn chưa nhập tên cá giống!";
                        count++;
                    }
                    else if (!Regex.IsMatch(ca_giongform.Ten, "^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆ fFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTu UùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ 0-9 ]{1,150}$"))
                    {
                        ViewBag.errorTen = "Tên cá giống không được chứa ký tự đặt biệt!";
                        count++;
                    }
                    // loi chua nhap mo ta
                    if (ca_giongform.MoTa == null)
                    {
                        ViewBag.errorMoTa = "Bạn chưa nhập mô tả cá giống!";
                        count++;
                    }
                    else if (!Regex.IsMatch(ca_giongform.Ten, "^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆ fFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTu UùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ 0-9 ]{1,150}$"))
                    {
                        ViewBag.errorTen = "Tên cá giống không được chứa ký tự đặt biệt!";
                        count++;
                    }
                    // loi chua nhap so luong
                    if (ca_giongform.SoLuong == null)
                    {
                        ViewBag.errorSoLuong = "Bạn chưa nhập số lượng cá giống!";
                        count++;
                    }
                    else if (ca_giongform.SoLuong < 0)
                    {
                        ViewBag.errorSoLuong = "Số lượng cá giống không được âm!";
                        count++;
                    }
                    if (ca_giongform.NgayTuoi == null)
                    {
                        ViewBag.errorNgayTuoi = "Bạn chưa nhập ngày tuổi của cá giống!";
                        count++;
                    }
                    else if (ca_giongform.NgayTuoi < 0)
                    {
                        ViewBag.errorNgayTuoi = "Tuổi cá giống không được âm!";
                        count++;
                    }

                    if (ca_giongform.Gia == null)
                    {
                        ViewBag.errorGia = "Bạn chưa nhập giá cá giống!";
                        count++;
                    }
                    else if (ca_giongform.Gia < 0)
                    {
                        ViewBag.errorGia = "Giá cá giống không được âm!";
                        count++;
                    }
                    // hien loi
                    if (count != 0)
                    {
                        var item = db.loai_ca_giong.ToList();
                        ViewBag.data = item;
                        return View();
                    }


                    //Them Ca Giong Moi
                    ca_giong ca_giong = new ca_giong();
                    //ca_giong.Ma = db.ca_giong.Max(p => p.Ma) + 1;
                    ca_giong.Ten = ca_giongform.Ten;
                    ca_giong.MoTa = ca_giongform.MoTa;
                    ca_giong.SoLuong = ca_giongform.SoLuong;
                    ca_giong.NgayTuoi = ca_giongform.NgayTuoi;
                    ca_giong.loai_ca_giong_Ma = ca_giongform.loai_ca_giong_Ma;
                    ca_giong.Gia = ca_giongform.Gia;
                    db.ca_giong.Add(ca_giong);
                    db.SaveChanges();
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Lỗi khi thêm cá giống mới");
            }
            //Cập nhật lại danh sách hiển thị
            var list = from s in db.ca_giong select s;
            return RedirectToAction("ListFish");
        }


        public ActionResult EditFish(int? id)
        {
            var list = db.ca_giong.SingleOrDefault(s => s.Ma == id);
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
        public ActionResult EditFish(int id)
        {
            var count = 0;
            var ca = db.ca_giong.Find(id);
            if (ModelState.IsValid)
            {
                
                if (Request["Ten"]== "")
                {
                    ViewBag.errorTen = "Bạn chưa nhập tên cá giống!";
                    count++;
                }
                else if (!Regex.IsMatch(Request["Ten"], "^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆ fFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTu UùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ 0-9 ]{1,150}$"))
                {
                    ViewBag.errorTen = "Tên cá giống không được chứa ký tự đặt biệt!";
                    count++;
                }
                // loi chua nhap mo ta
                if (Request["MoTa"] == "")
                {
                    ViewBag.errorMoTa = "Bạn chưa nhập mô tả cá giống!";
                    count++;
                }
                else if (!Regex.IsMatch(Request["MoTa"], "^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆ fFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTu UùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ 0-9 ]{1,150}$"))
                {
                    ViewBag.errorTen = "Tên cá giống không được chứa ký tự đặt biệt!";
                    count++;
                }
                // loi chua nhap so luong
                if (Request["SoLuong"] == "")
                {
                    ViewBag.errorSoLuong = "Bạn chưa nhập số lượng cá giống!";
                    count++;
                }
                //else if (int.Parse(Request["SoLuong"]) < 0)
                //{
                //    ViewBag.errorSoLuong = "Số lượng cá giống không được âm!";
                //    count++;
                //}
                if (Request["NgayTuoi"] == "")
                {
                    ViewBag.errorNgayTuoi = "Bạn chưa nhập ngày tuổi của cá giống!";
                    count++;
                }
                //else if (int.Parse(Request["NgayTuoi"]) < 0)
                //{
                //    ViewBag.errorNgayTuoi = "Tuổi cá giống không được âm!";
                //    count++;
                //}

                if (Request["Gia"] == "")
                {
                    ViewBag.errorGia = "Bạn chưa nhập giá cá giống!";
                    count++;
                }
                //else if (int.Parse(Request["Gia"]) < 0)
                //{
                //    ViewBag.errorGia = "Giá cá giống không được âm!";
                //    count++;
                //}

                if (count != 0)
                {
                    var item = db.loai_ca_giong.ToList();
                    ViewBag.data = item;
                    return View();
                }

                TryUpdateModel(ca, "", new string[] { "Ten", "MoTa", "SoLuong", "NgayTuoi", "loai_ca_giong_Ma","Gia" });
                db.Entry(ca).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ListFish");
        }

        //public ActionResult DeleteFish(int? id)
        //{
        //    ca_giong ca = db.ca_giong.SingleOrDefault(n => n.Ma == id);

        //    if (ca == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(ca);
        //}

        [HttpPost]
        public ActionResult DeleteFish(int id)
        {
            ca_giong ca = db.ca_giong.SingleOrDefault(n => n.Ma == id);
            db.ca_giong.Remove(ca);
            db.SaveChanges();
            return RedirectToAction("ListFish");
        }

    }
}