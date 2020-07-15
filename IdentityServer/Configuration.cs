using IdentityModel;
using IdentityServer4;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;

namespace IdentityServer
{
    //Clase para configurar las apis y los clientes si no se desea trabajar con una base de datos.
    public static class Configuration
    {
        static readonly string apiName = "ApiTest";

        public static IEnumerable<IdentityServer4.Models.IdentityResource> GetIdentityResources() =>
           new List<IdentityServer4.Models.IdentityResource>
           {
                new IdentityServer4.Models.IdentityResources.OpenId(),
                new IdentityServer4.Models.IdentityResources.Profile()
           };

        public static IEnumerable<TBLAPITEST> GetApis() =>
             new List<TBLAPITEST> {
                new TBLAPITEST(){
                    NOMBRE = apiName,
                    NOMBREMOSTRAR = apiName,
                    SCOPES = ApiScopes()
                }
             };

        public static IEnumerable<Clientes> GetClients() =>
            new List<Clientes> {
                new Clientes {
                    ClientId = "client_id",
                    ClientSecrets = ClientSecret("client_secret"),
                    AllowedGrantTypes = AllowedGrantTypes(),
                    AllowedScopes = Scopes()
                },
                new Clientes{
                    ClientId = "client_worker_id",
                    ClientSecrets = ClientSecret("client_worker_secret"),
                    AllowedGrantTypes = AllowedGrantTypes(),
                    AllowedScopes = Scopes()
                },
                new Clientes
                {
                    ClientId = "angular_id",
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedGrantTypes = AllowedGrantTypesAngular(),
                    RedirectUris = RedirectUri(),
                    PostLogoutRedirectUris = ClientPostLogoutRedirectUris(),
                    AllowedCorsOrigins = ClientCorsOrigins(),
                    AllowedScopes = ScopesAngular(),
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false
                }
            };


        public static List<ApiScope> ApiScopes()
        {
            List<ApiScope> lista = new List<ApiScope>
            {
                new ApiScope()
                {
                    Name = apiName,
                    DisplayName = apiName
                }
            };

            return lista;
        }


        public static List<ClientSecret> ClientSecret(string secret)
        {
            List<ClientSecret> lista = new List<ClientSecret>
            {
                new ClientSecret() { Value = secret.ToSha256() }
            };

            return lista;
        }



        public static List<ClientGrantType> AllowedGrantTypes()
        {
            List<ClientGrantType> lista = new List<ClientGrantType>();

            foreach (var item in IdentityServer4.Models.GrantTypes.ClientCredentials)
            {
                lista.Add(new ClientGrantType() { GrantType = item.ToString() });
            }

            return lista;
        }

        public static List<ClientGrantType> AllowedGrantTypesAngular()
        {
            List<ClientGrantType> lista = new List<ClientGrantType>();

            foreach (var item in IdentityServer4.Models.GrantTypes.Code)
            {
                lista.Add(new ClientGrantType() { GrantType = item.ToString() });
            }

            return lista;
        }


        public static List<ClientScope> Scopes()
        {
            List<ClientScope> lista = new List<ClientScope>
            {
                new ClientScope() { Scope = apiName }
            };

            return lista;
        }
        public static List<ClientScope> ScopesAngular()
        {
            List<ClientScope> lista = new List<ClientScope>
            {
                new ClientScope() { Scope = apiName },
                new ClientScope() { Scope = IdentityServerConstants.StandardScopes.OpenId }
            };

            return lista;
        }

        public static List<ClientRedirectUri> RedirectUri()
        {
            List<ClientRedirectUri> lista = new List<ClientRedirectUri>
            {
                new ClientRedirectUri() { RedirectUri = "http://localhost:4200" }
            };

            return lista;
        }

        public static List<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris()
        {
            List<ClientPostLogoutRedirectUri> lista = new List<ClientPostLogoutRedirectUri>
            {
                new ClientPostLogoutRedirectUri() { PostLogoutRedirectUri = "http://localhost:4200" }
            };

            return lista;
        }

        public static List<ClientCorsOrigin> ClientCorsOrigins()
        {
            List<ClientCorsOrigin> lista = new List<ClientCorsOrigin>
            {
                new ClientCorsOrigin() { Origin = "http://localhost:4200" }
            };

            return lista;
        }






    }
}
