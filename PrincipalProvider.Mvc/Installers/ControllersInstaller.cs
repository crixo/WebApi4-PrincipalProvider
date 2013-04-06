using System.Diagnostics.CodeAnalysis;
using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace PrincipalProvider.Mvc.Installers
{
	[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Improve readability using Windsor Fluent API registration")]
	public class ControllersInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromThisAssembly()
					.BasedOn<IHttpController>()
					.If(t => t.Name.EndsWith("Controller"))
					.Configure((c => c.LifestyleTransient())));
		}
		#endregion
	}
}