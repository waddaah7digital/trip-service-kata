using TripServiceKata.Exception;

namespace TripServiceKata.User
{
	public interface IUserSession
	{
		bool IsUserLoggedIn(User user);
		User GetLoggedInUser();
	}

	public class UserSession : IUserSession
	{
        private static readonly IUserSession userSession = new UserSession();

        private UserSession() { }

        public static IUserSession GetInstance()
        {
            return userSession;
        }

        public bool IsUserLoggedIn(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.IsUserLoggedIn() should not be called in an unit test");
        }

        public User GetLoggedInUser()
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.GetLoggedInUser() should not be called in an unit test");
        }
    }
}
