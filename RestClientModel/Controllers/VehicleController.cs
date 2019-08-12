using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestClientModel.Models;
using System.Collections;

namespace RestClientModel.Controllers 
{
    public class VehicleController : ApiController
    {
        /// <summary>
        /// Get all Vehicles
        /// </summary>
        /// <returns></returns>
        // GET: api/Vehicle
        public ArrayList Get()
        {
            VehiclePersistence vp = new VehiclePersistence();
            return vp.getVehicle();
        }
        /// <summary>
        /// Get a specific vehicle by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        

        // GET: api/Vehicle/5
        public Vehicles Get(int id)
        {
            VehiclePersistence vp = new VehiclePersistence();

            Vehicles vehicle = vp.getVehicle(id);
            return vehicle ;
        }

        // POST: api/Vehicle
        public HttpResponseMessage Post([FromBody]Vehicles value)
        {
            VehiclePersistence vp = new VehiclePersistence();
            long id;
            id = vp.saveVehicle(value);
            value.ID = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("vehicle/{0}", id));
            return response;
        }
        /// <summary>
        /// Add and vehicle
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        // PUT: api/Vehicle/5
        public HttpResponseMessage Put(long id, [FromBody]Vehicles value)
        {
            VehiclePersistence vp = new VehiclePersistence();
            bool recordExisted = false;
            recordExisted = vp.updateVehicle(id, value);
            HttpResponseMessage response;

            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }
        /// <summary>
        /// Update a vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE: api/Vehicle/5
        public HttpResponseMessage Delete(long id)
        {
            VehiclePersistence vp = new VehiclePersistence();
            bool recordExisted = false;
            recordExisted = vp.deleteVehicle(id);
            HttpResponseMessage response;
            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }   
    }
} 
