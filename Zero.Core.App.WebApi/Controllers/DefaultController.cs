using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Tools.WebResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Zero.Core.App.WebApi.Controllers
{
    [Route("api/Default")]
    [Produces("application/json")]
    public class DefaultController : ControllerBase
    {
       
        [HttpPost]
        public async Task<JsonResult> UpLoad(IFormFile[]  files)
        {

            return  AjaxHelper.JsonResult(System.Net.HttpStatusCode.OK, "成功");
        }

    }
}