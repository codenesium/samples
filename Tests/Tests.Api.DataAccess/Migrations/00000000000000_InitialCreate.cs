using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.DataAccess.Migrations
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

IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'SchemaA')
EXEC('CREATE SCHEMA [SchemaA] AUTHORIZATION [dbo]');
GO

IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'SchemaB')
EXEC('CREATE SCHEMA [SchemaB] AUTHORIZATION [dbo]');
GO

--IF (OBJECT_ID('dbo.FK_selfReference_selfReference', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[selfReference] DROP CONSTRAINT [FK_selfReference_selfReference]
--END
--GO
--IF (OBJECT_ID('dbo.FK_selfReference_selfReference2', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[selfReference] DROP CONSTRAINT [FK_selfReference_selfReference2]
--END
--GO


--IF (OBJECT_ID('SchemaB.FK_PersonRef_PersonA', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [SchemaB].[PersonRef] DROP CONSTRAINT [FK_PersonRef_PersonA]
--END
--GO
--IF (OBJECT_ID('SchemaB.FK_PersonRef_PersonB', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [SchemaB].[PersonRef] DROP CONSTRAINT [FK_PersonRef_PersonB]
--END
--GO

--IF OBJECT_ID('dbo.PERSON', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PERSON]
--END
--GO
--IF OBJECT_ID('dbo.RowVersionCheck', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[RowVersionCheck]
--END
--GO
--IF OBJECT_ID('dbo.selfReference', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[selfReference]
--END
--GO
--IF OBJECT_ID('dbo.Tables', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Tables]
--END
--GO
--IF OBJECT_ID('dbo.TestAllFieldTypes', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[TestAllFieldTypes]
--END
--GO
--IF OBJECT_ID('dbo.TestAllFieldTypesNullable', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[TestAllFieldTypesNullable]
--END
--GO
--IF OBJECT_ID('dbo.TimestampCheck', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[TimestampCheck]
--END
--GO

--IF OBJECT_ID('SchemaA.Person', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [SchemaA].[Person]
--END
--GO

--IF OBJECT_ID('SchemaB.Person', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [SchemaB].[Person]
--END
--GO
--IF OBJECT_ID('SchemaB.PersonRef', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [SchemaB].[PersonRef]
--END
--GO

CREATE TABLE [dbo].[PERSON](
[PERSON_ID] [int]   IDENTITY(1,1)  NOT NULL,
[PERSON_NAME] [varchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[RowVersionCheck](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (50)   NOT NULL,
[rowVersion] [uniqueidentifier]    ROWGUIDCOL NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[selfReference](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[selfReferenceId] [int]     NULL,
[selfReferenceId2] [int]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Tables](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TestAllFieldTypes](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[fieldBigInt] [bigint]     NOT NULL,
[fieldBinary] [binary]  (50)   NOT NULL,
[fieldBit] [bit]     NOT NULL,
[fieldChar] [char]  (10)   NOT NULL,
[fieldDate] [date]     NOT NULL,
[fieldDateTime] [datetime]     NOT NULL,
[fieldDateTime2] [datetime2]     NOT NULL,
[fieldDateTimeOffset] [datetimeoffset]     NOT NULL,
[fieldDecimal] [decimal]     NOT NULL,
[fieldFloat] [float]     NOT NULL,
[fieldGeography] [geography]     NOT NULL,
[fieldGeometry] [geometry]     NOT NULL,
[fieldHierarchyId] [hierarchyid]     NOT NULL,
[fieldImage] [image]     NOT NULL,
[fieldMoney] [money]     NOT NULL,
[fieldNChar] [nchar]  (10)   NOT NULL,
[fieldNText] [ntext]     NOT NULL,
[fieldNumeric] [decimal]     NOT NULL,
[fieldNVarchar] [nvarchar]  (50)   NOT NULL,
[fieldReal] [real]     NOT NULL,
[fieldSmallDateTime] [smalldatetime]     NOT NULL,
[fieldSmallInt] [smallint]     NOT NULL,
[fieldSmallMoney] [smallmoney]     NOT NULL,
[fieldText] [text]     NOT NULL,
[fieldTime] [time]     NOT NULL,
[fieldTimestamp] [timestamp]     NOT NULL,
[fieldTinyInt] [tinyint]     NOT NULL,
[fieldUniqueIdentifier] [uniqueidentifier]     NOT NULL,
[fieldVarBinary] [varbinary]  (50)   NOT NULL,
[fieldVarchar] [varchar]  (50)   NOT NULL,
[fieldVariant] [sql_variant]     NOT NULL,
[fieldXML] [xml]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TestAllFieldTypesNullable](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[fieldBigInt] [bigint]     NULL,
[fieldBinary] [binary]  (50)   NULL,
[fieldBit] [bit]     NULL,
[fieldChar] [char]  (10)   NULL,
[fieldDate] [date]     NULL,
[fieldDateTime] [datetime]     NULL,
[fieldDateTime2] [datetime2]     NULL,
[fieldDateTimeOffset] [datetimeoffset]     NULL,
[fieldDecimal] [decimal]     NULL,
[fieldFloat] [float]     NULL,
[fieldGeography] [geography]     NULL,
[fieldGeometry] [geometry]     NULL,
[fieldHierarchyId] [hierarchyid]     NULL,
[fieldImage] [image]     NULL,
[fieldMoney] [money]     NULL,
[fieldNChar] [nchar]  (10)   NULL,
[fieldNText] [ntext]     NULL,
[fieldNumeric] [decimal]     NULL,
[fieldNVarchar] [nvarchar]  (50)   NULL,
[fieldReal] [real]     NULL,
[fieldSmallDateTime] [smalldatetime]     NULL,
[fieldSmallInt] [smallint]     NULL,
[fieldSmallMoney] [smallmoney]     NULL,
[fieldText] [text]     NULL,
[fieldTime] [time]     NULL,
[fieldTimestamp] [timestamp]     NULL,
[fieldTinyInt] [tinyint]     NULL,
[fieldUniqueIdentifier] [uniqueidentifier]     NULL,
[fieldVarBinary] [varbinary]  (50)   NULL,
[fieldVarchar] [varchar]  (50)   NULL,
[fieldVariant] [sql_variant]     NULL,
[fieldXML] [xml]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TimestampCheck](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (50)   NULL,
[timestamp] [timestamp]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [SchemaA].[Person](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [SchemaB].[Person](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [SchemaB].[PersonRef](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[personAId] [int]     NOT NULL,
[personBId] [int]     NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[PERSON]
ADD CONSTRAINT[PK_PERSON_2] PRIMARY KEY CLUSTERED
(
[PERSON_ID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[RowVersionCheck]
ADD CONSTRAINT[PK_RowVersionCheck] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[selfReference]
ADD CONSTRAINT[PK_selfReference] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Tables]
ADD CONSTRAINT[PK_Tables] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TestAllFieldTypes]
ADD CONSTRAINT[PK_TestAllFieldTypes] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TestAllFieldTypesNullable]
ADD CONSTRAINT[PK_TestAllFieldTypesNullable] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TimestampCheck]
ADD CONSTRAINT[PK_TimestampCheck] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[SchemaA].[Person]
ADD CONSTRAINT[PK_Person] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[SchemaB].[Person]
ADD CONSTRAINT[PK_Person_1] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[SchemaB].[PersonRef]
ADD CONSTRAINT[PK_PersonRef] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

ALTER TABLE[dbo].[RowVersionCheck]
ADD CONSTRAINT[DF_RowVersionCheck_rowVersion]  DEFAULT(newid()) FOR[rowVersion]
GO


ALTER TABLE[dbo].[selfReference]  WITH CHECK ADD  CONSTRAINT[FK_selfReference_selfReference] FOREIGN KEY([selfReferenceId])
REFERENCES[dbo].[selfReference]([id])
GO
ALTER TABLE[dbo].[selfReference] CHECK CONSTRAINT[FK_selfReference_selfReference]
GO
ALTER TABLE[dbo].[selfReference]  WITH CHECK ADD  CONSTRAINT[FK_selfReference_selfReference2] FOREIGN KEY([selfReferenceId2])
REFERENCES[dbo].[selfReference]([id])
GO
ALTER TABLE[dbo].[selfReference] CHECK CONSTRAINT[FK_selfReference_selfReference2]
GO


ALTER TABLE[SchemaB].[PersonRef]  WITH CHECK ADD  CONSTRAINT[FK_PersonRef_PersonA] FOREIGN KEY([personAId])
REFERENCES[SchemaA].[Person]([id])
GO
ALTER TABLE[SchemaB].[PersonRef] CHECK CONSTRAINT[FK_PersonRef_PersonA]
GO
ALTER TABLE[SchemaB].[PersonRef]  WITH CHECK ADD  CONSTRAINT[FK_PersonRef_PersonB] FOREIGN KEY([personBId])
REFERENCES[SchemaB].[Person]([id])
GO
ALTER TABLE[SchemaB].[PersonRef] CHECK CONSTRAINT[FK_PersonRef_PersonB]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}