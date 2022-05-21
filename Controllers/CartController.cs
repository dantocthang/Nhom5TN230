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
            var productOrder = db.ca_giong.Find(id);
            string ThongBao = "";
            if (Session["ShoppingCart"] == null)
            {


                //Create New Shopping Cart Session 

                listCartItem = new List<CartItem>();
                if (Quantity <= productOrder.SoLuong)
                {
                    listCartItem.Add(new CartItem { Quantity = Quantity, productOrder = productOrder });
                    Session["ShoppingCart"] = listCartItem;
                }
                else
                {
                    ThongBao = "Bạn đã đặt quá số lượng hiện có của cá này!";
                }


            }
            else
            {
                bool flag = false;
                listCartItem = (List<CartItem>)Session["ShoppingCart"];
                foreach (CartItem item in listCartItem)
                {
                    if (item.productOrder.Ma == id)
                    {
                        if (Quantity + item.Quantity <= item.productOrder.SoLuong)
                        {
                            item.Quantity += Quantity; flag = true;
                        }
                        else ThongBao = "Bạn đã đặt quá số lượng hiện có của cá này!";
                        break;

                    }
                }

                if (!flag && ThongBao == "")
                    if (Quantity <= productOrder.SoLuong)
                    {
                        listCartItem.Add(new CartItem { Quantity = Quantity, productOrder = productOrder });


                    }
                    else ThongBao = "Bạn đã đặt quá số lượng hiện có của cá này!";
                Session["ShoppingCart"] = listCartItem;
            }

            int cartcount = 0;
            List<CartItem> ls = (List<CartItem>)Session["ShoppingCart"];
            if (ls != null)
            {
                foreach (CartItem item in ls)
                {
                    cartcount += 1;
                }
            }
            return Json(new { ItemAmount = cartcount, ThongBao = ThongBao }, JsonRequestBehavior.AllowGet);

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

        public JsonResult CartAmount()
        {
            int cartcount = 0;
            List<CartItem> ls = (List<CartItem>)Session["ShoppingCart"];
            if (ls != null)
            {
                foreach (CartItem item in ls)
                {
                    cartcount += 1;
                }
            }
            return Json(new { Count = cartcount }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClearCart()
        {
            Session.Remove("ShoppingCart");
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteFish(int id)
        {
            List<CartItem> ls = (List<CartItem>)Session["ShoppingCart"];
            if (ls != null)
            {
                foreach (CartItem item in ls)
                {
                    if (item.productOrder.Ma == id)
                    {
                        ls.Remove(item);
                        Session["ShoppingCart"] = ls;
                        break;

                    }
                }
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}