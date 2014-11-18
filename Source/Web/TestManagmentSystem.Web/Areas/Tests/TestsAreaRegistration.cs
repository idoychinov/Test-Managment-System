namespace TestManagmentSystem.Web.Areas.Tests
{
    using System.Web.Mvc;

    public class TestsAreaRegistration : AreaRegistration
    {
        public override string AreaName 
        {
            get 
            {
                return "Tests";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Tests_default",
                "Tests/{controller}/{action}/{id}",
                new {controler= "TestScenarios", action = "Index", id = UrlParameter.Optional },
                new string[] { "TestManagmentSystem.Web.Areas.Tests.Controllers" }
            );
        }
    }
}