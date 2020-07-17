using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using static Business.Constants.CustomClaimTypes;

namespace Business.Extensions
{
    public static class ClaimExtensions
    {
        public static int CompanyId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimType.CompanyId);
            return int.Parse(claim.Value);
        }
    }
}
