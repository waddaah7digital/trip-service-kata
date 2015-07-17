using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
	[TestFixture]
	public class TripServiceTest
	{
		[Test]
		public void When_no_user_is_logged_in_throws_user_not_logged_in_exception()
		{
			var tripService = new TripService(new MockUserSession(null), new MockTripDAOWrapper(new List<Trip.Trip>()));
			
			Assert.Throws<UserNotLoggedInException>(() => tripService.GetTripsByUser(new User.User()));
		}

		[Test]
		public void When_logged_in_user_is_not_a_friend_then_returns_no_trips()
		{
			var tripService = new TripService(new MockUserSession(new User.User()), new MockTripDAOWrapper(new List<Trip.Trip>()));
			
			var actual = tripService.GetTripsByUser(new User.User());

			Assert.That(actual, Is.EqualTo(Enumerable.Empty<Trip.Trip>()));
		}

		[Test]
		public void When_logged_in_user_is_a_friend_then_returns_trips_from_service()
		{
			var loggedInUser = new User.User();
			var tripService = new TripService(new MockUserSession(loggedInUser), new MockTripDAOWrapper(new List<Trip.Trip>{new Trip.Trip()}));
			var userToQuery = new User.User();
			userToQuery.AddFriend(loggedInUser);

			var actual = tripService.GetTripsByUser(userToQuery);
			Assert.That(actual, Is.EqualTo(new List<Trip.Trip>{new Trip.Trip()}));
		}
	}
}
