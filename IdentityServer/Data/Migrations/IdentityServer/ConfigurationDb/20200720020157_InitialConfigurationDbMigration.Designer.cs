﻿// <auto-generated />
using System;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace IdentityServer.Data.Migrations.IdentityServer.ConfigurationDb
{
    [DbContext(typeof(ConfigurationDbContext))]
    [Migration("20200720020157_InitialConfigurationDbMigration")]
    partial class InitialConfigurationDbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiAlcanceEntity", b =>
                {
                    b.Property<int>("ApiAlcanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApiId");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(1000);

                    b.Property<bool>("Enfatizar");

                    b.Property<bool>("MostrarDocumentoDescubrimiento");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NombreMostrar")
                        .HasMaxLength(200);

                    b.Property<bool>("Requerido");

                    b.HasKey("ApiAlcanceId");

                    b.HasIndex("ApiId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("TBLAPIALCANCES");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiEntity", b =>
                {
                    b.Property<int>("ApiId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("FECHACREACION");

                    b.Property<DateTime?>("FECHAMODIFICACION");

                    b.Property<DateTime?>("FechaUltimoAcceso");

                    b.Property<bool>("Habilitar");

                    b.Property<bool>("NoEditable");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NombreMostrar")
                        .HasMaxLength(200);

                    b.HasKey("ApiId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("TBLAPIS");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiSecretoEntity", b =>
                {
                    b.Property<int>("SecretoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApiId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("FechaExpiracion");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasMaxLength(4000);

                    b.HasKey("SecretoId");

                    b.HasIndex("ApiId");

                    b.ToTable("TBLAPISECRETOS");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteAlcanceEntity", b =>
                {
                    b.Property<int>("ClienteAlcanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alcance")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("ClienteId");

                    b.HasKey("ClienteAlcanceId");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBLCLIENTEALCANCES");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteEntity", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AbsoluteRefreshTokenLifetime");

                    b.Property<int>("AccessTokenLifetime");

                    b.Property<int>("AccessTokenType");

                    b.Property<bool>("AllowOfflineAccess");

                    b.Property<bool>("AllowPlainTextPkce");

                    b.Property<bool>("AlwaysIncludeUserClaimsInIdToken");

                    b.Property<bool>("AlwaysSendClientClaims");

                    b.Property<int>("AuthorizationCodeLifetime");

                    b.Property<bool>("BackChannelLogoutSessionRequired");

                    b.Property<string>("BackChannelLogoutUri")
                        .HasMaxLength(2000);

                    b.Property<string>("ClientClaimsPrefix")
                        .HasMaxLength(200);

                    b.Property<string>("ClienteIdDescripcion")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ClienteUrl")
                        .HasMaxLength(2000);

                    b.Property<int?>("ConsentLifetime");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(1000);

                    b.Property<int>("DeviceCodeLifetime");

                    b.Property<bool>("EnableLocalLogin");

                    b.Property<bool>("FrontChannelLogoutSessionRequired");

                    b.Property<string>("FrontChannelLogoutUri")
                        .HasMaxLength(2000);

                    b.Property<bool>("Habilitar");

                    b.Property<bool>("HabilitarTokenDesdeNavegador");

                    b.Property<int>("IdentityTokenLifetime");

                    b.Property<bool>("IncludeJwtId");

                    b.Property<DateTime?>("LastAccessed");

                    b.Property<string>("LogoUri")
                        .HasMaxLength(2000);

                    b.Property<string>("NombreCiente")
                        .HasMaxLength(200);

                    b.Property<bool>("NonEditable");

                    b.Property<string>("PairWiseSubjectSalt")
                        .HasMaxLength(200);

                    b.Property<bool>("PermitirRecordarConsentimiento");

                    b.Property<int>("RefreshTokenExpiration");

                    b.Property<int>("RefreshTokenUsage");

                    b.Property<bool>("RequiereConsentimiento");

                    b.Property<bool>("RequierePkce");

                    b.Property<bool>("RequiereSecreto");

                    b.Property<int>("SlidingRefreshTokenLifetime");

                    b.Property<string>("TipoProtocolo")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("UpdateAccessTokenClaimsOnRefresh");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UserCodeType")
                        .HasMaxLength(100);

                    b.Property<int?>("UserSsoLifetime");

                    b.HasKey("ClienteId");

                    b.HasIndex("ClienteIdDescripcion")
                        .IsUnique();

                    b.ToTable("TBLCLIENTES");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteOrigenCruzadoEntity", b =>
                {
                    b.Property<int>("ClienteOrigenCruzadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("ClienteOrigenCruzadoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBLCLIENTEORIGENCRUZADO");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteSecretoEntity", b =>
                {
                    b.Property<int>("SecretoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(2000);

                    b.Property<DateTime?>("FechaExpiracion");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasMaxLength(4000);

                    b.HasKey("SecretoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBLCLIENTESECRETOS");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteTipoConcesionEntity", b =>
                {
                    b.Property<int>("ClienteTipoConcesionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<string>("TipoConcesion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("ClienteTipoConcesionId");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBLCLIENTETIPOSCONCESIONES");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteUrlRedirigirCerrarSesionEntity", b =>
                {
                    b.Property<int>("ClienteUrlRedirigirCerrarSesionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.HasKey("ClienteUrlRedirigirCerrarSesionId");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBLCLIENTEURLREDIRIGIRCERRARSESION");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteUrlRedirigirEntity", b =>
                {
                    b.Property<int>("ClienteUrlRedirigirId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.HasKey("ClienteUrlRedirigirId");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBLCLIENTEURLREDIRIGIR");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiAlcanceEntity", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiEntity", "Api")
                        .WithMany("Alcances")
                        .HasForeignKey("ApiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiSecretoEntity", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiEntity", "Api")
                        .WithMany("Secretos")
                        .HasForeignKey("ApiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteAlcanceEntity", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ClienteEntity", "Cliente")
                        .WithMany("AllowedScopes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteOrigenCruzadoEntity", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ClienteEntity", "Cliente")
                        .WithMany("AllowedCorsOrigins")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteSecretoEntity", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ClienteEntity", "Cliente")
                        .WithMany("ClienteSecretos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteTipoConcesionEntity", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ClienteEntity", "Cliente")
                        .WithMany("HabilitarTiposConcesiones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteUrlRedirigirCerrarSesionEntity", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ClienteEntity", "Cliente")
                        .WithMany("ClienteRedirigirCerrarSesionUris")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClienteUrlRedirigirEntity", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ClienteEntity", "Cliente")
                        .WithMany("ClienteRedirigirUris")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}