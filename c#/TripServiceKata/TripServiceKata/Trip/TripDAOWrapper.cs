using System.Collections.Generic;

namespace TripServiceKata.Trip
{
	public class TripDAOWrapper : ITripDAOWrapper
	{
		public List<Trip> FindTripsByUser(User.User user)
		{
			return TripDAO.FindTripsByUser(user);
		}
	}
}