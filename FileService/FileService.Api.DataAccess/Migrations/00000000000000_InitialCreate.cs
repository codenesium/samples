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
				if (this.ActiveProvider == "Microsoft.EntityFrameworkCore.SqlServer")
				{
					migrationBuilder.Sql(@"IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'dbo')
EXEC('CREATE SCHEMA [dbo] AUTHORIZATION [dbo]');
GO

--IF (OBJECT_ID('dbo.FK_File_Bucket', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[File] DROP CONSTRAINT [FK_File_Bucket]
--END
--GO
--IF (OBJECT_ID('dbo.FK_File_fileTypeId_FileType_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[File] DROP CONSTRAINT [FK_File_fileTypeId_FileType_id]
--END
--GO

--IF OBJECT_ID('dbo.Bucket', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Bucket]
--END
--GO
--IF OBJECT_ID('dbo.File', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[File]
--END
--GO
--IF OBJECT_ID('dbo.FileType', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[FileType]
--END
--GO
--IF OBJECT_ID('dbo.VersionInfo', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[VersionInfo]
--END
--GO

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
[Version] [bigint]     NOT NULL,
[AppliedOn] [datetime]     NULL,
[Description] [nvarchar]  (1024)   NULL,
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
[externalId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[IX_Bucket_name] ON[dbo].[Bucket]
(
[name] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
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
ALTER TABLE[dbo].[VersionInfo]
ADD CONSTRAINT[UC_Version] PRIMARY KEY CLUSTERED
(
[Version] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[File]  WITH CHECK ADD  CONSTRAINT[FK_File_Bucket] FOREIGN KEY([bucketId])
REFERENCES[dbo].[Bucket]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[File] CHECK CONSTRAINT[FK_File_Bucket]
GO
ALTER TABLE[dbo].[File]  WITH CHECK ADD  CONSTRAINT[FK_File_fileTypeId_FileType_id] FOREIGN KEY([fileTypeId])
REFERENCES[dbo].[FileType]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[File] CHECK CONSTRAINT[FK_File_fileTypeId_FileType_id]
GO


SET IDENTITY_INSERT [dbo].[FileType] ON 

GO
INSERT [dbo].[FileType] ([id], [name]) VALUES (1, N'FileSystem')
GO
INSERT [dbo].[FileType] ([id], [name]) VALUES (2, N'Azure')
GO
INSERT [dbo].[FileType] ([id], [name]) VALUES (3, N'AWS')
GO
SET IDENTITY_INSERT [dbo].[FileType] OFF
GO
SET IDENTITY_INSERT [dbo].[Bucket] ON 

GO
INSERT [dbo].[Bucket] ([id], [name], [externalId]) VALUES (1, N'tmp', N'4f181019-8daf-48df-b399-708c772dcceb')
GO
INSERT [dbo].[Bucket] ([id], [name], [externalId]) VALUES (2, N'test', N'6cf8f9da-6bdd-4e4c-a44d-1ee5357a4828')
GO
SET IDENTITY_INSERT [dbo].[Bucket] OFF
GO
SET IDENTITY_INSERT [dbo].[File] ON 

GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (1, N'833b5ef1-4aee-4ffa-9d73-3e454f5b0c14', N'4bea94474f20c0a9a4641327c00de74ec504d5aba622985e4d46a2f77f491cb4', N'2382b1e90bd2743e72d3d488f523a4eb76be619d2b95a0892094f0060ae6cba2', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-09 19:46:05.177' AS DateTime), CAST(19239342.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (2, N'a159583b-19fe-440a-b089-ae6667b5cdc6', N'4bea94474f20c0a9a4641327c00de74ec504d5aba622985e4d46a2f77f491cb4', N'2382b1e90bd2743e72d3d488f523a4eb76be619d2b95a0892094f0060ae6cba2', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-09 19:46:25.533' AS DateTime), CAST(79604.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (3, N'0dbadcce-d849-4059-8661-f1b1a0be69f4', N'd73d87926aeadb4c241986cb1588efdda8593a0be9dddfbef9d6852b1a437cda', N'bc1bd0bba1fd89aa17a33d4b8f2d52d428d0d914c67ff9b2023f49c406560818', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:37:23.873' AS DateTime), CAST(19245577.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (4, N'3df4d7e3-e083-4a58-aa0d-d733eee81683', N'd73d87926aeadb4c241986cb1588efdda8593a0be9dddfbef9d6852b1a437cda', N'bc1bd0bba1fd89aa17a33d4b8f2d52d428d0d914c67ff9b2023f49c406560818', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:37:28.180' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (5, N'7a0ba788-8702-4f56-9178-aa97249cefa9', N'78d9b2dc8bda201650d29406a38b88ff9717796f68cf3456cc1c644c03731f8b', N'4995d6428eb9563b21e3df75ebae0146d311ab2a1205d10960bbf5374772baac', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:41:15.453' AS DateTime), CAST(19245666.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (6, N'dcfe9325-18bb-4119-a395-16359d139690', N'78d9b2dc8bda201650d29406a38b88ff9717796f68cf3456cc1c644c03731f8b', N'4995d6428eb9563b21e3df75ebae0146d311ab2a1205d10960bbf5374772baac', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:41:19.500' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (7, N'9ce0be1b-4e46-41ec-927a-566fbbd6be9d', N'267c2f70f1bb8a26bf6102c291e64b4b76164573ac3e52bc59d1a86a42b0d46a', N'b98543e30765ffc8216f093b56ee5966e008cad103d75f0106dfd2f294a705ad', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:49:34.443' AS DateTime), CAST(19245710.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (8, N'8129e8c6-dd29-4bd9-9270-e508ce3bc12e', N'267c2f70f1bb8a26bf6102c291e64b4b76164573ac3e52bc59d1a86a42b0d46a', N'b98543e30765ffc8216f093b56ee5966e008cad103d75f0106dfd2f294a705ad', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:49:37.843' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (9, N'480c19d6-93fe-43d7-bbf7-65cb3d8d9581', N'5c98f88cac3227175b3ffc26dca956528af4a2b5e2983da2bb1157c6b45bc84f', N'c5f7f5111bbddf0ad24b15ddb1568966d8ce8b1453e112ee5f3c675121e97844', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:03:16.150' AS DateTime), CAST(19245622.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (10, N'd6356018-3812-42c2-ade9-e6b2366f45e9', N'5c98f88cac3227175b3ffc26dca956528af4a2b5e2983da2bb1157c6b45bc84f', N'c5f7f5111bbddf0ad24b15ddb1568966d8ce8b1453e112ee5f3c675121e97844', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:03:19.853' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (11, N'268d6867-2085-4bb5-92ee-11ed85e1bb1b', N'0b9302777a6a01befb5dc2ee87723121c68affc571db23f2fc2dd5d105c0e9c0', N'b85aaeda66e36097e18a56c9040f93cb9673454d850336e7e045b8ddf799c1a4', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:12:50.990' AS DateTime), CAST(19245623.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (12, N'4c01efd0-2daa-40c2-b545-6ecc231e76b8', N'0b9302777a6a01befb5dc2ee87723121c68affc571db23f2fc2dd5d105c0e9c0', N'b85aaeda66e36097e18a56c9040f93cb9673454d850336e7e045b8ddf799c1a4', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:12:54.127' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (13, N'd66f8272-650f-410a-8ffb-3ce6afcc2f1a', N'6bd83ba7265d3759babf1f77079790c341c29f5d7bf76f557b193d717e1fddb2', N'9114987bb3b2c419e0ad5bc5e67433259df1d9f2a493a9659a30489a7e324cf8', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:19:17.257' AS DateTime), CAST(19245617.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (14, N'd9f60f7c-afb6-4153-aab0-8bd33631dbc5', N'6bd83ba7265d3759babf1f77079790c341c29f5d7bf76f557b193d717e1fddb2', N'9114987bb3b2c419e0ad5bc5e67433259df1d9f2a493a9659a30489a7e324cf8', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:19:21.657' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (15, N'4a52c929-e4c5-4766-b62a-df1f5cd83100', N'9532c942f96952cad89cd7958d73a55e3ed65ae49025bb1fedfb280f2e755431', N'11906c593a9834d0f088749a4f032986c9b64bf82cb8c99c38accec948db4c25', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:29:55.363' AS DateTime), CAST(19245577.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (16, N'0f47d146-1597-473b-a385-617d1298833e', N'9532c942f96952cad89cd7958d73a55e3ed65ae49025bb1fedfb280f2e755431', N'11906c593a9834d0f088749a4f032986c9b64bf82cb8c99c38accec948db4c25', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:30:00.620' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (17, N'd2707ebf-7199-4107-8aab-fd1bba54a85d', N'1031cfd604d439ebe0ebed87a3e3dd01a0bd1f1cd24c6d9fd004319be2ec1cc8', N'f7cb644aee342ce3f5742de8a0c8d16ba7ec046a9a00a4e23236b31698ae5764', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:32:56.033' AS DateTime), CAST(19245581.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (18, N'9fb0695d-bb24-4ebb-9118-1449d8590354', N'1031cfd604d439ebe0ebed87a3e3dd01a0bd1f1cd24c6d9fd004319be2ec1cc8', N'f7cb644aee342ce3f5742de8a0c8d16ba7ec046a9a00a4e23236b31698ae5764', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:33:00.750' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (19, N'85143ca9-f4bc-4962-bbec-eda65e50ebb8', N'ee55dfe12741d1d449dcb664230a3e9d83d396ef4576d3c5c08e58e88ab18554', N'ec6514259e62f4cc5fca720051e49d471908f779a4598cc2476f9734b2d8beb2', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:37:40.847' AS DateTime), CAST(19245673.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (20, N'59bc7999-7128-41fe-b877-d8fcfa80f3ec', N'ee55dfe12741d1d449dcb664230a3e9d83d396ef4576d3c5c08e58e88ab18554', N'ec6514259e62f4cc5fca720051e49d471908f779a4598cc2476f9734b2d8beb2', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:37:44.090' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (21, N'e32d9128-0c35-4171-82aa-f0c4c52d6f1d', N'f810b5c00b891a8e0e1f4e75268fe4a1e893cce5d6feec32de4a15c5e7f14405', N'34ee212afa78f09691dd44a314c0f5ea5aaa4dfc969c4ed08cf4f75079dc5fec', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:40:33.630' AS DateTime), CAST(19245597.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (22, N'0bcc9973-981a-49ea-997e-702d93cc048d', N'f810b5c00b891a8e0e1f4e75268fe4a1e893cce5d6feec32de4a15c5e7f14405', N'34ee212afa78f09691dd44a314c0f5ea5aaa4dfc969c4ed08cf4f75079dc5fec', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:40:37.520' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[File] OFF
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (1, CAST(N'2017-07-06 23:41:15.000' AS DateTime), N'')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (2, CAST(N'2017-07-06 23:41:16.000' AS DateTime), N'')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (3, CAST(N'2017-07-23 22:56:30.000' AS DateTime), N'Created bucket table')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (4, CAST(N'2017-07-24 15:31:32.000' AS DateTime), N'Added bucket referenced')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (5, CAST(N'2017-07-24 15:31:32.000' AS DateTime), N'Added description column to file')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (6, CAST(N'2017-07-24 15:40:45.000' AS DateTime), N'Create default buckets')
GO

");
				}
				else if (this.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
				{
					migrationBuilder.Sql(@"CREATE SCHEMA IF NOT EXISTS ""dbo"";

--ALTER TABLE ""dbo"".""File"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""File"" DISABLE TRIGGER ALL;

--DROP TABLE IF EXISTS ""dbo"".""Bucket"";
--DROP TABLE IF EXISTS ""dbo"".""File"";
--DROP TABLE IF EXISTS ""dbo"".""FileType"";
--DROP TABLE IF EXISTS ""dbo"".""VersionInfo"";

CREATE TABLE ""dbo"".""Bucket""(
""id""  SERIAL ,
""externalId"" uuid    NOT NULL,
""name"" varchar  (255)  NOT NULL);

CREATE TABLE ""dbo"".""File""(
""id""  SERIAL ,
""bucketId"" int    NULL,
""dateCreated"" timestamp    NOT NULL,
""description"" varchar  (255)  NULL,
""expiration"" timestamp    NOT NULL,
""extension"" varchar  (32)  NOT NULL,
""externalId"" uuid    NOT NULL,
""fileSizeInBytes"" decimal    NOT NULL,
""fileTypeId"" int    NOT NULL,
""location"" varchar  (255)  NOT NULL,
""privateKey"" varchar  (64)  NOT NULL,
""publicKey"" varchar  (64)  NOT NULL);

CREATE TABLE ""dbo"".""FileType""(
""id""  SERIAL ,
""name"" varchar  (255)  NOT NULL);

CREATE TABLE ""dbo"".""VersionInfo""(
""Version"" bigint    NOT NULL,
""AppliedOn"" timestamp    NULL,
""Description"" varchar  (1024)  NULL);

ALTER TABLE ""dbo"".""Bucket""
ADD CONSTRAINT ""PK_Bucket""
PRIMARY KEY
(
""id""
);
CREATE UNIQUE INDEX ""IX_Bucket_externalId"" ON ""dbo"".""Bucket""
(
""externalId"" ASC);
CREATE UNIQUE INDEX ""IX_Bucket_name"" ON ""dbo"".""Bucket""
(
""name"" ASC);
ALTER TABLE ""dbo"".""File""
ADD CONSTRAINT ""PK_File""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""FileType""
ADD CONSTRAINT ""PK_FileType""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""VersionInfo""
ADD CONSTRAINT ""UC_Version""
PRIMARY KEY
(
""Version""
);


ALTER TABLE ""dbo"".""File"" ADD CONSTRAINT ""FK_File_Bucket"" FOREIGN KEY(""bucketId"")
REFERENCES ""dbo"".""Bucket"" (""id"");
ALTER TABLE ""dbo"".""File"" ADD CONSTRAINT ""FK_File_fileTypeId_FileType_id"" FOREIGN KEY(""fileTypeId"")
REFERENCES ""dbo"".""FileType"" (""id"");


SET IDENTITY_INSERT [dbo].[FileType] ON 

GO
INSERT [dbo].[FileType] ([id], [name]) VALUES (1, N'FileSystem')
GO
INSERT [dbo].[FileType] ([id], [name]) VALUES (2, N'Azure')
GO
INSERT [dbo].[FileType] ([id], [name]) VALUES (3, N'AWS')
GO
SET IDENTITY_INSERT [dbo].[FileType] OFF
GO
SET IDENTITY_INSERT [dbo].[Bucket] ON 

GO
INSERT [dbo].[Bucket] ([id], [name], [externalId]) VALUES (1, N'tmp', N'4f181019-8daf-48df-b399-708c772dcceb')
GO
INSERT [dbo].[Bucket] ([id], [name], [externalId]) VALUES (2, N'test', N'6cf8f9da-6bdd-4e4c-a44d-1ee5357a4828')
GO
SET IDENTITY_INSERT [dbo].[Bucket] OFF
GO
SET IDENTITY_INSERT [dbo].[File] ON 

GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (1, N'833b5ef1-4aee-4ffa-9d73-3e454f5b0c14', N'4bea94474f20c0a9a4641327c00de74ec504d5aba622985e4d46a2f77f491cb4', N'2382b1e90bd2743e72d3d488f523a4eb76be619d2b95a0892094f0060ae6cba2', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-09 19:46:05.177' AS DateTime), CAST(19239342.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (2, N'a159583b-19fe-440a-b089-ae6667b5cdc6', N'4bea94474f20c0a9a4641327c00de74ec504d5aba622985e4d46a2f77f491cb4', N'2382b1e90bd2743e72d3d488f523a4eb76be619d2b95a0892094f0060ae6cba2', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-09 19:46:25.533' AS DateTime), CAST(79604.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (3, N'0dbadcce-d849-4059-8661-f1b1a0be69f4', N'd73d87926aeadb4c241986cb1588efdda8593a0be9dddfbef9d6852b1a437cda', N'bc1bd0bba1fd89aa17a33d4b8f2d52d428d0d914c67ff9b2023f49c406560818', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:37:23.873' AS DateTime), CAST(19245577.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (4, N'3df4d7e3-e083-4a58-aa0d-d733eee81683', N'd73d87926aeadb4c241986cb1588efdda8593a0be9dddfbef9d6852b1a437cda', N'bc1bd0bba1fd89aa17a33d4b8f2d52d428d0d914c67ff9b2023f49c406560818', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:37:28.180' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (5, N'7a0ba788-8702-4f56-9178-aa97249cefa9', N'78d9b2dc8bda201650d29406a38b88ff9717796f68cf3456cc1c644c03731f8b', N'4995d6428eb9563b21e3df75ebae0146d311ab2a1205d10960bbf5374772baac', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:41:15.453' AS DateTime), CAST(19245666.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (6, N'dcfe9325-18bb-4119-a395-16359d139690', N'78d9b2dc8bda201650d29406a38b88ff9717796f68cf3456cc1c644c03731f8b', N'4995d6428eb9563b21e3df75ebae0146d311ab2a1205d10960bbf5374772baac', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:41:19.500' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (7, N'9ce0be1b-4e46-41ec-927a-566fbbd6be9d', N'267c2f70f1bb8a26bf6102c291e64b4b76164573ac3e52bc59d1a86a42b0d46a', N'b98543e30765ffc8216f093b56ee5966e008cad103d75f0106dfd2f294a705ad', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:49:34.443' AS DateTime), CAST(19245710.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (8, N'8129e8c6-dd29-4bd9-9270-e508ce3bc12e', N'267c2f70f1bb8a26bf6102c291e64b4b76164573ac3e52bc59d1a86a42b0d46a', N'b98543e30765ffc8216f093b56ee5966e008cad103d75f0106dfd2f294a705ad', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 13:49:37.843' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (9, N'480c19d6-93fe-43d7-bbf7-65cb3d8d9581', N'5c98f88cac3227175b3ffc26dca956528af4a2b5e2983da2bb1157c6b45bc84f', N'c5f7f5111bbddf0ad24b15ddb1568966d8ce8b1453e112ee5f3c675121e97844', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:03:16.150' AS DateTime), CAST(19245622.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (10, N'd6356018-3812-42c2-ade9-e6b2366f45e9', N'5c98f88cac3227175b3ffc26dca956528af4a2b5e2983da2bb1157c6b45bc84f', N'c5f7f5111bbddf0ad24b15ddb1568966d8ce8b1453e112ee5f3c675121e97844', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:03:19.853' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (11, N'268d6867-2085-4bb5-92ee-11ed85e1bb1b', N'0b9302777a6a01befb5dc2ee87723121c68affc571db23f2fc2dd5d105c0e9c0', N'b85aaeda66e36097e18a56c9040f93cb9673454d850336e7e045b8ddf799c1a4', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:12:50.990' AS DateTime), CAST(19245623.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (12, N'4c01efd0-2daa-40c2-b545-6ecc231e76b8', N'0b9302777a6a01befb5dc2ee87723121c68affc571db23f2fc2dd5d105c0e9c0', N'b85aaeda66e36097e18a56c9040f93cb9673454d850336e7e045b8ddf799c1a4', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:12:54.127' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (13, N'd66f8272-650f-410a-8ffb-3ce6afcc2f1a', N'6bd83ba7265d3759babf1f77079790c341c29f5d7bf76f557b193d717e1fddb2', N'9114987bb3b2c419e0ad5bc5e67433259df1d9f2a493a9659a30489a7e324cf8', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:19:17.257' AS DateTime), CAST(19245617.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (14, N'd9f60f7c-afb6-4153-aab0-8bd33631dbc5', N'6bd83ba7265d3759babf1f77079790c341c29f5d7bf76f557b193d717e1fddb2', N'9114987bb3b2c419e0ad5bc5e67433259df1d9f2a493a9659a30489a7e324cf8', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:19:21.657' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (15, N'4a52c929-e4c5-4766-b62a-df1f5cd83100', N'9532c942f96952cad89cd7958d73a55e3ed65ae49025bb1fedfb280f2e755431', N'11906c593a9834d0f088749a4f032986c9b64bf82cb8c99c38accec948db4c25', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:29:55.363' AS DateTime), CAST(19245577.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (16, N'0f47d146-1597-473b-a385-617d1298833e', N'9532c942f96952cad89cd7958d73a55e3ed65ae49025bb1fedfb280f2e755431', N'11906c593a9834d0f088749a4f032986c9b64bf82cb8c99c38accec948db4c25', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:30:00.620' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (17, N'd2707ebf-7199-4107-8aab-fd1bba54a85d', N'1031cfd604d439ebe0ebed87a3e3dd01a0bd1f1cd24c6d9fd004319be2ec1cc8', N'f7cb644aee342ce3f5742de8a0c8d16ba7ec046a9a00a4e23236b31698ae5764', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:32:56.033' AS DateTime), CAST(19245581.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (18, N'9fb0695d-bb24-4ebb-9118-1449d8590354', N'1031cfd604d439ebe0ebed87a3e3dd01a0bd1f1cd24c6d9fd004319be2ec1cc8', N'f7cb644aee342ce3f5742de8a0c8d16ba7ec046a9a00a4e23236b31698ae5764', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:33:00.750' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (19, N'85143ca9-f4bc-4962-bbec-eda65e50ebb8', N'ee55dfe12741d1d449dcb664230a3e9d83d396ef4576d3c5c08e58e88ab18554', N'ec6514259e62f4cc5fca720051e49d471908f779a4598cc2476f9734b2d8beb2', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:37:40.847' AS DateTime), CAST(19245673.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (20, N'59bc7999-7128-41fe-b877-d8fcfa80f3ec', N'ee55dfe12741d1d449dcb664230a3e9d83d396ef4576d3c5c08e58e88ab18554', N'ec6514259e62f4cc5fca720051e49d471908f779a4598cc2476f9734b2d8beb2', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:37:44.090' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (21, N'e32d9128-0c35-4171-82aa-f0c4c52d6f1d', N'f810b5c00b891a8e0e1f4e75268fe4a1e893cce5d6feec32de4a15c5e7f14405', N'34ee212afa78f09691dd44a314c0f5ea5aaa4dfc969c4ed08cf4f75079dc5fec', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:40:33.630' AS DateTime), CAST(19245597.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
INSERT [dbo].[File] ([id], [externalId], [privateKey], [publicKey], [location], [expiration], [extension], [dateCreated], [fileSizeInBytes], [fileTypeId], [bucketId], [description]) VALUES (22, N'0bcc9973-981a-49ea-997e-702d93cc048d', N'f810b5c00b891a8e0e1f4e75268fe4a1e893cce5d6feec32de4a15c5e7f14405', N'34ee212afa78f09691dd44a314c0f5ea5aaa4dfc969c4ed08cf4f75079dc5fec', N'C:\Nebula\Uploads', CAST(N'9999-12-31 23:59:59.997' AS DateTime), N'', CAST(N'2017-07-10 14:40:37.520' AS DateTime), CAST(81847.0000 AS Decimal(18, 4)), 1, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[File] OFF
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (1, CAST(N'2017-07-06 23:41:15.000' AS DateTime), N'')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (2, CAST(N'2017-07-06 23:41:16.000' AS DateTime), N'')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (3, CAST(N'2017-07-23 22:56:30.000' AS DateTime), N'Created bucket table')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (4, CAST(N'2017-07-24 15:31:32.000' AS DateTime), N'Added bucket referenced')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (5, CAST(N'2017-07-24 15:31:32.000' AS DateTime), N'Added description column to file')
GO
INSERT [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (6, CAST(N'2017-07-24 15:40:45.000' AS DateTime), N'Create default buckets')
GO

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