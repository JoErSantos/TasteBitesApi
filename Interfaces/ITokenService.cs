using TasteBitesApi.Models;

namespace TasteBitesApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}