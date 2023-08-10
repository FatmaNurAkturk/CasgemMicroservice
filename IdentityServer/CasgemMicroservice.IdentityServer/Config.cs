// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace CasgemMicroservice.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){ Scopes={ "catalog_fullpermisson"} },
            new ApiResource("resource_photostock"){Scopes={"photostock_fullpermisson"}},
            new ApiResource("resource_basket"){Scopes={"basket_fullpermisson"}},
            new ApiResource("resource_discount"){Scopes={"discount_fullpermisson"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermisson","Ürün Listesi için tam erişim"),
                new ApiScope("photostock_fullpermisson","Fotoğraf işlemleri için tam erişim"),
                new ApiScope("basket_fullpermisson","basket api için full erişim"),
                new ApiScope("discount_fullpermisson","discount api için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "Casgem1Client",
                    ClientName = "Casgem Client Name",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "catalog_fullpermisson", "photostock_fullpermisson", IdentityServerConstants.LocalApi.ScopeName }
                },

                new Client
                {
                    ClientId = "Casgem2Client",
                    ClientName = "Casgem2 Client Name",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    AllowedScopes = { "catalog_fullpermisson", "basket_fullpermission", "basket_fullpermisson", "discount_fullpermisson", IdentityServerConstants.LocalApi.ScopeName,IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile },
                    AccessTokenLifetime = 3600
                },
            };
    }
}