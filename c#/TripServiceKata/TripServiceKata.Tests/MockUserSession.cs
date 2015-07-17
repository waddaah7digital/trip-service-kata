using TripServiceKata.User;

namespace TripServiceKata.Tests
{
	public class MockUserSession : IUserSession
	{
		private readonly User.User _loggedUser;

		public MockUserSession(User.User loggedUser)
		{
			_loggedUser = loggedUser;
		}

		public bool IsUserLoggedIn(User.User user)
		{
			throw new System.NotImplementedException();
		}

		public User.User GetLoggedUser()
		{
			return _loggedUser;
		}
	}
}