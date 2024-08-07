﻿using System.Security.Claims;
using Omini.Opme.Shared.Constants;

namespace Omini.Opme.Shared.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetEmail(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException("Claim userEmail not found", nameof(principal));
        }

        var claim = principal.FindFirst(ClaimTypes.Email);
        return claim?.Value;
    }

    public static Guid? GetOpmeUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException("Claim OpmeUserId not found", nameof(principal));
        }

        var claim = principal.FindFirst(OpmeKeyRegisteredClaimNames.OpmeUserId);

        if (Guid.TryParse(claim?.Value, out Guid result))
        {
            return result;
        }

        return null;
    }
}
