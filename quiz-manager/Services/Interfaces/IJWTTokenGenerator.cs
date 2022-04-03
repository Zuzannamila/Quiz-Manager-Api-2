using Microsoft.AspNetCore.Identity;

namespace quiz_manager.Services.Interfaces
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(IdentityUser user, IList<string> roles);
    }
}
