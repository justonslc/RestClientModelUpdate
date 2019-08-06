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
        // GET: api/Property
        public ArrayList Get()
        {
            PropertyPersistence pp = new PropertyPersistence();
            return pp.getProperty();
        }

        // GET: api/Property/5
        public Property Get(int id)
        {
            PropertyPersistence pp = new PropertyPersistence();

            Property property = pp.getProperty(id);
            return property;
        }

        // POST: api/Property
        public HttpResponseMessage Post([FromBody]Property value)
        {
            PropertyPersistence pp = new PropertyPersistence();
            long id;
            id = pp.saveProperty(value);
            value.ID = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("property/{0}", id));
            return response;
        }

        // PUT: api/Property/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Property/5
        public HttpResponseMessage Delete(long id)
        {
            PropertyPersistence pp = new PropertyPersistence();
            bool recordExisted = false;
            recordExisted = pp.deleteProperty(id);
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
