using Data.SQLServer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

          

        public IEnumerable<Book> Get()
        {
            //return ModelDAL.GetBooks().ToList();

            
            return ModelDAL.GetBooks().Tables[0].AsEnumerable()
            .Select(dataRow => new Book
            {
                Bookid = dataRow.Field<int>("Bookid"),
                Title = dataRow.Field<string>("Title"),
                Authors = dataRow.Field<string>("Authors"),
                Price = dataRow.Field<int>("Price"),
                Publishers = dataRow.Field<string>("Publisher"),
            }).ToList();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
