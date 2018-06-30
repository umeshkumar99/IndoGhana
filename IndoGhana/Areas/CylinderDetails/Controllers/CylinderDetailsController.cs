using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CylnderEntities;

namespace IndoGhana.Areas.CylinderDetails.Controllers
{
    public class CylinderDetailsController : Controller
    {
        // GET: CylinderDetails/CylinderDetails
        IndoGhanaEntities InventoryEntities = new IndoGhanaEntities();
        public ActionResult Index()
        {
            List<usp_CylinderMasterGet_Result> cylinderlist = new List<usp_CylinderMasterGet_Result>();
            try
            {
             
                cylinderlist = InventoryEntities.usp_CylinderMasterGet().ToList();
                return View(cylinderlist);
            }
                
            catch(Exception ex)
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Edit(string cylindernumber)
        {
            usp_CylinderMasterGetByID_Result cylinderDetails = new usp_CylinderMasterGetByID_Result();
            try
            {

                cylinderDetails = InventoryEntities.usp_CylinderMasterGetByID(cylindernumber).FirstOrDefault();
                return View(cylinderDetails);
            }

            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(FormCollection frm)
        {
            return RedirectToAction("Index");

        }
    }
}
