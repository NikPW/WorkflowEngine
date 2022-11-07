using Microsoft.AspNetCore.Mvc;

namespace ActivitiesApi.Controllers.Http
{
    public class SendHttpRequest : BaseController
    {
        [HttpPost]
        public string SendRequestToEtenderUzexUz()
        {
            return "SendRequestToEtenderUzexUz Method";
        }
        
        [HttpPost]
        public string SendRequestToHumo()
        {
            return "SendRequestToHumo Method";
        }
    }
}
