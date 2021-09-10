using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using phamarchy_systeam.Models;
using System.Web.Mvc;

namespace phamarchy_systeam.Controllers
{
    public class SaleReturn1Controller : Controller
    {
        Model1 db = new Model1();
        public ActionResult SaleReturnCart()
        {
            return View();
        }
        //public ActionResult Addtocart(int id)
        //{
        //    Product p = new Product();
        //    p.quantity = 5;
        //    List<Product> Rlist = new List<Product>();
        //    Rlist.Add(db.Products.Where(x => x.Product_id == id).FirstOrDefault());
        //    Session["productReturn"] = Rlist;
        //    return RedirectToAction("SaleReturnCart");
        //}

        public ActionResult AddTocart(int id, int quantity)
        {
            List<Product> Rlist = new List<Product>();
            if (Session["productReturn"] != null)
            {

                Rlist = (List<Product>)Session["productReturn"];
            }
            bool ProductExsit = false;
            foreach (var item in Rlist)
            {
                if (id == item.Product_id)
                {
                    ProductExsit = true;
                    item.Rquantity++;
                }
            }
            if (ProductExsit == false)
            {
                Product pro = db.Products.Where(p => p.Product_id == id).FirstOrDefault();
                Rlist.Add(pro);
                Rlist[0].Rquantity = quantity;
            }
            Session["productReturn"] = Rlist;
            return RedirectToAction("SaleReturnCart");
        }

    }
}