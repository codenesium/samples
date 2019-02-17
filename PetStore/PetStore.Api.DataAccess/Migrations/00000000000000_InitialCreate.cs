using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.DataAccess.Migrations
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

--IF (OBJECT_ID('dbo.FK_Pet_breedId_Breed_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Pet] DROP CONSTRAINT [FK_Pet_breedId_Breed_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Pet_penId_Pen_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Pet] DROP CONSTRAINT [FK_Pet_penId_Pen_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Sale_paymentTypeId_PaymentType_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Sale] DROP CONSTRAINT [FK_Sale_paymentTypeId_PaymentType_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Sale_petId_Pet_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Sale] DROP CONSTRAINT [FK_Sale_petId_Pet_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_breed_speciesid_species_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Breed] DROP CONSTRAINT [fk_breed_speciesid_species_id]
--END
--GO

--IF OBJECT_ID('dbo.Breed', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Breed]
--END
--GO
--IF OBJECT_ID('dbo.PaymentType', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PaymentType]
--END
--GO
--IF OBJECT_ID('dbo.Pen', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Pen]
--END
--GO
--IF OBJECT_ID('dbo.Pet', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Pet]
--END
--GO
--IF OBJECT_ID('dbo.Sale', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Sale]
--END
--GO
--IF OBJECT_ID('dbo.Species', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Species]
--END
--GO

CREATE TABLE [dbo].[Breed](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[speciesId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PaymentType](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Pen](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Pet](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[acquiredDate] [date]     NOT NULL,
[breedId] [int]     NOT NULL,
[description] [text]     NOT NULL,
[penId] [int]     NOT NULL,
[price] [money]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Sale](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[amount] [money]     NOT NULL,
[firstName] [varchar]  (90)   NOT NULL,
[lastName] [varchar]  (90)   NOT NULL,
[paymentTypeId] [int]     NOT NULL,
[petId] [int]     NOT NULL,
[phone] [varchar]  (10)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Species](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Breed]
ADD CONSTRAINT[PK_Breed] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Breed_speciesId] ON[dbo].[Breed]
(
[speciesId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PaymentType]
ADD CONSTRAINT[PK_PaymentType] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Pen]
ADD CONSTRAINT[PK_Pen] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Pet]
ADD CONSTRAINT[PK_Pet] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Sale]
ADD CONSTRAINT[PK_Sale] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Species]
ADD CONSTRAINT[PK_Species] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[Pet]  WITH CHECK ADD  CONSTRAINT[FK_Pet_breedId_Breed_id] FOREIGN KEY([breedId])
REFERENCES[dbo].[Breed]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Pet] CHECK CONSTRAINT[FK_Pet_breedId_Breed_id]
GO
ALTER TABLE[dbo].[Pet]  WITH CHECK ADD  CONSTRAINT[FK_Pet_penId_Pen_id] FOREIGN KEY([penId])
REFERENCES[dbo].[Pen]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Pet] CHECK CONSTRAINT[FK_Pet_penId_Pen_id]
GO
ALTER TABLE[dbo].[Sale]  WITH CHECK ADD  CONSTRAINT[FK_Sale_paymentTypeId_PaymentType_id] FOREIGN KEY([paymentTypeId])
REFERENCES[dbo].[PaymentType]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Sale] CHECK CONSTRAINT[FK_Sale_paymentTypeId_PaymentType_id]
GO
ALTER TABLE[dbo].[Sale]  WITH CHECK ADD  CONSTRAINT[FK_Sale_petId_Pet_id] FOREIGN KEY([petId])
REFERENCES[dbo].[Pet]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Sale] CHECK CONSTRAINT[FK_Sale_petId_Pet_id]
GO
ALTER TABLE[dbo].[Breed]  WITH CHECK ADD  CONSTRAINT[fk_breed_speciesid_species_id] FOREIGN KEY([speciesId])
REFERENCES[dbo].[Species]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Breed] CHECK CONSTRAINT[fk_breed_speciesid_species_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}