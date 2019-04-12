using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CADNS.Api.DataAccess.Migrations
{
		[DbContext(typeof(ApplicationDbContext))]
	[Migration("00000000000001_CreateIdentitySchema")]
	public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
				columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
					NewEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
				columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(maxLength: 36, nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
				columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 36, nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
						principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
				columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 256, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 256, nullable: false),
                    ProviderDisplayName = table.Column<string>(maxLength: 256, nullable: true),
                    UserId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
				columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 36, nullable: false),
                    RoleId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
				columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 36, nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

				if (this.ActiveProvider == "Microsoft.EntityFrameworkCore.SqlServer")
				{
					migrationBuilder.Sql(@"--Insert a default user with a username of test@test.com and pasword of Passw0rd$
				INSERT into [AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'cfc34544-c57e-47d1-bc30-355dcfb35f5a', N'test@test.com', N'TEST@TEST.COM', N'test@test.com', N'TEST@TEST.COM', 0, N'AQAAAAEAACcQAAAAEPHgwwSOWc0RC+QoKECQI4uhmqAuU5WWlMzgdWfVzlVqvmlH1OP3VpaIQr1t/BfPOA==', N'LYDQKGGRKXO4QYYP5NCCCMWDLKOWGI45', N'f6fbabae-d7c6-4ffd-9f93-841fcaf20e99', NULL, 0, 0, NULL, 1, 0)
				GO
				-- Add User Role
				INSERT into [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES 
				(N'225acd4b-5ec9-43e9-9fbe-9153033f45c9', N'User', N'USER', NULL)
				GO
				--Add Administrator Role
				INSERT into [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'55571210-c2b0-40e0-baf8-32882524bec8', N'Administrator', N'ADMINISTRATOR', N'')
				GO
				--Assign Admin user to User role
				INSERT into [AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cfc34544-c57e-47d1-bc30-355dcfb35f5a', N'225acd4b-5ec9-43e9-9fbe-9153033f45c9')
				GO
				--Assign Admin to Administrator Role
				INSERT  into [AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cfc34544-c57e-47d1-bc30-355dcfb35f5a', N'55571210-c2b0-40e0-baf8-32882524bec8')
				GO
				");
				}
				else if (this.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
				{
					migrationBuilder.Sql(@"--Insert a default user with a username of test@test.com and pasword of Passw0rd$
				INSERT into ""AspNetUsers"" (""Id"", ""UserName"", ""NormalizedUserName"", ""Email"", ""NormalizedEmail"", ""EmailConfirmed"", ""PasswordHash"", ""SecurityStamp"", ""ConcurrencyStamp"", ""PhoneNumber"", ""PhoneNumberConfirmed"", ""TwoFactorEnabled"", ""LockoutEnd"", ""LockoutEnabled"",""AccessFailedCount"") VALUES (N'cfc34544-c57e-47d1-bc30-355dcfb35f5a', N'test@test.com', N'TEST@TEST.COM', N'test@test.com', N'TEST@TEST.COM',TRUE, N'AQAAAAEAACcQAAAAEPHgwwSOWc0RC+QoKECQI4uhmqAuU5WWlMzgdWfVzlVqvmlH1OP3VpaIQr1t/BfPOA==', N'LYDQKGGRKXO4QYYP5NCCCMWDLKOWGI45', N'f6fbabae-d7c6-4ffd-9f93-841fcaf20e99', NULL, FALSE, FALSE, NULL, TRUE, 0);
			
				-- Add User Role
				INSERT into ""AspNetRoles"" (""Id"", ""Name"", ""NormalizedName"", ""ConcurrencyStamp"") VALUES 
				(N'225acd4b-5ec9-43e9-9fbe-9153033f45c9', N'User', N'USER', NULL);

				--Add Administrator Role
				INSERT into ""AspNetRoles"" (""Id"", ""Name"", ""NormalizedName"", ""ConcurrencyStamp"") VALUES (N'55571210-c2b0-40e0-baf8-32882524bec8', N'Administrator', N'ADMINISTRATOR', N'');

				--Assign Admin user to User role
				INSERT into ""AspNetUserRoles"" (""UserId"", ""RoleId"") VALUES (N'cfc34544-c57e-47d1-bc30-355dcfb35f5a', N'225acd4b-5ec9-43e9-9fbe-9153033f45c9');

				--Assign Admin to Administrator Role
				INSERT into ""AspNetUserRoles"" (""UserId"", ""RoleId"") VALUES (N'cfc34544-c57e-47d1-bc30-355dcfb35f5a', N'55571210-c2b0-40e0-baf8-32882524bec8');
				");
			}
			else
			{
				throw new NotImplementedException($"Unknown database provider. ActiveProvider={this.ActiveProvider}");
			}
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}