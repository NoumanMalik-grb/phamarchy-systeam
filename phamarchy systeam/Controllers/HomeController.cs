using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using phamarchy_systeam.Models;
namespace phamarchy_systeam.Controllers
{

    public class HomeController : Controller
    {
        Model1 db = new Model1();
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           
           
            return View();
        }

        [HttpPost]
        public ActionResult about(int id, int quantity)
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

            return PartialView("_about");
        }

        public ActionResult plus(int Rowno)
        {
            List<Product> plist = (List<Product>)Session["product"];
             
                plist[Rowno].quantity++;
         
            Session["product"] = plist;
            return RedirectToAction("about");
        }
        public ActionResult Minus(int Rowno)
        {
            List<Product> mlist = (List<Product>)Session["product"];
            mlist[Rowno].quantity--;
            if (mlist[Rowno].quantity==0)
            {
                mlist.RemoveAt(Rowno);
            }
            Session["product"] = mlist;
            return RedirectToAction("About");

        }
        public ActionResult SaleReturn()
        {
            return View();
        }    
        [HttpPost]
        public ActionResult SaleReturn(int? s)
        {
           
            if (s!=null)
            {
               
                ViewBag.s = s;
                return View();
                
            }
            else
            {
                var sub = db.Orders.ToList();
                return View(sub);
                
            }

        }
        public ActionResult payno(Order od)
        {
            od.Order_date_time = System.DateTime.Now;
            od.Order_status = "paid";
            od.Order_Type = "Sale";
            Session["order"] = od;
            if (Session["seller"]!=null)
            {
                User_details c = (User_details)Session["seller"];
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
                or.Product_sale_price = Convert.ToDecimal( p[i].Product_Sale_price);
                or.Product_purchase_price =Convert.ToDecimal( p[i].Product_Purchase_price);
                db.Order_details.Add(or);
                db.SaveChanges();
                Session["product"] = null;
            }

           return RedirectToAction("About","Home");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User_details user)
        {
            User_details u = db.User_details.Where(x => x.User_email == user.User_email && x.User_password == user.User_password).FirstOrDefault();
            if (u!=null)
            {
                if (u.User_type=="seller")
                {
                    Session["seller"] = u;
                    return RedirectToAction("About", "Home");
                }
                else
                {
                    Session["Admin"] = u;
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ViewBag.message = "user name or password invalid";
                return View();
            }
            

        }
       
        public ActionResult ReturnInvoice(int fid)
        {
          
            Session["id"] = fid;            
            return View();
        }
        public ActionResult SaleReturnCart()
        {
            return View();
        }
        public ActionResult AddtoCart(int id,int Detail_id, int quantity)
       {
           Order_details od= db.Order_details.Where(x => x.Od_id == Detail_id).FirstOrDefault();
            //if (od.Product_qlty < quantity)
            //{
            //    TempData["message"] = "Wrong Value";
            //    return RedirectToAction("ReturnInvoice",new { fid=od.Order_fid});
            //}
            List<Product> Rlist;
            if (Session["ReturnProduct"]==null)
            {
                Rlist = new List<Product>();
            }
            else
            {
                Rlist = (List<Product>)Session["ReturnProduct"];
            }
            bool ProducrExit = false;
            foreach (var item in Rlist)
            {
                if (id==item.Product_id)
                {
                    ProducrExit = true;
                    item.quantity++;
                }
                
            }
            if (ProducrExit == false)
            {
                Rlist.Add(db.Products.Where(x => x.Product_id == id).FirstOrDefault());
                Rlist[Rlist.Count - 1].quantity = Convert.ToInt32(quantity);
            }
            Session["ReturnProduct"] = Rlist;
            return RedirectToAction("SaleReturnCart");
        }
        public ActionResult Rplus(int RowNo)
        {
            List<Product> pluslist = (List<Product>)Session["ReturnProduct"];
            pluslist[RowNo].quantity++;
            Session["ReturnProduct"] = pluslist;
            return RedirectToAction("SaleReturnCart");
        }
        public ActionResult RMinus(int RowNo)
        {
            List<Product> minuslist = (List<Product>)Session["ReturnProduct"];
            minuslist[RowNo].quantity--;
            if (minuslist[RowNo].quantity==0)
            {
                minuslist.RemoveAt(RowNo);
            }
            Session["ReturnProduct"] = minuslist;
            return RedirectToAction("SaleReturnCart");
        }
        public ActionResult SRemove(int RowNo)
        {
            List<Product> removelist = (List<Product>)Session["ReturnProduct"];
            Session["ReturnProduct"] = removelist;
            removelist.RemoveAt(RowNo);
            return RedirectToAction("SaleReturnCart");
        }
        public ActionResult Returnpayno()
        {
            int RfID = (int)Session["id"];
            Order Rod = new Order();
            Rod.Order_FID_Return = RfID;
            Rod.Order_date_time = System.DateTime.Now;
             Rod.Order_status = "paid";
            Rod.Order_Type = "SaleReturn";
           
          
            Session["ReturnOrder"] = Rod;
            if (Session["seller"] != null)
            {
                User_details u = (User_details)Session["seller"];
                Rod.User_fid = u.User_id;
            }
           
            db.Orders.Add(Rod);
            db.SaveChanges();
            List<Product> p = (List<Product>)Session["ReturnProduct"];
            for (int i = 0; i < p.Count; i++)
            {
                Order_details od = new Order_details();
                int orderid = db.Orders.Max(x => x.Order_id);
                od.Order_fid = orderid;
                od.Product_fid = p[i].Product_id;
                od.Product_qlty = p[i].quantity * +1;
                od.Product_sale_price = Convert.ToDecimal(p[i].Product_Sale_price);
                od.Product_purchase_price = Convert.ToDecimal(p[i].Product_Purchase_price);
                db.Order_details.Add(od);
                db.SaveChanges();
                Session["ReturnProduct"] = null;
            }
            return RedirectToAction("about");
        }
    }
}