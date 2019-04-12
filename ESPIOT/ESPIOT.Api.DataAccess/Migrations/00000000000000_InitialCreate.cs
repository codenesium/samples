using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.DataAccess.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
    [Migration("00000000000000_InitialCreate")]
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
				if (this.ActiveProvider == "Microsoft.EntityFrameworkCore.SqlServer")
				{
					migrationBuilder.Sql(@"IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'dbo')
EXEC('CREATE SCHEMA [dbo] AUTHORIZATION [dbo]');
GO

--IF (OBJECT_ID('dbo.FK_DeviceAction_Device', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[DeviceAction] DROP CONSTRAINT [FK_DeviceAction_Device]
--END
--GO

--IF OBJECT_ID('dbo.Device', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Device]
--END
--GO
--IF OBJECT_ID('dbo.DeviceAction', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[DeviceAction]
--END
--GO

CREATE TABLE [dbo].[Device](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[dateOfLastPing] [datetime]     NOT NULL,
[isActive] [bit]     NOT NULL,
[name] [varchar]  (90)   NOT NULL,
[publicId] [uniqueidentifier]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[DeviceAction](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[action] [varchar]  (4000)   NOT NULL,
[deviceId] [int]     NOT NULL,
[name] [varchar]  (90)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Device]
ADD CONSTRAINT[PK_Device] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[IX_Device] ON[dbo].[Device]
(
[publicId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[DeviceAction]
ADD CONSTRAINT[PK_Action] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_DeviceAction_deviceActionId] ON[dbo].[DeviceAction]
(
[id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_DeviceAction_DeviceId] ON[dbo].[DeviceAction]
(
[deviceId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[DeviceAction]  WITH CHECK ADD  CONSTRAINT[FK_DeviceAction_Device] FOREIGN KEY([deviceId])
REFERENCES[dbo].[Device]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[DeviceAction] CHECK CONSTRAINT[FK_DeviceAction_Device]
GO

");
				}
				else if (this.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
				{
					migrationBuilder.Sql(@"CREATE SCHEMA IF NOT EXISTS ""dbo"";

--ALTER TABLE ""dbo"".""DeviceAction"" DISABLE TRIGGER ALL;

--DROP TABLE IF EXISTS ""dbo"".""Device"";
--DROP TABLE IF EXISTS ""dbo"".""DeviceAction"";

CREATE TABLE ""dbo"".""Device""(
""id""  SERIAL ,
""dateOfLastPing"" timestamp    NOT NULL,
""isActive"" boolean    NOT NULL,
""name"" varchar  (90)  NOT NULL,
""publicId"" uuid    NOT NULL);

CREATE TABLE ""dbo"".""DeviceAction""(
""id""  SERIAL ,
""action"" varchar  (4000)  NOT NULL,
""deviceId"" int    NOT NULL,
""name"" varchar  (90)  NOT NULL);

ALTER TABLE ""dbo"".""Device""
ADD CONSTRAINT ""PK_Device""
PRIMARY KEY
(
""id""
);
CREATE UNIQUE INDEX ""IX_Device"" ON ""dbo"".""Device""
(
""publicId"" ASC);
ALTER TABLE ""dbo"".""DeviceAction""
ADD CONSTRAINT ""PK_Action""
PRIMARY KEY
(
""id""
);
CREATE  INDEX ""IX_DeviceAction_deviceActionId"" ON ""dbo"".""DeviceAction""
(
""id"" ASC);
CREATE  INDEX ""IX_DeviceAction_DeviceId"" ON ""dbo"".""DeviceAction""
(
""deviceId"" ASC);


ALTER TABLE ""dbo"".""DeviceAction"" ADD CONSTRAINT ""FK_DeviceAction_Device"" FOREIGN KEY(""deviceId"")
REFERENCES ""dbo"".""Device"" (""id"");

");
				}
				else
				{
					throw new NotImplementedException($"Unknown database provider. ActiveProvider={this.ActiveProvider}");
				}
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}