using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.DataAccess.Migrations
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

--IF (OBJECT_ID('dbo.FK_Admin_tenantId_Tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Admin] DROP CONSTRAINT [FK_Admin_tenantId_Tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Admin_userId_User_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Admin] DROP CONSTRAINT [FK_Admin_userId_User_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Event_eventStatusId_EventStatus_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_eventStatusId_EventStatus_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_Event_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Event] DROP CONSTRAINT [fk_Event_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_EventStatus_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventStatus] DROP CONSTRAINT [fk_EventStatus_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_EventStudent_eventId_Event_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventStudent] DROP CONSTRAINT [FK_EventStudent_eventId_Event_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_EventStudent_studentId_Student_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventStudent] DROP CONSTRAINT [FK_EventStudent_studentId_Student_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_EventStudent_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventStudent] DROP CONSTRAINT [fk_EventStudent_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_EventTeacher_teacherId_Teacher_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventTeacher] DROP CONSTRAINT [FK_EventTeacher_teacherId_Teacher_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_EventTeacher_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventTeacher] DROP CONSTRAINT [fk_EventTeacher_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_EventTeacher_eventId_Event_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventTeacher] DROP CONSTRAINT [FK_EventTeacher_eventId_Event_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_Family_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Family] DROP CONSTRAINT [fk_Family_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Rate_teacherId_Teacher_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Rate] DROP CONSTRAINT [FK_Rate_teacherId_Teacher_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Rate_teacherSkillId_TeacherSkill_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Rate] DROP CONSTRAINT [FK_Rate_teacherSkillId_TeacherSkill_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_Rate_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Rate] DROP CONSTRAINT [fk_Rate_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_Space_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Space] DROP CONSTRAINT [fk_Space_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_SpaceFeature_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[SpaceFeature] DROP CONSTRAINT [fk_SpaceFeature_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[SpaceSpaceFeature] DROP CONSTRAINT [FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_SpaceSpaceFeature_spaceId_Space_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[SpaceSpaceFeature] DROP CONSTRAINT [FK_SpaceSpaceFeature_spaceId_Space_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_SpaceSpaceFeature_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[SpaceSpaceFeature] DROP CONSTRAINT [fk_SpaceSpaceFeature_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Student_familyId_Family_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Student] DROP CONSTRAINT [FK_Student_familyId_Family_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_Student_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Student] DROP CONSTRAINT [fk_Student_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Student_userId_User_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Student] DROP CONSTRAINT [FK_Student_userId_User_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_Studio_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Studio] DROP CONSTRAINT [fk_Studio_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_Teacher_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Teacher] DROP CONSTRAINT [fk_Teacher_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Teacher_userId_User_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Teacher] DROP CONSTRAINT [FK_Teacher_userId_User_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_TeacherSkill_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[TeacherSkill] DROP CONSTRAINT [fk_TeacherSkill_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_TeacherTeacherSkill_teacherId_Teacher_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[TeacherTeacherSkill] DROP CONSTRAINT [FK_TeacherTeacherSkill_teacherId_Teacher_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[TeacherTeacherSkill] DROP CONSTRAINT [FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_TeacherTeacherSkill_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[TeacherTeacherSkill] DROP CONSTRAINT [fk_TeacherTeacherSkill_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_User_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[User] DROP CONSTRAINT [fk_User_tenantId_tenant_id]
--END
--GO

--IF OBJECT_ID('dbo.Admin', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Admin]
--END
--GO
--IF OBJECT_ID('dbo.Event', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Event]
--END
--GO
--IF OBJECT_ID('dbo.EventStatus', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[EventStatus]
--END
--GO
--IF OBJECT_ID('dbo.EventStudent', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[EventStudent]
--END
--GO
--IF OBJECT_ID('dbo.EventTeacher', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[EventTeacher]
--END
--GO
--IF OBJECT_ID('dbo.Family', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Family]
--END
--GO
--IF OBJECT_ID('dbo.Rate', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Rate]
--END
--GO
--IF OBJECT_ID('dbo.Space', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Space]
--END
--GO
--IF OBJECT_ID('dbo.SpaceFeature', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[SpaceFeature]
--END
--GO
--IF OBJECT_ID('dbo.SpaceSpaceFeature', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[SpaceSpaceFeature]
--END
--GO
--IF OBJECT_ID('dbo.Student', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Student]
--END
--GO
--IF OBJECT_ID('dbo.Studio', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Studio]
--END
--GO
--IF OBJECT_ID('dbo.Teacher', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Teacher]
--END
--GO
--IF OBJECT_ID('dbo.TeacherSkill', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[TeacherSkill]
--END
--GO
--IF OBJECT_ID('dbo.TeacherTeacherSkill', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[TeacherTeacherSkill]
--END
--GO
--IF OBJECT_ID('dbo.Tenant', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Tenant]
--END
--GO
--IF OBJECT_ID('dbo.User', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[User]
--END
--GO

CREATE TABLE [dbo].[Admin](
[tenantId] [int]     NOT NULL,
[birthday] [date]     NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (128)   NULL,
[userId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Event](
[tenantId] [int]     NOT NULL,
[actualEndDate] [datetime]     NULL,
[actualStartDate] [datetime]     NULL,
[billAmount] [money]     NULL,
[eventStatusId] [int]     NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[scheduledEndDate] [datetime]     NULL,
[scheduledStartDate] [datetime]     NULL,
[studentNotes] [text]     NULL,
[teacherNotes] [text]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[EventStatus](
[tenantId] [int]     NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[EventStudent](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[eventId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[studentId] [int]     NOT NULL,
[tenantId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[EventTeacher](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[eventId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[teacherId] [int]     NOT NULL,
[tenantId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Family](
[tenantId] [int]     NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[notes] [text]     NULL,
[primaryContactEmail] [varchar]  (128)   NULL,
[primaryContactFirstName] [varchar]  (128)   NULL,
[primaryContactLastName] [varchar]  (128)   NULL,
[primaryContactPhone] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Rate](
[tenantId] [int]     NOT NULL,
[amountPerMinute] [money]     NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[teacherId] [int]     NOT NULL,
[teacherSkillId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Space](
[tenantId] [int]     NOT NULL,
[description] [varchar]  (128)   NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[SpaceFeature](
[tenantId] [int]     NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[SpaceSpaceFeature](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[spaceFeatureId] [int]     NOT NULL,
[spaceId] [int]     NOT NULL,
[tenantId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Student](
[tenantId] [int]     NOT NULL,
[birthday] [date]     NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[emailRemindersEnabled] [bit]     NOT NULL,
[familyId] [int]     NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isAdult] [bit]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (128)   NOT NULL,
[smsRemindersEnabled] [bit]     NOT NULL,
[userId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Studio](
[tenantId] [int]     NOT NULL,
[address1] [varchar]  (128)   NOT NULL,
[address2] [varchar]  (128)   NOT NULL,
[city] [varchar]  (128)   NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[province] [varchar]  (90)   NOT NULL,
[website] [varchar]  (128)   NOT NULL,
[zip] [varchar]  (128)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Teacher](
[tenantId] [int]     NOT NULL,
[birthday] [date]     NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (128)   NULL,
[userId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TeacherSkill](
[tenantId] [int]     NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TeacherTeacherSkill](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[teacherId] [int]     NOT NULL,
[teacherSkillId] [int]     NOT NULL,
[tenantId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Tenant](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[User](
[tenantId] [int]     NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[password] [varchar]  (128)   NOT NULL,
[username] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Admin]
ADD CONSTRAINT[PK_Admin] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Admin_userId] ON[dbo].[Admin]
(
[tenantId] ASC,
[userId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Event]
ADD CONSTRAINT[PK_Event] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Event_eventStatusId] ON[dbo].[Event]
(
[tenantId] ASC,
[eventStatusId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[EventStatus]
ADD CONSTRAINT[PK_EventStatus] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventStudent_eventId] ON[dbo].[EventStudent]
(
[tenantId] ASC,
[eventId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventStudent_studentId] ON[dbo].[EventStudent]
(
[tenantId] ASC,
[studentId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[EventStudent]
ADD CONSTRAINT[PK_EventStudent] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventTeacher_eventId] ON[dbo].[EventTeacher]
(
[tenantId] ASC,
[eventId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventTeacher_teacherId] ON[dbo].[EventTeacher]
(
[tenantId] ASC,
[teacherId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[EventTeacher]
ADD CONSTRAINT[PK_EventTeacher] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Family]
ADD CONSTRAINT[PK_Family] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Rate]
ADD CONSTRAINT[PK_Rate] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Rate_teacherId] ON[dbo].[Rate]
(
[tenantId] ASC,
[teacherId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Rate_teacherSkillId] ON[dbo].[Rate]
(
[tenantId] ASC,
[teacherSkillId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Space]
ADD CONSTRAINT[PK_Space] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[SpaceFeature]
ADD CONSTRAINT[PK_SpaceFeature] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_SpaceSpaceFeature_spaceFeatureId] ON[dbo].[SpaceSpaceFeature]
(
[tenantId] ASC,
[spaceFeatureId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_SpaceSpaceFeature_spaceId] ON[dbo].[SpaceSpaceFeature]
(
[tenantId] ASC,
[spaceId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]
ADD CONSTRAINT[PK_SpaceSpaceFeature] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Student]
ADD CONSTRAINT[PK_Student] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Student_familyId] ON[dbo].[Student]
(
[tenantId] ASC,
[familyId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Student_userId] ON[dbo].[Student]
(
[tenantId] ASC,
[userId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Studio]
ADD CONSTRAINT[PK_Studio] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Teacher]
ADD CONSTRAINT[PK_Teacher] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Teacher_userId] ON[dbo].[Teacher]
(
[tenantId] ASC,
[userId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TeacherSkill]
ADD CONSTRAINT[PK_TeacherSkill] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TeacherTeacherSkill_teacherId] ON[dbo].[TeacherTeacherSkill]
(
[tenantId] ASC,
[teacherId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TeacherTeacherSkill_teacherSkillId] ON[dbo].[TeacherTeacherSkill]
(
[tenantId] ASC,
[teacherSkillId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]
ADD CONSTRAINT[PK_TeacherTeacherSkill] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Tenant]
ADD CONSTRAINT[PK_Tenant] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[User]
ADD CONSTRAINT[PK_User] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[Admin]  WITH CHECK ADD  CONSTRAINT[FK_Admin_tenantId_Tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Admin] CHECK CONSTRAINT[FK_Admin_tenantId_Tenant_id]
GO
ALTER TABLE[dbo].[Admin]  WITH CHECK ADD  CONSTRAINT[FK_Admin_userId_User_id] FOREIGN KEY([tenantId],[userId])
REFERENCES[dbo].[User]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Admin] CHECK CONSTRAINT[FK_Admin_userId_User_id]
GO
ALTER TABLE[dbo].[Event]  WITH CHECK ADD  CONSTRAINT[FK_Event_eventStatusId_EventStatus_id] FOREIGN KEY([tenantId],[eventStatusId])
REFERENCES[dbo].[EventStatus]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Event] CHECK CONSTRAINT[FK_Event_eventStatusId_EventStatus_id]
GO
ALTER TABLE[dbo].[Event]  WITH CHECK ADD  CONSTRAINT[fk_Event_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Event] CHECK CONSTRAINT[fk_Event_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[EventStatus]  WITH CHECK ADD  CONSTRAINT[fk_EventStatus_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventStatus] CHECK CONSTRAINT[fk_EventStatus_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[EventStudent]  WITH CHECK ADD  CONSTRAINT[FK_EventStudent_eventId_Event_id] FOREIGN KEY([tenantId],[eventId])
REFERENCES[dbo].[Event]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventStudent] CHECK CONSTRAINT[FK_EventStudent_eventId_Event_id]
GO
ALTER TABLE[dbo].[EventStudent]  WITH CHECK ADD  CONSTRAINT[FK_EventStudent_studentId_Student_id] FOREIGN KEY([tenantId],[studentId])
REFERENCES[dbo].[Student]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventStudent] CHECK CONSTRAINT[FK_EventStudent_studentId_Student_id]
GO
ALTER TABLE[dbo].[EventStudent]  WITH CHECK ADD  CONSTRAINT[fk_EventStudent_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventStudent] CHECK CONSTRAINT[fk_EventStudent_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[EventTeacher]  WITH CHECK ADD  CONSTRAINT[FK_EventTeacher_teacherId_Teacher_id] FOREIGN KEY([tenantId],[teacherId])
REFERENCES[dbo].[Teacher]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventTeacher] CHECK CONSTRAINT[FK_EventTeacher_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[EventTeacher]  WITH CHECK ADD  CONSTRAINT[fk_EventTeacher_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventTeacher] CHECK CONSTRAINT[fk_EventTeacher_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[EventTeacher]  WITH CHECK ADD  CONSTRAINT[FK_EventTeacher_eventId_Event_id] FOREIGN KEY([tenantId],[eventId])
REFERENCES[dbo].[Event]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventTeacher] CHECK CONSTRAINT[FK_EventTeacher_eventId_Event_id]
GO
ALTER TABLE[dbo].[Family]  WITH CHECK ADD  CONSTRAINT[fk_Family_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Family] CHECK CONSTRAINT[fk_Family_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[FK_Rate_teacherId_Teacher_id] FOREIGN KEY([tenantId],[teacherId])
REFERENCES[dbo].[Teacher]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[FK_Rate_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[FK_Rate_teacherSkillId_TeacherSkill_id] FOREIGN KEY([tenantId],[teacherSkillId])
REFERENCES[dbo].[TeacherSkill]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[FK_Rate_teacherSkillId_TeacherSkill_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[fk_Rate_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[fk_Rate_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Space]  WITH CHECK ADD  CONSTRAINT[fk_Space_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Space] CHECK CONSTRAINT[fk_Space_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[SpaceFeature]  WITH CHECK ADD  CONSTRAINT[fk_SpaceFeature_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[SpaceFeature] CHECK CONSTRAINT[fk_SpaceFeature_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]  WITH CHECK ADD  CONSTRAINT[FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id] FOREIGN KEY([tenantId],[spaceFeatureId])
REFERENCES[dbo].[SpaceFeature]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[SpaceSpaceFeature] CHECK CONSTRAINT[FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id]
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]  WITH CHECK ADD  CONSTRAINT[FK_SpaceSpaceFeature_spaceId_Space_id] FOREIGN KEY([tenantId],[spaceId])
REFERENCES[dbo].[Space]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[SpaceSpaceFeature] CHECK CONSTRAINT[FK_SpaceSpaceFeature_spaceId_Space_id]
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]  WITH CHECK ADD  CONSTRAINT[fk_SpaceSpaceFeature_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[SpaceSpaceFeature] CHECK CONSTRAINT[fk_SpaceSpaceFeature_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[FK_Student_familyId_Family_id] FOREIGN KEY([tenantId],[familyId])
REFERENCES[dbo].[Family]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[FK_Student_familyId_Family_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[fk_Student_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[fk_Student_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[FK_Student_userId_User_id] FOREIGN KEY([tenantId],[userId])
REFERENCES[dbo].[User]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[FK_Student_userId_User_id]
GO
ALTER TABLE[dbo].[Studio]  WITH CHECK ADD  CONSTRAINT[fk_Studio_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Studio] CHECK CONSTRAINT[fk_Studio_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT[fk_Teacher_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Teacher] CHECK CONSTRAINT[fk_Teacher_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT[FK_Teacher_userId_User_id] FOREIGN KEY([tenantId],[userId])
REFERENCES[dbo].[User]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Teacher] CHECK CONSTRAINT[FK_Teacher_userId_User_id]
GO
ALTER TABLE[dbo].[TeacherSkill]  WITH CHECK ADD  CONSTRAINT[fk_TeacherSkill_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[TeacherSkill] CHECK CONSTRAINT[fk_TeacherSkill_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]  WITH CHECK ADD  CONSTRAINT[FK_TeacherTeacherSkill_teacherId_Teacher_id] FOREIGN KEY([tenantId],[teacherId])
REFERENCES[dbo].[Teacher]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[TeacherTeacherSkill] CHECK CONSTRAINT[FK_TeacherTeacherSkill_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]  WITH CHECK ADD  CONSTRAINT[FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id] FOREIGN KEY([tenantId],[teacherSkillId])
REFERENCES[dbo].[TeacherSkill]([tenantId],[id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[TeacherTeacherSkill] CHECK CONSTRAINT[FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id]
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]  WITH CHECK ADD  CONSTRAINT[fk_TeacherTeacherSkill_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[TeacherTeacherSkill] CHECK CONSTRAINT[fk_TeacherTeacherSkill_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[User]  WITH CHECK ADD  CONSTRAINT[fk_User_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[User] CHECK CONSTRAINT[fk_User_tenantId_tenant_id]
GO


SET IDENTITY_INSERT [dbo].[Tenant] ON 

GO
INSERT [dbo].[Tenant] ([id], [name]) VALUES (1, N'tenant1')
GO
INSERT [dbo].[Tenant] ([id], [name]) VALUES (2, N'tenant2')
GO
SET IDENTITY_INSERT [dbo].[Tenant] OFF
GO
SET IDENTITY_INSERT [dbo].[EventStatus] ON 

GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 1, N'Pending', 0)
GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 2, N'Started', 0)
GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 3, N'Completed', 0)
GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 4, N'Rescheduled', 0)
GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 5, N'No Show', 0)
GO
SET IDENTITY_INSERT [dbo].[EventStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Event] ON 

GO
INSERT [dbo].[Event] ([tenantId], [actualEndDate], [actualStartDate], [billAmount], [eventStatusId], [id], [scheduledEndDate], [scheduledStartDate], [studentNotes], [teacherNotes],[isDeleted]) VALUES (1, NULL, NULL, NULL, 1, 1, CAST(N'2018-10-10 20:41:15.017' AS DateTime), CAST(N'2018-10-03 20:41:15.017' AS DateTime), NULL, NULL, 0)
GO
INSERT [dbo].[Event] ([tenantId], [actualEndDate], [actualStartDate], [billAmount], [eventStatusId], [id], [scheduledEndDate], [scheduledStartDate], [studentNotes], [teacherNotes],[isDeleted]) VALUES (1, NULL, NULL, NULL, 1, 2, CAST(N'2018-10-30 20:41:15.017' AS DateTime), CAST(N'2018-10-24 20:41:15.017' AS DateTime), NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Event] OFF
GO
SET IDENTITY_INSERT [dbo].[Family] ON 

GO
INSERT [dbo].[Family] ([tenantId], [id], [notes], [primaryContactEmail], [primaryContactFirstName], [primaryContactLastName], [primaryContactPhone],[isDeleted]) VALUES (1, 1, NULL, N'test', N'test', N'test', N'test', 0)
GO
SET IDENTITY_INSERT [dbo].[Family] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([tenantId], [id], [password], [username],[isDeleted]) VALUES (1, 1, N'password', N'student', 0)
GO
INSERT [dbo].[User] ([tenantId], [id], [password], [username],[isDeleted]) VALUES (1, 2, N'password', N'teacher', 0)
GO
INSERT [dbo].[User] ([tenantId], [id], [password], [username],[isDeleted]) VALUES (1, 3, N'password', N'admin', 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

GO
INSERT [dbo].[Student] ([tenantId], [birthday], [email], [emailRemindersEnabled], [familyId], [firstName], [id], [isAdult], [lastName], [phone], [smsRemindersEnabled], [userId],[isDeleted]) VALUES (1, CAST(N'2018-10-03' AS Date), N'test@test.com', 0, 1, N'John', 1, 0, N'Doe', N'9407279332', 0, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO

INSERT [dbo].[EventStudent] ([tenantId], [eventId], [studentId],[isDeleted]) VALUES (1, 1, 1, 0)
GO
INSERT [dbo].[EventStudent] ([tenantId], [eventId],  [studentId],[isDeleted]) VALUES (1, 2,  1, 0)

GO
SET IDENTITY_INSERT [dbo].[Space] ON 

GO
INSERT [dbo].[Space] ([tenantId], [description], [id], [name],[isDeleted]) VALUES (1, N'studio1', 1, N'studio1', 0)
GO
INSERT [dbo].[Space] ([tenantId], [description], [id], [name],[isDeleted]) VALUES (1, N'studio2', 2, N'studio2', 0)
GO
SET IDENTITY_INSERT [dbo].[Space] OFF
GO
SET IDENTITY_INSERT [dbo].[SpaceFeature] ON 

GO
INSERT [dbo].[SpaceFeature] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 1, N'whiteboard', 0)
GO
INSERT [dbo].[SpaceFeature] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 2, N'guitar amp', 0)
GO
INSERT [dbo].[SpaceFeature] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 3, N'piano', 0)
GO
SET IDENTITY_INSERT [dbo].[SpaceFeature] OFF


GO
INSERT [dbo].[SpaceSpaceFeature] ([tenantId], [spaceFeatureId], [spaceId],[isDeleted]) VALUES (1,  1, 1, 0)
GO
INSERT [dbo].[SpaceSpaceFeature] ([tenantId],  [spaceFeatureId], [spaceId],[isDeleted]) VALUES (1,  2, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

GO
INSERT [dbo].[Teacher] ([tenantId], [birthday], [email], [firstName], [id], [lastName], [phone], [userId],[isDeleted]) VALUES (1, CAST(N'2018-10-03' AS Date), N'test@test.com', N'test', 1, N'lastname', N'9407279332', 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[TeacherSkill] ON 

GO
INSERT [dbo].[TeacherSkill] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 1, N'Guitar', 0)
GO
INSERT [dbo].[TeacherSkill] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 2, N'Piano', 0)
GO
SET IDENTITY_INSERT [dbo].[TeacherSkill] OFF
GO
SET IDENTITY_INSERT [dbo].[Rate] ON 

GO
INSERT [dbo].[Rate] ([tenantId], [amountPerMinute], [id], [teacherId], [teacherSkillId],[isDeleted]) VALUES (1, 1.0000, 1, 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Rate] OFF
GO

INSERT [dbo].[TeacherTeacherSkill] ([tenantId],  [teacherId], [teacherSkillId],[isDeleted]) VALUES (1,  1, 1, 0)
GO
INSERT [dbo].[TeacherTeacherSkill] ([tenantId],  [teacherId], [teacherSkillId],[isDeleted]) VALUES (1,  1, 2, 0)
GO

INSERT [dbo].[EventTeacher] ([tenantId], [eventId],  [teacherId],[isDeleted]) VALUES (1, 1,  1, 0)
GO
INSERT [dbo].[EventTeacher] ([tenantId], [eventId],  [teacherId],[isDeleted]) VALUES (1, 2,  1, 0)
GO
SET IDENTITY_INSERT [dbo].[Studio] ON 

GO
INSERT [dbo].[Studio] ([tenantId], [address1], [address2], [city], [id], [name], [province], [website], [zip], [isDeleted]) VALUES (1, N'123 FAKE ST', N'SWE 2', N'Austin', 2, N'Test STudio', N'TX', N'https://www.codenesium.com', N'787478', 0)
GO
SET IDENTITY_INSERT [dbo].[Studio] OFF
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

GO
INSERT [dbo].[Admin] ([tenantId], [birthday], [email], [firstName], [id], [lastName], [phone], [userId],[isDeleted]) VALUES (1, CAST(N'2018-10-03' AS Date), N'admin@gmail.com', N'travis', 1, N'taylor', N'94072793332', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO

");
				}
				else if (this.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
				{
					migrationBuilder.Sql(@"CREATE SCHEMA IF NOT EXISTS ""dbo"";

--ALTER TABLE ""dbo"".""Admin"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Admin"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Event"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Event"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""EventStatus"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""EventStudent"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""EventStudent"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""EventStudent"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""EventTeacher"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""EventTeacher"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""EventTeacher"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Family"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Rate"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Rate"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Rate"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Space"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""SpaceFeature"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""SpaceSpaceFeature"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""SpaceSpaceFeature"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""SpaceSpaceFeature"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Student"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Student"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Student"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Studio"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Teacher"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""Teacher"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""TeacherSkill"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""TeacherTeacherSkill"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""TeacherTeacherSkill"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""TeacherTeacherSkill"" DISABLE TRIGGER ALL;
--ALTER TABLE ""dbo"".""User"" DISABLE TRIGGER ALL;

--DROP TABLE IF EXISTS ""dbo"".""Admin"";
--DROP TABLE IF EXISTS ""dbo"".""Event"";
--DROP TABLE IF EXISTS ""dbo"".""EventStatus"";
--DROP TABLE IF EXISTS ""dbo"".""EventStudent"";
--DROP TABLE IF EXISTS ""dbo"".""EventTeacher"";
--DROP TABLE IF EXISTS ""dbo"".""Family"";
--DROP TABLE IF EXISTS ""dbo"".""Rate"";
--DROP TABLE IF EXISTS ""dbo"".""Space"";
--DROP TABLE IF EXISTS ""dbo"".""SpaceFeature"";
--DROP TABLE IF EXISTS ""dbo"".""SpaceSpaceFeature"";
--DROP TABLE IF EXISTS ""dbo"".""Student"";
--DROP TABLE IF EXISTS ""dbo"".""Studio"";
--DROP TABLE IF EXISTS ""dbo"".""Teacher"";
--DROP TABLE IF EXISTS ""dbo"".""TeacherSkill"";
--DROP TABLE IF EXISTS ""dbo"".""TeacherTeacherSkill"";
--DROP TABLE IF EXISTS ""dbo"".""Tenant"";
--DROP TABLE IF EXISTS ""dbo"".""User"";

CREATE TABLE ""dbo"".""Admin""(
""tenantId"" int    NOT NULL,
""birthday"" date    NULL,
""email"" varchar  (128)  NOT NULL,
""firstName"" varchar  (128)  NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""lastName"" varchar  (128)  NOT NULL,
""phone"" varchar  (128)  NULL,
""userId"" int    NOT NULL);

CREATE TABLE ""dbo"".""Event""(
""tenantId"" int    NOT NULL,
""actualEndDate"" timestamp    NULL,
""actualStartDate"" timestamp    NULL,
""billAmount"" money    NULL,
""eventStatusId"" int    NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""scheduledEndDate"" timestamp    NULL,
""scheduledStartDate"" timestamp    NULL,
""studentNotes"" text  (2147483647)  NULL,
""teacherNotes"" text  (2147483647)  NULL);

CREATE TABLE ""dbo"".""EventStatus""(
""tenantId"" int    NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""name"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""EventStudent""(
""id""  SERIAL ,
""eventId"" int    NOT NULL,
""isDeleted"" boolean    NOT NULL,
""studentId"" int    NOT NULL,
""tenantId"" int    NOT NULL);

CREATE TABLE ""dbo"".""EventTeacher""(
""id""  SERIAL ,
""eventId"" int    NOT NULL,
""isDeleted"" boolean    NOT NULL,
""teacherId"" int    NOT NULL,
""tenantId"" int    NOT NULL);

CREATE TABLE ""dbo"".""Family""(
""tenantId"" int    NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""notes"" text  (2147483647)  NULL,
""primaryContactEmail"" varchar  (128)  NULL,
""primaryContactFirstName"" varchar  (128)  NULL,
""primaryContactLastName"" varchar  (128)  NULL,
""primaryContactPhone"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""Rate""(
""tenantId"" int    NOT NULL,
""amountPerMinute"" money    NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""teacherId"" int    NOT NULL,
""teacherSkillId"" int    NOT NULL);

CREATE TABLE ""dbo"".""Space""(
""tenantId"" int    NOT NULL,
""description"" varchar  (128)  NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""name"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""SpaceFeature""(
""tenantId"" int    NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""name"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""SpaceSpaceFeature""(
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""spaceFeatureId"" int    NOT NULL,
""spaceId"" int    NOT NULL,
""tenantId"" int    NOT NULL);

CREATE TABLE ""dbo"".""Student""(
""tenantId"" int    NOT NULL,
""birthday"" date    NOT NULL,
""email"" varchar  (128)  NOT NULL,
""emailRemindersEnabled"" boolean    NOT NULL,
""familyId"" int    NOT NULL,
""firstName"" varchar  (128)  NOT NULL,
""id""  SERIAL ,
""isAdult"" boolean    NOT NULL,
""isDeleted"" boolean    NOT NULL,
""lastName"" varchar  (128)  NOT NULL,
""phone"" varchar  (128)  NOT NULL,
""smsRemindersEnabled"" boolean    NOT NULL,
""userId"" int    NOT NULL);

CREATE TABLE ""dbo"".""Studio""(
""tenantId"" int    NOT NULL,
""address1"" varchar  (128)  NOT NULL,
""address2"" varchar  (128)  NOT NULL,
""city"" varchar  (128)  NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""name"" varchar  (128)  NOT NULL,
""province"" varchar  (90)  NOT NULL,
""website"" varchar  (128)  NOT NULL,
""zip"" varchar  (128)  NULL);

CREATE TABLE ""dbo"".""Teacher""(
""tenantId"" int    NOT NULL,
""birthday"" date    NOT NULL,
""email"" varchar  (128)  NOT NULL,
""firstName"" varchar  (128)  NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""lastName"" varchar  (128)  NOT NULL,
""phone"" varchar  (128)  NULL,
""userId"" int    NOT NULL);

CREATE TABLE ""dbo"".""TeacherSkill""(
""tenantId"" int    NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""name"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""TeacherTeacherSkill""(
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""teacherId"" int    NOT NULL,
""teacherSkillId"" int    NOT NULL,
""tenantId"" int    NOT NULL);

CREATE TABLE ""dbo"".""Tenant""(
""id""  SERIAL ,
""name"" varchar  (128)  NOT NULL);

CREATE TABLE ""dbo"".""User""(
""tenantId"" int    NOT NULL,
""id""  SERIAL ,
""isDeleted"" boolean    NOT NULL,
""password"" varchar  (128)  NOT NULL,
""username"" varchar  (128)  NOT NULL);

ALTER TABLE ""dbo"".""Admin""
ADD CONSTRAINT ""PK_Admin""
PRIMARY KEY
(
""tenantId""
,""id""
);
CREATE  INDEX ""IX_Admin_userId"" ON ""dbo"".""Admin""
(
""tenantId"" ASC,
""userId"" ASC);
ALTER TABLE ""dbo"".""Event""
ADD CONSTRAINT ""PK_Event""
PRIMARY KEY
(
""tenantId""
,""id""
);
CREATE  INDEX ""IX_Event_eventStatusId"" ON ""dbo"".""Event""
(
""tenantId"" ASC,
""eventStatusId"" ASC);
ALTER TABLE ""dbo"".""EventStatus""
ADD CONSTRAINT ""PK_EventStatus""
PRIMARY KEY
(
""tenantId""
,""id""
);
CREATE  INDEX ""IX_EventStudent_eventId"" ON ""dbo"".""EventStudent""
(
""tenantId"" ASC,
""eventId"" ASC);
CREATE  INDEX ""IX_EventStudent_studentId"" ON ""dbo"".""EventStudent""
(
""tenantId"" ASC,
""studentId"" ASC);
ALTER TABLE ""dbo"".""EventStudent""
ADD CONSTRAINT ""PK_EventStudent""
PRIMARY KEY
(
""id""
);
CREATE  INDEX ""IX_EventTeacher_eventId"" ON ""dbo"".""EventTeacher""
(
""tenantId"" ASC,
""eventId"" ASC);
CREATE  INDEX ""IX_EventTeacher_teacherId"" ON ""dbo"".""EventTeacher""
(
""tenantId"" ASC,
""teacherId"" ASC);
ALTER TABLE ""dbo"".""EventTeacher""
ADD CONSTRAINT ""PK_EventTeacher""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Family""
ADD CONSTRAINT ""PK_Family""
PRIMARY KEY
(
""tenantId""
,""id""
);
ALTER TABLE ""dbo"".""Rate""
ADD CONSTRAINT ""PK_Rate""
PRIMARY KEY
(
""tenantId""
,""id""
);
CREATE  INDEX ""IX_Rate_teacherId"" ON ""dbo"".""Rate""
(
""tenantId"" ASC,
""teacherId"" ASC);
CREATE  INDEX ""IX_Rate_teacherSkillId"" ON ""dbo"".""Rate""
(
""tenantId"" ASC,
""teacherSkillId"" ASC);
ALTER TABLE ""dbo"".""Space""
ADD CONSTRAINT ""PK_Space""
PRIMARY KEY
(
""tenantId""
,""id""
);
ALTER TABLE ""dbo"".""SpaceFeature""
ADD CONSTRAINT ""PK_SpaceFeature""
PRIMARY KEY
(
""tenantId""
,""id""
);
CREATE  INDEX ""IX_SpaceSpaceFeature_spaceFeatureId"" ON ""dbo"".""SpaceSpaceFeature""
(
""tenantId"" ASC,
""spaceFeatureId"" ASC);
CREATE  INDEX ""IX_SpaceSpaceFeature_spaceId"" ON ""dbo"".""SpaceSpaceFeature""
(
""tenantId"" ASC,
""spaceId"" ASC);
ALTER TABLE ""dbo"".""SpaceSpaceFeature""
ADD CONSTRAINT ""PK_SpaceSpaceFeature""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Student""
ADD CONSTRAINT ""PK_Student""
PRIMARY KEY
(
""tenantId""
,""id""
);
CREATE  INDEX ""IX_Student_familyId"" ON ""dbo"".""Student""
(
""tenantId"" ASC,
""familyId"" ASC);
CREATE  INDEX ""IX_Student_userId"" ON ""dbo"".""Student""
(
""tenantId"" ASC,
""userId"" ASC);
ALTER TABLE ""dbo"".""Studio""
ADD CONSTRAINT ""PK_Studio""
PRIMARY KEY
(
""tenantId""
,""id""
);
ALTER TABLE ""dbo"".""Teacher""
ADD CONSTRAINT ""PK_Teacher""
PRIMARY KEY
(
""tenantId""
,""id""
);
CREATE  INDEX ""IX_Teacher_userId"" ON ""dbo"".""Teacher""
(
""tenantId"" ASC,
""userId"" ASC);
ALTER TABLE ""dbo"".""TeacherSkill""
ADD CONSTRAINT ""PK_TeacherSkill""
PRIMARY KEY
(
""tenantId""
,""id""
);
CREATE  INDEX ""IX_TeacherTeacherSkill_teacherId"" ON ""dbo"".""TeacherTeacherSkill""
(
""tenantId"" ASC,
""teacherId"" ASC);
CREATE  INDEX ""IX_TeacherTeacherSkill_teacherSkillId"" ON ""dbo"".""TeacherTeacherSkill""
(
""tenantId"" ASC,
""teacherSkillId"" ASC);
ALTER TABLE ""dbo"".""TeacherTeacherSkill""
ADD CONSTRAINT ""PK_TeacherTeacherSkill""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""Tenant""
ADD CONSTRAINT ""PK_Tenant""
PRIMARY KEY
(
""id""
);
ALTER TABLE ""dbo"".""User""
ADD CONSTRAINT ""PK_User""
PRIMARY KEY
(
""tenantId""
,""id""
);


ALTER TABLE ""dbo"".""Admin"" ADD CONSTRAINT ""FK_Admin_tenantId_Tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""Admin"" ADD CONSTRAINT ""FK_Admin_userId_User_id"" FOREIGN KEY(""tenantId"",""userId"")
REFERENCES ""dbo"".""User"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""Event"" ADD CONSTRAINT ""FK_Event_eventStatusId_EventStatus_id"" FOREIGN KEY(""tenantId"",""eventStatusId"")
REFERENCES ""dbo"".""EventStatus"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""Event"" ADD CONSTRAINT ""fk_Event_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""EventStatus"" ADD CONSTRAINT ""fk_EventStatus_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""EventStudent"" ADD CONSTRAINT ""FK_EventStudent_eventId_Event_id"" FOREIGN KEY(""tenantId"",""eventId"")
REFERENCES ""dbo"".""Event"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""EventStudent"" ADD CONSTRAINT ""FK_EventStudent_studentId_Student_id"" FOREIGN KEY(""tenantId"",""studentId"")
REFERENCES ""dbo"".""Student"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""EventStudent"" ADD CONSTRAINT ""fk_EventStudent_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""EventTeacher"" ADD CONSTRAINT ""FK_EventTeacher_teacherId_Teacher_id"" FOREIGN KEY(""tenantId"",""teacherId"")
REFERENCES ""dbo"".""Teacher"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""EventTeacher"" ADD CONSTRAINT ""fk_EventTeacher_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""EventTeacher"" ADD CONSTRAINT ""FK_EventTeacher_eventId_Event_id"" FOREIGN KEY(""tenantId"",""eventId"")
REFERENCES ""dbo"".""Event"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""Family"" ADD CONSTRAINT ""fk_Family_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""Rate"" ADD CONSTRAINT ""FK_Rate_teacherId_Teacher_id"" FOREIGN KEY(""tenantId"",""teacherId"")
REFERENCES ""dbo"".""Teacher"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""Rate"" ADD CONSTRAINT ""FK_Rate_teacherSkillId_TeacherSkill_id"" FOREIGN KEY(""tenantId"",""teacherSkillId"")
REFERENCES ""dbo"".""TeacherSkill"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""Rate"" ADD CONSTRAINT ""fk_Rate_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""Space"" ADD CONSTRAINT ""fk_Space_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""SpaceFeature"" ADD CONSTRAINT ""fk_SpaceFeature_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""SpaceSpaceFeature"" ADD CONSTRAINT ""FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id"" FOREIGN KEY(""tenantId"",""spaceFeatureId"")
REFERENCES ""dbo"".""SpaceFeature"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""SpaceSpaceFeature"" ADD CONSTRAINT ""FK_SpaceSpaceFeature_spaceId_Space_id"" FOREIGN KEY(""tenantId"",""spaceId"")
REFERENCES ""dbo"".""Space"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""SpaceSpaceFeature"" ADD CONSTRAINT ""fk_SpaceSpaceFeature_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""Student"" ADD CONSTRAINT ""FK_Student_familyId_Family_id"" FOREIGN KEY(""tenantId"",""familyId"")
REFERENCES ""dbo"".""Family"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""Student"" ADD CONSTRAINT ""fk_Student_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""Student"" ADD CONSTRAINT ""FK_Student_userId_User_id"" FOREIGN KEY(""tenantId"",""userId"")
REFERENCES ""dbo"".""User"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""Studio"" ADD CONSTRAINT ""fk_Studio_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""Teacher"" ADD CONSTRAINT ""fk_Teacher_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""Teacher"" ADD CONSTRAINT ""FK_Teacher_userId_User_id"" FOREIGN KEY(""tenantId"",""userId"")
REFERENCES ""dbo"".""User"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""TeacherSkill"" ADD CONSTRAINT ""fk_TeacherSkill_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""TeacherTeacherSkill"" ADD CONSTRAINT ""FK_TeacherTeacherSkill_teacherId_Teacher_id"" FOREIGN KEY(""tenantId"",""teacherId"")
REFERENCES ""dbo"".""Teacher"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""TeacherTeacherSkill"" ADD CONSTRAINT ""FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id"" FOREIGN KEY(""tenantId"",""teacherSkillId"")
REFERENCES ""dbo"".""TeacherSkill"" (""tenantId"",""id"");
ALTER TABLE ""dbo"".""TeacherTeacherSkill"" ADD CONSTRAINT ""fk_TeacherTeacherSkill_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");
ALTER TABLE ""dbo"".""User"" ADD CONSTRAINT ""fk_User_tenantId_tenant_id"" FOREIGN KEY(""tenantId"")
REFERENCES ""dbo"".""Tenant"" (""id"");


SET IDENTITY_INSERT [dbo].[Tenant] ON 

GO
INSERT [dbo].[Tenant] ([id], [name]) VALUES (1, N'tenant1')
GO
INSERT [dbo].[Tenant] ([id], [name]) VALUES (2, N'tenant2')
GO
SET IDENTITY_INSERT [dbo].[Tenant] OFF
GO
SET IDENTITY_INSERT [dbo].[EventStatus] ON 

GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 1, N'Pending', 0)
GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 2, N'Started', 0)
GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 3, N'Completed', 0)
GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 4, N'Rescheduled', 0)
GO
INSERT [dbo].[EventStatus] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 5, N'No Show', 0)
GO
SET IDENTITY_INSERT [dbo].[EventStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Event] ON 

GO
INSERT [dbo].[Event] ([tenantId], [actualEndDate], [actualStartDate], [billAmount], [eventStatusId], [id], [scheduledEndDate], [scheduledStartDate], [studentNotes], [teacherNotes],[isDeleted]) VALUES (1, NULL, NULL, NULL, 1, 1, CAST(N'2018-10-10 20:41:15.017' AS DateTime), CAST(N'2018-10-03 20:41:15.017' AS DateTime), NULL, NULL, 0)
GO
INSERT [dbo].[Event] ([tenantId], [actualEndDate], [actualStartDate], [billAmount], [eventStatusId], [id], [scheduledEndDate], [scheduledStartDate], [studentNotes], [teacherNotes],[isDeleted]) VALUES (1, NULL, NULL, NULL, 1, 2, CAST(N'2018-10-30 20:41:15.017' AS DateTime), CAST(N'2018-10-24 20:41:15.017' AS DateTime), NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Event] OFF
GO
SET IDENTITY_INSERT [dbo].[Family] ON 

GO
INSERT [dbo].[Family] ([tenantId], [id], [notes], [primaryContactEmail], [primaryContactFirstName], [primaryContactLastName], [primaryContactPhone],[isDeleted]) VALUES (1, 1, NULL, N'test', N'test', N'test', N'test', 0)
GO
SET IDENTITY_INSERT [dbo].[Family] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([tenantId], [id], [password], [username],[isDeleted]) VALUES (1, 1, N'password', N'student', 0)
GO
INSERT [dbo].[User] ([tenantId], [id], [password], [username],[isDeleted]) VALUES (1, 2, N'password', N'teacher', 0)
GO
INSERT [dbo].[User] ([tenantId], [id], [password], [username],[isDeleted]) VALUES (1, 3, N'password', N'admin', 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

GO
INSERT [dbo].[Student] ([tenantId], [birthday], [email], [emailRemindersEnabled], [familyId], [firstName], [id], [isAdult], [lastName], [phone], [smsRemindersEnabled], [userId],[isDeleted]) VALUES (1, CAST(N'2018-10-03' AS Date), N'test@test.com', 0, 1, N'John', 1, 0, N'Doe', N'9407279332', 0, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO

INSERT [dbo].[EventStudent] ([tenantId], [eventId], [studentId],[isDeleted]) VALUES (1, 1, 1, 0)
GO
INSERT [dbo].[EventStudent] ([tenantId], [eventId],  [studentId],[isDeleted]) VALUES (1, 2,  1, 0)

GO
SET IDENTITY_INSERT [dbo].[Space] ON 

GO
INSERT [dbo].[Space] ([tenantId], [description], [id], [name],[isDeleted]) VALUES (1, N'studio1', 1, N'studio1', 0)
GO
INSERT [dbo].[Space] ([tenantId], [description], [id], [name],[isDeleted]) VALUES (1, N'studio2', 2, N'studio2', 0)
GO
SET IDENTITY_INSERT [dbo].[Space] OFF
GO
SET IDENTITY_INSERT [dbo].[SpaceFeature] ON 

GO
INSERT [dbo].[SpaceFeature] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 1, N'whiteboard', 0)
GO
INSERT [dbo].[SpaceFeature] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 2, N'guitar amp', 0)
GO
INSERT [dbo].[SpaceFeature] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 3, N'piano', 0)
GO
SET IDENTITY_INSERT [dbo].[SpaceFeature] OFF


GO
INSERT [dbo].[SpaceSpaceFeature] ([tenantId], [spaceFeatureId], [spaceId],[isDeleted]) VALUES (1,  1, 1, 0)
GO
INSERT [dbo].[SpaceSpaceFeature] ([tenantId],  [spaceFeatureId], [spaceId],[isDeleted]) VALUES (1,  2, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

GO
INSERT [dbo].[Teacher] ([tenantId], [birthday], [email], [firstName], [id], [lastName], [phone], [userId],[isDeleted]) VALUES (1, CAST(N'2018-10-03' AS Date), N'test@test.com', N'test', 1, N'lastname', N'9407279332', 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[TeacherSkill] ON 

GO
INSERT [dbo].[TeacherSkill] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 1, N'Guitar', 0)
GO
INSERT [dbo].[TeacherSkill] ([tenantId], [id], [name],[isDeleted]) VALUES (1, 2, N'Piano', 0)
GO
SET IDENTITY_INSERT [dbo].[TeacherSkill] OFF
GO
SET IDENTITY_INSERT [dbo].[Rate] ON 

GO
INSERT [dbo].[Rate] ([tenantId], [amountPerMinute], [id], [teacherId], [teacherSkillId],[isDeleted]) VALUES (1, 1.0000, 1, 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Rate] OFF
GO

INSERT [dbo].[TeacherTeacherSkill] ([tenantId],  [teacherId], [teacherSkillId],[isDeleted]) VALUES (1,  1, 1, 0)
GO
INSERT [dbo].[TeacherTeacherSkill] ([tenantId],  [teacherId], [teacherSkillId],[isDeleted]) VALUES (1,  1, 2, 0)
GO

INSERT [dbo].[EventTeacher] ([tenantId], [eventId],  [teacherId],[isDeleted]) VALUES (1, 1,  1, 0)
GO
INSERT [dbo].[EventTeacher] ([tenantId], [eventId],  [teacherId],[isDeleted]) VALUES (1, 2,  1, 0)
GO
SET IDENTITY_INSERT [dbo].[Studio] ON 

GO
INSERT [dbo].[Studio] ([tenantId], [address1], [address2], [city], [id], [name], [province], [website], [zip], [isDeleted]) VALUES (1, N'123 FAKE ST', N'SWE 2', N'Austin', 2, N'Test STudio', N'TX', N'https://www.codenesium.com', N'787478', 0)
GO
SET IDENTITY_INSERT [dbo].[Studio] OFF
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

GO
INSERT [dbo].[Admin] ([tenantId], [birthday], [email], [firstName], [id], [lastName], [phone], [userId],[isDeleted]) VALUES (1, CAST(N'2018-10-03' AS Date), N'admin@gmail.com', N'travis', 1, N'taylor', N'94072793332', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO

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