using Microsoft.AspNetCore.Mvc;

namespace ActivitiesApi.Controllers.Http
{
    public class ReceiveHttpRequest : BaseController
    {
        [HttpPost]
        public string StartWorkflow()
        {
            return "StartWorkflow Method";
        }

        [HttpPost]
        public string IdontKnowAboutLogic()
        {
            return "IdontKnowAboutLogic Method";
        }
    }
}
