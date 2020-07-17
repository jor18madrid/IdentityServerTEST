using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace IdentityServer.Data.Migrations.IdentityServer.ConfigurationDb
{
    public partial class InitialConfigurationDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBLAPIS",
                columns: table => new
                {
                    APIID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    HABILITAR = table.Column<bool>(nullable: false),
                    NOMBRE = table.Column<string>(maxLength: 200, nullable: false),
                    NOMBREMOSTRAR = table.Column<string>(maxLength: 200, nullable: true),
                    DESCRIPCION = table.Column<string>(maxLength: 1000, nullable: true),
                    FECHACREACION = table.Column<DateTime>(nullable: false),
                    FECHAMODIFICACION = table.Column<DateTime>(nullable: true),
                    FECHAULTIMOACCESO = table.Column<DateTime>(nullable: true),
                    NOEDITABLE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLAPIS", x => x.APIID);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    ProtocolType = table.Column<string>(maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(nullable: false),
                    AllowRememberConsent = table.Column<bool>(nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    RequirePkce = table.Column<bool>(nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    IdentityTokenLifetime = table.Column<int>(nullable: false),
                    AccessTokenLifetime = table.Column<int>(nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(nullable: false),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false),
                    RefreshTokenUsage = table.Column<int>(nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false),
                    AccessTokenType = table.Column<int>(nullable: false),
                    EnableLocalLogin = table.Column<bool>(nullable: false),
                    IncludeJwtId = table.Column<bool>(nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(nullable: false),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBLAPIALCANCES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLAPIALCANCES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLAPIALCANCES_TBLAPIS_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "TBLAPIS",
                        principalColumn: "APIID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLAPISECRETOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLAPISECRETOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLAPISECRETOS_TBLAPIS_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "TBLAPIS",
                        principalColumn: "APIID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTEALCANCES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Scope = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTEALCANCES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTEALCANCES_TBLCLIENTES_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTEORIGENCRUZADO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Origin = table.Column<string>(maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTEORIGENCRUZADO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTEORIGENCRUZADO_TBLCLIENTES_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTEREDIRIGIRCERRARSESIONURL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTEREDIRIGIRCERRARSESIONURL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTEREDIRIGIRCERRARSESIONURL_TBLCLIENTES_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTEREDIRIGIRURL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    RedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTEREDIRIGIRURL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTEREDIRIGIRURL_TBLCLIENTES_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTESECRETOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTESECRETOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTESECRETOS_TBLCLIENTES_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLTIPOSCONCESIONES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    GrantType = table.Column<string>(maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLTIPOSCONCESIONES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLTIPOSCONCESIONES_TBLCLIENTES_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPIALCANCES_ApiResourceId",
                table: "TBLAPIALCANCES",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPIALCANCES_Name",
                table: "TBLAPIALCANCES",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPIS_NOMBRE",
                table: "TBLAPIS",
                column: "NOMBRE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPISECRETOS_ApiResourceId",
                table: "TBLAPISECRETOS",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTEALCANCES_ClientId",
                table: "TBLCLIENTEALCANCES",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTEORIGENCRUZADO_ClientId",
                table: "TBLCLIENTEORIGENCRUZADO",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTEREDIRIGIRCERRARSESIONURL_ClientId",
                table: "TBLCLIENTEREDIRIGIRCERRARSESIONURL",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTEREDIRIGIRURL_ClientId",
                table: "TBLCLIENTEREDIRIGIRURL",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTES_ClientId",
                table: "TBLCLIENTES",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTESECRETOS_ClientId",
                table: "TBLCLIENTESECRETOS",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLTIPOSCONCESIONES_ClientId",
                table: "TBLTIPOSCONCESIONES",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBLAPIALCANCES");

            migrationBuilder.DropTable(
                name: "TBLAPISECRETOS");

            migrationBuilder.DropTable(
                name: "TBLCLIENTEALCANCES");

            migrationBuilder.DropTable(
                name: "TBLCLIENTEORIGENCRUZADO");

            migrationBuilder.DropTable(
                name: "TBLCLIENTEREDIRIGIRCERRARSESIONURL");

            migrationBuilder.DropTable(
                name: "TBLCLIENTEREDIRIGIRURL");

            migrationBuilder.DropTable(
                name: "TBLCLIENTESECRETOS");

            migrationBuilder.DropTable(
                name: "TBLTIPOSCONCESIONES");

            migrationBuilder.DropTable(
                name: "TBLAPIS");

            migrationBuilder.DropTable(
                name: "TBLCLIENTES");
        }
    }
}
