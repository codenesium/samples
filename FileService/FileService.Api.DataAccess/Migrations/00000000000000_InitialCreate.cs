using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.DataAccess.Migrations
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

CREATE TABLE [dbo].[Bucket](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[externalId] [uniqueidentifier]     NOT NULL,
[name] [nvarchar]  (255)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[File](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[bucketId] [int]     NULL,
[dateCreated] [datetime]     NOT NULL,
[description] [nvarchar]  (255)   NULL,
[expiration] [datetime]     NOT NULL,
[extension] [varchar]  (32)   NOT NULL,
[externalId] [uniqueidentifier]     NOT NULL,
[fileSizeInBytes] [decimal]     NOT NULL,
[fileTypeId] [int]     NOT NULL,
[location] [varchar]  (255)   NOT NULL,
[privateKey] [varchar]  (64)   NOT NULL,
[publicKey] [varchar]  (64)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[FileType](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (255)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[VersionInfo](
[AppliedOn] [datetime]     NULL,
[Description] [nvarchar]  (1024)   NULL,
[Version] [bigint]     NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Bucket]
ADD CONSTRAINT[PK_Bucket] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[IX_Bucket_externalId] ON[dbo].[Bucket]
(
[externalId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[IX_Bucket_name] ON[dbo].[Bucket]
(
[name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[File]
ADD CONSTRAINT[PK_File] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[FileType]
ADD CONSTRAINT[PK_FileType] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE CLUSTERED INDEX[UC_Version] ON[dbo].[VersionInfo]
(
[Version] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[File]  WITH CHECK ADD  CONSTRAINT[FK_File_Bucket] FOREIGN KEY([bucketId])
REFERENCES[dbo].[Bucket]([id])
GO
ALTER TABLE[dbo].[File] CHECK CONSTRAINT[FK_File_Bucket]
GO
ALTER TABLE[dbo].[File]  WITH CHECK ADD  CONSTRAINT[FK_File_fileTypeId_FileType_id] FOREIGN KEY([fileTypeId])
REFERENCES[dbo].[FileType]([id])
GO
ALTER TABLE[dbo].[File] CHECK CONSTRAINT[FK_File_fileTypeId_FileType_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
          
		}
	}
};