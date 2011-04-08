namespace BeerCollection.Common
{
    using DotNetNuke.Entities.Users;

    public class UserProvider : IUserProvider
    {
        public UserInfo GetUser(int portalId, int userId)
        {
            return new UserController().GetUser(portalId, userId);
        }
    }
}