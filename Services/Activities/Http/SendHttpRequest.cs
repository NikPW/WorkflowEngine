using DatabaseContext;
using DilshodWorkflowEngine.Service.Base;

namespace ActivitiesApi.Activities.Http
{
    public class SendHttpRequest : BaseService
    {
        public SendHttpRequest(AppDbContext context) : base(context)
        {
            
        }
        
        public string SendRequestToEtenderUzexUz()
        {
            return "SendRequestToEtenderUzexUz Method";
        }
        
        public string SendRequestToHumo()
        {
            return "SendRequestToHumo Method";
        }
    }
}
