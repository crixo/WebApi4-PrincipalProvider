using System.Diagnostics.CodeAnalysis;
using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PrincipalProvider.Mvc.Users;

namespace PrincipalProvider.Mvc.Installers
{
	[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Improve readability using Windsor Fluent API registration")]
	public class RepositoriesInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IUserRepository>().ImplementedBy<FakeUserRepository>().LifeStyle.Singleton);
		}
		#endregion
	}
}