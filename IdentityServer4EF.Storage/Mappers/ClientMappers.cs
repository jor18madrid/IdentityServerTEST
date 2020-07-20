// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace IdentityServer4.EntityFramework.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for clients.
    /// </summary>
    public static class ClientMappers
    {
        static ClientMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        //public static Client ToModel(this ClienteEntity entity)
        //{
        //    return Mapper.Map<Client>(entity);
        //}

        public static Client ToModel(this ClienteEntity entity)
        {
            var model = new Models.Client()
            {
                AllowOfflineAccess = entity.AllowOfflineAccess,
                IdentityTokenLifetime = entity.IdentityTokenLifetime,
                AccessTokenLifetime = entity.AccessTokenLifetime,
                AuthorizationCodeLifetime = entity.AuthorizationCodeLifetime,
                AbsoluteRefreshTokenLifetime = entity.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = entity.SlidingRefreshTokenLifetime,
                ConsentLifetime = entity.ConsentLifetime,
                RefreshTokenUsage = (TokenUsage)entity.RefreshTokenUsage,
                UpdateAccessTokenClaimsOnRefresh = entity.UpdateAccessTokenClaimsOnRefresh,
                RefreshTokenExpiration = (TokenExpiration)entity.RefreshTokenExpiration,
                AccessTokenType = (AccessTokenType)entity.AccessTokenType,
                EnableLocalLogin = entity.EnableLocalLogin,
                IncludeJwtId = entity.IncludeJwtId,
                AlwaysSendClientClaims = entity.AlwaysSendClientClaims,
                ClientClaimsPrefix = entity.ClientClaimsPrefix,
                PairWiseSubjectSalt = entity.PairWiseSubjectSalt,
                UserCodeType = entity.UserCodeType,
                DeviceCodeLifetime = entity.DeviceCodeLifetime,
                AlwaysIncludeUserClaimsInIdToken = entity.AlwaysIncludeUserClaimsInIdToken,
                AllowedScopes = entity.AllowedScopes.MapScopes(),
                BackChannelLogoutSessionRequired = entity.BackChannelLogoutSessionRequired,
                Enabled = entity.Habilitar,
                ClientId = entity.ClienteIdDescripcion,
                ProtocolType = entity.TipoProtocolo,
                ClientSecrets = entity.ClienteSecretos.MapSecrets(),
                RequireClientSecret = entity.RequiereSecreto,
                ClientName = entity.NombreCiente,
                Description = entity.Descripcion,
                ClientUri = entity.ClienteUrl,
                LogoUri = entity.LogoUri,
                AllowedCorsOrigins = entity.AllowedCorsOrigins.MapCorsOrigins(),
                RequireConsent = entity.RequiereConsentimiento,
                AllowedGrantTypes = entity.TiposConcesionesHabilitadas.MapTiposConcesiones(),
                RequirePkce = entity.RequierePkce,
                AllowPlainTextPkce = entity.AllowPlainTextPkce,
                AllowAccessTokensViaBrowser = entity.HabilitarTokenDesdeNavegador,
                RedirectUris = entity.ClienteRedirigirUris.MapRedirectUris(),
                PostLogoutRedirectUris = entity.ClienteRedirigirCerrarSesionUris.MapPostLogOutRedirectUris(),
                FrontChannelLogoutUri = entity.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = entity.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = entity.BackChannelLogoutUri,
                AllowRememberConsent = entity.PermitirRecordarConsentimiento
            };
            return model;
        }


        public static ICollection<string> MapRedirectUris(this List<ClienteUrlRedirigirEntity> lista)
        {
            var model = new List<string>();

            foreach (var item in lista)
            {
                model.Add(item.Url);
            }
            return model;
        }

        public static ICollection<string> MapPostLogOutRedirectUris(this List<ClienteUrlRedirigirCerrarSesionEntity> lista)
        {
            var model = new List<string>();

            foreach (var item in lista)
            {
                model.Add(item.Url);
            }
            return model;
        }

        public static ICollection<string> MapTiposConcesiones(this List<ClienteTipoConcesionEntity> lista)
        {
            var model = new List<string>();

            foreach (var item in lista)
            {
                model.Add(item.TipoConcesion);
            }
            return model;
        }

        public static ICollection<string> MapCorsOrigins(this List<ClienteOrigenCruzadoEntity> lista)
        {
            var model = new List<string>();

            foreach (var item in lista)
            {
                model.Add(item.Origen);
            }
            return model;
        }

        public static ICollection<Secret> MapSecrets(this List<ClienteSecretoEntity> lista)
        {
            List<Models.Secret> model = new List<Models.Secret>();

            foreach (var item in lista)
            {
                model.Add(
                    new Models.Secret
                    {
                        Description = item.Descripcion,
                        Expiration = item.FechaExpiracion,
                        Type = item.Tipo,
                        Value = item.Valor
                    });
            }
            return model;
        }

        public static ICollection<string> MapScopes(this List<ClienteAlcanceEntity> lista)
        {
            var model = new List<string>();

            foreach (var item in lista)
            {
                model.Add(item.Alcance);
            }
            return model;
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static ClienteEntity ToEntity(this Client model)
        {
            return Mapper.Map<ClienteEntity>(model);
        }
    }
}