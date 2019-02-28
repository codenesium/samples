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

SET IDENTITY_INSERT [dbo].[Species] ON 

GO
INSERT [dbo].[Species] ([id], [name]) VALUES (1, N'Bird')
GO
INSERT [dbo].[Species] ([id], [name]) VALUES (2, N'Dog')
GO
INSERT [dbo].[Species] ([id], [name]) VALUES (3, N'Cat')
GO
SET IDENTITY_INSERT [dbo].[Species] OFF
GO
SET IDENTITY_INSERT [dbo].[Breed] ON 

GO
INSERT [dbo].[Breed] ([id], [name], [speciesId]) VALUES (1, N'Dove', 1)
GO
INSERT [dbo].[Breed] ([id], [name], [speciesId]) VALUES (2, N'Attack Ostrich', 1)
GO
INSERT [dbo].[Breed] ([id], [name], [speciesId]) VALUES (3, N'Cassowary', 1)
GO
INSERT [dbo].[Breed] ([id], [name], [speciesId]) VALUES (4, N'Pug', 2)
GO
INSERT [dbo].[Breed] ([id], [name], [speciesId]) VALUES (5, N'Collie', 2)
GO
INSERT [dbo].[Breed] ([id], [name], [speciesId]) VALUES (6, N'Pit Bull', 2)
GO
INSERT [dbo].[Breed] ([id], [name], [speciesId]) VALUES (7, N'Maine Coon', 3)
GO
INSERT [dbo].[Breed] ([id], [name], [speciesId]) VALUES (8, N'Toyger', 3)
GO
INSERT [dbo].[Breed] ([id], [name], [speciesId]) VALUES (9, N'Siberian', 3)
GO
SET IDENTITY_INSERT [dbo].[Breed] OFF
GO
SET IDENTITY_INSERT [dbo].[Pen] ON 

GO
INSERT [dbo].[Pen] ([id], [name]) VALUES (1, N'A')
GO
INSERT [dbo].[Pen] ([id], [name]) VALUES (2, N'B')
GO
INSERT [dbo].[Pen] ([id], [name]) VALUES (3, N'C')
GO
SET IDENTITY_INSERT [dbo].[Pen] OFF
GO
SET IDENTITY_INSERT [dbo].[Pet] ON 

GO
INSERT [dbo].[Pet] ([id], [acquiredDate], [breedId], [description], [penId], [price]) VALUES (3, CAST(N'2019-01-01' AS Date), 3, N'a scary bird', 1, 100.0000)
GO
INSERT [dbo].[Pet] ([id], [acquiredDate], [breedId], [description], [penId], [price]) VALUES (5, CAST(N'2019-01-07' AS Date), 4, N'cutest dog', 2, 450.0000)
GO
SET IDENTITY_INSERT [dbo].[Pet] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentType] ON 

GO
INSERT [dbo].[PaymentType] ([id], [name]) VALUES (1, N'Check')
GO
INSERT [dbo].[PaymentType] ([id], [name]) VALUES (2, N'Cash')
GO
INSERT [dbo].[PaymentType] ([id], [name]) VALUES (3, N'Card')
GO
SET IDENTITY_INSERT [dbo].[PaymentType] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale] ON 

GO
INSERT [dbo].[Sale] ([id], [amount], [firstName], [lastName], [paymentTypeId], [petId], [phone]) VALUES (6, 1000.0000, N'Bugs ', N'Bunny', 1, 3, N'5555555555')
GO
SET IDENTITY_INSERT [dbo].[Sale] OFF
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}