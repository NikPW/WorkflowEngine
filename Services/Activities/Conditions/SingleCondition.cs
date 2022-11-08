using Core.Activities.Conditions;
using DatabaseContext;
using DilshodWorkflowEngine.Service.Base;

namespace ActivitiesApi.Activities.Conditions
{
    public class SingleCondition : BaseService
    {
        public SingleCondition(AppDbContext context) : base(context)
        {
            
        }
        
        public bool SetSingleCondition(SingleConditionForm conditions)
        {
            if (conditions.FirstCondition.Equals(conditions.SecondCondition))
            {
                
            }

            return true;
        }
    }
}
