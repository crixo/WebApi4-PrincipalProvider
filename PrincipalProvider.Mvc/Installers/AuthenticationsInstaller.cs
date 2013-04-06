﻿using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PrincipalProvider.Mvc.Authentication;

namespace PrincipalProvider.Mvc.Installers
{
	[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Improve readability using Windsor Fluent API registration")]
	public class AuthenticationsInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IPrincipalProvider>().ImplementedBy<DummyPrincipalProvider>().LifeStyle.Singleton);
		}
		#endregion
	}
}