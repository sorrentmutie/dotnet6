// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityProvider.Models;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                //new IdentityResources.Profile(),
                new ProfileWithRoleIdentityResource(),
                new IdentityResources.Email(),
                   };

        public static IEnumerable<ApiScope> Apis =>
            new ApiScope[]
            {
                new ApiScope("weatherapi", "weatherapi", userClaims: new[] { JwtClaimTypes.Role }),
                new ApiScope("magazzino"),
                new ApiScope("ordini")
            };

        public static IEnumerable<ApiResource> ApiScopes =>
            new ApiResource[]
            {
                new ApiResource("magazzino", "Magazzino"),
                new ApiResource("ordini", "Ordini"),
                new ApiResource("weatherapi", "Weather API",
                    userClaims: new[] { JwtClaimTypes.Role }) { Scopes = new [] {"weatherapi" } }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
              new Client
              {
                  ClientId = "myappblazor",
                  AllowedGrantTypes = GrantTypes.Code,
                  RequirePkce = true,
                  RequireClientSecret = false,
                  AllowedCorsOrigins = {"https://localhost:7001"},
                  AllowedScopes = {"openid", "profile", "weatherapi", "email"},
                  RedirectUris = {"https://localhost:7001/authentication/login-callback"},
                  Enabled = true,
                  PostLogoutRedirectUris = {"https://localhost:7001"}
              }  
            };
    }
}