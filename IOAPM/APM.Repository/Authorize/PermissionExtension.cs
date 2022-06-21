using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace APM.Repository.Authorize
{
    public static class PermissionExtension
    {
        public static bool HavePermission(this Controller c, string claimValue)
        {
            var user = c.HttpContext.User as ClaimsPrincipal;
            bool havePer = user.HasClaim(claimValue, claimValue);
            return havePer;
        }

        public static bool HavePermission(this IIdentity claims, string claimValue)
        {
            var userClaims = claims as ClaimsIdentity;
            bool havePer = userClaims.HasClaim(claimValue, claimValue);
            return havePer;
        }
    }
}
