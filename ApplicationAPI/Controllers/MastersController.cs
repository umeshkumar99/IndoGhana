using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CylnderEntities;

namespace ApplicationAPI.Controllers
{
    public class MastersController : ApiController
    {

        IndoGhanaEntities InventoryEntities = new IndoGhanaEntities();

        [HttpGet]
        public List<usp_CylinderMasterGet_Result> GetCylinderMasterList()
        {
            List<usp_CylinderMasterGet_Result> cylinderlist = new List<usp_CylinderMasterGet_Result>();
            cylinderlist = InventoryEntities.usp_CylinderMasterGet().ToList();
            return cylinderlist;
        }
        [HttpGet]
        public usp_CylinderMasterGetByID_Result GetCylinderMasterListByID(string CylindeNumber )
        {
            usp_CylinderMasterGetByID_Result cylinderlist = new usp_CylinderMasterGetByID_Result();
            cylinderlist = InventoryEntities.usp_CylinderMasterGetByID(CylindeNumber).FirstOrDefault();
            return cylinderlist;
        }


        [HttpGet]
        public List<usp_CylinderMasterMobileGet_Result> GetCylinderMasterMobileList()
        {
            List<usp_CylinderMasterMobileGet_Result> cylinderlist = new List<usp_CylinderMasterMobileGet_Result>();
            cylinderlist = InventoryEntities.usp_CylinderMasterMobileGet().ToList();
            return cylinderlist;
        }
        [HttpGet]
        public usp_CylinderMasterMobileGetByID_Result GetCylinderMasterListMobileByID(string CylindeNumber)
        {
            usp_CylinderMasterMobileGetByID_Result cylinderlist = new usp_CylinderMasterMobileGetByID_Result();
            cylinderlist = InventoryEntities.usp_CylinderMasterMobileGetByID(CylindeNumber).FirstOrDefault();
            return cylinderlist;
        }

        [HttpPost]
        public string CylinderMasterInsertUpdate(usp_CylinderMasterGetByID_Result cylinderDetails)
        {

            string result;
            result=InventoryEntities.usp_CylinderMasterInsertUpdateMobile(cylinderDetails.CylindeNumber, cylinderDetails.Barcode, cylinderDetails.PresentStateID, cylinderDetails.GasInUseID, cylinderDetails.VendorBranchID, cylinderDetails.Size, cylinderDetails.SizeUOMID, cylinderDetails.CurrentLocationID
                , cylinderDetails.CurrentCustomerBranchID, cylinderDetails.Branchid, cylinderDetails.CompanyID, cylinderDetails.CreatedByID,cylinderDetails.UpdatedByID,cylinderDetails.status).FirstOrDefault();
            return result;
        }

        [HttpPost]
        public string CylinderMasterInsertUpdate(usp_CylinderMasterMobileGetByID_Result cylinderDetails)
        {

            string result;
            result = InventoryEntities.usp_CylinderMasterInsertUpdateMobile(cylinderDetails.CylindeNumber, cylinderDetails.Barcode, cylinderDetails.PresentStateID, cylinderDetails.GasInUseID, cylinderDetails.VendorBranchID, cylinderDetails.Size, cylinderDetails.SizeUOMID, cylinderDetails.CurrentLocationID
                , cylinderDetails.CurrentCustomerBranchID, cylinderDetails.Branchid, cylinderDetails.CompanyID, cylinderDetails.CreatedByID, cylinderDetails.UpdatedByID, cylinderDetails.status).FirstOrDefault();
            return result;
        }
        

        [HttpGet]
        public List<usp_CustomerListGet_Result> GetCustomerMobileList()
        {
            List<usp_CustomerListGet_Result> customerlist = new List<usp_CustomerListGet_Result>();
            customerlist = InventoryEntities.usp_CustomerListGet().ToList();
            return customerlist;
        }


        [HttpGet]
        public List<usp_CustomerSiteListGet_Result> GetCustomerMobileSiteList(int customerID)
        {
            List<usp_CustomerSiteListGet_Result> customerSitelist = new List<usp_CustomerSiteListGet_Result>();
            customerSitelist = InventoryEntities.usp_CustomerSiteListGet(customerID).ToList();
            return customerSitelist;
        }



        [HttpGet]
        public List<usp_VendorListGet_Result> GetVendorMobileList()
        {
            List<usp_VendorListGet_Result> Vendorlist = new List<usp_VendorListGet_Result>();
            Vendorlist = InventoryEntities.usp_VendorListGet().ToList();
            return Vendorlist;
        }


        [HttpGet]
        public List<usp_VendorBranchListGet_Result> GetVendorBranchMobileList(int VendorID)
        {
            List<usp_VendorBranchListGet_Result> VendorBranchlist = new List<usp_VendorBranchListGet_Result>();
            VendorBranchlist = InventoryEntities.usp_VendorBranchListGet(VendorID).ToList();
            return VendorBranchlist;
        }


        [HttpGet]
        public List<usp_VendorBranchListDetailsGet_Result> GetVendorBranchMobileList()
        {
            List<usp_VendorBranchListDetailsGet_Result> Vendorlist = new List<usp_VendorBranchListDetailsGet_Result>();
            Vendorlist = InventoryEntities.usp_VendorBranchListDetailsGet().ToList();
            return Vendorlist;
        }


        [HttpGet]
        public List<usp_CustomrSiteListGet_Result> GetCustomerSiteMobileList()
        {
            List<usp_CustomrSiteListGet_Result> Customerlist = new List<usp_CustomrSiteListGet_Result>();
            Customerlist = InventoryEntities.usp_CustomrSiteListGet().ToList();
            return Customerlist;
        }


    }
}
