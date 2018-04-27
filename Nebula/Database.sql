IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'dbo')
EXEC('CREATE SCHEMA [dbo] AUTHORIZATION [dbo]');
GO

IF (OBJECT_ID('FK_Clasp_nextChainId_Chain_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Clasp] DROP CONSTRAINT [FK_Clasp_nextChainId_Chain_id]
END
GO
IF (OBJECT_ID('FK_Clasp_previousChainId_Chain_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Clasp] DROP CONSTRAINT [FK_Clasp_previousChainId_Chain_id]
END
GO
IF (OBJECT_ID('FK_Link_chainId_Chain_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Link] DROP CONSTRAINT [FK_Link_chainId_Chain_id]
END
GO
IF (OBJECT_ID('FK_Chain_chainStatusId_ChainStatus_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Chain] DROP CONSTRAINT [FK_Chain_chainStatusId_ChainStatus_id]
END
GO
IF (OBJECT_ID('FK_LinkLog_linkId_Link_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[LinkLog] DROP CONSTRAINT [FK_LinkLog_linkId_Link_id]
END
GO
IF (OBJECT_ID('FK_Link_linkStatusId_LinkStatus_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Link] DROP CONSTRAINT [FK_Link_linkStatusId_LinkStatus_id]
END
GO
IF (OBJECT_ID('FK_Link_assignedMachineId_Machine_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Link] DROP CONSTRAINT [FK_Link_assignedMachineId_Machine_id]
END
GO
IF (OBJECT_ID('FK_MachineRefTeam_machineId_Machine_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[MachineRefTeam] DROP CONSTRAINT [FK_MachineRefTeam_machineId_Machine_id]
END
GO
IF (OBJECT_ID('FK_Team_organizationId_Organization_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Team] DROP CONSTRAINT [FK_Team_organizationId_Organization_id]
END
GO
IF (OBJECT_ID('FK_Chain_teamId_Team_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Chain] DROP CONSTRAINT [FK_Chain_teamId_Team_id]
END
GO
IF (OBJECT_ID('FK_machineRefTeam_teamId_Team_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[MachineRefTeam] DROP CONSTRAINT [FK_machineRefTeam_teamId_Team_id]
END
GO

IF OBJECT_ID('dbo.Chain', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Chain]
END
GO
IF OBJECT_ID('dbo.ChainStatus', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[ChainStatus]
END
GO
IF OBJECT_ID('dbo.Clasp', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Clasp]
END
GO
IF OBJECT_ID('dbo.Link', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Link]
END
GO
IF OBJECT_ID('dbo.LinkLog', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[LinkLog]
END
GO
IF OBJECT_ID('dbo.LinkStatus', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[LinkStatus]
END
GO
IF OBJECT_ID('dbo.Machine', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Machine]
END
GO
IF OBJECT_ID('dbo.MachineRefTeam', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[MachineRefTeam]
END
GO
IF OBJECT_ID('dbo.Organization', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Organization]
END
GO
IF OBJECT_ID('dbo.Team', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Team]
END
GO
IF OBJECT_ID('dbo.VersionInfo', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[VersionInfo]
END
GO

CREATE TABLE [dbo].[Chain](
[id] [int]   IDENTITY(1,1) NOT NULL,
[chainStatusId] [int]    NOT NULL,
[externalId] [uniqueidentifier]    NOT NULL,
[name] [varchar]  (128)  NOT NULL,
[teamId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ChainStatus](
[id] [int]   IDENTITY(1,1) NOT NULL,
[name] [varchar]  (128)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Clasp](
[id] [int]   IDENTITY(1,1) NOT NULL,
[nextChainId] [int]    NOT NULL,
[previousChainId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Link](
[id] [int]   IDENTITY(1,1) NOT NULL,
[assignedMachineId] [int]    NULL,
[chainId] [int]    NOT NULL,
[dateCompleted] [datetime]    NULL,
[dateStarted] [datetime]    NULL,
[dynamicParameters] [text]    NULL,
[externalId] [uniqueidentifier]    NOT NULL,
[linkStatusId] [int]    NOT NULL,
[name] [varchar]  (128)  NOT NULL,
[order] [int]    NOT NULL,
[response] [text]    NULL,
[staticParameters] [text]    NULL,
[timeoutInSeconds] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[LinkLog](
[id] [int]   IDENTITY(1,1) NOT NULL,
[dateEntered] [datetime]    NOT NULL,
[linkId] [int]    NOT NULL,
[log] [text]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[LinkStatus](
[id] [int]   IDENTITY(1,1) NOT NULL,
[name] [varchar]  (128)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Machine](
[id] [int]   IDENTITY(1,1) NOT NULL,
[description] [text]    NOT NULL,
[jwtKey] [varchar]  (128)  NOT NULL,
[lastIpAddress] [varchar]  (128)  NOT NULL,
[machineGuid] [uniqueidentifier]    NOT NULL,
[name] [varchar]  (128)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[MachineRefTeam](
[id] [int]   IDENTITY(1,1) NOT NULL,
[machineId] [int]    NOT NULL,
[teamId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Organization](
[id] [int]   IDENTITY(1,1) NOT NULL,
[name] [varchar]  (128)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Team](
[id] [int]   IDENTITY(1,1) NOT NULL,
[name] [varchar]  (128)  NOT NULL,
[organizationId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[VersionInfo](
[AppliedOn] [datetime]    NULL,
[Description] [nvarchar]  (1024)  NULL,
[Version] [bigint]    NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Chain]
ADD CONSTRAINT[PK_chain] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ChainStatus]
ADD CONSTRAINT[PK_chainStatus] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Clasp]
ADD CONSTRAINT[PK_Clasp] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Link]
ADD CONSTRAINT[PK_link] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[LinkLog]
ADD CONSTRAINT[PK_linkLog] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[LinkStatus]
ADD CONSTRAINT[PK_linkStatus] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Machine]
ADD CONSTRAINT[PK_machine] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[MachineRefTeam]
ADD CONSTRAINT[PK_machineRefTeam] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Organization]
ADD CONSTRAINT[PK_organization] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Team]
ADD CONSTRAINT[PK_team] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE CLUSTERED INDEX[UC_Version] ON[dbo].[VersionInfo]
(
[Version] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

ALTER TABLE[dbo].[Clasp]  WITH CHECK ADD  CONSTRAINT[FK_Clasp_nextChainId_Chain_id] FOREIGN KEY([nextChainId])
REFERENCES[dbo].[Chain]([id])
GO
ALTER TABLE[dbo].[Clasp] CHECK CONSTRAINT[FK_Clasp_nextChainId_Chain_id]
GO
ALTER TABLE[dbo].[Clasp]  WITH CHECK ADD  CONSTRAINT[FK_Clasp_previousChainId_Chain_id] FOREIGN KEY([previousChainId])
REFERENCES[dbo].[Chain]([id])
GO
ALTER TABLE[dbo].[Clasp] CHECK CONSTRAINT[FK_Clasp_previousChainId_Chain_id]
GO
ALTER TABLE[dbo].[Link]  WITH CHECK ADD  CONSTRAINT[FK_Link_chainId_Chain_id] FOREIGN KEY([chainId])
REFERENCES[dbo].[Chain]([id])
GO
ALTER TABLE[dbo].[Link] CHECK CONSTRAINT[FK_Link_chainId_Chain_id]
GO
ALTER TABLE[dbo].[Chain]  WITH CHECK ADD  CONSTRAINT[FK_Chain_chainStatusId_ChainStatus_id] FOREIGN KEY([chainStatusId])
REFERENCES[dbo].[ChainStatus]([id])
GO
ALTER TABLE[dbo].[Chain] CHECK CONSTRAINT[FK_Chain_chainStatusId_ChainStatus_id]
GO
ALTER TABLE[dbo].[LinkLog]  WITH CHECK ADD  CONSTRAINT[FK_LinkLog_linkId_Link_id] FOREIGN KEY([linkId])
REFERENCES[dbo].[Link]([id])
GO
ALTER TABLE[dbo].[LinkLog] CHECK CONSTRAINT[FK_LinkLog_linkId_Link_id]
GO
ALTER TABLE[dbo].[Link]  WITH CHECK ADD  CONSTRAINT[FK_Link_linkStatusId_LinkStatus_id] FOREIGN KEY([linkStatusId])
REFERENCES[dbo].[LinkStatus]([id])
GO
ALTER TABLE[dbo].[Link] CHECK CONSTRAINT[FK_Link_linkStatusId_LinkStatus_id]
GO
ALTER TABLE[dbo].[Link]  WITH CHECK ADD  CONSTRAINT[FK_Link_assignedMachineId_Machine_id] FOREIGN KEY([assignedMachineId])
REFERENCES[dbo].[Machine]([id])
GO
ALTER TABLE[dbo].[Link] CHECK CONSTRAINT[FK_Link_assignedMachineId_Machine_id]
GO
ALTER TABLE[dbo].[MachineRefTeam]  WITH CHECK ADD  CONSTRAINT[FK_MachineRefTeam_machineId_Machine_id] FOREIGN KEY([machineId])
REFERENCES[dbo].[Machine]([id])
GO
ALTER TABLE[dbo].[MachineRefTeam] CHECK CONSTRAINT[FK_MachineRefTeam_machineId_Machine_id]
GO
ALTER TABLE[dbo].[Team]  WITH CHECK ADD  CONSTRAINT[FK_Team_organizationId_Organization_id] FOREIGN KEY([organizationId])
REFERENCES[dbo].[Organization]([id])
GO
ALTER TABLE[dbo].[Team] CHECK CONSTRAINT[FK_Team_organizationId_Organization_id]
GO
ALTER TABLE[dbo].[Chain]  WITH CHECK ADD  CONSTRAINT[FK_Chain_teamId_Team_id] FOREIGN KEY([teamId])
REFERENCES[dbo].[Team]([id])
GO
ALTER TABLE[dbo].[Chain] CHECK CONSTRAINT[FK_Chain_teamId_Team_id]
GO
ALTER TABLE[dbo].[MachineRefTeam]  WITH CHECK ADD  CONSTRAINT[FK_machineRefTeam_teamId_Team_id] FOREIGN KEY([teamId])
REFERENCES[dbo].[Team]([id])
GO
ALTER TABLE[dbo].[MachineRefTeam] CHECK CONSTRAINT[FK_machineRefTeam_teamId_Team_id]
GO

