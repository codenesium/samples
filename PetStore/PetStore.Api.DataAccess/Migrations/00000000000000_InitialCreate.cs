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

CREATE TABLE [dbo].[Breed](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
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
[speciesId] [int]     NOT NULL,
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
REFERENCES[dbo].[Breed]([id])
GO
ALTER TABLE[dbo].[Pet] CHECK CONSTRAINT[FK_Pet_breedId_Breed_id]
GO
ALTER TABLE[dbo].[Pet]  WITH CHECK ADD  CONSTRAINT[FK_Pet_penId_Pen_id] FOREIGN KEY([penId])
REFERENCES[dbo].[Pen]([id])
GO
ALTER TABLE[dbo].[Pet] CHECK CONSTRAINT[FK_Pet_penId_Pen_id]
GO
ALTER TABLE[dbo].[Pet]  WITH CHECK ADD  CONSTRAINT[FK_Pet_speciesId_Species_id] FOREIGN KEY([speciesId])
REFERENCES[dbo].[Species]([id])
GO
ALTER TABLE[dbo].[Pet] CHECK CONSTRAINT[FK_Pet_speciesId_Species_id]
GO
ALTER TABLE[dbo].[Sale]  WITH CHECK ADD  CONSTRAINT[FK_Sale_petId_Pet_id] FOREIGN KEY([petId])
REFERENCES[dbo].[Pet]([id])
GO
ALTER TABLE[dbo].[Sale] CHECK CONSTRAINT[FK_Sale_petId_Pet_id]
GO
ALTER TABLE[dbo].[Sale]  WITH CHECK ADD  CONSTRAINT[FK_Sale_paymentTypeId_PaymentType_id] FOREIGN KEY([paymentTypeId])
REFERENCES[dbo].[PaymentType]([id])
GO
ALTER TABLE[dbo].[Sale] CHECK CONSTRAINT[FK_Sale_paymentTypeId_PaymentType_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
          
		}
	}
};