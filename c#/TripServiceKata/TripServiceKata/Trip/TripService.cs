using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
	    private readonly IUserSession _userSession;
	    private readonly ITripDAOWrapper _tripDaoWrapper;

	    public TripService(IUserSession userSession, ITripDAOWrapper tripDaoWrapper)
	    {
		    _userSession = userSession;
		    _tripDaoWrapper = tripDaoWrapper;
	    }

	    public List<Trip> GetTripsByUser(User.User user)
        {
            List<Trip> tripList = new List<Trip>();
            User.User loggedInUser = _userSession.GetLoggedInUser();
            bool isFriend = false;
            if (loggedInUser != null)
            {
                foreach(User.User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedInUser))
                    {
                        isFriend = true;
                        break;
                    }
                }
                if (isFriend)
                {
                    tripList = _tripDaoWrapper.FindTripsByUser(user);
                }
                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}
