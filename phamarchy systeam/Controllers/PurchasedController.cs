using phamarchy_systeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phamarchy_systeam.Controllers
{
    public class PurchasedController : Controller
    {
        Model1 db = new Model1();
        
        // GET: Purchased
        public ActionResult PurchasedProduct()
        {
            ViewBag.Supplier_fid = new SelectList(db.Supplier_details, "Supplier_id", "Supplier_name");

            return View();
        }

        [HttpPost]
        public ActionResult PurchasedProduct(int id, int quantity)
        {
            List<Product> plist;
            if (Session["product"] == null)
            {
                plist = new List<Product>();
            }
            else
            {
                plist = (List<Product>)Session["product"];
            }
            bool ProductExsit = false;
            foreach (var item in plist)
            {
                if (id == item.Product_id)
                {
                    ProductExsit = true;
                    item.quantity++;
                }
            }
            if (ProductExsit == false)
            {
                plist.Add(db.Products.Where(p => p.Product_id == id).FirstOrDefault());
                plist[plist.Count - 1].quantity = Convert.ToInt32(quantity);
            }
            Session["product"] = plist;
            ViewBag.Supplier_fid = new SelectList(db.Supplier_details, "Supplier_id", "Supplier_name");
            return PartialView("_purchasedProduct");
        }
        public ActionResult plus(int Rowno)
        {
            List<Product> plist = (List<Product>)Session["product"];

            plist[Rowno].quantity+=7;

            Session["product"] = plist;
            return RedirectToAction("PurchasedProduct");
        }
        public ActionResult Minus(int Rowno)
        {
            List<Product> mlist = (List<Product>)Session["product"];
            mlist[Rowno].quantity--;
            if (mlist[Rowno].quantity == 0)
            {
                mlist.RemoveAt(Rowno);
            }
            Session["product"] = mlist;
            return RedirectToAction("PurchasedProduct");

        }
        public ActionResult payno(Order od)
        {
            od.Order_date_time = System.DateTime.Now;
            od.Order_status = "paid";
            od.Order_Type = "Purchased";
            Session["order"] = od;
            if (Session["Admin"] != null)
            {
                User_details c = (User_details)Session["Admin"];
                od.User_fid = c.User_id;
            }
            db.Orders.Add(od);
            db.SaveChanges();

            List<Product> p = (List<Product>)Session["product"];
            for (int i = 0; i < p.Count; i++)
            {
                Order_details or = new Order_details();
                int orderid = db.Orders.Max(x => x.Order_id);
                or.Order_fid = orderid;
                or.Product_fid = p[i].Product_id;
                or.Product_qlty = p[i].quantity * -1;
                or.Product_sale_price =Convert.ToDecimal( p[i].Product_Sale_price);
                or.Product_purchase_price =Convert.ToDecimal( p[i].Product_Purchase_price);
                db.Order_details.Add(or);
                db.SaveChanges();
                Session["product"] = null;
            }

            return RedirectToAction("PurchasedProduct", "Purchased");
        }
        //working for the purchase return start
        public ActionResult PurchasedReturn(int? se)
        {
            if (se!=null)
            {
                ViewBag.message = se;
                return View();
            }
            else
            {
                var total = db.Orders.ToList();
                return View(total);
            }
        }

        public ActionResult PurchasedReturnInvoice(int PRid)
        {
            Session["PReturn"] = PRid;
            return View();
        }
        public ActionResult PurchaseddReturnAddToCart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseddReturnAddToCart(int? id , int Detail_id, int quantity)
        {
            List<Product> PRlist;
            if (Session["PurcahsedReturnProduct"]==null)
            {
                PRlist = new List<Product>(); 
            }
            else
            {
                PRlist = (List<Product>)Session["PurcahsedReturnProduct"];
            }
            bool productexit = false;
            foreach (var item in PRlist)
            {
                if (id==item.Product_id)
                {
                    productexit = true;
                    item.quantity++;
                }
            }
            if (productexit==false)
            {
                PRlist.Add(db.Products.Where(x => x.Product_id == id).FirstOrDefault());
                PRlist[PRlist.Count - 1].quantity = Convert.ToInt32(quantity);
            }
            
            Session["PurcahsedReturnProduct"] = PRlist;

            return RedirectToAction("PurchaseddReturnAddToCart");
        }
        public ActionResult PurchasedMinus(int Rowno)
        {
            List<Product> prminus = (List<Product>)Session["PurcahsedReturnProduct"];
            prminus[Rowno].quantity--;
            if (prminus[Rowno].quantity==0)
            {
                prminus.RemoveAt(0);
            }
            Session["PurcahsedReturnProduct"] = prminus;
            return RedirectToAction("PurchaseddReturnAddToCart");
        }
        public ActionResult PurchasedPlus(int Rowno)
        {
            List<Product> PrPlus = (List<Product>)Session["PurcahsedReturnProduct"];
            PrPlus[Rowno].quantity++;
            Session["PurcahsedReturnProduct"] = PrPlus;
            return RedirectToAction("PurchaseddReturnAddToCart");
        }
        public ActionResult PurchasedRemove(int Rowno)
        {
            List<Product> PrRemove = (List<Product>)Session["PurcahsedReturnProduct"];
            PrRemove.RemoveAt(Rowno);
            return RedirectToAction("PurchaseddReturnAddToCart");
        }

        public ActionResult PurchasedReturnPay()
        {
            int PRid = (int)Session["PReturn"];
            Order d = new Order();
            d.Order_FID_Return = PRid;
            d.Order_date_time = System.DateTime.Now;
            d.Order_status = "paid";
            d.Order_Type = "PurchasedReturn";
            Session["PurchasedReturn"] = d;
            if (Session["Admin"]!=null)
            {
                User_details u = (User_details)Session["Admin"];
                d.User_fid = u.User_id;
            }
            db.Orders.Add(d);
            db.SaveChanges();
            List<Product> p = (List<Product>)Session["PurcahsedReturnProduct"];
            for (int i = 0; i < p.Count; i++)
            {
                Order_details od = new Order_details();
                int orderid = db.Orders.Max(x => x.Order_id);
                od.Order_fid = orderid;
                od.Product_fid = p[i].Product_id;
                od.Product_qlty = p[i].quantity * -1;
                od.Product_sale_price = Convert.ToDecimal(p[i].Product_Sale_price);
                od.Product_purchase_price = Convert.ToDecimal(p[i].Product_Purchase_price);
                db.Order_details.Add(od);
                db.SaveChanges();
                Session["PurcahsedReturnProduct"] = null;
              
            }
            return RedirectToAction("PurchasedProduct");
        }

    }
}