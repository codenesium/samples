using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.DataAccess.Migrations
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

CREATE TABLE [dbo].[Admin](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[password] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (128)   NOT NULL,
[username] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[City](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[provinceId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Country](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Customer](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Event](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[address1] [varchar]  (128)   NOT NULL,
[address2] [varchar]  (128)   NOT NULL,
[cityId] [int]     NOT NULL,
[date] [datetime]     NOT NULL,
[description] [text]     NOT NULL,
[endDate] [datetime]     NOT NULL,
[facebook] [varchar]  (128)   NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[startDate] [datetime]     NOT NULL,
[website] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Province](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[countryId] [int]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Sale](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[ipAddress] [varchar]  (128)   NOT NULL,
[notes] [text]     NOT NULL,
[saleDate] [datetime]     NOT NULL,
[transactionId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[SaleTickets](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[saleId] [int]     NOT NULL,
[ticketId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Ticket](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[publicId] [varchar]  (8)   NOT NULL,
[ticketStatusId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TicketStatus](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Transaction](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[amount] [money]     NOT NULL,
[gatewayConfirmationNumber] [varchar]  (1)   NOT NULL,
[transactionStatusId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TransactionStatus](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Venue](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[address1] [varchar]  (128)   NOT NULL,
[address2] [varchar]  (128)   NOT NULL,
[adminId] [int]     NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[facebook] [varchar]  (128)   NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (128)   NOT NULL,
[provinceId] [int]     NOT NULL,
[website] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Admin]
ADD CONSTRAINT[PK_admin] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[City]
ADD CONSTRAINT[PK_city] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_city_provinceId] ON[dbo].[City]
(
[provinceId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Country]
ADD CONSTRAINT[PK_country] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Customer]
ADD CONSTRAINT[PK_customer] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Event]
ADD CONSTRAINT[PK_Event] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_event_cityId] ON[dbo].[Event]
(
[cityId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Province]
ADD CONSTRAINT[PK_province] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_province_countryId] ON[dbo].[Province]
(
[countryId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Sale]
ADD CONSTRAINT[PK_sale] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_sale_id] ON[dbo].[Sale]
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_sale_transactionId] ON[dbo].[Sale]
(
[transactionId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[SaleTickets]
ADD CONSTRAINT[PK_saleTickets] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_saleTickets_ticketId] ON[dbo].[SaleTickets]
(
[ticketId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Ticket]
ADD CONSTRAINT[PK_ticket] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ticket_ticketStatusId] ON[dbo].[Ticket]
(
[ticketStatusId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TicketStatus]
ADD CONSTRAINT[PK_ticketStatus] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Transaction]
ADD CONSTRAINT[PK_transaction] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_transaction_transactionStatusId] ON[dbo].[Transaction]
(
[transactionStatusId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TransactionStatus]
ADD CONSTRAINT[PK_transactionStatus] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Venue]
ADD CONSTRAINT[PK_venue] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_venue_adminId] ON[dbo].[Venue]
(
[adminId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_venue_provinceId] ON[dbo].[Venue]
(
[provinceId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[City]  WITH CHECK ADD  CONSTRAINT[fk_city_provinceid_province_id] FOREIGN KEY([provinceId])
REFERENCES[dbo].[Province]([id])
GO
ALTER TABLE[dbo].[City] CHECK CONSTRAINT[fk_city_provinceid_province_id]
GO
ALTER TABLE[dbo].[Event]  WITH CHECK ADD  CONSTRAINT[fk_event_cityid_city_id] FOREIGN KEY([cityId])
REFERENCES[dbo].[City]([id])
GO
ALTER TABLE[dbo].[Event] CHECK CONSTRAINT[fk_event_cityid_city_id]
GO
ALTER TABLE[dbo].[Province]  WITH CHECK ADD  CONSTRAINT[fk_province_countryid_country_id] FOREIGN KEY([countryId])
REFERENCES[dbo].[Country]([id])
GO
ALTER TABLE[dbo].[Province] CHECK CONSTRAINT[fk_province_countryid_country_id]
GO
ALTER TABLE[dbo].[Sale]  WITH CHECK ADD  CONSTRAINT[fk_sale_transactionid_transaction_id] FOREIGN KEY([transactionId])
REFERENCES[dbo].[Transaction]([id])
GO
ALTER TABLE[dbo].[Sale] CHECK CONSTRAINT[fk_sale_transactionid_transaction_id]
GO
ALTER TABLE[dbo].[SaleTickets]  WITH CHECK ADD  CONSTRAINT[FK_saleTickets_saleId_sale_id] FOREIGN KEY([saleId])
REFERENCES[dbo].[Sale]([id])
GO
ALTER TABLE[dbo].[SaleTickets] CHECK CONSTRAINT[FK_saleTickets_saleId_sale_id]
GO
ALTER TABLE[dbo].[SaleTickets]  WITH CHECK ADD  CONSTRAINT[fk_saletickets_ticketid_ticket_id] FOREIGN KEY([ticketId])
REFERENCES[dbo].[Ticket]([id])
GO
ALTER TABLE[dbo].[SaleTickets] CHECK CONSTRAINT[fk_saletickets_ticketid_ticket_id]
GO
ALTER TABLE[dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT[fk_ticket_ticketstatusid_ticketstatus_id] FOREIGN KEY([ticketStatusId])
REFERENCES[dbo].[TicketStatus]([id])
GO
ALTER TABLE[dbo].[Ticket] CHECK CONSTRAINT[fk_ticket_ticketstatusid_ticketstatus_id]
GO
ALTER TABLE[dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT[fk_transaction_transactionstatusid_transactionstatus_id] FOREIGN KEY([transactionStatusId])
REFERENCES[dbo].[TransactionStatus]([id])
GO
ALTER TABLE[dbo].[Transaction] CHECK CONSTRAINT[fk_transaction_transactionstatusid_transactionstatus_id]
GO
ALTER TABLE[dbo].[Venue]  WITH CHECK ADD  CONSTRAINT[fk_venue_provinceid_province_id] FOREIGN KEY([provinceId])
REFERENCES[dbo].[Province]([id])
GO
ALTER TABLE[dbo].[Venue] CHECK CONSTRAINT[fk_venue_provinceid_province_id]
GO
ALTER TABLE[dbo].[Venue]  WITH CHECK ADD  CONSTRAINT[fk_venue_adminid_admin_id] FOREIGN KEY([adminId])
REFERENCES[dbo].[Admin]([id])
GO
ALTER TABLE[dbo].[Venue] CHECK CONSTRAINT[fk_venue_adminid_admin_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}