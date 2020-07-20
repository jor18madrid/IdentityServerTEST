// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


#pragma warning disable 1591

using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace IdentityServer4.EntityFramework.Entities
{
    public class ClienteEntity
    {
        public int ClienteId { get; set; }
        public bool Habilitar { get; set; } = true;
        public string ClienteIdDescripcion { get; set; }
        public string TipoProtocolo { get; set; } = "oidc";
        public List<ClienteSecretoEntity> ClienteSecretos { get; set; }
        public bool RequiereSecreto { get; set; } = true;
        public string NombreCiente { get; set; }
        public string Descripcion { get; set; }
        public string ClienteUrl { get; set; }
        public string LogoUri { get; set; }
        public bool RequiereConsentimiento { get; set; } = true;
        public bool PermitirRecordarConsentimiento { get; set; } = true;
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public List<ClienteTipoConcesionEntity> TiposConcesionesHabilitadas { get; set; }
        public bool RequierePkce { get; set; }
        public bool AllowPlainTextPkce { get; set; }
        public bool HabilitarTokenDesdeNavegador { get; set; }
        public List<ClienteUrlRedirigirEntity> ClienteRedirigirUris { get; set; }
        public List<ClienteUrlRedirigirCerrarSesionEntity> ClienteRedirigirCerrarSesionUris { get; set; }
        public string FrontChannelLogoutUri { get; set; }
        public bool FrontChannelLogoutSessionRequired { get; set; } = true;
        public string BackChannelLogoutUri { get; set; }
        public bool BackChannelLogoutSessionRequired { get; set; } = true;
        public bool AllowOfflineAccess { get; set; }
        public List<ClienteAlcanceEntity> AllowedScopes { get; set; }
        public int IdentityTokenLifetime { get; set; } = 300;
        public int AccessTokenLifetime { get; set; } = 3600;
        public int AuthorizationCodeLifetime { get; set; } = 300;
        public int? ConsentLifetime { get; set; } = null;
        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;
        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;
        public int RefreshTokenUsage { get; set; } = (int)TokenUsage.OneTimeOnly;
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        public int RefreshTokenExpiration { get; set; } = (int)TokenExpiration.Absolute;
        public int AccessTokenType { get; set; } = (int)0; // AccessTokenType.Jwt;
        public bool EnableLocalLogin { get; set; } = true;
        //public List<ClientIdPRestriction> IdentityProviderRestrictions { get; set; }
        public bool IncludeJwtId { get; set; }
        //public List<ClientClaim> Claims { get; set; }
        public bool AlwaysSendClientClaims { get; set; }
        public string ClientClaimsPrefix { get; set; } = "client_";
        public string PairWiseSubjectSalt { get; set; }
        public List<ClienteOrigenCruzadoEntity> AllowedCorsOrigins { get; set; }
        //public List<ClientProperty> Properties { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public int? UserSsoLifetime { get; set; }
        public string UserCodeType { get; set; }
        public int DeviceCodeLifetime { get; set; } = 300;
        public bool NonEditable { get; set; }
    }
}