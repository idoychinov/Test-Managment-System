[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TestManagmentSystem.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TestManagmentSystem.Web.App_Start.NinjectWebCommon), "Stop")]

namespace TestManagmentSystem.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using TestManagmentSystem.Data;
    using TestManagmentSystem.Data.UnitOfWork;
    using TestManagmentSystem.Web.Areas.Tests.Infrastructure.Services;
    using TestManagmentSystem.Web.Areas.Tests.Infrastructure.Services.Contracts;
    using TestManagmentSystem.Web.Infrastructure;
    using TestManagmentSystem.Web.Infrastructure.Services;
    using TestManagmentSystem.Web.Infrastructure.Services.Contracts;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITestManagmentSystemDbContext>().To<TestManagmentSystemDbContext>();
            kernel.Bind<ITestManagmentSystemData>().To<TestManagmentSystemData>();
            kernel.Bind<ISanitizer>().To<HtmlSanitizerAdapter>();

            kernel.Bind<IHomeServices>().To<HomeServices>();
            kernel.Bind<ISystemsServices>().To<SystemsServices>();
            kernel.Bind<IIssuesServices>().To<IssuesServices>();
            kernel.Bind<ITestScenarioServices>().To<TestScenarioServices>();
        }        
    }
}
