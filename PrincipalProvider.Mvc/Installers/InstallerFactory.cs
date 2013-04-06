using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;

namespace PrincipalProvider.Mvc.Installers
{
	public class MyInstallerFactory : InstallerFactory
	{
		public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
		{
			var windsorInfrastructureInstaller = installerTypes.FirstOrDefault(it => it == typeof (WindsorInfrastructureInstaller));

			var retVal = new List<Type>();
			retVal.Add(windsorInfrastructureInstaller);
			retVal.AddRange(installerTypes.Where(it => (it != typeof(WindsorInfrastructureInstaller) && (typeof(IWindsorInstaller).IsAssignableFrom(it)))));

			return retVal;
		}
	}
}