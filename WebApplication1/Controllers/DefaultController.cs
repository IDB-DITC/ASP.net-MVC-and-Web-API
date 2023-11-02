using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class DefaultController : ApiController
    {

        static List<string> data = new List<string>();



        // GET: api/Default
        [HttpGet]
        public IEnumerable<string> Alldata()
        {


            return data;
        }

        // GET: api/Default/5
        [HttpGet]
        public HttpResponseMessage Data(int id)
        {
            try
            {
                if (data.Count <= id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $" no data found by id {id}");
                }

                else
                    return Request.CreateResponse(HttpStatusCode.OK, data[id]);
            }


            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }




        }
        // POST: api/Default
        [HttpPost]
        public HttpResponseMessage AddToList([FromBody] string value)
        {
            try
            {
               
                data.Add(value);

                return Request.CreateResponse(HttpStatusCode.Created, value);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
           
        }

        // PUT: api/Default/5
        [HttpPut]
        public HttpResponseMessage UpdateInList(int id, [FromBody] string value)
        {
            try
            {
                if (data.Count <= id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"edit failed, no data found by id {id}");
                }
                data[id] = value;

                return Request.CreateResponse(HttpStatusCode.OK, $"edit success by id {id}");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
           
        }

        // DELETE: api/Default/5
        [HttpDelete]
        public HttpResponseMessage RemoveFromList(int id)
        {
            try
            {
                if (data.Count <= id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"delete failed, no data found by id {id}");
                }
                data.RemoveAt(id);
                return Request.CreateResponse(HttpStatusCode.OK, $"deleted success by id {id}");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
            
        }
    }
}
