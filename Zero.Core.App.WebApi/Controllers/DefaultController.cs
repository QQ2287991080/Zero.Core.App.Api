using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Zero.Core.App.WebApi.Controllers
{
    [Route("api/Default")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpPost]
        public void UpLoad(IFormFile[] files)
        {

        }

    }
}