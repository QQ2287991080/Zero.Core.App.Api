using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Zero.Core.App.WebApi.Controllers
{
    [Route("api/Values")]
    [Produces("application/json")]
    public class ValuesController :ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
       
        // POST api/values
        [HttpPost]
        public void Post(Test test)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public class Test
        {
            /// <summary>
            /// 姓名
            /// </summary>
            public int Age { get; set; }
            public string Name { get; set; }

        }
    }
}
