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

        public static IEnumerable<ApiEntity> GetApis() =>
             new List<ApiEntity> {
                new ApiEntity(){
                    Nombre = apiName,
                    NombreMostrar = apiName,
                    Alcances = ApiScopes()
                }
             };

        public static IEnumerable<ClienteEntity> GetClients() =>
            new List<ClienteEntity> {
                new ClienteEntity {
                    ClienteIdDescripcion = "client_id",
                    ClienteSecretos = ClientSecret("client_secret"),
                    TiposConcesionesHabilitadas = AllowedGrantTypes(),
                    AllowedScopes = Scopes()
                },
                new ClienteEntity{
                    ClienteIdDescripcion = "client_worker_id",
                    ClienteSecretos = ClientSecret("client_worker_secret"),
                    TiposConcesionesHabilitadas = AllowedGrantTypes(),
                    AllowedScopes = Scopes()
                },
                new ClienteEntity
                {
                    ClienteIdDescripcion = "angular_id",
                    RequierePkce = true,
                    RequiereSecreto = false,
                    TiposConcesionesHabilitadas = AllowedGrantTypesAngular(),
                    ClienteRedirigirUris = RedirectUri(),
                    ClienteRedirigirCerrarSesionUris = ClientPostLogoutRedirectUris(),
                    AllowedCorsOrigins = ClientCorsOrigins(),
                    AllowedScopes = ScopesAngular(),
                    HabilitarTokenDesdeNavegador = true,
                    RequiereConsentimiento = false
                }
            };


        public static List<ApiAlcanceEntity> ApiScopes()
        {
            List<ApiAlcanceEntity> lista = new List<ApiAlcanceEntity>
            {
                new ApiAlcanceEntity()
                {
                    Nombre = apiName,
                    NombreMostrar = apiName
                }
            };

            return lista;
        }


        public static List<ClienteSecretoEntity> ClientSecret(string secret)
        {
            List<ClienteSecretoEntity> lista = new List<ClienteSecretoEntity>
            {
                new ClienteSecretoEntity() { Valor = secret.ToSha256() }
            };

            return lista;
        }



        public static List<ClienteTipoConcesionEntity> AllowedGrantTypes()
        {
            List<ClienteTipoConcesionEntity> lista = new List<ClienteTipoConcesionEntity>();

            foreach (var item in IdentityServer4.Models.GrantTypes.ClientCredentials)
            {
                lista.Add(new ClienteTipoConcesionEntity() { TipoConcesion = item.ToString() });
            }

            return lista;
        }

        public static List<ClienteTipoConcesionEntity> AllowedGrantTypesAngular()
        {
            List<ClienteTipoConcesionEntity> lista = new List<ClienteTipoConcesionEntity>();

            foreach (var item in IdentityServer4.Models.GrantTypes.Code)
            {
                lista.Add(new ClienteTipoConcesionEntity() { TipoConcesion = item.ToString() });
            }

            return lista;
        }


        public static List<ClienteAlcanceEntity> Scopes()
        {
            List<ClienteAlcanceEntity> lista = new List<ClienteAlcanceEntity>
            {
                new ClienteAlcanceEntity() { Alcance = apiName }
            };

            return lista;
        }
        public static List<ClienteAlcanceEntity> ScopesAngular()
        {
            List<ClienteAlcanceEntity> lista = new List<ClienteAlcanceEntity>
            {
                new ClienteAlcanceEntity() { Alcance = apiName },
                new ClienteAlcanceEntity() { Alcance = IdentityServerConstants.StandardScopes.OpenId }
            };

            return lista;
        }

        public static List<ClienteUrlRedirigirEntity> RedirectUri()
        {
            List<ClienteUrlRedirigirEntity> lista = new List<ClienteUrlRedirigirEntity>
            {
                new ClienteUrlRedirigirEntity() { Url = "http://localhost:4200" }
            };

            return lista;
        }

        public static List<ClienteUrlRedirigirCerrarSesionEntity> ClientPostLogoutRedirectUris()
        {
            List<ClienteUrlRedirigirCerrarSesionEntity> lista = new List<ClienteUrlRedirigirCerrarSesionEntity>
            {
                new ClienteUrlRedirigirCerrarSesionEntity() { Url = "http://localhost:4200" }
            };

            return lista;
        }

        public static List<ClienteOrigenCruzadoEntity> ClientCorsOrigins()
        {
            List<ClienteOrigenCruzadoEntity> lista = new List<ClienteOrigenCruzadoEntity>
            {
                new ClienteOrigenCruzadoEntity() { Origen = "http://localhost:4200" }
            };

            return lista;
        }






    }
}
