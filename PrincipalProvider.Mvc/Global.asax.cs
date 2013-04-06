using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PrincipalProvider.Mvc.Authentication;
using PrincipalProvider.Mvc.Infrastructure;
using PrincipalProvider.Mvc.Installers;

namespace PrincipalProvider.Mvc
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class WebApiApplication : System.Web.HttpApplication
	{
		private IWindsorContainer _container;

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			BootStrapContainer();

			var authorizationMessageHandler = _container.Resolve<BasicAuthMessageHandler>();
			GlobalConfiguration.Configuration.MessageHandlers.Add(authorizationMessageHandler);

			// Set Windsor as Controllers(WebApis) factory.
			GlobalConfiguration.Configuration.Services.Replace(
				typeof(IHttpControllerActivator),
				new WindsorCompositionRoot(_container));
		}

		protected void Application_End()
		{
			_container.Dispose();
		}

		private void BootStrapContainer()
		{
			_container = new WindsorContainer();
			_container.Install(FromAssembly.This(new MyInstallerFactory()));
		}
	}
}