using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CylnderEntities;

namespace IndoGhana.Areas.Masters.Controllers
{
    public class CustomerController : Controller
    {
        IndoGhanaEntities InventoryEntities = new IndoGhanaEntities();
        // GET: Masters/Customer
        public ActionResult Index()
        {
            if (Session["logindetails"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Index", "UserLogin", new { area = "Login" });
            }
            return View();
        }
        public ActionResult CustomerList()
        {
            if (Session["logindetails"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Index", "UserLogin", new { area = "Login" });
            }

        try {

               List<usp_CustomerMasterGet_Result> customerList = InventoryEntities.usp_CustomerMasterGet().ToList();
                return Json(customerList, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            { return View("Index"); }
        }

        public ActionResult CustomerSiteList(int id)
        {
            if (Session["logindetails"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Index", "UserLogin", new { area = "Login" });
            }

            try
            {

                List<usp_CustomerSiteMasterGetbyID_Result> siteList = InventoryEntities.usp_CustomerSiteMasterGetbyID(id).ToList();
                return Json(siteList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            { return View("Index"); }
        }


       public ActionResult CreateCustomerDetails()
        {
            if (Session["logindetails"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Index");
            }
           
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomerDetails(FormCollection frm)
        {
            try { 
            usp_CustomerMasterGetbyID_Result customerdetails = new usp_CustomerMasterGetbyID_Result();
            TryUpdateModel(customerdetails);
            USP_GetUserDetails_Result logindetails;
            //if (Session["logindetails"] != null)
            //{
            logindetails = (USP_GetUserDetails_Result)Session["logindetails"];
            // }
            string result = (string)InventoryEntities.usp_CustomerMasterInsertUpdate(0, customerdetails.CustomerName, customerdetails.CustomerAddress, customerdetails.ContactPersonName, customerdetails.ContactNumber
                , customerdetails.Email, logindetails.Branch_Id, logindetails.Company_Id, logindetails.USer_Id, 0, DateTime.Now, customerdetails.status, customerdetails.IsOwner).FirstOrDefault();
            if (result == "Duplicate")
            {

                ModelState.AddModelError("Error", "Customer already exists");

                return View();
            }
            else if (result == "Duplicate mobile")
            {

                ModelState.AddModelError("Error", "Mobile No. already exists");


                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }



        public ActionResult CreateCustomerSiteDetails()
        {
            if (Session["logindetails"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Index");
            }
             FillViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomerSiteDetails(FormCollection frm)
        {
            try
            {
                //test
                return RedirectToAction("Index");
            }

            
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        private void FillViewBag()
        {
            ViewBag.CustomerID = new SelectList(InventoryEntities.usp_CustomerListGet(), "CustomerID", "CustomerName");
        }

        }
    }