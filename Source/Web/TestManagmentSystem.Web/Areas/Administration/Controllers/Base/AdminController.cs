namespace TestManagmentSystem.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;
    using TestManagmentSystem.Common;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
        public AdminController(ITestManagmentSystemData data)
            : base(data)
        {
        }
    }
}