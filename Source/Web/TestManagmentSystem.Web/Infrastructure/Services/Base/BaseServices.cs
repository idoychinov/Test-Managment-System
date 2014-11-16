using TestManagmentSystem.Data.UnitOfWork;

namespace TestManagmentSystem.Web.Infrastructure.Services.Base
{
    public abstract class BaseServices
    {
        protected ITestManagmentSystemData Data { get; set; }

        public BaseServices(ITestManagmentSystemData data)
        {
            this.Data = data;
        }
    }
}
