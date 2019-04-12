using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.DataAccess.Migrations
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

--IF (OBJECT_ID('dbo.FK_AirTransport_handlerId_Handler_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[AirTransport] DROP CONSTRAINT [FK_AirTransport_handlerId_Handler_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Breed_speciesId_Species_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Breed] DROP CONSTRAINT [FK_Breed_speciesId_Species_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_CountryRequirement_countryId_Country_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[CountryRequirement] DROP CONSTRAINT [FK_CountryRequirement_countryId_Country_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_customercommunication_customerid_customer_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[CustomerCommunication] DROP CONSTRAINT [fk_customercommunication_customerid_customer_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_CustomerCommunication_employeeId_Employee_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[CustomerCommunication] DROP CONSTRAINT [FK_CustomerCommunication_employeeId_Employee_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Destination_countryId_Country_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Destination] DROP CONSTRAINT [FK_Destination_countryId_Country_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_HandlerPipelineStep_handlerId_Handler_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[HandlerPipelineStep] DROP CONSTRAINT [FK_HandlerPipelineStep_handlerId_Handler_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_HandlerPipelineStep_pipelineStepId_PipelineStep_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[HandlerPipelineStep] DROP CONSTRAINT [FK_HandlerPipelineStep_pipelineStepId_PipelineStep_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_OtherTransport_pipelineStepId_PipelineStep_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[OtherTransport] DROP CONSTRAINT [FK_OtherTransport_pipelineStepId_PipelineStep_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_OtherTransport_handlerId_Handler_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[OtherTransport] DROP CONSTRAINT [FK_OtherTransport_handlerId_Handler_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Pet_breedId_Breed_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Pet] DROP CONSTRAINT [FK_Pet_breedId_Breed_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Pipeline_pipelineStatusId_PipelineStatus_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Pipeline] DROP CONSTRAINT [FK_Pipeline_pipelineStatusId_PipelineStatus_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_PipelineStep_pipelineStepStatusId_PipelineStepStatus_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[PipelineStep] DROP CONSTRAINT [FK_PipelineStep_pipelineStepStatusId_PipelineStepStatus_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_PipelineStep_shipperId_Employee_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[PipelineStep] DROP CONSTRAINT [FK_PipelineStep_shipperId_Employee_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_PipelineStepDestination_destinationId_Destination_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[PipelineStepDestination] DROP CONSTRAINT [FK_PipelineStepDestination_destinationId_Destination_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_PipelineStepDestination_pipelineStepId_PipelineStep_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[PipelineStepDestination] DROP CONSTRAINT [FK_PipelineStepDestination_pipelineStepId_PipelineStep_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_PipelineStepNote_pipelineStepId_PipelineStep_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[PipelineStepNote] DROP CONSTRAINT [FK_PipelineStepNote_pipelineStepId_PipelineStep_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_PipelineStepNote_employeeId_Employee_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[PipelineStepNote] DROP CONSTRAINT [FK_PipelineStepNote_employeeId_Employee_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_PipelineStepStepRequirement_pipelineStepId_PipelineStep_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[PipelineStepStepRequirement] DROP CONSTRAINT [FK_PipelineStepStepRequirement_pipelineStepId_PipelineStep_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Sale_petId_Pet_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Sale] DROP CONSTRAINT [FK_Sale_petId_Pet_id]
--END
--GO

--IF OBJECT_ID('dbo.Airline', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Airline]
--END
--GO
--IF OBJECT_ID('dbo.AirTransport', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[AirTransport]
--END
--GO
--IF OBJECT_ID('dbo.Breed', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Breed]
--END
--GO
--IF OBJECT_ID('dbo.Country', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Country]
--END
--GO
--IF OBJECT_ID('dbo.CountryRequirement', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[CountryRequirement]
--END
--GO
--IF OBJECT_ID('dbo.Customer', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Customer]
--END
--GO
--IF OBJECT_ID('dbo.CustomerCommunication', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[CustomerCommunication]
--END
--GO
--IF OBJECT_ID('dbo.Destination', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Destination]
--END
--GO
--IF OBJECT_ID('dbo.Employee', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Employee]
--END
--GO
--IF OBJECT_ID('dbo.Handler', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Handler]
--END
--GO
--IF OBJECT_ID('dbo.HandlerPipelineStep', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[HandlerPipelineStep]
--END
--GO
--IF OBJECT_ID('dbo.OtherTransport', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[OtherTransport]
--END
--GO
--IF OBJECT_ID('dbo.Pet', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Pet]
--END
--GO
--IF OBJECT_ID('dbo.Pipeline', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Pipeline]
--END
--GO
--IF OBJECT_ID('dbo.PipelineStatus', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PipelineStatus]
--END
--GO
--IF OBJECT_ID('dbo.PipelineStep', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PipelineStep]
--END
--GO
--IF OBJECT_ID('dbo.PipelineStepDestination', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PipelineStepDestination]
--END
--GO
--IF OBJECT_ID('dbo.PipelineStepNote', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PipelineStepNote]
--END
--GO
--IF OBJECT_ID('dbo.PipelineStepStatus', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PipelineStepStatus]
--END
--GO
--IF OBJECT_ID('dbo.PipelineStepStepRequirement', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PipelineStepStepRequirement]
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

CREATE TABLE [dbo].[Airline](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[AirTransport](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[airlineId] [int]     NOT NULL,
[flightNumber] [varchar]  (12)   NOT NULL,
[handlerId] [int]     NOT NULL,
[landDate] [datetime]     NOT NULL,
[pipelineStepId] [int]     NOT NULL,
[takeoffDate] [datetime]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Breed](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[speciesId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Country](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[CountryRequirement](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[countryId] [int]     NOT NULL,
[details] [text]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Customer](
[id] [int]     NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[notes] [text]     NULL,
[phone] [varchar]  (10)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[CustomerCommunication](
[id] [int]     NOT NULL,
[customerId] [int]     NOT NULL,
[dateCreated] [datetime]     NOT NULL,
[employeeId] [int]     NOT NULL,
[notes] [text]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Destination](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[countryId] [int]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[order] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Employee](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[isSalesPerson] [bit]     NOT NULL,
[isShipper] [bit]     NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Handler](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[countryId] [int]     NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (10)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[HandlerPipelineStep](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[handlerId] [int]     NOT NULL,
[pipelineStepId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[OtherTransport](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[handlerId] [int]     NOT NULL,
[pipelineStepId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Pet](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[breedId] [int]     NOT NULL,
[clientId] [int]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[weight] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Pipeline](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[pipelineStatusId] [int]     NOT NULL,
[saleId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PipelineStatus](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PipelineStep](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[pipelineStepStatusId] [int]     NOT NULL,
[shipperId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PipelineStepDestination](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[destinationId] [int]     NOT NULL,
[pipelineStepId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PipelineStepNote](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[employeeId] [int]     NOT NULL,
[note] [text]     NOT NULL,
[pipelineStepId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PipelineStepStatus](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PipelineStepStepRequirement](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[details] [text]     NOT NULL,
[pipelineStepId] [int]     NOT NULL,
[requirementMet] [bit]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Sale](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[amount] [money]     NOT NULL,
[cutomerId] [int]     NOT NULL,
[note] [text]     NOT NULL,
[petId] [int]     NOT NULL,
[saleDate] [datetime]     NOT NULL,
[salesPersonId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Species](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Airline]
ADD CONSTRAINT[PK_Airline] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[AirTransport]
ADD CONSTRAINT[PK_AirTransport] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Breed]
ADD CONSTRAINT[PK_Breed] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Country]
ADD CONSTRAINT[PK_Country] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[CountryRequirement]
ADD CONSTRAINT[PK_CountryRequirement] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Customer]
ADD CONSTRAINT[PK_Customer] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[CustomerCommunication]
ADD CONSTRAINT[PK_CustomerCommunication] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_CustomerCommunication_customerId] ON[dbo].[CustomerCommunication]
(
[customerId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_CustomerCommunication_employeeId] ON[dbo].[CustomerCommunication]
(
[employeeId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Destination]
ADD CONSTRAINT[PK_Destination] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Employee]
ADD CONSTRAINT[PK_Employee] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Handler]
ADD CONSTRAINT[PK_Handler] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[HandlerPipelineStep]
ADD CONSTRAINT[PK_HandlerPipelineStep] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[OtherTransport]
ADD CONSTRAINT[PK_OtherTransport] PRIMARY KEY CLUSTERED
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
ALTER TABLE[dbo].[Pipeline]
ADD CONSTRAINT[PK_Pipeline] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PipelineStatus]
ADD CONSTRAINT[PK_PipelineStatus] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PipelineStep]
ADD CONSTRAINT[PK_PipelineStep] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PipelineStepDestination]
ADD CONSTRAINT[PK_PipelineStepDestination] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PipelineStepNote]
ADD CONSTRAINT[PK_PipelineStepNote] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PipelineStepStatus]
ADD CONSTRAINT[PK_PipelineStepStatus] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PipelineStepStepRequirement]
ADD CONSTRAINT[PK_PipelineStepStepRequirement] PRIMARY KEY CLUSTERED
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


ALTER TABLE[dbo].[AirTransport]  WITH CHECK ADD  CONSTRAINT[FK_AirTransport_handlerId_Handler_id] FOREIGN KEY([handlerId])
REFERENCES[dbo].[Handler]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[AirTransport] CHECK CONSTRAINT[FK_AirTransport_handlerId_Handler_id]
GO
ALTER TABLE[dbo].[Breed]  WITH CHECK ADD  CONSTRAINT[FK_Breed_speciesId_Species_id] FOREIGN KEY([speciesId])
REFERENCES[dbo].[Species]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Breed] CHECK CONSTRAINT[FK_Breed_speciesId_Species_id]
GO
ALTER TABLE[dbo].[CountryRequirement]  WITH CHECK ADD  CONSTRAINT[FK_CountryRequirement_countryId_Country_id] FOREIGN KEY([countryId])
REFERENCES[dbo].[Country]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[CountryRequirement] CHECK CONSTRAINT[FK_CountryRequirement_countryId_Country_id]
GO
ALTER TABLE[dbo].[CustomerCommunication]  WITH CHECK ADD  CONSTRAINT[fk_customercommunication_customerid_customer_id] FOREIGN KEY([customerId])
REFERENCES[dbo].[Customer]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[CustomerCommunication] CHECK CONSTRAINT[fk_customercommunication_customerid_customer_id]
GO
ALTER TABLE[dbo].[CustomerCommunication]  WITH CHECK ADD  CONSTRAINT[FK_CustomerCommunication_employeeId_Employee_id] FOREIGN KEY([employeeId])
REFERENCES[dbo].[Employee]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[CustomerCommunication] CHECK CONSTRAINT[FK_CustomerCommunication_employeeId_Employee_id]
GO
ALTER TABLE[dbo].[Destination]  WITH CHECK ADD  CONSTRAINT[FK_Destination_countryId_Country_id] FOREIGN KEY([countryId])
REFERENCES[dbo].[Country]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Destination] CHECK CONSTRAINT[FK_Destination_countryId_Country_id]
GO
ALTER TABLE[dbo].[HandlerPipelineStep]  WITH CHECK ADD  CONSTRAINT[FK_HandlerPipelineStep_handlerId_Handler_id] FOREIGN KEY([handlerId])
REFERENCES[dbo].[Handler]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[HandlerPipelineStep] CHECK CONSTRAINT[FK_HandlerPipelineStep_handlerId_Handler_id]
GO
ALTER TABLE[dbo].[HandlerPipelineStep]  WITH CHECK ADD  CONSTRAINT[FK_HandlerPipelineStep_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[HandlerPipelineStep] CHECK CONSTRAINT[FK_HandlerPipelineStep_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[OtherTransport]  WITH CHECK ADD  CONSTRAINT[FK_OtherTransport_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[OtherTransport] CHECK CONSTRAINT[FK_OtherTransport_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[OtherTransport]  WITH CHECK ADD  CONSTRAINT[FK_OtherTransport_handlerId_Handler_id] FOREIGN KEY([handlerId])
REFERENCES[dbo].[Handler]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[OtherTransport] CHECK CONSTRAINT[FK_OtherTransport_handlerId_Handler_id]
GO
ALTER TABLE[dbo].[Pet]  WITH CHECK ADD  CONSTRAINT[FK_Pet_breedId_Breed_id] FOREIGN KEY([breedId])
REFERENCES[dbo].[Breed]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Pet] CHECK CONSTRAINT[FK_Pet_breedId_Breed_id]
GO
ALTER TABLE[dbo].[Pipeline]  WITH CHECK ADD  CONSTRAINT[FK_Pipeline_pipelineStatusId_PipelineStatus_id] FOREIGN KEY([pipelineStatusId])
REFERENCES[dbo].[PipelineStatus]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Pipeline] CHECK CONSTRAINT[FK_Pipeline_pipelineStatusId_PipelineStatus_id]
GO
ALTER TABLE[dbo].[PipelineStep]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStep_pipelineStepStatusId_PipelineStepStatus_id] FOREIGN KEY([pipelineStepStatusId])
REFERENCES[dbo].[PipelineStepStatus]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[PipelineStep] CHECK CONSTRAINT[FK_PipelineStep_pipelineStepStatusId_PipelineStepStatus_id]
GO
ALTER TABLE[dbo].[PipelineStep]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStep_shipperId_Employee_id] FOREIGN KEY([shipperId])
REFERENCES[dbo].[Employee]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[PipelineStep] CHECK CONSTRAINT[FK_PipelineStep_shipperId_Employee_id]
GO
ALTER TABLE[dbo].[PipelineStepDestination]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepDestination_destinationId_Destination_id] FOREIGN KEY([destinationId])
REFERENCES[dbo].[Destination]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[PipelineStepDestination] CHECK CONSTRAINT[FK_PipelineStepDestination_destinationId_Destination_id]
GO
ALTER TABLE[dbo].[PipelineStepDestination]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepDestination_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[PipelineStepDestination] CHECK CONSTRAINT[FK_PipelineStepDestination_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[PipelineStepNote]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepNote_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[PipelineStepNote] CHECK CONSTRAINT[FK_PipelineStepNote_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[PipelineStepNote]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepNote_employeeId_Employee_id] FOREIGN KEY([employeeId])
REFERENCES[dbo].[Employee]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[PipelineStepNote] CHECK CONSTRAINT[FK_PipelineStepNote_employeeId_Employee_id]
GO
ALTER TABLE[dbo].[PipelineStepStepRequirement]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepStepRequirement_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[PipelineStepStepRequirement] CHECK CONSTRAINT[FK_PipelineStepStepRequirement_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[Sale]  WITH CHECK ADD  CONSTRAINT[FK_Sale_petId_Pet_id] FOREIGN KEY([petId])
REFERENCES[dbo].[Pet]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Sale] CHECK CONSTRAINT[FK_Sale_petId_Pet_id]
GO

");
				}
				else if (this.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
				{
					migrationBuilder.Sql(@"CREATE SCHEMA IF NOT EXISTS ""dbo"";

--ALTER TABLE ""dbo"".""AirTransport"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Breed"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""CountryRequirement"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""CustomerCommunication"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""CustomerCommunication"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Destination"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""HandlerPipelineStep"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""HandlerPipelineStep"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""OtherTransport"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""OtherTransport"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Pet"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Pipeline"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""PipelineStep"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""PipelineStep"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""PipelineStepDestination"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""PipelineStepDestination"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""PipelineStepNote"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""PipelineStepNote"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""PipelineStepStepRequirement"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Sale"" DISABLE TRIGGER ALL;

--DROP TABLE IF EXISTS ""dbo"".""Airline"";
--DROP TABLE IF EXISTS ""dbo"".""AirTransport"";
--DROP TABLE IF EXISTS ""dbo"".""Breed"";
--DROP TABLE IF EXISTS ""dbo"".""Country"";
--DROP TABLE IF EXISTS ""dbo"".""CountryRequirement"";
--DROP TABLE IF EXISTS ""dbo"".""Customer"";
--DROP TABLE IF EXISTS ""dbo"".""CustomerCommunication"";
--DROP TABLE IF EXISTS ""dbo"".""Destination"";
--DROP TABLE IF EXISTS ""dbo"".""Employee"";
--DROP TABLE IF EXISTS ""dbo"".""Handler"";
--DROP TABLE IF EXISTS ""dbo"".""HandlerPipelineStep"";
--DROP TABLE IF EXISTS ""dbo"".""OtherTransport"";
--DROP TABLE IF EXISTS ""dbo"".""Pet"";
--DROP TABLE IF EXISTS ""dbo"".""Pipeline"";
--DROP TABLE IF EXISTS ""dbo"".""PipelineStatus"";
--DROP TABLE IF EXISTS ""dbo"".""PipelineStep"";
--DROP TABLE IF EXISTS ""dbo"".""PipelineStepDestination"";
--DROP TABLE IF EXISTS ""dbo"".""PipelineStepNote"";
--DROP TABLE IF EXISTS ""dbo"".""PipelineStepStatus"";
--DROP TABLE IF EXISTS ""dbo"".""PipelineStepStepRequirement"";
--DROP TABLE IF EXISTS ""dbo"".""Sale"";
--DROP TABLE IF EXISTS ""dbo"".""Species"";

CREATE TABLE ""dbo"".""Airline""(
""id""  SERIAL ,
""name"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""AirTransport""(
""id""  SERIAL ,
""airlineId"" int    NOT NULL,
""flightNumber"" varchar  (12)  NOT NULL,
""handlerId"" int    NOT NULL,
""landDate"" timestamp    NOT NULL,
""pipelineStepId"" int    NOT NULL,
""takeoffDate"" timestamp    NOT NULL);

CREATE TABLE ""dbo"".""Breed""(
""id""  SERIAL ,
""name"" varchar  (128)  NOT NULL,
""speciesId"" int    NOT NULL);

CREATE TABLE ""dbo"".""Country""(
""id""  SERIAL ,
""name"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""CountryRequirement""(
""id""  SERIAL ,
""countryId"" int    NOT NULL,
""details"" text  (2147483647)  NOT NULL);

CREATE TABLE ""dbo"".""Customer""(
""id"" int    NOT NULL,
""email"" varchar  (128)  NOT NULL,
""firstName"" varchar  (128)  NOT NULL,
""lastName"" varchar  (128)  NOT NULL,
""notes"" text  (2147483647)  NULL,
""phone"" varchar  (10)  NOT NULL);

CREATE TABLE ""dbo"".""CustomerCommunication""(
""id"" int    NOT NULL,
""customerId"" int    NOT NULL,
""dateCreated"" timestamp    NOT NULL,
""employeeId"" int    NOT NULL,
""notes"" text  (2147483647)  NOT NULL);

CREATE TABLE ""dbo"".""Destination""(
""id""  SERIAL ,
""countryId"" int    NOT NULL,
""name"" varchar  (128)  NOT NULL,
""order"" int    NOT NULL);

CREATE TABLE ""dbo"".""Employee""(
""id""  SERIAL ,
""firstName"" varchar  (128)  NOT NULL,
""isSalesPerson"" boolean    NOT NULL,
""isShipper"" boolean    NOT NULL,
""lastName"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""Handler""(
""id""  SERIAL ,
""countryId"" int    NOT NULL,
""email"" varchar  (128)  NOT NULL,
""firstName"" varchar  (128)  NOT NULL,
""lastName"" varchar  (128)  NOT NULL,
""phone"" varchar  (10)  NOT NULL);

CREATE TABLE ""dbo"".""HandlerPipelineStep""(
""id""  SERIAL ,
""handlerId"" int    NOT NULL,
""pipelineStepId"" int    NOT NULL);

CREATE TABLE ""dbo"".""OtherTransport""(
""id""  SERIAL ,
""handlerId"" int    NOT NULL,
""pipelineStepId"" int    NOT NULL);

CREATE TABLE ""dbo"".""Pet""(
""id""  SERIAL ,
""breedId"" int    NOT NULL,
""clientId"" int    NOT NULL,
""name"" varchar  (128)  NOT NULL,
""weight"" int    NOT NULL);

CREATE TABLE ""dbo"".""Pipeline""(
""id""  SERIAL ,
""pipelineStatusId"" int    NOT NULL,
""saleId"" int    NOT NULL);

CREATE TABLE ""dbo"".""PipelineStatus""(
""id""  SERIAL ,
""name"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""PipelineStep""(
""id""  SERIAL ,
""name"" varchar  (128)  NOT NULL,
""pipelineStepStatusId"" int    NOT NULL,
""shipperId"" int    NOT NULL);

CREATE TABLE ""dbo"".""PipelineStepDestination""(
""id""  SERIAL ,
""destinationId"" int    NOT NULL,
""pipelineStepId"" int    NOT NULL);

CREATE TABLE ""dbo"".""PipelineStepNote""(
""id""  SERIAL ,
""employeeId"" int    NOT NULL,
""note"" text  (2147483647)  NOT NULL,
""pipelineStepId"" int    NOT NULL);

CREATE TABLE ""dbo"".""PipelineStepStatus""(
""id""  SERIAL ,
""name"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""PipelineStepStepRequirement""(
""id""  SERIAL ,
""details"" text  (2147483647)  NOT NULL,
""pipelineStepId"" int    NOT NULL,
""requirementMet"" boolean    NOT NULL);

CREATE TABLE ""dbo"".""Sale""(
""id""  SERIAL ,
""amount"" money    NOT NULL,
""cutomerId"" int    NOT NULL,
""note"" text  (2147483647)  NOT NULL,
""petId"" int    NOT NULL,
""saleDate"" timestamp    NOT NULL,
""salesPersonId"" int    NOT NULL);

CREATE TABLE ""dbo"".""Species""(
""id""  SERIAL ,
""name"" varchar  (128)  NOT NULL);

ALTER TABLE ""dbo"".""Airline""
ADD CONSTRAINT ""PK_Airline""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""AirTransport""
ADD CONSTRAINT ""PK_AirTransport""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Breed""
ADD CONSTRAINT ""PK_Breed""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Country""
ADD CONSTRAINT ""PK_Country""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""CountryRequirement""
ADD CONSTRAINT ""PK_CountryRequirement""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Customer""
ADD CONSTRAINT ""PK_Customer""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""CustomerCommunication""
ADD CONSTRAINT ""PK_CustomerCommunication""
PRIMARY KEY
(
""id""
);
CREATE  INDEX ""IX_CustomerCommunication_customerId"" ON ""dbo"".""CustomerCommunication""
(
""customerId"" ASC);
CREATE  INDEX ""IX_CustomerCommunication_employeeId"" ON ""dbo"".""CustomerCommunication""
(
""employeeId"" ASC);
ALTER TABLE ""dbo"".""Destination""
ADD CONSTRAINT ""PK_Destination""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Employee""
ADD CONSTRAINT ""PK_Employee""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Handler""
ADD CONSTRAINT ""PK_Handler""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""HandlerPipelineStep""
ADD CONSTRAINT ""PK_HandlerPipelineStep""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""OtherTransport""
ADD CONSTRAINT ""PK_OtherTransport""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Pet""
ADD CONSTRAINT ""PK_Pet""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Pipeline""
ADD CONSTRAINT ""PK_Pipeline""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""PipelineStatus""
ADD CONSTRAINT ""PK_PipelineStatus""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""PipelineStep""
ADD CONSTRAINT ""PK_PipelineStep""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""PipelineStepDestination""
ADD CONSTRAINT ""PK_PipelineStepDestination""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""PipelineStepNote""
ADD CONSTRAINT ""PK_PipelineStepNote""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""PipelineStepStatus""
ADD CONSTRAINT ""PK_PipelineStepStatus""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""PipelineStepStepRequirement""
ADD CONSTRAINT ""PK_PipelineStepStepRequirement""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Sale""
ADD CONSTRAINT ""PK_Sale""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Species""
ADD CONSTRAINT ""PK_Species""
PRIMARY KEY
(
""id""
);


ALTER TABLE ""dbo"".""AirTransport"" ADD CONSTRAINT ""FK_AirTransport_handlerId_Handler_id"" FOREIGN KEY(""handlerId"")
REFERENCES ""dbo"".""Handler"" (""id"");
ALTER TABLE ""dbo"".""Breed"" ADD CONSTRAINT ""FK_Breed_speciesId_Species_id"" FOREIGN KEY(""speciesId"")
REFERENCES ""dbo"".""Species"" (""id"");
ALTER TABLE ""dbo"".""CountryRequirement"" ADD CONSTRAINT ""FK_CountryRequirement_countryId_Country_id"" FOREIGN KEY(""countryId"")
REFERENCES ""dbo"".""Country"" (""id"");
ALTER TABLE ""dbo"".""CustomerCommunication"" ADD CONSTRAINT ""fk_customercommunication_customerid_customer_id"" FOREIGN KEY(""customerId"")
REFERENCES ""dbo"".""Customer"" (""id"");
ALTER TABLE ""dbo"".""CustomerCommunication"" ADD CONSTRAINT ""FK_CustomerCommunication_employeeId_Employee_id"" FOREIGN KEY(""employeeId"")
REFERENCES ""dbo"".""Employee"" (""id"");
ALTER TABLE ""dbo"".""Destination"" ADD CONSTRAINT ""FK_Destination_countryId_Country_id"" FOREIGN KEY(""countryId"")
REFERENCES ""dbo"".""Country"" (""id"");
ALTER TABLE ""dbo"".""HandlerPipelineStep"" ADD CONSTRAINT ""FK_HandlerPipelineStep_handlerId_Handler_id"" FOREIGN KEY(""handlerId"")
REFERENCES ""dbo"".""Handler"" (""id"");
ALTER TABLE ""dbo"".""HandlerPipelineStep"" ADD CONSTRAINT ""FK_HandlerPipelineStep_pipelineStepId_PipelineStep_id"" FOREIGN KEY(""pipelineStepId"")
REFERENCES ""dbo"".""PipelineStep"" (""id"");
ALTER TABLE ""dbo"".""OtherTransport"" ADD CONSTRAINT ""FK_OtherTransport_pipelineStepId_PipelineStep_id"" FOREIGN KEY(""pipelineStepId"")
REFERENCES ""dbo"".""PipelineStep"" (""id"");
ALTER TABLE ""dbo"".""OtherTransport"" ADD CONSTRAINT ""FK_OtherTransport_handlerId_Handler_id"" FOREIGN KEY(""handlerId"")
REFERENCES ""dbo"".""Handler"" (""id"");
ALTER TABLE ""dbo"".""Pet"" ADD CONSTRAINT ""FK_Pet_breedId_Breed_id"" FOREIGN KEY(""breedId"")
REFERENCES ""dbo"".""Breed"" (""id"");
ALTER TABLE ""dbo"".""Pipeline"" ADD CONSTRAINT ""FK_Pipeline_pipelineStatusId_PipelineStatus_id"" FOREIGN KEY(""pipelineStatusId"")
REFERENCES ""dbo"".""PipelineStatus"" (""id"");
ALTER TABLE ""dbo"".""PipelineStep"" ADD CONSTRAINT ""FK_PipelineStep_pipelineStepStatusId_PipelineStepStatus_id"" FOREIGN KEY(""pipelineStepStatusId"")
REFERENCES ""dbo"".""PipelineStepStatus"" (""id"");
ALTER TABLE ""dbo"".""PipelineStep"" ADD CONSTRAINT ""FK_PipelineStep_shipperId_Employee_id"" FOREIGN KEY(""shipperId"")
REFERENCES ""dbo"".""Employee"" (""id"");
ALTER TABLE ""dbo"".""PipelineStepDestination"" ADD CONSTRAINT ""FK_PipelineStepDestination_destinationId_Destination_id"" FOREIGN KEY(""destinationId"")
REFERENCES ""dbo"".""Destination"" (""id"");
ALTER TABLE ""dbo"".""PipelineStepDestination"" ADD CONSTRAINT ""FK_PipelineStepDestination_pipelineStepId_PipelineStep_id"" FOREIGN KEY(""pipelineStepId"")
REFERENCES ""dbo"".""PipelineStep"" (""id"");
ALTER TABLE ""dbo"".""PipelineStepNote"" ADD CONSTRAINT ""FK_PipelineStepNote_pipelineStepId_PipelineStep_id"" FOREIGN KEY(""pipelineStepId"")
REFERENCES ""dbo"".""PipelineStep"" (""id"");
ALTER TABLE ""dbo"".""PipelineStepNote"" ADD CONSTRAINT ""FK_PipelineStepNote_employeeId_Employee_id"" FOREIGN KEY(""employeeId"")
REFERENCES ""dbo"".""Employee"" (""id"");
ALTER TABLE ""dbo"".""PipelineStepStepRequirement"" ADD CONSTRAINT ""FK_PipelineStepStepRequirement_pipelineStepId_PipelineStep_id"" FOREIGN KEY(""pipelineStepId"")
REFERENCES ""dbo"".""PipelineStep"" (""id"");
ALTER TABLE ""dbo"".""Sale"" ADD CONSTRAINT ""FK_Sale_petId_Pet_id"" FOREIGN KEY(""petId"")
REFERENCES ""dbo"".""Pet"" (""id"");

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