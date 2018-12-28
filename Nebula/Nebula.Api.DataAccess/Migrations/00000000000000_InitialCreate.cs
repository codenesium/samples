using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.DataAccess.Migrations
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

--IF (OBJECT_ID('dbo.FK_Chain_teamId_Team_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Chain] DROP CONSTRAINT [FK_Chain_teamId_Team_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Chain_chainStatusId_ChainStatus_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Chain] DROP CONSTRAINT [FK_Chain_chainStatusId_ChainStatus_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Clasp_nextChainId_Chain_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Clasp] DROP CONSTRAINT [FK_Clasp_nextChainId_Chain_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Clasp_previousChainId_Chain_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Clasp] DROP CONSTRAINT [FK_Clasp_previousChainId_Chain_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Link_chainId_Chain_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Link] DROP CONSTRAINT [FK_Link_chainId_Chain_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Link_linkStatusId_LinkStatus_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Link] DROP CONSTRAINT [FK_Link_linkStatusId_LinkStatus_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Link_assignedMachineId_Machine_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Link] DROP CONSTRAINT [FK_Link_assignedMachineId_Machine_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_LinkLog_linkId_Link_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[LinkLog] DROP CONSTRAINT [FK_LinkLog_linkId_Link_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_machineRefTeam_teamId_Team_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[MachineRefTeam] DROP CONSTRAINT [FK_machineRefTeam_teamId_Team_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_MachineRefTeam_machineId_Machine_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[MachineRefTeam] DROP CONSTRAINT [FK_MachineRefTeam_machineId_Machine_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Team_organizationId_Organization_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Team] DROP CONSTRAINT [FK_Team_organizationId_Organization_id]
--END
--GO

--IF OBJECT_ID('dbo.Chain', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Chain]
--END
--GO
--IF OBJECT_ID('dbo.ChainStatus', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[ChainStatus]
--END
--GO
--IF OBJECT_ID('dbo.Clasp', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Clasp]
--END
--GO
--IF OBJECT_ID('dbo.Link', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Link]
--END
--GO
--IF OBJECT_ID('dbo.LinkLog', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[LinkLog]
--END
--GO
--IF OBJECT_ID('dbo.LinkStatus', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[LinkStatus]
--END
--GO
--IF OBJECT_ID('dbo.Machine', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Machine]
--END
--GO
--IF OBJECT_ID('dbo.MachineRefTeam', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[MachineRefTeam]
--END
--GO
--IF OBJECT_ID('dbo.Organization', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Organization]
--END
--GO
--IF OBJECT_ID('dbo.sysdiagrams', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[sysdiagrams]
--END
--GO
--IF OBJECT_ID('dbo.Team', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Team]
--END
--GO
--IF OBJECT_ID('dbo.VersionInfo', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[VersionInfo]
--END
--GO

CREATE TABLE [dbo].[Chain](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[chainStatusId] [int]     NOT NULL,
[externalId] [uniqueidentifier]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[teamId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ChainStatus](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Clasp](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[nextChainId] [int]     NOT NULL,
[previousChainId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Link](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[assignedMachineId] [int]     NULL,
[chainId] [int]     NOT NULL,
[dateCompleted] [datetime]     NULL,
[dateStarted] [datetime]     NULL,
[dynamicParameters] [text]     NULL,
[externalId] [uniqueidentifier]     NOT NULL,
[linkStatusId] [int]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[order] [int]     NOT NULL,
[response] [text]     NULL,
[staticParameters] [text]     NULL,
[timeoutInSeconds] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[LinkLog](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[dateEntered] [datetime]     NOT NULL,
[linkId] [int]     NOT NULL,
[log] [text]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[LinkStatus](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Machine](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[description] [text]     NOT NULL,
[jwtKey] [varchar]  (128)   NOT NULL,
[lastIpAddress] [varchar]  (128)   NOT NULL,
[machineGuid] [uniqueidentifier]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[MachineRefTeam](
[machineId] [int]     NOT NULL,
[teamId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Organization](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[sysdiagrams](
[diagram_id] [int]   IDENTITY(1,1)  NOT NULL,
[definition] [varbinary]  (1)   NULL,
[name] [nvarchar]  (128)   NOT NULL,
[principal_id] [int]     NOT NULL,
[version] [int]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Team](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[organizationId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[VersionInfo](
[Version] [bigint]     NOT NULL,
[AppliedOn] [datetime]     NULL,
[Description] [nvarchar]  (1024)   NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Chain]
ADD CONSTRAINT[PK_chain] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AX_Chain_ExternalId] ON[dbo].[Chain]
(
[externalId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ChainStatus]
ADD CONSTRAINT[PK_chainStatus] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AX_ChainStatus_Name] ON[dbo].[ChainStatus]
(
[name] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Clasp]
ADD CONSTRAINT[PK_Clasp] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Link]
ADD CONSTRAINT[PK_link] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AX_Link_ExternalId] ON[dbo].[Link]
(
[externalId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[AX_Link_ChainId] ON[dbo].[Link]
(
[chainId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[LinkLog]
ADD CONSTRAINT[PK_linkLog] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[LinkStatus]
ADD CONSTRAINT[PK_linkStatus] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AX_LinkStatus_Name] ON[dbo].[LinkStatus]
(
[name] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Machine]
ADD CONSTRAINT[PK_machine] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AX_Machine_MachineGuid] ON[dbo].[Machine]
(
[machineGuid] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[MachineRefTeam]
ADD CONSTRAINT[PK_MachineRefTeam] PRIMARY KEY CLUSTERED
(
[machineId] ASC
,[teamId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Organization]
ADD CONSTRAINT[PK_organization] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AX_organization_Name] ON[dbo].[Organization]
(
[name] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[sysdiagrams]
ADD CONSTRAINT[PK__sysdiagr__C2B05B61A233D1A5] PRIMARY KEY CLUSTERED
(
[diagram_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UK_principal_name] ON[dbo].[sysdiagrams]
(
[principal_id] ASC,
[name] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Team]
ADD CONSTRAINT[PK_team] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[AX_Team_Name] ON[dbo].[Team]
(
[name] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[VersionInfo]
ADD CONSTRAINT[UC_Version] PRIMARY KEY CLUSTERED
(
[Version] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[Chain]  WITH CHECK ADD  CONSTRAINT[FK_Chain_teamId_Team_id] FOREIGN KEY([teamId])
REFERENCES[dbo].[Team]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Chain] CHECK CONSTRAINT[FK_Chain_teamId_Team_id]
GO
ALTER TABLE[dbo].[Chain]  WITH CHECK ADD  CONSTRAINT[FK_Chain_chainStatusId_ChainStatus_id] FOREIGN KEY([chainStatusId])
REFERENCES[dbo].[ChainStatus]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Chain] CHECK CONSTRAINT[FK_Chain_chainStatusId_ChainStatus_id]
GO
ALTER TABLE[dbo].[Clasp]  WITH CHECK ADD  CONSTRAINT[FK_Clasp_nextChainId_Chain_id] FOREIGN KEY([nextChainId])
REFERENCES[dbo].[Chain]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Clasp] CHECK CONSTRAINT[FK_Clasp_nextChainId_Chain_id]
GO
ALTER TABLE[dbo].[Clasp]  WITH CHECK ADD  CONSTRAINT[FK_Clasp_previousChainId_Chain_id] FOREIGN KEY([previousChainId])
REFERENCES[dbo].[Chain]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Clasp] CHECK CONSTRAINT[FK_Clasp_previousChainId_Chain_id]
GO
ALTER TABLE[dbo].[Link]  WITH CHECK ADD  CONSTRAINT[FK_Link_chainId_Chain_id] FOREIGN KEY([chainId])
REFERENCES[dbo].[Chain]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Link] CHECK CONSTRAINT[FK_Link_chainId_Chain_id]
GO
ALTER TABLE[dbo].[Link]  WITH CHECK ADD  CONSTRAINT[FK_Link_linkStatusId_LinkStatus_id] FOREIGN KEY([linkStatusId])
REFERENCES[dbo].[LinkStatus]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Link] CHECK CONSTRAINT[FK_Link_linkStatusId_LinkStatus_id]
GO
ALTER TABLE[dbo].[Link]  WITH CHECK ADD  CONSTRAINT[FK_Link_assignedMachineId_Machine_id] FOREIGN KEY([assignedMachineId])
REFERENCES[dbo].[Machine]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Link] CHECK CONSTRAINT[FK_Link_assignedMachineId_Machine_id]
GO
ALTER TABLE[dbo].[LinkLog]  WITH CHECK ADD  CONSTRAINT[FK_LinkLog_linkId_Link_id] FOREIGN KEY([linkId])
REFERENCES[dbo].[Link]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[LinkLog] CHECK CONSTRAINT[FK_LinkLog_linkId_Link_id]
GO
ALTER TABLE[dbo].[MachineRefTeam]  WITH CHECK ADD  CONSTRAINT[FK_machineRefTeam_teamId_Team_id] FOREIGN KEY([teamId])
REFERENCES[dbo].[Team]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[MachineRefTeam] CHECK CONSTRAINT[FK_machineRefTeam_teamId_Team_id]
GO
ALTER TABLE[dbo].[MachineRefTeam]  WITH CHECK ADD  CONSTRAINT[FK_MachineRefTeam_machineId_Machine_id] FOREIGN KEY([machineId])
REFERENCES[dbo].[Machine]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[MachineRefTeam] CHECK CONSTRAINT[FK_MachineRefTeam_machineId_Machine_id]
GO
ALTER TABLE[dbo].[Team]  WITH CHECK ADD  CONSTRAINT[FK_Team_organizationId_Organization_id] FOREIGN KEY([organizationId])
REFERENCES[dbo].[Organization]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Team] CHECK CONSTRAINT[FK_Team_organizationId_Organization_id]
GO

insert into chainstatus(name) values('Running')
insert into chainstatus(name) values('Completed')

insert into linkstatus(name) values('Running')
insert into linkstatus(name) values('Completed')

insert into organization(name) values('Alpha')
insert into organization(name) values('Beta')

insert into team(name,organizationid) values('TeamA',1)
insert into team(name,organizationid) values('TeamB',2)

insert into machine(name,machineGuid,[description],jwtKey,lastIpAddress) values('machine1','938e50e5-8d19-440a-a81b-e11a131be358','a machine','Passw0rd','192.168.1.123')
insert into machine(name,machineGuid,[description],jwtKey,lastIpAddress) values('machine2','bbf6e969-82b1-474a-9e01-56cde4a18cff','a machine','Passw0rd','192.168.1.124')

insert into machineRefTeam (machineId,teamId) values(1,1);
insert into machineRefTeam (machineId,teamId) values(2,2);

insert into Chain(name,teamId,chainStatusId,externalId) Values('Deploy',1,1,'82378afb-a1f6-4c6f-a31a-7a7328c26f2e')
insert into Chain(name,teamId,chainStatusId,externalId) Values('Execute',2,1,'c6865b56-a574-4986-b6f7-4a292adebdfe')
");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}