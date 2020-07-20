// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer4.EntityFramework.Extensions
{
    /// <summary>
    /// Extension methods to define the database schema for the configuration and operational data stores.
    /// </summary>
    public static class ModelBuilderExtensions
    {
        private static EntityTypeBuilder<TEntity> ToTable<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder, TableConfiguration configuration)
            where TEntity : class
        {
            return string.IsNullOrWhiteSpace(configuration.Schema) ? entityTypeBuilder.ToTable(configuration.Name) : entityTypeBuilder.ToTable(configuration.Name, configuration.Schema);
        }

        /// <summary>
        /// Configures the client context.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="storeOptions">The store options.</param>
        public static void ConfigureClientContext(this ModelBuilder modelBuilder, ConfigurationStoreOptions storeOptions)
        {
            if (!string.IsNullOrWhiteSpace(storeOptions.DefaultSchema)) modelBuilder.HasDefaultSchema(storeOptions.DefaultSchema);

            modelBuilder.Entity<ClienteEntity>(client =>
            {
                client.ToTable(storeOptions.Client).HasKey(x => x.ClienteId);

                client.Property(x => x.ClienteIdDescripcion).HasMaxLength(200).IsRequired();
                client.Property(x => x.TipoProtocolo).HasMaxLength(200).IsRequired();
                client.Property(x => x.NombreCiente).HasMaxLength(200);
                client.Property(x => x.ClienteUrl).HasMaxLength(2000);
                client.Property(x => x.LogoUri).HasMaxLength(2000);
                client.Property(x => x.Descripcion).HasMaxLength(1000);
                client.Property(x => x.FrontChannelLogoutUri).HasMaxLength(2000);
                client.Property(x => x.BackChannelLogoutUri).HasMaxLength(2000);
                client.Property(x => x.ClientClaimsPrefix).HasMaxLength(200);
                client.Property(x => x.PairWiseSubjectSalt).HasMaxLength(200);
                client.Property(x => x.UserCodeType).HasMaxLength(100);

                client.HasIndex(x => x.ClienteIdDescripcion).IsUnique();

                client.HasMany(x => x.TiposConcesionesHabilitadas).WithOne(x => x.Cliente).HasForeignKey(x=>x.ClienteId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.ClienteRedirigirUris).WithOne(x => x.Cliente).HasForeignKey(x => x.ClienteId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.ClienteRedirigirCerrarSesionUris).WithOne(x => x.Cliente).HasForeignKey(x => x.ClienteId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.AllowedScopes).WithOne(x => x.Cliente).HasForeignKey(x => x.ClienteId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.ClienteSecretos).WithOne(x => x.Cliente).HasForeignKey(x => x.ClienteId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //client.HasMany(x => x.Claims).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //client.HasMany(x => x.IdentityProviderRestrictions).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.AllowedCorsOrigins).WithOne(x => x.Cliente).HasForeignKey(x => x.ClienteId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //client.HasMany(x => x.Properties).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ClienteTipoConcesionEntity>(grantType =>
            {
                grantType.ToTable(storeOptions.ClientGrantType).HasKey(x=>x.ClienteTipoConcesionId);
                grantType.Property(x => x.TipoConcesion).HasMaxLength(250).IsRequired();
            });

            modelBuilder.Entity<ClienteUrlRedirigirEntity>(redirectUri =>
            {
                redirectUri.ToTable(storeOptions.ClientRedirectUri).HasKey(x => x.ClienteUrlRedirigirId);
                redirectUri.Property(x => x.Url).HasMaxLength(2000).IsRequired();
            });

            modelBuilder.Entity<ClienteUrlRedirigirCerrarSesionEntity>(postLogoutRedirectUri =>
            {
                postLogoutRedirectUri.ToTable(storeOptions.ClientPostLogoutRedirectUri).HasKey(x => x.ClienteUrlRedirigirCerrarSesionId);
                postLogoutRedirectUri.Property(x => x.Url).HasMaxLength(2000).IsRequired();
            });

            modelBuilder.Entity<ClienteAlcanceEntity>(scope =>
            {
                scope.ToTable(storeOptions.ClientScopes).HasKey(x => x.ClienteAlcanceId);
                scope.Property(x => x.Alcance).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<ClienteSecretoEntity>(secret =>
            {
                secret.ToTable(storeOptions.ClientSecret).HasKey(x=>x.SecretoId);
                secret.Property(x => x.Valor).HasMaxLength(4000).IsRequired();
                secret.Property(x => x.Tipo).HasMaxLength(250).IsRequired();
                secret.Property(x => x.Descripcion).HasMaxLength(2000);
            });

            //modelBuilder.Entity<ClientClaim>(claim =>
            //{
            //    claim.ToTable(storeOptions.ClientClaim);
            //    claim.Property(x => x.Type).HasMaxLength(250).IsRequired();
            //    claim.Property(x => x.Value).HasMaxLength(250).IsRequired();
            //});

            //modelBuilder.Entity<ClientIdPRestriction>(idPRestriction =>
            //{
            //    idPRestriction.ToTable(storeOptions.ClientIdPRestriction);
            //    idPRestriction.Property(x => x.Provider).HasMaxLength(200).IsRequired();
            //});

            modelBuilder.Entity<ClienteOrigenCruzadoEntity>(corsOrigin =>
            {
                corsOrigin.ToTable(storeOptions.ClientCorsOrigin).HasKey(x => x.ClienteOrigenCruzadoId);
                corsOrigin.Property(x => x.Origen).HasMaxLength(150).IsRequired();
            });

            //modelBuilder.Entity<ClientProperty>(property =>
            //{
            //    property.ToTable(storeOptions.ClientProperty);
            //    property.Property(x => x.Key).HasMaxLength(250).IsRequired();
            //    property.Property(x => x.Value).HasMaxLength(2000).IsRequired();
            //});
        }

        /// <summary>
        /// Configures the persisted grant context.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="storeOptions">The store options.</param>
        public static void ConfigurePersistedGrantContext(this ModelBuilder modelBuilder, OperationalStoreOptions storeOptions)
        {
            if (!string.IsNullOrWhiteSpace(storeOptions.DefaultSchema)) modelBuilder.HasDefaultSchema(storeOptions.DefaultSchema);

            //modelBuilder.Entity<PersistedGrant>(grant =>
            //{
            //    grant.ToTable(storeOptions.PersistedGrants);

            //    grant.Property(x => x.Key).HasMaxLength(200).ValueGeneratedNever();
            //    grant.Property(x => x.Type).HasMaxLength(50).IsRequired();
            //    grant.Property(x => x.SubjectId).HasMaxLength(200);
            //    grant.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
            //    grant.Property(x => x.CreationTime).IsRequired();
            //    // 50000 chosen to be explicit to allow enough size to avoid truncation, yet stay beneath the MySql row size limit of ~65K
            //    // apparently anything over 4K converts to nvarchar(max) on SqlServer
            //    grant.Property(x => x.Data).HasMaxLength(50000).IsRequired();

            //    grant.HasKey(x => x.Key);

            //    grant.HasIndex(x => new { x.SubjectId, x.ClientId, x.Type });
            //});

            //modelBuilder.Entity<DeviceFlowCodes>(codes =>
            //{
            //    codes.ToTable(storeOptions.DeviceFlowCodes);

            //    codes.Property(x => x.DeviceCode).HasMaxLength(200).IsRequired();
            //    codes.Property(x => x.UserCode).HasMaxLength(200).IsRequired();
            //    codes.Property(x => x.SubjectId).HasMaxLength(200);
            //    codes.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
            //    codes.Property(x => x.CreationTime).IsRequired();
            //    codes.Property(x => x.Expiration).IsRequired();
            //    // 50000 chosen to be explicit to allow enough size to avoid truncation, yet stay beneath the MySql row size limit of ~65K
            //    // apparently anything over 4K converts to nvarchar(max) on SqlServer
            //    codes.Property(x => x.Data).HasMaxLength(50000).IsRequired();

            //    codes.HasKey(x => new {x.UserCode});

            //    codes.HasIndex(x => x.DeviceCode).IsUnique();
            //});
        }

        /// <summary>
        /// Configures the resources context.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="storeOptions">The store options.</param>
        public static void ConfigureResourcesContext(this ModelBuilder modelBuilder, ConfigurationStoreOptions storeOptions)
        {
            if (!string.IsNullOrWhiteSpace(storeOptions.DefaultSchema)) modelBuilder.HasDefaultSchema(storeOptions.DefaultSchema);

            //modelBuilder.Entity<IdentityResource>(identityResource =>
            //{
            //    identityResource.ToTable(storeOptions.IdentityResource).HasKey(x => x.Id);

            //    identityResource.Property(x => x.Name).HasMaxLength(200).IsRequired();
            //    identityResource.Property(x => x.DisplayName).HasMaxLength(200);
            //    identityResource.Property(x => x.Description).HasMaxLength(1000);

            //    identityResource.HasIndex(x => x.Name).IsUnique();

            //    identityResource.HasMany(x => x.UserClaims).WithOne(x => x.IdentityResource).HasForeignKey(x => x.IdentityResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            //    identityResource.HasMany(x => x.Properties).WithOne(x => x.IdentityResource).HasForeignKey(x => x.IdentityResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<IdentityClaim>(claim =>
            //{
            //    claim.ToTable(storeOptions.IdentityClaim).HasKey(x => x.Id);

            //    claim.Property(x => x.Type).HasMaxLength(200).IsRequired();
            //});

            //modelBuilder.Entity<IdentityResourceProperty>(property =>
            //{
            //    property.ToTable(storeOptions.IdentityResourceProperty);
            //    property.Property(x => x.Key).HasMaxLength(250).IsRequired();
            //    property.Property(x => x.Value).HasMaxLength(2000).IsRequired();
            //});



            modelBuilder.Entity<ApiEntity>(apiResource =>
            {
                apiResource.ToTable(storeOptions.ApiResource).HasKey(x => x.ApiId);

                apiResource.Property(x => x.Nombre).HasMaxLength(200).IsRequired();
                apiResource.Property(x => x.NombreMostrar).HasMaxLength(200);
                apiResource.Property(x => x.Descripcion).HasMaxLength(1000);

                apiResource.HasIndex(x => x.Nombre).IsUnique();

                apiResource.HasMany(x => x.Secretos).WithOne(x => x.Api).HasForeignKey(x => x.ApiId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                apiResource.HasMany(x => x.Alcances).WithOne(x => x.Api).HasForeignKey(x => x.ApiId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //apiResource.HasMany(x => x.USERCLAIMS).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                //apiResource.HasMany(x => x.PROPIEDADES).WithOne(x => x.ApiResource).HasForeignKey(x => x.ApiResourceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ApiSecretoEntity>(apiSecret =>
            {
                apiSecret.ToTable(storeOptions.ApiSecret).HasKey(x => x.SecretoId);

                apiSecret.Property(x => x.Descripcion).HasMaxLength(1000);
                apiSecret.Property(x => x.Valor).HasMaxLength(4000).IsRequired();
                apiSecret.Property(x => x.Tipo).HasMaxLength(250).IsRequired();
            });

            //modelBuilder.Entity<ApiResourceClaim>(apiClaim =>
            //{
            //    apiClaim.ToTable(storeOptions.ApiClaim).HasKey(x => x.Id);
            //    apiClaim.Property(x => x.Type).HasMaxLength(200).IsRequired();
            //});

            modelBuilder.Entity<ApiAlcanceEntity>(apiScope =>
            {
                apiScope.ToTable(storeOptions.ApiScope).HasKey(x => x.ApiAlcanceId);

                apiScope.Property(x => x.Nombre).HasMaxLength(200).IsRequired();
                apiScope.Property(x => x.NombreMostrar).HasMaxLength(200);
                apiScope.Property(x => x.Descripcion).HasMaxLength(1000);

                apiScope.HasIndex(x => x.Nombre).IsUnique();

                //apiScope.HasMany(x => x.UserClaims).WithOne(x => x.ApiScope).HasForeignKey(x => x.ApiScopeId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity<ApiScopeClaim>(apiScopeClaim =>
            //{
            //    apiScopeClaim.ToTable(storeOptions.ApiScopeClaim).HasKey(x => x.Id);

            //    apiScopeClaim.Property(x => x.Type).HasMaxLength(200).IsRequired();
            //});

            //modelBuilder.Entity<ApiResourceProperty>(property =>
            //{
            //    property.ToTable(storeOptions.ApiResourceProperty);
            //    property.Property(x => x.Key).HasMaxLength(250).IsRequired();
            //    property.Property(x => x.Value).HasMaxLength(2000).IsRequired();
            //});

        }
    }
}
