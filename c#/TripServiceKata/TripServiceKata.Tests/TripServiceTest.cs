using System.Collections.Generic;
using System.Linq;
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
			var userSession = new MockUserSession(null);
			var tripService = new TripService(userSession, new TripDAOWrapper());
			Assert.Throws<UserNotLoggedInException>(() => tripService.GetTripsByUser(new User.User()));
		}

		[Test]
		public void When_logged_in_user_is_not_a_friend_then_returns_no_trips()
		{
			var userSession = new MockUserSession(new User.User());
			var tripService = new TripService(userSession, new TripDAOWrapper());
			var actual = tripService.GetTripsByUser(new User.User());

			Assert.That(actual, Is.EqualTo(Enumerable.Empty<Trip.Trip>()));
		}

		[Test]
		public void When_logged_in_user_is_a_friend_then_returns_trips_from_service()
		{
			var loggedInUser = new User.User();
			var userSession = new MockUserSession(loggedInUser);
			var tripsFromService = new List<Trip.Trip>{new Trip.Trip()};
			var tripService = new TripService(userSession, new MockTripDAOWrapper(tripsFromService));
			var userToQuery = new User.User();
			userToQuery.AddFriend(loggedInUser);

			var actual = tripService.GetTripsByUser(userToQuery);
			Assert.That(actual, Is.EqualTo(tripsFromService));
		}
	}

	public class MockTripDAOWrapper : ITripDAOWrapper
	{
		private readonly List<Trip.Trip> _trips;

		public MockTripDAOWrapper(List<Trip.Trip> trips)
		{
			_trips = trips;
		}

		public List<Trip.Trip> FindTripsByUser(User.User user)
		{
			return _trips;
		}
	}
}
