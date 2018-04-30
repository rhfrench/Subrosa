using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Subrosa.Models;

namespace Subrosa.Api.Controllers
{
    [Route("[controller]")]
    public class UploadController : Controller
    {
        [HttpPost]
        public void Post([FromBody]string value)
        {
            if (!String.IsNullOrWhiteSpace(value))
                return;

            KeyLogModel model = JsonConvert.DeserializeObject<KeyLogModel>(value);
            

        }
    }
}
