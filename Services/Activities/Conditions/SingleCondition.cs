using Core.Activities.Conditions;
using DilshodWorkflowEngine.Service.Base;

namespace ActivitiesApi.Activities.Conditions
{
    public class SingleCondition : IBaseService
    {
        public bool SetSingleCondition(SingleConditionForm conditions)
        {
            if (conditions.FirstCondition.Equals(conditions.SecondCondition))
            {
                
            }

            return true;
        }
    }
}
