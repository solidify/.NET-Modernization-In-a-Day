using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.WebApi.Controllers
{
    [Route("api/fail")]
    public class ExceptionController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

           throw new NotImplementedException("endpoint not ready");
            
        }
    }
}
