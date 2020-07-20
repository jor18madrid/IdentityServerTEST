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
                    ApiId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Habilitar = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    NombreMostrar = table.Column<string>(maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 1000, nullable: true),
                    FECHACREACION = table.Column<DateTime>(nullable: false),
                    FECHAMODIFICACION = table.Column<DateTime>(nullable: true),
                    FechaUltimoAcceso = table.Column<DateTime>(nullable: true),
                    NoEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLAPIS", x => x.ApiId);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTES",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Habilitar = table.Column<bool>(nullable: false),
                    ClienteIdDescripcion = table.Column<string>(maxLength: 200, nullable: false),
                    TipoProtocolo = table.Column<string>(maxLength: 200, nullable: false),
                    RequiereSecreto = table.Column<bool>(nullable: false),
                    NombreCiente = table.Column<string>(maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 1000, nullable: true),
                    ClienteUrl = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    RequiereConsentimiento = table.Column<bool>(nullable: false),
                    PermitirRecordarConsentimiento = table.Column<bool>(nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    RequierePkce = table.Column<bool>(nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    HabilitarTokenDesdeNavegador = table.Column<bool>(nullable: false),
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
                    table.PrimaryKey("PK_TBLCLIENTES", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "TBLAPIALCANCES",
                columns: table => new
                {
                    ApiAlcanceId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    NombreMostrar = table.Column<string>(maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 1000, nullable: true),
                    Requerido = table.Column<bool>(nullable: false),
                    Enfatizar = table.Column<bool>(nullable: false),
                    MostrarDocumentoDescubrimiento = table.Column<bool>(nullable: false),
                    ApiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLAPIALCANCES", x => x.ApiAlcanceId);
                    table.ForeignKey(
                        name: "FK_TBLAPIALCANCES_TBLAPIS_ApiId",
                        column: x => x.ApiId,
                        principalTable: "TBLAPIS",
                        principalColumn: "ApiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLAPISECRETOS",
                columns: table => new
                {
                    SecretoId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 1000, nullable: true),
                    Valor = table.Column<string>(maxLength: 4000, nullable: false),
                    FechaExpiracion = table.Column<DateTime>(nullable: true),
                    Tipo = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ApiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLAPISECRETOS", x => x.SecretoId);
                    table.ForeignKey(
                        name: "FK_TBLAPISECRETOS_TBLAPIS_ApiId",
                        column: x => x.ApiId,
                        principalTable: "TBLAPIS",
                        principalColumn: "ApiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTEALCANCES",
                columns: table => new
                {
                    ClienteAlcanceId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Alcance = table.Column<string>(maxLength: 200, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTEALCANCES", x => x.ClienteAlcanceId);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTEALCANCES_TBLCLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTEORIGENCRUZADO",
                columns: table => new
                {
                    ClienteOrigenCruzadoId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Origen = table.Column<string>(maxLength: 150, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTEORIGENCRUZADO", x => x.ClienteOrigenCruzadoId);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTEORIGENCRUZADO_TBLCLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTESECRETOS",
                columns: table => new
                {
                    SecretoId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 2000, nullable: true),
                    Valor = table.Column<string>(maxLength: 4000, nullable: false),
                    FechaExpiracion = table.Column<DateTime>(nullable: true),
                    Tipo = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTESECRETOS", x => x.SecretoId);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTESECRETOS_TBLCLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTETIPOSCONCESIONES",
                columns: table => new
                {
                    ClienteTipoConcesionId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TipoConcesion = table.Column<string>(maxLength: 250, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTETIPOSCONCESIONES", x => x.ClienteTipoConcesionId);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTETIPOSCONCESIONES_TBLCLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTEURLREDIRIGIR",
                columns: table => new
                {
                    ClienteUrlRedirigirId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(maxLength: 2000, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTEURLREDIRIGIR", x => x.ClienteUrlRedirigirId);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTEURLREDIRIGIR_TBLCLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLCLIENTEURLREDIRIGIRCERRARSESION",
                columns: table => new
                {
                    ClienteUrlRedirigirCerrarSesionId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(maxLength: 2000, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLCLIENTEURLREDIRIGIRCERRARSESION", x => x.ClienteUrlRedirigirCerrarSesionId);
                    table.ForeignKey(
                        name: "FK_TBLCLIENTEURLREDIRIGIRCERRARSESION_TBLCLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBLCLIENTES",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPIALCANCES_ApiId",
                table: "TBLAPIALCANCES",
                column: "ApiId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPIALCANCES_Nombre",
                table: "TBLAPIALCANCES",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPIS_Nombre",
                table: "TBLAPIS",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLAPISECRETOS_ApiId",
                table: "TBLAPISECRETOS",
                column: "ApiId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTEALCANCES_ClienteId",
                table: "TBLCLIENTEALCANCES",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTEORIGENCRUZADO_ClienteId",
                table: "TBLCLIENTEORIGENCRUZADO",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTES_ClienteIdDescripcion",
                table: "TBLCLIENTES",
                column: "ClienteIdDescripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTESECRETOS_ClienteId",
                table: "TBLCLIENTESECRETOS",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTETIPOSCONCESIONES_ClienteId",
                table: "TBLCLIENTETIPOSCONCESIONES",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTEURLREDIRIGIR_ClienteId",
                table: "TBLCLIENTEURLREDIRIGIR",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLCLIENTEURLREDIRIGIRCERRARSESION_ClienteId",
                table: "TBLCLIENTEURLREDIRIGIRCERRARSESION",
                column: "ClienteId");
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
                name: "TBLCLIENTESECRETOS");

            migrationBuilder.DropTable(
                name: "TBLCLIENTETIPOSCONCESIONES");

            migrationBuilder.DropTable(
                name: "TBLCLIENTEURLREDIRIGIR");

            migrationBuilder.DropTable(
                name: "TBLCLIENTEURLREDIRIGIRCERRARSESION");

            migrationBuilder.DropTable(
                name: "TBLAPIS");

            migrationBuilder.DropTable(
                name: "TBLCLIENTES");
        }
    }
}
