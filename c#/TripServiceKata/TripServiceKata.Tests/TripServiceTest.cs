using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKata.Tests
{
	[TestFixture]
	public class TripServiceTest
	{
		[Test]
		public void When_no_user_is_logged_in_throws_user_not_logged_in_exception()
		{
			IUserSession userSession = new MockUserSession(null);
			var tripService = new TripService(userSession);
			Assert.Throws<UserNotLoggedInException>(() => tripService.GetTripsByUser(new User.User()));
		}
	}
}
