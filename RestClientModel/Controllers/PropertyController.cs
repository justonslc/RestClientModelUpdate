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
    public class PropertyController : ApiController
    {
        /// <summary>
        /// Get all Property
        /// </summary>
        /// <returns></returns>
        // GET: api/Property
        public ArrayList Get()
        {
            PropertyPersistence pp = new PropertyPersistence();
            return pp.GetProperty();
        }
        /// <summary>
        /// Get a specific property by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET: api/Property/5
        public Property Get(int id)
        {
            PropertyPersistence pp = new PropertyPersistence();

            Property property = pp.GetProperty(id);
            return property;
        }

        // POST: api/Property
        public HttpResponseMessage Post([FromBody]Property value)
        {
            PropertyPersistence pp = new PropertyPersistence();
            long id;
            id = pp.SaveProperty(value);
            value.ID = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("property/{0}", id));
            return response;
        }
        /// <summary>
        /// Add property
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="value"></param>

        // PUT: api/Property/5
        public HttpResponseMessage Put(long id, [FromBody]Property value)
        {
            PropertyPersistence pp = new PropertyPersistence();
            bool recordExisted = false;
            recordExisted = pp.UpdateProperty(id, value);
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

        // DELETE: api/Property/5
        public HttpResponseMessage Delete(long id)
        {
            PropertyPersistence pp = new PropertyPersistence();
            bool recordExisted = false;
            recordExisted = pp.DeleteProperty(id);
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
