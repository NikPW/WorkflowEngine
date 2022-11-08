using DatabaseContext;
using DilshodWorkflowEngine.Service.Base;

namespace ActivitiesApi.Activities.Http
{
    public class ReceiveHttpRequest : BaseService
    {
        public ReceiveHttpRequest(AppDbContext context) : base(context)
        {
            
        }
        
        public string StartWorkflow()
        {
            return "StartWorkflow Method";
        }
        
        public string IdontKnowAboutLogic()
        {
            return "IdontKnowAboutLogic Method";
        }
    }
}
