using System.Security.Claims;

namespace Scout.Application.Common.Services;

public interface ICurrentUserService
{
    string Email { get;  }
    string UserId { get;  }
    public ClaimsPrincipal User { get; }
}