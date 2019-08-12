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
    public class PersonController : ApiController
    {
        /// <summary>
        /// Get All Persons
        /// </summary>
        /// <returns></returns>
        // GET: api/Person
        public ArrayList Get()
        {
            PersonPersistence pp = new PersonPersistence();
            return pp.getPersons();
        }
        /// <summary>
        /// Get a Specific Person by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET: api/Person/5
        public Person Get(int id)
        {
            PersonPersistence pp = new PersonPersistence();

            Person person = pp.getPerson(id);
            return person;
        }

        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Person value)
        {
            PersonPersistence pp = new PersonPersistence();
            long id;
            id = pp.savePerson(value);
            value.ID = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("person/{0}", id));
            return response;
        }
        /// <summary>
        /// Add a person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>

        // PUT: api/Person/5
        public HttpResponseMessage Put(long id, [FromBody]Person value)
        {
            PersonPersistence pp = new PersonPersistence();
            bool recordExisted = false;
            recordExisted = pp.updatePerson(id, value);
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
        /// Update a person by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE: api/Person/5
        public HttpResponseMessage Delete(long id)
        {
            PersonPersistence pp = new PersonPersistence();
            bool recordExisted = false;
            recordExisted = pp.deletePerson(id);
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
