using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab11.Controllers
{
    public class RequestController : ApiController
    {
        DataSS data = new DataSS();
        // GET api/values
        public IEnumerable<RequestSet> Get() =>
            data.RequestSet;

        // GET api/values/5
        public RequestSet Get(int id) =>
            data.RequestSet.Find(id);

        // POST api/values
        public void Post([FromBody] RequestSet request)
        {
            data.RequestSet.Add(request);
            data.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] RequestSet request)
        {
            if (id == request.Id)
            {
                data.Entry(request).State = System.Data.Entity.EntityState.Modified;
                data.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var elem = data.RequestSet.FirstOrDefault(el => el.Id == id);
            if (elem != null)
            {
                data.RequestSet.Remove(elem);
                data.SaveChanges();
            }
        }
    }
}
