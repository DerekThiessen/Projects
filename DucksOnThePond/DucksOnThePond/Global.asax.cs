using DucksOnThePond.Core;
using DucksOnThePond.Core.Interfaces;
using DucksOnThePond.Infrastructure;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DucksOnThePond
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IUnityContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            _container = new UnityContainer();
            _container.RegisterType<IPlayerService, PlayerService>();

            IControllerFactory controllerFactory = new UnityControllerFactory(_container);

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}