using System.Collections.Generic;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
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