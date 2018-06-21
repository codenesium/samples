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
			migrationBuilder.Sql(@"IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'dbo')
EXEC('CREATE SCHEMA [dbo] AUTHORIZATION [dbo]');
GO

CREATE TABLE [dbo].[Airline](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[AirTransport](
[airlineId] [int]   IDENTITY(1,1)  NOT NULL,
[flightNumber] [varchar]  (12)   NOT NULL,
[handlerId] [int]     NOT NULL,
[id] [int]     NOT NULL,
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

CREATE TABLE [dbo].[Client](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[notes] [text]     NULL,
[phone] [varchar]  (10)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ClientCommunication](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[clientId] [int]     NOT NULL,
[dateCreated] [datetime]     NOT NULL,
[employeeId] [int]     NOT NULL,
[notes] [text]     NOT NULL,
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
[clientId] [int]     NOT NULL,
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
[airlineId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Breed]
ADD CONSTRAINT[PK_Breed] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Client]
ADD CONSTRAINT[PK_Client] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ClientCommunication]
ADD CONSTRAINT[PK_ClientCommunication] PRIMARY KEY CLUSTERED
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
REFERENCES[dbo].[Handler]([id])
GO
ALTER TABLE[dbo].[AirTransport] CHECK CONSTRAINT[FK_AirTransport_handlerId_Handler_id]
GO
ALTER TABLE[dbo].[Breed]  WITH CHECK ADD  CONSTRAINT[FK_Breed_speciesId_Species_id] FOREIGN KEY([speciesId])
REFERENCES[dbo].[Species]([id])
GO
ALTER TABLE[dbo].[Breed] CHECK CONSTRAINT[FK_Breed_speciesId_Species_id]
GO
ALTER TABLE[dbo].[ClientCommunication]  WITH CHECK ADD  CONSTRAINT[FK_ClientCommunication_clientId_Client_id] FOREIGN KEY([clientId])
REFERENCES[dbo].[Client]([id])
GO
ALTER TABLE[dbo].[ClientCommunication] CHECK CONSTRAINT[FK_ClientCommunication_clientId_Client_id]
GO
ALTER TABLE[dbo].[ClientCommunication]  WITH CHECK ADD  CONSTRAINT[FK_ClientCommunication_employeeId_Employee_id] FOREIGN KEY([employeeId])
REFERENCES[dbo].[Employee]([id])
GO
ALTER TABLE[dbo].[ClientCommunication] CHECK CONSTRAINT[FK_ClientCommunication_employeeId_Employee_id]
GO
ALTER TABLE[dbo].[CountryRequirement]  WITH CHECK ADD  CONSTRAINT[FK_CountryRequirement_countryId_Country_id] FOREIGN KEY([countryId])
REFERENCES[dbo].[Country]([id])
GO
ALTER TABLE[dbo].[CountryRequirement] CHECK CONSTRAINT[FK_CountryRequirement_countryId_Country_id]
GO
ALTER TABLE[dbo].[Destination]  WITH CHECK ADD  CONSTRAINT[FK_Destination_countryId_Country_id] FOREIGN KEY([countryId])
REFERENCES[dbo].[Country]([id])
GO
ALTER TABLE[dbo].[Destination] CHECK CONSTRAINT[FK_Destination_countryId_Country_id]
GO
ALTER TABLE[dbo].[HandlerPipelineStep]  WITH CHECK ADD  CONSTRAINT[FK_HandlerPipelineStep_handlerId_Handler_id] FOREIGN KEY([handlerId])
REFERENCES[dbo].[Handler]([id])
GO
ALTER TABLE[dbo].[HandlerPipelineStep] CHECK CONSTRAINT[FK_HandlerPipelineStep_handlerId_Handler_id]
GO
ALTER TABLE[dbo].[HandlerPipelineStep]  WITH CHECK ADD  CONSTRAINT[FK_HandlerPipelineStep_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id])
GO
ALTER TABLE[dbo].[HandlerPipelineStep] CHECK CONSTRAINT[FK_HandlerPipelineStep_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[OtherTransport]  WITH CHECK ADD  CONSTRAINT[FK_OtherTransport_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id])
GO
ALTER TABLE[dbo].[OtherTransport] CHECK CONSTRAINT[FK_OtherTransport_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[OtherTransport]  WITH CHECK ADD  CONSTRAINT[FK_OtherTransport_handlerId_Handler_id] FOREIGN KEY([handlerId])
REFERENCES[dbo].[Handler]([id])
GO
ALTER TABLE[dbo].[OtherTransport] CHECK CONSTRAINT[FK_OtherTransport_handlerId_Handler_id]
GO
ALTER TABLE[dbo].[Pet]  WITH CHECK ADD  CONSTRAINT[FK_Pet_breedId_Breed_id] FOREIGN KEY([breedId])
REFERENCES[dbo].[Breed]([id])
GO
ALTER TABLE[dbo].[Pet] CHECK CONSTRAINT[FK_Pet_breedId_Breed_id]
GO
ALTER TABLE[dbo].[Pet]  WITH CHECK ADD  CONSTRAINT[FK_Pet_clientId_Client_id] FOREIGN KEY([clientId])
REFERENCES[dbo].[Client]([id])
GO
ALTER TABLE[dbo].[Pet] CHECK CONSTRAINT[FK_Pet_clientId_Client_id]
GO
ALTER TABLE[dbo].[Pipeline]  WITH CHECK ADD  CONSTRAINT[FK_Pipeline_pipelineStatusId_PipelineStatus_id] FOREIGN KEY([pipelineStatusId])
REFERENCES[dbo].[PipelineStatus]([id])
GO
ALTER TABLE[dbo].[Pipeline] CHECK CONSTRAINT[FK_Pipeline_pipelineStatusId_PipelineStatus_id]
GO
ALTER TABLE[dbo].[PipelineStep]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStep_pipelineStepStatusId_PipelineStepStatus_id] FOREIGN KEY([pipelineStepStatusId])
REFERENCES[dbo].[PipelineStepStatus]([id])
GO
ALTER TABLE[dbo].[PipelineStep] CHECK CONSTRAINT[FK_PipelineStep_pipelineStepStatusId_PipelineStepStatus_id]
GO
ALTER TABLE[dbo].[PipelineStep]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStep_shipperId_Employee_id] FOREIGN KEY([shipperId])
REFERENCES[dbo].[Employee]([id])
GO
ALTER TABLE[dbo].[PipelineStep] CHECK CONSTRAINT[FK_PipelineStep_shipperId_Employee_id]
GO
ALTER TABLE[dbo].[PipelineStepDestination]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepDestination_destinationId_Destination_id] FOREIGN KEY([destinationId])
REFERENCES[dbo].[Destination]([id])
GO
ALTER TABLE[dbo].[PipelineStepDestination] CHECK CONSTRAINT[FK_PipelineStepDestination_destinationId_Destination_id]
GO
ALTER TABLE[dbo].[PipelineStepDestination]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepDestination_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id])
GO
ALTER TABLE[dbo].[PipelineStepDestination] CHECK CONSTRAINT[FK_PipelineStepDestination_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[PipelineStepNote]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepNote_employeeId_Employee_id] FOREIGN KEY([employeeId])
REFERENCES[dbo].[Employee]([id])
GO
ALTER TABLE[dbo].[PipelineStepNote] CHECK CONSTRAINT[FK_PipelineStepNote_employeeId_Employee_id]
GO
ALTER TABLE[dbo].[PipelineStepNote]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepNote_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id])
GO
ALTER TABLE[dbo].[PipelineStepNote] CHECK CONSTRAINT[FK_PipelineStepNote_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[PipelineStepStepRequirement]  WITH CHECK ADD  CONSTRAINT[FK_PipelineStepStepRequirement_pipelineStepId_PipelineStep_id] FOREIGN KEY([pipelineStepId])
REFERENCES[dbo].[PipelineStep]([id])
GO
ALTER TABLE[dbo].[PipelineStepStepRequirement] CHECK CONSTRAINT[FK_PipelineStepStepRequirement_pipelineStepId_PipelineStep_id]
GO
ALTER TABLE[dbo].[Sale]  WITH CHECK ADD  CONSTRAINT[FK_Sale_petId_Pet_id] FOREIGN KEY([petId])
REFERENCES[dbo].[Pet]([id])
GO
ALTER TABLE[dbo].[Sale] CHECK CONSTRAINT[FK_Sale_petId_Pet_id]
GO
ALTER TABLE[dbo].[Sale]  WITH CHECK ADD  CONSTRAINT[FK_Sale_clientId_Client_id] FOREIGN KEY([clientId])
REFERENCES[dbo].[Client]([id])
GO
ALTER TABLE[dbo].[Sale] CHECK CONSTRAINT[FK_Sale_clientId_Client_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}