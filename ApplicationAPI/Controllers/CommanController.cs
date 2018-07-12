﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CylnderEntities;

namespace CylinderAPI.Controllers
{
    public class CommanController : ApiController
    {

        IndoGhanaEntities InventoryEntities = new IndoGhanaEntities();
        // GET api/<controller>
        public List<usp_tblStatusMasterGetByType_Result> GetDropDownValues(int statusTypeID )
        {
            List<usp_tblStatusMasterGetByType_Result> statusList=new List<usp_tblStatusMasterGetByType_Result>();
            try
            {
                statusList = InventoryEntities.usp_tblStatusMasterGetByType(statusTypeID).ToList();
                return statusList;
            }
            
            catch (Exception ex)
            {
                return statusList;
            }
            
        }
        [HttpPost]
        public int GetBatchStartEnd(List<BatchStartEnd> batchStartEnd)
        {
            try
            {
                int result = 0;
                foreach (BatchStartEnd batch in batchStartEnd)
                {
                     result = (int)InventoryEntities.usp_tblBatchStartEndInsert(batch.VanBatchNumber, batch.BatchStartDateTime, batch.BatchEndDatetime, batch.ForDate, batch.Sstat, batch.CompanyID, batch.BranchID, batch.UserID).FirstOrDefault();
                }
                return result;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        [HttpPost]
        public int GetCylinderInVan(List<CylinderInVan> cylinderInVan)
        {
            try
            {
                int result=0;
                foreach (CylinderInVan cylinder in cylinderInVan)
                {
                    result = (int)InventoryEntities.usp_tblCylinderInVanInsert(cylinder.vehicleID, cylinder.initialSize, cylinder.remainingsizeforRefill, cylinder.vanBatchNumber, cylinder.VendorName, cylinder.cylinderLoadingDateTime, cylinder.cylinderID, cylinder.cylinderNumber, cylinder.cylinderVendorID, cylinder.cylinderBranchID, cylinder.sstat, cylinder.transactionPoint, cylinder.LocationID, cylinder.TransType, cylinder.CylinderStatus, cylinder.OwnerId, cylinder.vendorBranchID, cylinder.CompanyID, cylinder.BranchID, cylinder.UserID).FirstOrDefault();
                }
                return result;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

    }
}