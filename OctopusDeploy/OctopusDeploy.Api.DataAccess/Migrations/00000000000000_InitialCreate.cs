using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.DataAccess.Migrations
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

CREATE TABLE [dbo].[Account](
[Id] [nvarchar]  (210)   NOT NULL,
[AccountType] [nvarchar]  (50)   NOT NULL,
[EnvironmentIds] [nvarchar]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[TenantIds] [nvarchar]     NULL,
[TenantTags] [nvarchar]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ActionTemplate](
[Id] [nvarchar]  (50)   NOT NULL,
[ActionType] [nvarchar]  (50)   NOT NULL,
[CommunityActionTemplateId] [nvarchar]  (50)   NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[Version] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ActionTemplateVersion](
[Id] [nvarchar]  (50)   NOT NULL,
[ActionType] [nvarchar]  (50)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[LatestActionTemplateId] [nvarchar]  (50)   NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[Version] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ApiKey](
[Id] [nvarchar]  (50)   NOT NULL,
[ApiKeyHashed] [nvarchar]  (200)   NOT NULL,
[Created] [datetimeoffset]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[UserId] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Artifact](
[Id] [nvarchar]  (50)   NOT NULL,
[Created] [datetimeoffset]     NOT NULL,
[EnvironmentId] [nvarchar]  (50)   NULL,
[Filename] [nvarchar]  (200)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[ProjectId] [nvarchar]  (50)   NULL,
[RelatedDocumentIds] [nvarchar]     NOT NULL,
[TenantId] [nvarchar]  (50)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Certificate](
[Id] [varchar]  (210)   NOT NULL,
[Archived] [datetimeoffset]     NULL,
[Created] [datetimeoffset]     NOT NULL,
[DataVersion] [timestamp]     NOT NULL,
[EnvironmentIds] [nvarchar]     NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[NotAfter] [datetimeoffset]     NOT NULL,
[Subject] [nvarchar]     NOT NULL,
[TenantIds] [nvarchar]     NULL,
[TenantTags] [nvarchar]     NULL,
[Thumbprint] [nvarchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Channel](
[Id] [nvarchar]  (50)   NOT NULL,
[DataVersion] [timestamp]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[LifecycleId] [nvarchar]  (50)   NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[ProjectId] [nvarchar]  (50)   NOT NULL,
[TenantTags] [nvarchar]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[CommunityActionTemplate](
[Id] [nvarchar]  (50)   NOT NULL,
[ExternalId] [uniqueidentifier]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Configuration](
[Id] [nvarchar]  (50)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[DashboardConfiguration](
[Id] [nvarchar]  (50)   NOT NULL,
[IncludedEnvironmentIds] [nvarchar]     NOT NULL,
[IncludedProjectIds] [nvarchar]     NOT NULL,
[IncludedTenantIds] [nvarchar]     NULL,
[IncludedTenantTags] [nvarchar]     NULL,
[JSON] [nvarchar]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Deployment](
[Id] [nvarchar]  (50)   NOT NULL,
[ChannelId] [nvarchar]  (50)   NOT NULL,
[Created] [datetimeoffset]     NOT NULL,
[DeployedBy] [nvarchar]  (200)   NOT NULL,
[DeployedToMachineIds] [nvarchar]     NULL,
[EnvironmentId] [nvarchar]  (50)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[ProjectGroupId] [nvarchar]  (50)   NOT NULL,
[ProjectId] [nvarchar]  (50)   NOT NULL,
[ReleaseId] [nvarchar]  (50)   NOT NULL,
[TaskId] [nvarchar]  (50)   NULL,
[TenantId] [nvarchar]  (50)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[DeploymentEnvironment](
[Id] [nvarchar]  (50)   NOT NULL,
[DataVersion] [timestamp]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[SortOrder] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[DeploymentHistory](
[DeploymentId] [nvarchar]  (50)   NOT NULL,
[ChannelId] [nvarchar]  (50)   NULL,
[ChannelName] [nvarchar]  (200)   NULL,
[CompletedTime] [datetimeoffset]     NULL,
[Created] [datetimeoffset]     NOT NULL,
[DeployedBy] [nvarchar]  (200)   NULL,
[DeploymentName] [nvarchar]  (200)   NOT NULL,
[DurationSeconds] [int]     NULL,
[EnvironmentId] [nvarchar]  (50)   NOT NULL,
[EnvironmentName] [nvarchar]  (200)   NOT NULL,
[ProjectId] [nvarchar]  (50)   NOT NULL,
[ProjectName] [nvarchar]  (200)   NOT NULL,
[ProjectSlug] [nvarchar]  (210)   NOT NULL,
[QueueTime] [datetimeoffset]     NOT NULL,
[ReleaseId] [nvarchar]  (150)   NOT NULL,
[ReleaseVersion] [nvarchar]  (100)   NOT NULL,
[StartTime] [datetimeoffset]     NULL,
[TaskId] [nvarchar]  (50)   NOT NULL,
[TaskState] [nvarchar]  (50)   NOT NULL,
[TenantId] [nvarchar]  (50)   NULL,
[TenantName] [nvarchar]  (200)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[DeploymentProcess](
[Id] [nvarchar]  (150)   NOT NULL,
[IsFrozen] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[OwnerId] [nvarchar]  (150)   NOT NULL,
[RelatedDocumentIds] [nvarchar]     NULL,
[Version] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[DeploymentRelatedMachine](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[DeploymentId] [nvarchar]  (50)   NOT NULL,
[MachineId] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Event](
[Id] [nvarchar]  (50)   NOT NULL,
[AutoId] [bigint]     NOT NULL,
[Category] [nvarchar]  (50)   NOT NULL,
[EnvironmentId] [nvarchar]  (50)   NULL,
[JSON] [nvarchar]     NOT NULL,
[Message] [nvarchar]     NOT NULL,
[Occurred] [datetimeoffset]     NOT NULL,
[ProjectId] [nvarchar]  (50)   NULL,
[RelatedDocumentIds] [nvarchar]     NOT NULL,
[TenantId] [nvarchar]  (50)   NULL,
[UserId] [nvarchar]  (50)   NOT NULL,
[Username] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[EventRelatedDocument](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[EventId] [nvarchar]  (50)   NOT NULL,
[RelatedDocumentId] [nvarchar]  (250)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ExtensionConfiguration](
[Id] [nvarchar]  (50)   NOT NULL,
[ExtensionAuthor] [nvarchar]  (1000)   NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (1000)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Feed](
[Id] [nvarchar]  (210)   NOT NULL,
[FeedType] [nvarchar]  (50)   NOT NULL,
[FeedUri] [nvarchar]  (512)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Interruption](
[Id] [nvarchar]  (50)   NOT NULL,
[Created] [datetimeoffset]     NOT NULL,
[EnvironmentId] [nvarchar]  (50)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[ProjectId] [nvarchar]  (50)   NOT NULL,
[RelatedDocumentIds] [nvarchar]     NOT NULL,
[ResponsibleTeamIds] [nvarchar]     NOT NULL,
[Status] [nvarchar]  (50)   NOT NULL,
[TaskId] [nvarchar]  (50)   NOT NULL,
[TenantId] [nvarchar]  (50)   NULL,
[Title] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Invitation](
[Id] [nvarchar]  (50)   NOT NULL,
[InvitationCode] [nvarchar]  (200)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[KeyAllocation](
[CollectionName] [nvarchar]  (50)   NOT NULL,
[Allocated] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[LibraryVariableSet](
[Id] [nvarchar]  (50)   NOT NULL,
[ContentType] [nvarchar]  (50)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[VariableSetId] [nvarchar]  (150)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Lifecycle](
[Id] [nvarchar]  (50)   NOT NULL,
[DataVersion] [timestamp]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Machine](
[Id] [nvarchar]  (50)   NOT NULL,
[CommunicationStyle] [nvarchar]  (50)   NOT NULL,
[EnvironmentIds] [nvarchar]     NOT NULL,
[Fingerprint] [nvarchar]  (50)   NULL,
[IsDisabled] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[MachinePolicyId] [nvarchar]  (50)   NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[RelatedDocumentIds] [nvarchar]     NULL,
[Roles] [nvarchar]     NOT NULL,
[TenantIds] [nvarchar]     NULL,
[TenantTags] [nvarchar]     NULL,
[Thumbprint] [nvarchar]  (50)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[MachinePolicy](
[Id] [nvarchar]  (50)   NOT NULL,
[IsDefault] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Mutex](
[Id] [nvarchar]  (450)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[NuGetPackage](
[Id] [nvarchar]  (450)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[PackageId] [nvarchar]  (100)   NOT NULL,
[Version] [nvarchar]  (349)   NOT NULL,
[VersionBuild] [int]     NOT NULL,
[VersionMajor] [int]     NOT NULL,
[VersionMinor] [int]     NOT NULL,
[VersionRevision] [int]     NOT NULL,
[VersionSpecial] [nvarchar]  (250)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[OctopusServerInstallationHistory](
[Id] [nvarchar]  (50)   NOT NULL,
[Installed] [datetimeoffset]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Node] [nvarchar]  (200)   NULL,
[Version] [nvarchar]  (200)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[OctopusServerNode](
[Id] [nvarchar]  (250)   NOT NULL,
[IsInMaintenanceMode] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[LastSeen] [datetimeoffset]     NOT NULL,
[MaxConcurrentTasks] [int]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[Rank] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Project](
[Id] [nvarchar]  (50)   NOT NULL,
[AutoCreateRelease] [bit]     NOT NULL,
[DataVersion] [timestamp]     NOT NULL,
[DeploymentProcessId] [nvarchar]  (50)   NULL,
[DiscreteChannelRelease] [bit]     NOT NULL,
[IncludedLibraryVariableSetIds] [nvarchar]     NULL,
[IsDisabled] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[LifecycleId] [nvarchar]  (50)   NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[ProjectGroupId] [nvarchar]  (50)   NOT NULL,
[Slug] [nvarchar]  (210)   NOT NULL,
[VariableSetId] [nvarchar]  (150)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ProjectGroup](
[Id] [nvarchar]  (50)   NOT NULL,
[DataVersion] [timestamp]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ProjectTrigger](
[Id] [nvarchar]  (50)   NOT NULL,
[IsDisabled] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[ProjectId] [nvarchar]  (50)   NOT NULL,
[TriggerType] [nvarchar]  (50)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Proxy](
[Id] [nvarchar]  (50)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Release](
[Id] [nvarchar]  (150)   NOT NULL,
[Assembled] [datetimeoffset]     NOT NULL,
[ChannelId] [nvarchar]  (50)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[ProjectDeploymentProcessSnapshotId] [nvarchar]  (150)   NOT NULL,
[ProjectId] [nvarchar]  (150)   NOT NULL,
[ProjectVariableSetSnapshotId] [nvarchar]  (150)   NOT NULL,
[Version] [nvarchar]  (100)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[SchemaVersions](
[Id] [int]   IDENTITY(1,1)  NOT NULL,
[Applied] [datetime]     NOT NULL,
[ScriptName] [nvarchar]  (255)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[ServerTask](
[Id] [nvarchar]  (50)   NOT NULL,
[CompletedTime] [datetimeoffset]     NULL,
[ConcurrencyTag] [nvarchar]  (100)   NULL,
[Description] [nvarchar]     NOT NULL,
[DurationSeconds] [int]     NOT NULL,
[EnvironmentId] [nvarchar]  (50)   NULL,
[ErrorMessage] [nvarchar]     NULL,
[HasPendingInterruptions] [bit]     NOT NULL,
[HasWarningsOrErrors] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (50)   NOT NULL,
[ProjectId] [nvarchar]  (50)   NULL,
[QueueTime] [datetimeoffset]     NOT NULL,
[ServerNodeId] [nvarchar]  (250)   NULL,
[StartTime] [datetimeoffset]     NULL,
[State] [nvarchar]  (50)   NOT NULL,
[TenantId] [nvarchar]  (50)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Subscription](
[Id] [nvarchar]  (50)   NOT NULL,
[IsDisabled] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[Type] [nvarchar]  (50)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TagSet](
[Id] [nvarchar]  (50)   NOT NULL,
[DataVersion] [timestamp]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[SortOrder] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Team](
[Id] [nvarchar]  (50)   NOT NULL,
[EnvironmentIds] [nvarchar]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[MemberUserIds] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[ProjectGroupIds] [nvarchar]     NULL,
[ProjectIds] [nvarchar]     NOT NULL,
[TenantIds] [nvarchar]     NULL,
[TenantTags] [nvarchar]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Tenant](
[Id] [nvarchar]  (50)   NOT NULL,
[DataVersion] [timestamp]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[ProjectIds] [nvarchar]     NOT NULL,
[TenantTags] [nvarchar]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TenantVariable](
[Id] [nvarchar]  (50)   NOT NULL,
[EnvironmentId] [nvarchar]  (50)   NULL,
[JSON] [nvarchar]     NOT NULL,
[OwnerId] [nvarchar]  (50)   NOT NULL,
[RelatedDocumentId] [nvarchar]     NULL,
[TenantId] [nvarchar]  (50)   NOT NULL,
[VariableTemplateId] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[User](
[Id] [nvarchar]  (50)   NOT NULL,
[DisplayName] [nvarchar]  (200)   NULL,
[EmailAddress] [nvarchar]  (400)   NULL,
[ExternalId] [nvarchar]  (400)   NULL,
[ExternalIdentifiers] [nvarchar]     NULL,
[IdentificationToken] [uniqueidentifier]     NOT NULL,
[IsActive] [bit]     NOT NULL,
[IsService] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Username] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[UserRole](
[Id] [nvarchar]  (50)   NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[VariableSet](
[Id] [nvarchar]  (150)   NOT NULL,
[IsFrozen] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[OwnerId] [nvarchar]  (150)   NOT NULL,
[RelatedDocumentIds] [nvarchar]     NULL,
[Version] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Worker](
[Id] [nvarchar]  (50)   NOT NULL,
[CommunicationStyle] [nvarchar]  (50)   NOT NULL,
[Fingerprint] [nvarchar]  (50)   NULL,
[IsDisabled] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[MachinePolicyId] [nvarchar]  (50)   NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[RelatedDocumentIds] [nvarchar]     NULL,
[Thumbprint] [nvarchar]  (50)   NULL,
[WorkerPoolIds] [nvarchar]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[WorkerPool](
[Id] [nvarchar]  (50)   NOT NULL,
[IsDefault] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[SortOrder] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[WorkerTaskLease](
[Id] [nvarchar]  (50)   NOT NULL,
[Exclusive] [bit]     NOT NULL,
[JSON] [nvarchar]     NOT NULL,
[Name] [nvarchar]  (200)   NOT NULL,
[TaskId] [nvarchar]  (50)   NOT NULL,
[WorkerId] [nvarchar]  (50)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Account]
ADD CONSTRAINT[PK_Account_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_AccountUniqueName] ON[dbo].[Account]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ActionTemplate]
ADD CONSTRAINT[PK_ActionTemplate_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ActionTemplateUniqueName] ON[dbo].[ActionTemplate]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ActionTemplateVersion]
ADD CONSTRAINT[PK_ActionTemplateVersion_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ActionTemplateVersionUniqueNameVersion] ON[dbo].[ActionTemplateVersion]
(
[Name] ASC
,[Version] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ActionTemplateVersion_LatestActionTemplateId] ON[dbo].[ActionTemplateVersion]
(
[LatestActionTemplateId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ApiKey]
ADD CONSTRAINT[PK_ApiKey_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ApiKeyUnique] ON[dbo].[ApiKey]
(
[ApiKeyHashed] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Artifact]
ADD CONSTRAINT[PK_Artifact_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Artifact_TenantId] ON[dbo].[Artifact]
(
[TenantId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Certificate]
ADD CONSTRAINT[PK_Certificate_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Certificate_Created] ON[dbo].[Certificate]
(
[Created] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Certificate_DataVersion] ON[dbo].[Certificate]
(
[DataVersion] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Certificate_NotAfter] ON[dbo].[Certificate]
(
[NotAfter] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Certificate_Thumbprint] ON[dbo].[Certificate]
(
[Thumbprint] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Channel]
ADD CONSTRAINT[PK_Channel_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ChannelUniqueNamePerProject] ON[dbo].[Channel]
(
[Name] ASC
,[ProjectId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Channel_DataVersion] ON[dbo].[Channel]
(
[DataVersion] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Channel_ProjectId] ON[dbo].[Channel]
(
[ProjectId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[CommunityActionTemplate]
ADD CONSTRAINT[PK_CommunityActionTemplate_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_CommunityActionTemplateExternalId] ON[dbo].[CommunityActionTemplate]
(
[ExternalId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_CommunityActionTemplateName] ON[dbo].[CommunityActionTemplate]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Configuration]
ADD CONSTRAINT[PK_Configuration_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[DashboardConfiguration]
ADD CONSTRAINT[PK_DashboardConfiguration_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Deployment]
ADD CONSTRAINT[PK_Deployment_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Deployment_ChannelId] ON[dbo].[Deployment]
(
[ChannelId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Deployment_Index] ON[dbo].[Deployment]
(
[Id] ASC
,[ProjectId] ASC
,[ProjectGroupId] ASC
,[Name] ASC
,[Created] ASC
,[ReleaseId] ASC
,[TaskId] ASC
,[EnvironmentId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Deployment_TenantId] ON[dbo].[Deployment]
(
[TenantId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[DeploymentEnvironment]
ADD CONSTRAINT[PK_DeploymentEnvironment_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_DeploymentEnvironmentNameUnique] ON[dbo].[DeploymentEnvironment]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_DeploymentEnvironment_DataVersion] ON[dbo].[DeploymentEnvironment]
(
[DataVersion] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[DeploymentHistory]
ADD CONSTRAINT[PK_DeploymentHistory_DeploymentId] PRIMARY KEY CLUSTERED
(
[DeploymentId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_DeploymentHistory_Created] ON[dbo].[DeploymentHistory]
(
[Created] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[DeploymentProcess]
ADD CONSTRAINT[PK_DeploymentProcess_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[DeploymentRelatedMachine]
ADD CONSTRAINT[PK_DeploymentRelatedMachine] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_DeploymentRelatedMachine_Deployment] ON[dbo].[DeploymentRelatedMachine]
(
[DeploymentId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_DeploymentRelatedMachine_Machine] ON[dbo].[DeploymentRelatedMachine]
(
[MachineId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Event]
ADD CONSTRAINT[PK_Event_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Event_AutoId] ON[dbo].[Event]
(
[AutoId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Event_Category_AutoId] ON[dbo].[Event]
(
[Id] ASC
,[RelatedDocumentIds] ASC
,[Occurred] ASC
,[Category] ASC
,[AutoId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Event_CommonSearch] ON[dbo].[Event]
(
[Id] ASC
,[RelatedDocumentIds] ASC
,[ProjectId] ASC
,[EnvironmentId] ASC
,[Category] ASC
,[UserId] ASC
,[Occurred] ASC
,[TenantId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Event_Occurred] ON[dbo].[Event]
(
[Id] ASC
,[Occurred] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[EventRelatedDocument]
ADD CONSTRAINT[PK_EventRelatedDocument] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventRelatedDocument_EventId] ON[dbo].[EventRelatedDocument]
(
[EventId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventRelatedDocument_RelatedDocumentId] ON[dbo].[EventRelatedDocument]
(
[EventId] ASC
,[RelatedDocumentId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ExtensionConfiguration]
ADD CONSTRAINT[PK_ExtensionConfiguration_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Feed]
ADD CONSTRAINT[PK_Feed_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_FeedNameUnique] ON[dbo].[Feed]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Interruption]
ADD CONSTRAINT[PK_Interruption_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Interruption_TenantId] ON[dbo].[Interruption]
(
[TenantId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Invitation]
ADD CONSTRAINT[PK_Invitation_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[KeyAllocation]
ADD CONSTRAINT[PK_KeyAllocation_CollectionName] PRIMARY KEY CLUSTERED
(
[CollectionName] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[LibraryVariableSet]
ADD CONSTRAINT[PK_LibraryVariableSet_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_LibraryVariableSetNameUnique] ON[dbo].[LibraryVariableSet]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Lifecycle]
ADD CONSTRAINT[PK_Lifecycle_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_LifecycleNameUnique] ON[dbo].[Lifecycle]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Lifecycle_DataVersion] ON[dbo].[Lifecycle]
(
[DataVersion] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Machine]
ADD CONSTRAINT[PK_Machine_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_MachineNameUnique] ON[dbo].[Machine]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Machine_MachinePolicy] ON[dbo].[Machine]
(
[MachinePolicyId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[MachinePolicy]
ADD CONSTRAINT[PK_MachinePolicy_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_MachinePolicy] ON[dbo].[MachinePolicy]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Mutex]
ADD CONSTRAINT[PK_Mutex_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[NuGetPackage]
ADD CONSTRAINT[PK_NuGetPackage_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[OctopusServerNode]
ADD CONSTRAINT[PK_OctopusServerNode_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Project]
ADD CONSTRAINT[PK_Project_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ProjectNameUnique] ON[dbo].[Project]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ProjectSlugUnique] ON[dbo].[Project]
(
[Slug] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Project_DataVersion] ON[dbo].[Project]
(
[DataVersion] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Project_DiscreteChannelRelease] ON[dbo].[Project]
(
[DiscreteChannelRelease] ASC
,[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ProjectGroup]
ADD CONSTRAINT[PK_ProjectGroup_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ProjectGroupNameUnique] ON[dbo].[ProjectGroup]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ProjectGroup_DataVersion] ON[dbo].[ProjectGroup]
(
[DataVersion] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ProjectTrigger]
ADD CONSTRAINT[PK_ProjectTrigger_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ProjectTriggerNameUnique] ON[dbo].[ProjectTrigger]
(
[ProjectId] ASC
,[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ProjectTrigger_Project] ON[dbo].[ProjectTrigger]
(
[ProjectId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Proxy]
ADD CONSTRAINT[PK_Proxy_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ProxyNameUnique] ON[dbo].[Proxy]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Release]
ADD CONSTRAINT[PK_Release_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_ReleaseVersionUnique] ON[dbo].[Release]
(
[Version] ASC
,[ProjectId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Release_Assembled] ON[dbo].[Release]
(
[Id] ASC
,[Assembled] DESC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Release_ProjectDeploymentProcessSnapshotId] ON[dbo].[Release]
(
[ProjectDeploymentProcessSnapshotId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Release_ProjectId_ChannelId_Assembled] ON[dbo].[Release]
(
[Id] ASC
,[Version] ASC
,[ProjectVariableSetSnapshotId] ASC
,[ProjectDeploymentProcessSnapshotId] ASC
,[JSON] ASC
,[ProjectId] ASC
,[ChannelId] ASC
,[Assembled] DESC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Release_ProjectId_Version_Assembled] ON[dbo].[Release]
(
[Id] ASC
,[ChannelId] ASC
,[ProjectVariableSetSnapshotId] ASC
,[ProjectDeploymentProcessSnapshotId] ASC
,[JSON] ASC
,[ProjectId] ASC
,[Version] ASC
,[Assembled] DESC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[SchemaVersions]
ADD CONSTRAINT[PK_SchemaVersions_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[ServerTask]
ADD CONSTRAINT[PK_ServerTask_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ServerTask_Common] ON[dbo].[ServerTask]
(
[Description] ASC
,[QueueTime] ASC
,[StartTime] ASC
,[CompletedTime] ASC
,[ErrorMessage] ASC
,[ConcurrencyTag] ASC
,[HasPendingInterruptions] ASC
,[HasWarningsOrErrors] ASC
,[DurationSeconds] ASC
,[JSON] ASC
,[State] ASC
,[Name] ASC
,[ProjectId] ASC
,[EnvironmentId] ASC
,[TenantId] ASC
,[ServerNodeId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ServerTask_TaskQueue_GetActiveConcurrencyTags] ON[dbo].[ServerTask]
(
[State] ASC
,[ConcurrencyTag] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_ServerTask_TaskQueue_PopTask] ON[dbo].[ServerTask]
(
[Name] ASC
,[Description] ASC
,[StartTime] ASC
,[CompletedTime] ASC
,[ErrorMessage] ASC
,[HasWarningsOrErrors] ASC
,[ProjectId] ASC
,[EnvironmentId] ASC
,[TenantId] ASC
,[DurationSeconds] ASC
,[JSON] ASC
,[QueueTime] ASC
,[State] ASC
,[ConcurrencyTag] ASC
,[HasPendingInterruptions] ASC
,[ServerNodeId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Subscription]
ADD CONSTRAINT[PK_Subscription_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_SubscriptionNameUnique] ON[dbo].[Subscription]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TagSet]
ADD CONSTRAINT[PK_TagSet_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_TagSetName] ON[dbo].[TagSet]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TagSet_DataVersion] ON[dbo].[TagSet]
(
[DataVersion] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Team]
ADD CONSTRAINT[PK_Team_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_TeamNameUnique] ON[dbo].[Team]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Tenant]
ADD CONSTRAINT[PK_Tenant_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_TenantName] ON[dbo].[Tenant]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Tenant_DataVersion] ON[dbo].[Tenant]
(
[DataVersion] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TenantVariable]
ADD CONSTRAINT[PK_TenantVariable_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_TenantVariable] ON[dbo].[TenantVariable]
(
[TenantId] ASC
,[OwnerId] ASC
,[EnvironmentId] ASC
,[VariableTemplateId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TenantVariable_TenantId] ON[dbo].[TenantVariable]
(
[TenantId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[User]
ADD CONSTRAINT[PK_User_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_UserUsernameUnique] ON[dbo].[User]
(
[Username] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_User_DisplayName] ON[dbo].[User]
(
[DisplayName] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_User_EmailAddress] ON[dbo].[User]
(
[EmailAddress] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_User_ExternalId] ON[dbo].[User]
(
[ExternalId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[UserRole]
ADD CONSTRAINT[PK_UserRole_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_UserRoleNameUnique] ON[dbo].[UserRole]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[VariableSet]
ADD CONSTRAINT[PK_VariableSet_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Worker]
ADD CONSTRAINT[PK_Worker_Id] PRIMARY KEY NONCLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_WorkerNameUnique] ON[dbo].[Worker]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  CLUSTERED INDEX[IX_Worker_MachinePolicy] ON[dbo].[Worker]
(
[MachinePolicyId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[WorkerPool]
ADD CONSTRAINT[PK_WorkerPool_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ_WorkerPoolNameUnique] ON[dbo].[WorkerPool]
(
[Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[WorkerTaskLease]
ADD CONSTRAINT[PK_WorkerTaskLease_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

ALTER TABLE[dbo].[MachinePolicy]
ADD CONSTRAINT[DF__MachinePo__IsDef__7C4F7684]  DEFAULT((0)) FOR[IsDefault]
GO

ALTER TABLE[dbo].[OctopusServerNode]
ADD CONSTRAINT[DF_OctopusServerNode_IsMaintMode]  DEFAULT((0)) FOR[IsInMaintenanceMode]
GO

ALTER TABLE[dbo].[OctopusServerNode]
ADD CONSTRAINT[DF_OctopusServerNode_MaxConTasks]  DEFAULT((5)) FOR[MaxConcurrentTasks]
GO

ALTER TABLE[dbo].[Project]
ADD CONSTRAINT[DF__Project__Discret__25518C17]  DEFAULT((0)) FOR[DiscreteChannelRelease]
GO

ALTER TABLE[dbo].[ProjectTrigger]
ADD CONSTRAINT[DF__ProjectTr__IsDis__4E53A1AA]  DEFAULT((0)) FOR[IsDisabled]
GO

ALTER TABLE[dbo].[Subscription]
ADD CONSTRAINT[DF__Subscript__IsDis__18EBB532]  DEFAULT((0)) FOR[IsDisabled]
GO

ALTER TABLE[dbo].[WorkerTaskLease]
ADD CONSTRAINT[DF__WorkerTas__Exclu__57DD0BE4]  DEFAULT((0)) FOR[Exclusive]
GO


ALTER TABLE[dbo].[DeploymentRelatedMachine]  WITH CHECK ADD  CONSTRAINT[FK_DeploymentRelatedMachine_DeploymentId] FOREIGN KEY([DeploymentId])
REFERENCES[dbo].[Deployment]([Id])
GO
ALTER TABLE[dbo].[DeploymentRelatedMachine] CHECK CONSTRAINT[FK_DeploymentRelatedMachine_DeploymentId]
GO
ALTER TABLE[dbo].[EventRelatedDocument]  WITH CHECK ADD  CONSTRAINT[FK_EventRelatedDocument_EventId] FOREIGN KEY([EventId])
REFERENCES[dbo].[Event]([Id])
GO
ALTER TABLE[dbo].[EventRelatedDocument] CHECK CONSTRAINT[FK_EventRelatedDocument_EventId]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
          
		}
	}
};