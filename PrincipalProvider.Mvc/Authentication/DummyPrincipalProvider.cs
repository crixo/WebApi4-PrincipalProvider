using System;
using System.Security.Principal;
using Castle.Core.Logging;
using MySample1.Apps.API;
using PrincipalProvider.Mvc.Users;

namespace PrincipalProvider.Mvc.Authentication
{
	public class DummyPrincipalProvider : IPrincipalProvider
	{
		private IUserRepository _userRepository;

		public ILogger Logger { get; set; }

		public DummyPrincipalProvider(IUserRepository userRepository)
		{
			this._userRepository = userRepository;
		}

		public IPrincipal CreatePrincipal(string username, string password)
		{
			IPrincipal principal = null;
			try
			{
				if (Login(username, password))
				{
					var identity = new GenericIdentity(username);
					principal = new GenericPrincipal(identity, new[] {"User"});

					if (!identity.IsAuthenticated)
					{
						throw new ApplicationException("Unauthorized");
					}
				}
			}
			catch(Exception exc)
			{
				Logger.Error("An error occurred on creating IPrincipal.", exc);
			}

			return principal;
		}

		private bool Login(string username, string password)
		{
			var user = _userRepository.Get(username);
			if (user != null)
			{
				return user.Password == password;
			}

			return false;
		}
	}
}