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
            return View();
        }
        [HttpGet]

        public ActionResult GetCylinderList()
        {
            List<usp_CylinderMasterGet_Result> cylinderlist = new List<usp_CylinderMasterGet_Result>();
            try
            {
             
                cylinderlist = InventoryEntities.usp_CylinderMasterGet().ToList();
                return Json(cylinderlist, JsonRequestBehavior.AllowGet);
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
                FillViewBag();
                ViewBag.VendorBranchID = new SelectList(InventoryEntities.usp_VendorBranchListGet(cylinderDetails.VendorID), "VendorBranchID", "VendorBranchName");
                return View(cylinderDetails);
            }

            catch (Exception ex)
            {
                return View();
            }
        }

       

        public JsonResult getBranch(int id)
        {
            List<SelectListItem> BranchSelectList = new List<SelectListItem>();
            List<usp_VendorBranchListGet_Result> BranchList = new List<usp_VendorBranchListGet_Result>();
            //AddressModel address = new AddressModel();
            BranchList=InventoryEntities.usp_VendorBranchListGet(id).ToList();
            BranchList.ForEach(x =>
            {
                BranchSelectList.Add(new SelectListItem { Text = x.VendorBranchName, Value = x.VendorBranchID.ToString() });
            });
            return Json(new SelectList(BranchSelectList, "Value", "Text", JsonRequestBehavior.AllowGet));
            }

        
        [HttpPost]
        public ActionResult Edit(FormCollection frm)
        {

            try
            {
                usp_CylinderMasterGetByID_Result cylinder = new usp_CylinderMasterGetByID_Result();
                TryUpdateModel(cylinder);
                //bool b= int.TryParse(frm["WLCapacityUOMID"], out re);
                object result = InventoryEntities.usp_CylinderMasterInsertUpdate(cylinder.CylindeNumber, cylinder.CylindeNumber, cylinder.ManufacturerID,
                    cylinder.PurchaseDate, cylinder.InitialGasID, cylinder.WLCapacity,
                    cylinder.WLCapacityUOMID, cylinder.WorkingPressure, cylinder.WorkingPressureUOMID,
                    cylinder.TestDate, cylinder.NextTestDate, cylinder.ValveModelID,
                    cylinder.PresentStateID, cylinder.GasInUseID, cylinder.VendorBranchID,
                    cylinder.Size, cylinder.SizeUOMID, cylinder.CurrentLocationID, 1, 1, 1, 1, cylinder.status);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Detail(string cylindernumber)
        {
            usp_CylinderMasterGetByID_Result cylinderDetails = new usp_CylinderMasterGetByID_Result();
            cylinderDetails = InventoryEntities.usp_CylinderMasterGetByID(cylindernumber).FirstOrDefault();
            return View(cylinderDetails);
        }
        public ActionResult printbarcode(string cylindernumber)
        {
            usp_CylinderMasterGetBarcodeImage_Result barcodeImage = new usp_CylinderMasterGetBarcodeImage_Result();
            barcodeImage = InventoryEntities.usp_CylinderMasterGetBarcodeImage(cylindernumber).FirstOrDefault();
            return View(barcodeImage);
        }
        [HttpGet]
        public ActionResult CreateCylinderDetails()
        {
            FillViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCylinderDetails(FormCollection frm)
        {
            try
            {
                usp_CylinderMasterGetByID_Result cylinder = new usp_CylinderMasterGetByID_Result();
                TryUpdateModel(cylinder);
                //bool b= int.TryParse(frm["WLCapacityUOMID"], out re);
                object result = InventoryEntities.usp_CylinderMasterInsertUpdate(cylinder.CylindeNumber, cylinder.CylindeNumber, cylinder.ManufacturerID,
                    cylinder.PurchaseDate, cylinder.InitialGasID, cylinder.WLCapacity,
                    cylinder.WLCapacityUOMID, cylinder.WorkingPressure, cylinder.WorkingPressureUOMID,
                    cylinder.TestDate, cylinder.NextTestDate, cylinder.ValveModelID,
                    cylinder.PresentStateID, cylinder.GasInUseID, cylinder.VendorBranchID,
                    cylinder.Size, cylinder.SizeUOMID, cylinder.CurrentLocationID, 1, 1, 1, 1, cylinder.status);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        private void FillViewBag()
        {
            ViewBag.InitialGasID = new SelectList(InventoryEntities.usp_tblStatusMasterGetByType(4), "StatusID", "statusDesc");
            ViewBag.WLCapacityUOMID = new SelectList(InventoryEntities.usp_tblStatusMasterGetByType(7), "StatusID", "statusDesc");
            ViewBag.WorkingPressureUOMID = new SelectList(InventoryEntities.usp_tblStatusMasterGetByType(7), "StatusID", "statusDesc");
            ViewBag.ValveModelID = new SelectList(InventoryEntities.usp_tblStatusMasterGetByType(5), "StatusID", "statusDesc");
            ViewBag.PresentStateID = new SelectList(InventoryEntities.usp_tblStatusMasterGetByType(1), "StatusID", "statusDesc");
            ViewBag.GasInUseID = new SelectList(InventoryEntities.usp_tblStatusMasterGetByType(4), "StatusID", "statusDesc");
            ViewBag.SizeUOMID = new SelectList(InventoryEntities.usp_tblStatusMasterGetByType(7), "StatusID", "statusDesc");
            ViewBag.CurrentLocationID = new SelectList(InventoryEntities.usp_tblStatusMasterGetByType(3), "StatusID", "statusDesc");
            ViewBag.VendorID = new SelectList(InventoryEntities.usp_VendorListGet(), "VendorID", "VendorName");
            



            ViewBag.ManufacturerID = new SelectList(InventoryEntities.usp_ManufacturerMasterGet(), "ManufacturerID", "ManufacturerName");

        }
    }
}
