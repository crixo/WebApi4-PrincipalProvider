namespace PrincipalProvider.Mvc.Users
{
	public class FakeUserRepository : IUserRepository
	{
		public User Get(string userName)
		{
			return new User(){ UserName = userName, Password = "pwd"};
		}
	}

}