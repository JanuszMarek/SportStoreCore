﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Lessons.Areas.Identity.Infrastructure
{
    //class to the example project that simulates a system that provides claims information
    /*
    public class LocationClaimsProvider
    {
        
        public static Task<ClaimsPrincipal> AddClaims(ClaimsTransformationContext context) {
             ClaimsPrincipal principal = context.Principal;
             if (principal != null && !principal.HasClaim(c => c.Type == ClaimTypes.PostalCode))
             {
                 ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                 if (identity != null && identity.IsAuthenticated && identity.Name != null)
                 {
                     if (identity.Name.ToLower() == "alice")
                     {
                         identity.AddClaims(new Claim[] {
                             CreateClaim(ClaimTypes.PostalCode, "DC 20500"),
                             CreateClaim(ClaimTypes.StateOrProvince, "DC")
                         });
                     }
                     else
                     {
                         identity.AddClaims(new Claim[] {
                             CreateClaim(ClaimTypes.PostalCode, "NY 10036"),
                             CreateClaim(ClaimTypes.StateOrProvince, "NY")
                         });
                     }
                 }
             }
            return Task.FromResult(principal);
        }

        private static Claim CreateClaim(string type, string value) => new Claim(type, value, ClaimValueTypes.String, "RemoteClaims");
    }
    */
} 
    
    