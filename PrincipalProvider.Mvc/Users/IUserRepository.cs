namespace PrincipalProvider.Mvc.Users
{
	public interface IUserRepository
	{
		User Get(string userName);
	}
}
