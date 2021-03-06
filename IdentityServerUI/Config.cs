﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerUI
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("rotuladores", "API Rotuladores", new List<string> { "role" })
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "applicationCON",

                    ClientName = "Cliente: Aplicación de Consola",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("prueba_CON".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "rotuladores" }
                },

                // MVC client using code flow + pkce
                new Client
                {
                    ClientId = "applicationMVC",

                    ClientName = "Cliente: Aplicación Web MVC",

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,

                    RequirePkce = true,

                    ClientSecrets = { new Secret("prueba_MVC".Sha256()) },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = { "openid", "profile", "rotuladores" }
                },

                // SPA client using code flow + pkce
                new Client
                {
                    ClientId = "SPA",
                    ClientName = "Cliente: SPA",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =
                    {
                        "http://localhost:5002/index.html",
                        "http://localhost:5002/callback.html",
                        "http://localhost:5002/silent.html",
                        "http://localhost:5002/popup.html",
                    },

                    PostLogoutRedirectUris = { "http://localhost:5002/index.html" },
                    AllowedCorsOrigins = { "http://localhost:5002" },

                    AllowedScopes = { "openid", "profile", "rotuladores" }
                }
            };
    }
}