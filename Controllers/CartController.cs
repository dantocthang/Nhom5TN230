using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom5TN230.Models;

namespace Nhom5TN230.Controllers
{
    
    public class CartController : Controller
    {
        FishMarketEntities db = new FishMarketEntities();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddToCart(int id, int Quantity)
        {
            List<CartItem> listCartItem;
            if (Session["ShoppingCart"] == null)
            {
                //Create New Shopping Cart Session 
                listCartItem = new List<CartItem>();
                listCartItem.Add(new CartItem { Quantity = Quantity, productOrder = db.ca_giong.Find(id) });
                Session["ShoppingCart"] = listCartItem;
            }
            else
            {
                bool flag = false;
                listCartItem = (List<CartItem>)Session["ShoppingCart"];
                foreach (CartItem item in listCartItem)
                {
                    if (item.productOrder.Ma == id)
                    {
                        item.Quantity+=Quantity; flag = true;
                        break;
                    }
                }

                if (!flag)
                    listCartItem.Add(new CartItem { Quantity = Quantity, productOrder = db.ca_giong.Find(id) });

                Session["ShoppingCart"] = listCartItem;
            }
            
            int cartcount = 0;
            List<CartItem> ls = (List<CartItem>)Session["ShoppingCart"];
            foreach (CartItem item in ls)
            {
                cartcount += 1;
            }
            return Json(new { ItemAmount = cartcount }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CartQuick()
        {
            if (Session["ShoppingCart"] != null)
            {
                var listCartItem = (List<CartItem>)Session["ShoppingCart"];
                return View(listCartItem);
            }
            return View();
        }


        public ActionResult CartDetail()
        {
            if (Session["ShoppingCart"] != null)
            {
                var listCartItem = (List<CartItem>)Session["ShoppingCart"];
                return View(listCartItem);
            }
            return View();
        }
    }
}