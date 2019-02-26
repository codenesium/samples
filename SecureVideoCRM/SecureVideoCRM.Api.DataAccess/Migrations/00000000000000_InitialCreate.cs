using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using SecureVideoCRMNS.Api.DataAccess;

namespace SecureVideoCRMNS.Api.DataAccess.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
    [Migration("00000000000000_InitialCreate")]
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'dbo')
EXEC('CREATE SCHEMA [dbo] AUTHORIZATION [dbo]');
GO

--IF (OBJECT_ID('dbo.fk_user_subscriptionid_subscription_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[User] DROP CONSTRAINT [fk_user_subscriptionid_subscription_id]
--END
--GO

--IF OBJECT_ID('dbo.Video', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Video]
--END
--GO
--IF OBJECT_ID('dbo.User', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[User]
--END
--GO
--IF OBJECT_ID('dbo.Subscription', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Subscription]
--END
--GO

CREATE TABLE [dbo].[Video](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[title] [varchar]  (128)   NOT NULL,
[url] [varchar]  (128)   NOT NULL,
[description] [varchar]  (4000)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[User](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[password] [varchar]  (128)   NOT NULL,
[subscriptionId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Subscription](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Video]
ADD CONSTRAINT[PK_Video] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[User]
ADD CONSTRAINT[PK_User] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_User_subscriptionId] ON[dbo].[User]
(
[subscriptionId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Subscription]
ADD CONSTRAINT[PK_Subscription] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[User]  WITH CHECK ADD  CONSTRAINT[fk_user_subscriptionid_subscription_id] FOREIGN KEY([subscriptionId])
REFERENCES[dbo].[Subscription]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[User] CHECK CONSTRAINT[fk_user_subscriptionid_subscription_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}