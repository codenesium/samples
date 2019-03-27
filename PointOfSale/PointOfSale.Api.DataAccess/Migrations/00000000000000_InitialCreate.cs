using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using PointOfSaleNS.Api.DataAccess;

namespace PointOfSaleNS.Api.DataAccess.Migrations
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


--IF OBJECT_ID('dbo.Customer', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Customer]
--END
--GO
--IF OBJECT_ID('dbo.Product', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Product]
--END
--GO
--IF OBJECT_ID('dbo.Sale', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Sale]
--END
--GO
--IF OBJECT_ID('dbo.SaleProduct', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[SaleProduct]
--END
--GO

CREATE TABLE [dbo].[Customer](
[id] [int]     NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (15)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Product](
[id] [int]     NOT NULL,
[active] [bit]     NOT NULL,
[description] [varchar]  (4096)   NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[price] [money]     NOT NULL,
[quantity] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Sale](
[id] [int]     NOT NULL,
[customerId] [int]     NOT NULL,
[date] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[SaleProduct](
[productId] [int]     NOT NULL,
[saleId] [int]     NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Customer]
ADD CONSTRAINT[PK_Customer] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Product]
ADD CONSTRAINT[PK_Product] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_sale_customerId] ON[dbo].[sale]
(
[customerId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Sale]
ADD CONSTRAINT[PK_Sale] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_saleProduct_productId] ON[dbo].[saleProduct]
(
[productId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_saleProduct_saleId] ON[dbo].[saleProduct]
(
[saleId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[SaleProduct]
ADD CONSTRAINT[PK_SaleProduct] PRIMARY KEY CLUSTERED
(
[productId] ASC
,[saleId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO



");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}