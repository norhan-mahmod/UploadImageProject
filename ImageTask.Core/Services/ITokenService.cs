using ImageTask.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Talabat.Core.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
