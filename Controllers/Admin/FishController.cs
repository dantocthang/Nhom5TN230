using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Nhom5TN230.Controllers.Admin
{


    public class FishController : Controller
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

        public ActionResult FishType()
        {
            //var data = from s in db.loai_ca_giong select s;
            if (CheckRole(1) == 1)
                return View();
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");
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
            if (CheckRole(1) == 1)
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


            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult EditFishType(int id)
        {
            if (CheckRole(1) == 1)
            {
                var ft = db.loai_ca_giong.Find(id);
                return View(ft);
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");

        }

        [HttpPost, ActionName("EditFishType")]
        public ActionResult EditFishTypePost(int id)
        {
            if (CheckRole(1) == 1)
            {
                var data = new loai_ca_giong();
                try
                {
                    if (ModelState.IsValid)
                    {
                        data = db.loai_ca_giong.Find(id);
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
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");

        }



        public ActionResult DeleteFishType(int Ma)
        {
            if (CheckRole(1) == 1)
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
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");

        }



        // Section Cá giống
        public ActionResult ListFish()
        {
            if (CheckRole(1) == 1)
            {
                var list = from s in db.ca_giong select s;
                return View(list);
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");

        }




        public ActionResult CreateFish()
        {
            if (CheckRole(1) == 1)
            {
                var item = db.loai_ca_giong.ToList();
                ViewBag.data = item;
                return View();
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");

        }

        [HttpPost, ActionName("CreateFish")]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult CreateFish(ca_giong ca_giongform, List<HttpPostedFileBase> image)
        {
            if (CheckRole(1) == 1)
            {
                var count = 0;
                string[] imageNames = new string[] { };
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

                        // nhieu hinh anh
                        foreach (var item in image)
                        {

                            if (item != null)
                            {
                                var fileName = Path.GetFileName(item.FileName);
                                var path = Path.Combine(HttpContext.Server.MapPath("~/Content/assets/img/products/"), (db.ca_giong.Max(p => p.Ma) + 1) + fileName);
                                Array.Resize(ref imageNames, imageNames.Length + 1);
                                imageNames[imageNames.GetUpperBound(0)] = (db.ca_giong.Max(p => p.Ma) + 1) + fileName;
                                if (System.IO.File.Exists(path))
                                {
                                    ViewBag.errorHinh = "Hình ảnh đã tồn tại!";
                                    count++;
                                }
                                else if (count == 0)
                                {
                                    item.SaveAs(path);
                                }
                            }
                            else
                            {
                                ViewBag.errorHinh = "Bạn chưa thêm hình ảnh cá giống!";
                                count++;
                            }
                        }

                        // hien loi
                        if (count != 0)
                        {
                            var item = db.loai_ca_giong.ToList();
                            ViewBag.data = item;
                            return View();
                        }

                        //Them ca giong moi
                        ca_giong ca_giong = new ca_giong();

                        ca_giong.Ten = ca_giongform.Ten;
                        ca_giong.MoTa = ca_giongform.MoTa;
                        ca_giong.SoLuong = ca_giongform.SoLuong;
                        ca_giong.NgayTuoi = ca_giongform.NgayTuoi;
                        ca_giong.loai_ca_giong_Ma = ca_giongform.loai_ca_giong_Ma;
                        ca_giong.Gia = ca_giongform.Gia;
                        db.ca_giong.Add(ca_giong);
                        db.SaveChanges();


                        var i = 0;
                        // luu nhieu anh vao database
                        foreach (var item in image)
                        {

                            hinh_anh hinh = new hinh_anh();
                            hinh.Ten = imageNames[i];
                            i++;
                            hinh.ca_giong_Ma = db.ca_giong.Max(p => p.Ma);
                            db.hinh_anh.Add(hinh);
                            db.SaveChanges();
                        }
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
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");

        }



        public ActionResult EditFish(int? id)
        {
            if (CheckRole(1) == 1)
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
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");

        }

        [HttpPost, ActionName("EditFish")]
        [ValidateInput(false)]
        public ActionResult EditFish(int id)
        {
            if (CheckRole(1) == 1)
            {
                var count = 0;
                var ca = db.ca_giong.Find(id);
                if (ModelState.IsValid)
                {

                    if (Request["Ten"] == "")
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

                    TryUpdateModel(ca, "", new string[] { "Ten", "MoTa", "SoLuong", "NgayTuoi", "loai_ca_giong_Ma", "Gia" });
                    db.Entry(ca).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("ListFish");
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");

        }



        [HttpPost]
        public ActionResult DeleteFish(int id)
        {
            if (CheckRole(1) == 1)
            {
                ca_giong ca = db.ca_giong.SingleOrDefault(n => n.Ma == id);
                if (ca == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }

                //var ca_hinh = ca.hinh_anh.ToList();
                var ca_hinh = ca.hinh_anh.ToList();
                if (ca_hinh != null)
                {
                    foreach (var item in ca_hinh)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/assets/img/products/"), item.Ten);

                        //Xoá ảnh trong thư mục ~/Content/assets/img/products/
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                            db.hinh_anh.Remove(item);
                        }
                    }

                }
                db.ca_giong.Remove(ca);
                db.SaveChanges();

                return RedirectToAction("ListFish");
            }
            else if (CheckRole(1) == 2)
                return RedirectToAction("Index", "Admin");
            else return RedirectToAction("Index", "Home");



        }




    }
}