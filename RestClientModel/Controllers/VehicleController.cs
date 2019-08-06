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
        // GET: api/Vehicle
        public ArrayList Get()
        {
            VehiclePersistence vp = new VehiclePersistence();
            return vp.getVehicle();
        }

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

        // PUT: api/Vehicle/5
        public HttpResponseMessage Put([FromBody]Vehicles value)
        {
            VehiclePersistence vp = new VehiclePersistence();
            long id;
            id = vp.saveVehicle(value);
            value.ID = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("vehicle/{0}", id));
            return response;
        }

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
