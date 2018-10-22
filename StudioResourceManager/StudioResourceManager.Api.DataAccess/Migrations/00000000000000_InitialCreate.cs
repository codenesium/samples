using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.DataAccess.Migrations
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
--IF (OBJECT_ID('dbo.fk_Event_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Event] DROP CONSTRAINT [fk_Event_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Event_eventStatusId_EventStatus_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_eventStatusId_EventStatus_id]
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
--IF (OBJECT_ID('dbo.FK_EventTeacher_eventId_Event_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventTeacher] DROP CONSTRAINT [FK_EventTeacher_eventId_Event_id]
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
--IF (OBJECT_ID('dbo.fk_Family_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Family] DROP CONSTRAINT [fk_Family_tenantId_tenant_id]
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
--IF (OBJECT_ID('dbo.FK_Rate_teacherId_Teacher_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Rate] DROP CONSTRAINT [FK_Rate_teacherId_Teacher_id]
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
--IF (OBJECT_ID('dbo.fk_SpaceSpaceFeature_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[SpaceSpaceFeature] DROP CONSTRAINT [fk_SpaceSpaceFeature_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_SpaceSpaceFeature_spaceId_Space_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[SpaceSpaceFeature] DROP CONSTRAINT [FK_SpaceSpaceFeature_spaceId_Space_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[SpaceSpaceFeature] DROP CONSTRAINT [FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id]
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
--IF (OBJECT_ID('dbo.fk_TeacherTeacherSkill_tenantId_tenant_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[TeacherTeacherSkill] DROP CONSTRAINT [fk_TeacherTeacherSkill_tenantId_tenant_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[TeacherTeacherSkill] DROP CONSTRAINT [FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_TeacherTeacherSkill_teacherId_Teacher_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[TeacherTeacherSkill] DROP CONSTRAINT [FK_TeacherTeacherSkill_teacherId_Teacher_id]
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
--IF OBJECT_ID('dbo.vEvents', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[vEvents]
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
[tenantId] [int]     NOT NULL,
[eventId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[studentId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[EventTeacher](
[tenantId] [int]     NOT NULL,
[eventId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[teacherId] [int]     NOT NULL,
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
[tenantId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[spaceFeatureId] [int]     NOT NULL,
[spaceId] [int]     NOT NULL,
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
[tenantId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[teacherId] [int]     NOT NULL,
[teacherSkillId] [int]     NOT NULL,
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

CREATE TABLE [dbo].[vEvents](
[tenantId] [int]     NOT NULL,
[actualEndDate] [datetime]     NULL,
[actualStartDate] [datetime]     NULL,
[billAmount] [money]     NULL,
[eventStatusId] [int]     NOT NULL,
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[scheduledEndDate] [datetime]     NULL,
[scheduledStartDate] [datetime]     NULL,
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
ALTER TABLE[dbo].[EventStudent]
ADD CONSTRAINT[PK_EventStudent] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[eventId] ASC
,[studentId] ASC
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
ALTER TABLE[dbo].[EventTeacher]
ADD CONSTRAINT[PK_EventTeacher] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[eventId] ASC
,[teacherId] ASC
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
ALTER TABLE[dbo].[SpaceSpaceFeature]
ADD CONSTRAINT[PK_SpaceSpaceFeature] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[spaceId] ASC
,[spaceFeatureId] ASC
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
ALTER TABLE[dbo].[TeacherTeacherSkill]
ADD CONSTRAINT[PK_TeacherTeacherSkill] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[teacherId] ASC
,[teacherSkillId] ASC
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
ALTER TABLE[dbo].[vEvents]
ADD CONSTRAINT[pk_VEvents] PRIMARY KEY CLUSTERED
(
[tenantId] ASC
,[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[Admin]  WITH CHECK ADD  CONSTRAINT[FK_Admin_tenantId_Tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[Admin] CHECK CONSTRAINT[FK_Admin_tenantId_Tenant_id]
GO
ALTER TABLE[dbo].[Admin]  WITH CHECK ADD  CONSTRAINT[FK_Admin_userId_User_id] FOREIGN KEY([tenantId],[userId])
REFERENCES[dbo].[User]([tenantId],[id])
GO
ALTER TABLE[dbo].[Admin] CHECK CONSTRAINT[FK_Admin_userId_User_id]
GO
ALTER TABLE[dbo].[Event]  WITH CHECK ADD  CONSTRAINT[fk_Event_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[Event] CHECK CONSTRAINT[fk_Event_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Event]  WITH CHECK ADD  CONSTRAINT[FK_Event_eventStatusId_EventStatus_id] FOREIGN KEY([tenantId],[eventStatusId])
REFERENCES[dbo].[EventStatus]([tenantId],[id])
GO
ALTER TABLE[dbo].[Event] CHECK CONSTRAINT[FK_Event_eventStatusId_EventStatus_id]
GO
ALTER TABLE[dbo].[EventStatus]  WITH CHECK ADD  CONSTRAINT[fk_EventStatus_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[EventStatus] CHECK CONSTRAINT[fk_EventStatus_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[EventStudent]  WITH CHECK ADD  CONSTRAINT[FK_EventStudent_eventId_Event_id] FOREIGN KEY([tenantId],[eventId])
REFERENCES[dbo].[Event]([tenantId],[id])
GO
ALTER TABLE[dbo].[EventStudent] CHECK CONSTRAINT[FK_EventStudent_eventId_Event_id]
GO
ALTER TABLE[dbo].[EventStudent]  WITH CHECK ADD  CONSTRAINT[FK_EventStudent_studentId_Student_id] FOREIGN KEY([tenantId],[studentId])
REFERENCES[dbo].[Student]([tenantId],[id])
GO
ALTER TABLE[dbo].[EventStudent] CHECK CONSTRAINT[FK_EventStudent_studentId_Student_id]
GO
ALTER TABLE[dbo].[EventStudent]  WITH CHECK ADD  CONSTRAINT[fk_EventStudent_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[EventStudent] CHECK CONSTRAINT[fk_EventStudent_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[EventTeacher]  WITH CHECK ADD  CONSTRAINT[FK_EventTeacher_eventId_Event_id] FOREIGN KEY([tenantId],[eventId])
REFERENCES[dbo].[Event]([tenantId],[id])
GO
ALTER TABLE[dbo].[EventTeacher] CHECK CONSTRAINT[FK_EventTeacher_eventId_Event_id]
GO
ALTER TABLE[dbo].[EventTeacher]  WITH CHECK ADD  CONSTRAINT[FK_EventTeacher_teacherId_Teacher_id] FOREIGN KEY([tenantId],[teacherId])
REFERENCES[dbo].[Teacher]([tenantId],[id])
GO
ALTER TABLE[dbo].[EventTeacher] CHECK CONSTRAINT[FK_EventTeacher_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[EventTeacher]  WITH CHECK ADD  CONSTRAINT[fk_EventTeacher_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[EventTeacher] CHECK CONSTRAINT[fk_EventTeacher_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Family]  WITH CHECK ADD  CONSTRAINT[fk_Family_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[Family] CHECK CONSTRAINT[fk_Family_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[FK_Rate_teacherSkillId_TeacherSkill_id] FOREIGN KEY([tenantId],[teacherSkillId])
REFERENCES[dbo].[TeacherSkill]([tenantId],[id])
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[FK_Rate_teacherSkillId_TeacherSkill_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[fk_Rate_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[fk_Rate_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[FK_Rate_teacherId_Teacher_id] FOREIGN KEY([tenantId],[teacherId])
REFERENCES[dbo].[Teacher]([tenantId],[id])
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[FK_Rate_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[Space]  WITH CHECK ADD  CONSTRAINT[fk_Space_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[Space] CHECK CONSTRAINT[fk_Space_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[SpaceFeature]  WITH CHECK ADD  CONSTRAINT[fk_SpaceFeature_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[SpaceFeature] CHECK CONSTRAINT[fk_SpaceFeature_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]  WITH CHECK ADD  CONSTRAINT[fk_SpaceSpaceFeature_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[SpaceSpaceFeature] CHECK CONSTRAINT[fk_SpaceSpaceFeature_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]  WITH CHECK ADD  CONSTRAINT[FK_SpaceSpaceFeature_spaceId_Space_id] FOREIGN KEY([tenantId],[spaceId])
REFERENCES[dbo].[Space]([tenantId],[id])
GO
ALTER TABLE[dbo].[SpaceSpaceFeature] CHECK CONSTRAINT[FK_SpaceSpaceFeature_spaceId_Space_id]
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]  WITH CHECK ADD  CONSTRAINT[FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id] FOREIGN KEY([tenantId],[spaceFeatureId])
REFERENCES[dbo].[SpaceFeature]([tenantId],[id])
GO
ALTER TABLE[dbo].[SpaceSpaceFeature] CHECK CONSTRAINT[FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[FK_Student_familyId_Family_id] FOREIGN KEY([tenantId],[familyId])
REFERENCES[dbo].[Family]([tenantId],[id])
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[FK_Student_familyId_Family_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[fk_Student_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[fk_Student_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[FK_Student_userId_User_id] FOREIGN KEY([tenantId],[userId])
REFERENCES[dbo].[User]([tenantId],[id])
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[FK_Student_userId_User_id]
GO
ALTER TABLE[dbo].[Studio]  WITH CHECK ADD  CONSTRAINT[fk_Studio_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[Studio] CHECK CONSTRAINT[fk_Studio_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT[fk_Teacher_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[Teacher] CHECK CONSTRAINT[fk_Teacher_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT[FK_Teacher_userId_User_id] FOREIGN KEY([tenantId],[userId])
REFERENCES[dbo].[User]([tenantId],[id])
GO
ALTER TABLE[dbo].[Teacher] CHECK CONSTRAINT[FK_Teacher_userId_User_id]
GO
ALTER TABLE[dbo].[TeacherSkill]  WITH CHECK ADD  CONSTRAINT[fk_TeacherSkill_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[TeacherSkill] CHECK CONSTRAINT[fk_TeacherSkill_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]  WITH CHECK ADD  CONSTRAINT[fk_TeacherTeacherSkill_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[TeacherTeacherSkill] CHECK CONSTRAINT[fk_TeacherTeacherSkill_tenantId_tenant_id]
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]  WITH CHECK ADD  CONSTRAINT[FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id] FOREIGN KEY([tenantId],[teacherSkillId])
REFERENCES[dbo].[TeacherSkill]([tenantId],[id])
GO
ALTER TABLE[dbo].[TeacherTeacherSkill] CHECK CONSTRAINT[FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id]
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]  WITH CHECK ADD  CONSTRAINT[FK_TeacherTeacherSkill_teacherId_Teacher_id] FOREIGN KEY([tenantId],[teacherId])
REFERENCES[dbo].[Teacher]([tenantId],[id])
GO
ALTER TABLE[dbo].[TeacherTeacherSkill] CHECK CONSTRAINT[FK_TeacherTeacherSkill_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[User]  WITH CHECK ADD  CONSTRAINT[fk_User_tenantId_tenant_id] FOREIGN KEY([tenantId])
REFERENCES[dbo].[Tenant]([id])
GO
ALTER TABLE[dbo].[User] CHECK CONSTRAINT[fk_User_tenantId_tenant_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}