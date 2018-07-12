using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CylnderEntities;

namespace IndoGhana.Areas.Login.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: Login/UserLogin
        IndoGhanaEntities InventoryEntities = new IndoGhanaEntities();
        public ActionResult Index()
        {

            
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDetails login)
        {
            try
            {
                TryUpdateModel(login);
                string username = Request["username"];
                string password = Request["password"];
                //USP_GetUserDetails_Result logindetails= InventoryEntities.USP_GetUserDetails(login.UserName, login.Password, login.Phone).FirstOrDefault();
                USP_GetUserDetails_Result logindetails = InventoryEntities.USP_GetUserDetails(username, password, "").FirstOrDefault();
                // return View();
                Session["logindetails"] = logindetails;
                return RedirectToAction("Index", "CylinderDetails", new { area = "CylinderDetails" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult ListUsers()
        {
            return View();
        }
        public ActionResult ListUsersDetails()
        {
            List<usp_tblUserMasterGet_Result> users = new List<usp_tblUserMasterGet_Result>();
            users = InventoryEntities.usp_tblUserMasterGet().ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public ActionResult ListUsers(FormCollection frm)
        {
            return View();
        }

        public ActionResult EditUser(int User_Id)
        {
            usp_tblUserMasterGetByID_Result userdetails= InventoryEntities.usp_tblUserMasterGetByID(User_Id).FirstOrDefault();
            return View(userdetails);
        }
        [HttpPost]
        public ActionResult EditUser(FormCollection frm)
        {
            return RedirectToAction("Index");
        }
        public ActionResult CreateUserDetails()
        {
            return View();
        }
       [HttpPost]
        public ActionResult CreateUserDetails(FormCollection frm)
        {
            return View();
        }
    }
}