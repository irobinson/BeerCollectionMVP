namespace BeerCollection.Common
{
    using DotNetNuke.Entities.Users;

    public interface IUserProvider
    {
        UserInfo GetUser(int portalId, int userId);
    }
}