using System.Collections.Generic;

namespace TripServiceKata.Trip
{
	public interface ITripDAOWrapper
	{
		List<Trip> FindTripsByUser(User.User user);
	}
}