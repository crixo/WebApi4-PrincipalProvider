using System.Security.Principal;

namespace PrincipalProvider.Mvc.Authentication
{
	public interface IPrincipalProvider
    {
        IPrincipal CreatePrincipal(string username, string password);
    }
}