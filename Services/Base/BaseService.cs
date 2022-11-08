using System.Data;
using DatabaseContext;

namespace DilshodWorkflowEngine.Service.Base
{
    public class BaseService
    {
        protected readonly AppDbContext Context;

        public BaseService(AppDbContext context)
        {
            Context = context;
        }
    }
}
