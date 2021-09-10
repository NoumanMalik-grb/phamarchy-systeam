using phamarchy_systeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phamarchy_systeam.Controllers
{
    public class ReportsController : Controller
    {
        Model1 db = new Model1();
        // GET: Reports
        
        public ActionResult Stockreports(FilterModel filter)
        {
            if (filter.DateTo==null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                filter.DateTo = System.DateTime.Now;

            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(filter.DateTo).ToString("s");
            }
            ViewBag.Category = db.Categories.Select(x => new SelectListItem { Value = x.Category_id.ToString(), Text = x.Category_name });
            if (filter.Category==null)
            {
                ViewBag.Product = db.Products.Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_name });
            }
            else
            {
                ViewBag.Product = db.Products.Where(x => x.Category_fid == filter.Category).Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_name });
            }
            var p = db.Products.ToList();
            if (filter.Category!=null)
            {
                p = db.Products.Where(x => x.Category_fid == filter.Category).ToList();
            }
            if (filter.Product!=null)
            {
                p = db.Products.Where(x => x.Product_id == filter.Product).ToList();
            }

            return View(p);
        }


        public ActionResult PurchasedReports(FilterModel f)
        {
            if (f.DateFrom==null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                f.DateFrom = System.DateTime.Today;
            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(f.DateFrom).ToString("s");
            }
            if (f.DateTo==null)
            {
                ViewBag.DateTo = System.DateTime.Today.ToString("s");
                ViewBag.DateTo = System.DateTime.Today;

            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(f.DateTo).ToString("s");
            }
            ViewBag.Category = db.Categories.Select(x => new SelectListItem { Value = x.Category_id.ToString(), Text = x.Category_name });
            if (f.Category==null)
            {
                ViewBag.Product = db.Products.Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_name });
            }
            else
            {
                ViewBag.Product = db.Products.Where(x => x.Category_fid == f.Category).Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_name });
            }
            var od = db.Order_details.Select(x => x.Order_fid).ToList();
            if (f.Category!=null)
            {
                var p = db.Products.Where(i => i.Category_fid == f.Category).Select(i => i.Product_id).ToList();
                if (f.Product!=null)
                {
                    p = db.Products.Where(i => i.Product_id == f.Product).Select(i => i.Product_id).ToList();
                }
                od = db.Order_details.Where(x => p.Contains(x.Product_fid)).Select(x => x.Order_fid).ToList();
            }
            var sr = db.Orders.Where(s => s.Order_Type == "Purchased" & s.Order_date_time >= f.DateFrom & s.Order_date_time <= f.DateTo & od.Contains(s.Order_id)).OrderByDescending(x => x.Order_id).ToList();
            return View(sr);
        }
        public ActionResult ProfitandLossReports(FilterModel filter)
        {
            if (filter.DateFrom==null)
            {
                ViewBag.Datefrom = System.DateTime.Today.ToString("s");
                ViewBag.Datefrom = System.DateTime.Today;
            }
            else
            {
                ViewBag.Datefrom = Convert.ToDateTime(filter.DateFrom).ToString("s");
            }
            if (filter.DateTo==null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                ViewBag.DateTo = System.DateTime.Now;
            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(filter.DateTo).ToString("s");
            }
            ViewBag.Category = db.Categories.Select(x => new SelectListItem { Value = x.Category_id.ToString(), Text = x.Category_name });
            if (filter.Category==null)
            {
                ViewBag.Product = db.Products.Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_name });
            }
            else
            {
                ViewBag.Product = db.Products.Where(x => x.Category_fid == filter.Category).Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_name });
            }
            var od = db.Order_details.Select(x => x.Order_fid).ToList();
            if (filter.Category!=null)
            {
                var p = db.Products.Where(i => i.Category_fid == filter.Category).Select(i=> i.Product_id).ToList();
                if (filter.Product!=null)
                {
                    p = db.Products.Where(i => i.Product_id == filter.Product).Select(i => i.Product_id).ToList();
                }
                od = db.Order_details.Where(i => p.Contains(i.Product_fid)).Select(i => i.Order_fid).ToList();
            }
            var sr = db.Orders.Where(x => x.Order_Type == "Sale" & x.Order_date_time >= filter.DateFrom & x.Order_date_time <= filter.DateTo & od.Contains(x.Order_id)).OrderByDescending(x => x.Order_id).ToList();
            return View(sr);
        }
        public ActionResult SaleReport(FilterModel f)
        {

            if (f.DateFrom== null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                f.DateFrom = System.DateTime.Today;
            }
            else
                ViewBag.DateFrom = Convert.ToDateTime(f.DateFrom).ToString("s");
            if (f.DateTo == null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                f.DateTo = System.DateTime.Now;
            }
            else
                ViewBag.DateTo = Convert.ToDateTime(f.DateTo).ToString("s");

            ViewBag.Category = db.Categories.Select(x => new SelectListItem { Value = x.Category_id.ToString(), Text = x.Category_name });
            if (f.Category == null)
            {
                ViewBag.Product = db.Products.Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_name });
            }
            else
                ViewBag.Product = db.Products.Where(x => x.Category_fid == f.Category).Select(x => new SelectListItem { Value = x.Product_id.ToString(), Text = x.Product_name });


            var od = db.Order_details.Select(x => x.Order_fid).ToList();
            if (f.Category != null)
            {
                var p = db.Products.Where(x => x.Category_fid == f.Category).Select(x => x.Product_id).ToList();
                if (f.Product != null)
                {

                    p = db.Products.Where(x => x.Product_id == f.Product).Select(x => x.Product_id).ToList();
                }

                od = db.Order_details.Where(x => p.Contains(x.Product_fid)).Select(x => x.Order_fid).ToList();

            }
            var o = db.Orders.Where(x => x.Order_Type == "Sale" & x.Order_date_time >= f.DateFrom & x.Order_date_time <= f.DateTo & od.Contains(x.Order_id)).ToList();

            return View(o);
        }
        public ActionResult PurchasedReturnReports(FilterModel PRmodel)
        {
            if (PRmodel.DateFrom==null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                PRmodel.DateFrom = System.DateTime.Now;
            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(PRmodel.DateFrom).ToString("s");
            }
            if (PRmodel.DateTo==null)
            {
                ViewBag.DateTo = System.DateTime.Today.ToString("y");
                ViewBag.DateTo = System.DateTime.Now;
            }
            else
            {
                  //ViewBag.DateTo=Convert.date
            }

            return View();
        }
        public ActionResult saleReturnReport()
        {
            return View();
        }
        public ActionResult invoice(int id)
        {
            ViewBag.id =id;
            
            return View();
                
        }
        

    }
}