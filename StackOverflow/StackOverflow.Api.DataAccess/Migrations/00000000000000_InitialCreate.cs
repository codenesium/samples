using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.DataAccess.Migrations
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


--IF OBJECT_ID('dbo.Badges', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Badges]
--END
--GO
--IF OBJECT_ID('dbo.Comments', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Comments]
--END
--GO
--IF OBJECT_ID('dbo.LinkTypes', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[LinkTypes]
--END
--GO
--IF OBJECT_ID('dbo.PostHistory', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PostHistory]
--END
--GO
--IF OBJECT_ID('dbo.PostHistoryTypes', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PostHistoryTypes]
--END
--GO
--IF OBJECT_ID('dbo.PostLinks', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PostLinks]
--END
--GO
--IF OBJECT_ID('dbo.Posts', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Posts]
--END
--GO
--IF OBJECT_ID('dbo.PostTypes', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PostTypes]
--END
--GO
--IF OBJECT_ID('dbo.Tags', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Tags]
--END
--GO
--IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Users]
--END
--GO
--IF OBJECT_ID('dbo.Votes', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Votes]
--END
--GO
--IF OBJECT_ID('dbo.VoteTypes', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[VoteTypes]
--END
--GO

CREATE TABLE [dbo].[Badges](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[Date] [datetime]     NOT NULL,
[Name] [nvarchar]  (40)   NOT NULL,
[UserId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Comments](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[CreationDate] [datetime]     NOT NULL,
[PostId] [int]     NOT NULL,
[Score] [int]     NULL,
[Text] [nvarchar]  (700)   NOT NULL,
[UserId] [int]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[LinkTypes](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[Type] [varchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PostHistory](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[Comment] [ntext]     NULL,
[CreationDate] [datetime]     NOT NULL,
[PostHistoryTypeId] [int]     NOT NULL,
[PostId] [int]     NOT NULL,
[RevisionGUID] [char]  (36)   NOT NULL,
[Text] [ntext]     NULL,
[UserDisplayName] [nvarchar]  (40)   NULL,
[UserId] [int]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PostHistoryTypes](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[Type] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PostLinks](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[CreationDate] [datetime]     NOT NULL,
[LinkTypeId] [int]     NOT NULL,
[PostId] [int]     NOT NULL,
[RelatedPostId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Posts](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[AcceptedAnswerId] [int]     NULL,
[AnswerCount] [int]     NULL,
[Body] [nvarchar]     NOT NULL,
[ClosedDate] [datetime]     NULL,
[CommentCount] [int]     NULL,
[CommunityOwnedDate] [datetime]     NULL,
[CreationDate] [datetime]     NOT NULL,
[FavoriteCount] [int]     NULL,
[LastActivityDate] [datetime]     NOT NULL,
[LastEditDate] [datetime]     NULL,
[LastEditorDisplayName] [nvarchar]  (40)   NULL,
[LastEditorUserId] [int]     NULL,
[OwnerUserId] [int]     NULL,
[ParentId] [int]     NULL,
[PostTypeId] [int]     NOT NULL,
[Score] [int]     NOT NULL,
[Tags] [nvarchar]  (150)   NULL,
[Title] [nvarchar]  (250)   NULL,
[ViewCount] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PostTypes](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[Type] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Tags](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[Count] [int]     NOT NULL,
[ExcerptPostId] [int]     NOT NULL,
[TagName] [nvarchar]  (150)   NOT NULL,
[WikiPostId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Users](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[AboutMe] [nvarchar]     NULL,
[AccountId] [int]     NULL,
[Age] [int]     NULL,
[CreationDate] [datetime]     NOT NULL,
[DisplayName] [nvarchar]  (40)   NOT NULL,
[DownVotes] [int]     NOT NULL,
[EmailHash] [nvarchar]  (40)   NULL,
[LastAccessDate] [datetime]     NOT NULL,
[Location] [nvarchar]  (100)   NULL,
[Reputation] [int]     NOT NULL,
[UpVotes] [int]     NOT NULL,
[Views] [int]     NOT NULL,
[WebsiteUrl] [nvarchar]  (200)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Votes](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[BountyAmount] [int]     NULL,
[CreationDate] [datetime]     NOT NULL,
[PostId] [int]     NOT NULL,
[UserId] [int]     NULL,
[VoteTypeId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[VoteTypes](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[Name] [varchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Badges]
ADD CONSTRAINT[PK_Badges__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Comments]
ADD CONSTRAINT[PK_Comments__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[LinkTypes]
ADD CONSTRAINT[PK_LinkTypes__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PostHistory]
ADD CONSTRAINT[PK_PostHistory__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PostHistoryTypes]
ADD CONSTRAINT[PK_PostHistoryTypes__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PostLinks]
ADD CONSTRAINT[PK_PostLinks__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Posts]
ADD CONSTRAINT[PK_Posts__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[NonClusteredIndex-20180824-123547] ON[dbo].[Posts]
(
[OwnerUserId] ASC)
INCLUDE(
[AnswerCount])
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PostTypes]
ADD CONSTRAINT[PK_PostTypes__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Tags]
ADD CONSTRAINT[PK_Tags__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Users]
ADD CONSTRAINT[PK_Users_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Votes]
ADD CONSTRAINT[PK_Votes__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[NonClusteredIndex-20180824-125907] ON[dbo].[Votes]
(
[UserId] ASC)
INCLUDE(
[PostId],
[VoteTypeId])
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[VoteTypes]
ADD CONSTRAINT[PK_VoteType__Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO



");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}