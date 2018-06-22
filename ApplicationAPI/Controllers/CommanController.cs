using System;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}