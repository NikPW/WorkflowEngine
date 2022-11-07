using System.Data;
using DilshodWorkflowEngine.Service.Base;

namespace ActivitiesApi.Activities
{
    public class GetActivity : IBaseService
    {
        public GetActivity() : base()
        {
            
        }
        
        public int Plus(int a, int b)
        {
            return a + b;
        }
    }
}
