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
        // GET: Fish
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult FishType()
        {
            //var data = from s in db.loai_ca_giong select s;
            return View();
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

    }
}