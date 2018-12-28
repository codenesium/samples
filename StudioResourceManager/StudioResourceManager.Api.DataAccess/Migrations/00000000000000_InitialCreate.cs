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
--IF (OBJECT_ID('dbo.FK_EventTeacher_teacherId_Teacher_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventTeacher] DROP CONSTRAINT [FK_EventTeacher_teacherId_Teacher_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_EventTeacher_eventId_Event_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[EventTeacher] DROP CONSTRAINT [FK_EventTeacher_eventId_Event_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Rate_teacherSkillId_TeacherSkill_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Rate] DROP CONSTRAINT [FK_Rate_teacherSkillId_TeacherSkill_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Rate_teacherId_Teacher_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Rate] DROP CONSTRAINT [FK_Rate_teacherId_Teacher_id]
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
--IF (OBJECT_ID('dbo.FK_Student_userId_User_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Student] DROP CONSTRAINT [FK_Student_userId_User_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Teacher_userId_User_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Teacher] DROP CONSTRAINT [FK_Teacher_userId_User_id]
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
--IF OBJECT_ID('dbo.User', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[User]
--END
--GO

CREATE TABLE [dbo].[Admin](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[birthday] [date]     NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[isDeleted] [bit]     NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (128)   NULL,
[userId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Event](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[actualEndDate] [datetime]     NULL,
[actualStartDate] [datetime]     NULL,
[billAmount] [money]     NULL,
[eventStatusId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[scheduledEndDate] [datetime]     NULL,
[scheduledStartDate] [datetime]     NULL,
[studentNotes] [text]     NULL,
[teacherNotes] [text]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[EventStatus](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[EventStudent](
[eventId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[studentId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[EventTeacher](
[eventId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[teacherId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Family](
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
[id] [int]   IDENTITY(1,1)  NOT NULL,
[amountPerMinute] [money]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[teacherId] [int]     NOT NULL,
[teacherSkillId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Space](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[description] [varchar]  (128)   NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[SpaceFeature](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[SpaceSpaceFeature](
[spaceId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[spaceFeatureId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Student](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[birthday] [date]     NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[emailRemindersEnabled] [bit]     NOT NULL,
[familyId] [int]     NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[isAdult] [bit]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (128)   NOT NULL,
[smsRemindersEnabled] [bit]     NOT NULL,
[userId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Studio](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[address1] [varchar]  (128)   NOT NULL,
[address2] [varchar]  (128)   NOT NULL,
[city] [varchar]  (128)   NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
[province] [varchar]  (90)   NOT NULL,
[website] [varchar]  (128)   NOT NULL,
[zip] [varchar]  (128)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Teacher](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[birthday] [date]     NOT NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[isDeleted] [bit]     NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[phone] [varchar]  (128)   NULL,
[userId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TeacherSkill](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TeacherTeacherSkill](
[teacherId] [int]     NOT NULL,
[isDeleted] [bit]     NOT NULL,
[teacherSkillId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[User](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[isDeleted] [bit]     NOT NULL,
[password] [varchar]  (128)   NOT NULL,
[username] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Admin]
ADD CONSTRAINT[PK_Admin] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Admin_userId] ON[dbo].[Admin]
(
[userId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Event]
ADD CONSTRAINT[PK_Event] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Event_eventStatusId] ON[dbo].[Event]
(
[eventStatusId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[EventStatus]
ADD CONSTRAINT[PK_EventStatus] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[EventStudent]
ADD CONSTRAINT[PK_EventStudent] PRIMARY KEY CLUSTERED
(
[eventId] ASC
,[studentId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventStudent_eventId] ON[dbo].[EventStudent]
(
[eventId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventStudent_studentId] ON[dbo].[EventStudent]
(
[studentId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[EventTeacher]
ADD CONSTRAINT[PK_EventTeacher] PRIMARY KEY CLUSTERED
(
[eventId] ASC
,[teacherId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventTeacher_eventId] ON[dbo].[EventTeacher]
(
[eventId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_EventTeacher_teacherId] ON[dbo].[EventTeacher]
(
[teacherId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Family]
ADD CONSTRAINT[PK_Family] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Rate]
ADD CONSTRAINT[PK_Rate] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Rate_teacherId] ON[dbo].[Rate]
(
[teacherId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Rate_teacherSkillId] ON[dbo].[Rate]
(
[teacherSkillId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Space]
ADD CONSTRAINT[PK_Space] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[SpaceFeature]
ADD CONSTRAINT[PK_SpaceFeature] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]
ADD CONSTRAINT[PK_SpaceSpaceFeature] PRIMARY KEY CLUSTERED
(
[spaceId] ASC
,[spaceFeatureId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_SpaceSpaceFeature_spaceFeatureId] ON[dbo].[SpaceSpaceFeature]
(
[spaceFeatureId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_SpaceSpaceFeature_spaceId] ON[dbo].[SpaceSpaceFeature]
(
[spaceId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Student]
ADD CONSTRAINT[PK_Student] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Student_familyId] ON[dbo].[Student]
(
[familyId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Student_userId] ON[dbo].[Student]
(
[userId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Studio]
ADD CONSTRAINT[PK_Studio] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Teacher]
ADD CONSTRAINT[PK_Teacher] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Teacher_userId] ON[dbo].[Teacher]
(
[userId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TeacherSkill]
ADD CONSTRAINT[PK_TeacherSkill] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]
ADD CONSTRAINT[PK_TeacherTeacherSkill] PRIMARY KEY CLUSTERED
(
[teacherId] ASC
,[teacherSkillId] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TeacherTeacherSkill_teacherId] ON[dbo].[TeacherTeacherSkill]
(
[teacherId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_TeacherTeacherSkill_teacherSkillId] ON[dbo].[TeacherTeacherSkill]
(
[teacherSkillId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[User]
ADD CONSTRAINT[PK_User] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[Admin]  WITH CHECK ADD  CONSTRAINT[FK_Admin_userId_User_id] FOREIGN KEY([userId])
REFERENCES[dbo].[User]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Admin] CHECK CONSTRAINT[FK_Admin_userId_User_id]
GO
ALTER TABLE[dbo].[Event]  WITH CHECK ADD  CONSTRAINT[FK_Event_eventStatusId_EventStatus_id] FOREIGN KEY([eventStatusId])
REFERENCES[dbo].[EventStatus]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Event] CHECK CONSTRAINT[FK_Event_eventStatusId_EventStatus_id]
GO
ALTER TABLE[dbo].[EventStudent]  WITH CHECK ADD  CONSTRAINT[FK_EventStudent_eventId_Event_id] FOREIGN KEY([eventId])
REFERENCES[dbo].[Event]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventStudent] CHECK CONSTRAINT[FK_EventStudent_eventId_Event_id]
GO
ALTER TABLE[dbo].[EventStudent]  WITH CHECK ADD  CONSTRAINT[FK_EventStudent_studentId_Student_id] FOREIGN KEY([studentId])
REFERENCES[dbo].[Student]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventStudent] CHECK CONSTRAINT[FK_EventStudent_studentId_Student_id]
GO
ALTER TABLE[dbo].[EventTeacher]  WITH CHECK ADD  CONSTRAINT[FK_EventTeacher_teacherId_Teacher_id] FOREIGN KEY([teacherId])
REFERENCES[dbo].[Teacher]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventTeacher] CHECK CONSTRAINT[FK_EventTeacher_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[EventTeacher]  WITH CHECK ADD  CONSTRAINT[FK_EventTeacher_eventId_Event_id] FOREIGN KEY([eventId])
REFERENCES[dbo].[Event]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[EventTeacher] CHECK CONSTRAINT[FK_EventTeacher_eventId_Event_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[FK_Rate_teacherSkillId_TeacherSkill_id] FOREIGN KEY([teacherSkillId])
REFERENCES[dbo].[TeacherSkill]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[FK_Rate_teacherSkillId_TeacherSkill_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[FK_Rate_teacherId_Teacher_id] FOREIGN KEY([teacherId])
REFERENCES[dbo].[Teacher]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[FK_Rate_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]  WITH CHECK ADD  CONSTRAINT[FK_SpaceSpaceFeature_spaceId_Space_id] FOREIGN KEY([spaceId])
REFERENCES[dbo].[Space]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[SpaceSpaceFeature] CHECK CONSTRAINT[FK_SpaceSpaceFeature_spaceId_Space_id]
GO
ALTER TABLE[dbo].[SpaceSpaceFeature]  WITH CHECK ADD  CONSTRAINT[FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id] FOREIGN KEY([spaceFeatureId])
REFERENCES[dbo].[SpaceFeature]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[SpaceSpaceFeature] CHECK CONSTRAINT[FK_SpaceSpaceFeature_spaceFeatureId_SpaceFeature_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[FK_Student_familyId_Family_id] FOREIGN KEY([familyId])
REFERENCES[dbo].[Family]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[FK_Student_familyId_Family_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[FK_Student_userId_User_id] FOREIGN KEY([userId])
REFERENCES[dbo].[User]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[FK_Student_userId_User_id]
GO
ALTER TABLE[dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT[FK_Teacher_userId_User_id] FOREIGN KEY([userId])
REFERENCES[dbo].[User]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Teacher] CHECK CONSTRAINT[FK_Teacher_userId_User_id]
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]  WITH CHECK ADD  CONSTRAINT[FK_TeacherTeacherSkill_teacherId_Teacher_id] FOREIGN KEY([teacherId])
REFERENCES[dbo].[Teacher]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[TeacherTeacherSkill] CHECK CONSTRAINT[FK_TeacherTeacherSkill_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[TeacherTeacherSkill]  WITH CHECK ADD  CONSTRAINT[FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id] FOREIGN KEY([teacherSkillId])
REFERENCES[dbo].[TeacherSkill]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[TeacherTeacherSkill] CHECK CONSTRAINT[FK_TeacherTeacherSkill_teacherSkillId_TeacherSkill_id]
GO

SET IDENTITY_INSERT [dbo].[EventStatus] ON 

GO
INSERT [dbo].[EventStatus] ([id], [name],[isDeleted]) VALUES ( 1, N'Pending', 0)
GO
INSERT [dbo].[EventStatus] ([id], [name],[isDeleted]) VALUES ( 2, N'Started', 0)
GO
INSERT [dbo].[EventStatus] ([id], [name],[isDeleted]) VALUES ( 3, N'Completed', 0)
GO
INSERT [dbo].[EventStatus] ([id], [name],[isDeleted]) VALUES ( 4, N'Rescheduled', 0)
GO
INSERT [dbo].[EventStatus] ([id], [name],[isDeleted]) VALUES ( 5, N'No Show', 0)
GO
SET IDENTITY_INSERT [dbo].[EventStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Event] ON 

GO
INSERT [dbo].[Event] ([actualEndDate], [actualStartDate], [billAmount], [eventStatusId], [id], [scheduledEndDate], [scheduledStartDate], [studentNotes], [teacherNotes],[isDeleted]) VALUES ( NULL, NULL, NULL, 1, 1, CAST(N'2018-10-10 20:41:15.017' AS DateTime), CAST(N'2018-10-03 20:41:15.017' AS DateTime), NULL, NULL, 0)
GO
INSERT [dbo].[Event] ([actualEndDate], [actualStartDate], [billAmount], [eventStatusId], [id], [scheduledEndDate], [scheduledStartDate], [studentNotes], [teacherNotes],[isDeleted]) VALUES ( NULL, NULL, NULL, 1, 2, CAST(N'2018-10-30 20:41:15.017' AS DateTime), CAST(N'2018-10-24 20:41:15.017' AS DateTime), NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Event] OFF
GO
SET IDENTITY_INSERT [dbo].[Family] ON 

GO
INSERT [dbo].[Family] ([id], [notes], [primaryContactEmail], [primaryContactFirstName], [primaryContactLastName], [primaryContactPhone],[isDeleted]) VALUES ( 1, NULL, N'test', N'test', N'test', N'test', 0)
GO
SET IDENTITY_INSERT [dbo].[Family] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([id], [password], [username],[isDeleted]) VALUES ( 1, N'password', N'student', 0)
GO
INSERT [dbo].[User] ([id], [password], [username],[isDeleted]) VALUES ( 2, N'password', N'teacher', 0)
GO
INSERT [dbo].[User] ([id], [password], [username],[isDeleted]) VALUES ( 3, N'password', N'admin', 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

GO
INSERT [dbo].[Student] ([birthday], [email], [emailRemindersEnabled], [familyId], [firstName], [id], [isAdult], [lastName], [phone], [smsRemindersEnabled], [userId],[isDeleted]) VALUES ( CAST(N'2018-10-03' AS Date), N'test@test.com', 0, 1, N'John', 1, 0, N'Doe', N'9407279332', 0, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO

INSERT [dbo].[EventStudent] ([eventId], [studentId],[isDeleted]) VALUES ( 1, 1, 0)
GO
INSERT [dbo].[EventStudent] ([eventId],  [studentId],[isDeleted]) VALUES ( 2,  1, 0)

GO
SET IDENTITY_INSERT [dbo].[Space] ON 

GO
INSERT [dbo].[Space] ([description], [id], [name],[isDeleted]) VALUES ( N'studio1', 1, N'studio1', 0)
GO
INSERT [dbo].[Space] ([description], [id], [name],[isDeleted]) VALUES ( N'studio2', 2, N'studio2', 0)
GO
SET IDENTITY_INSERT [dbo].[Space] OFF
GO
SET IDENTITY_INSERT [dbo].[SpaceFeature] ON 

GO
INSERT [dbo].[SpaceFeature] ([id], [name],[isDeleted]) VALUES ( 1, N'whiteboard', 0)
GO
INSERT [dbo].[SpaceFeature] ([id], [name],[isDeleted]) VALUES ( 2, N'guitar amp', 0)
GO
INSERT [dbo].[SpaceFeature] ([id], [name],[isDeleted]) VALUES ( 3, N'piano', 0)
GO
SET IDENTITY_INSERT [dbo].[SpaceFeature] OFF


GO
INSERT [dbo].[SpaceSpaceFeature] ([spaceFeatureId], [spaceId],[isDeleted]) VALUES (  1, 1, 0)
GO
INSERT [dbo].[SpaceSpaceFeature] ( [spaceFeatureId], [spaceId],[isDeleted]) VALUES (  2, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

GO
INSERT [dbo].[Teacher] ([birthday], [email], [firstName], [id], [lastName], [phone], [userId],[isDeleted]) VALUES ( CAST(N'2018-10-03' AS Date), N'test@test.com', N'test', 1, N'lastname', N'9407279332', 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[TeacherSkill] ON 

GO
INSERT [dbo].[TeacherSkill] ([id], [name],[isDeleted]) VALUES ( 1, N'Guitar', 0)
GO
INSERT [dbo].[TeacherSkill] ([id], [name],[isDeleted]) VALUES ( 2, N'Piano', 0)
GO
SET IDENTITY_INSERT [dbo].[TeacherSkill] OFF
GO
SET IDENTITY_INSERT [dbo].[Rate] ON 

GO
INSERT [dbo].[Rate] ([amountPerMinute], [id], [teacherId], [teacherSkillId],[isDeleted]) VALUES ( 1.0000, 1, 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Rate] OFF
GO

INSERT [dbo].[TeacherTeacherSkill] ( [teacherId], [teacherSkillId],[isDeleted]) VALUES (  1, 1, 0)
GO
INSERT [dbo].[TeacherTeacherSkill] ( [teacherId], [teacherSkillId],[isDeleted]) VALUES (  1, 2, 0)
GO

INSERT [dbo].[EventTeacher] ([eventId],  [teacherId],[isDeleted]) VALUES ( 1,  1, 0)
GO
INSERT [dbo].[EventTeacher] ([eventId],  [teacherId],[isDeleted]) VALUES ( 2,  1, 0)
GO
SET IDENTITY_INSERT [dbo].[Studio] ON 

GO
INSERT [dbo].[Studio] ([address1], [address2], [city], [id], [name], [province], [website], [zip], [isDeleted]) VALUES ( N'123 FAKE ST', N'SWE 2', N'Austin', 2, N'Test STudio', N'TX', N'https://www.codenesium.com', N'787478', 0)
GO
SET IDENTITY_INSERT [dbo].[Studio] OFF
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

GO
INSERT [dbo].[Admin] ([birthday], [email], [firstName], [id], [lastName], [phone], [userId],[isDeleted]) VALUES ( CAST(N'2018-10-03' AS Date), N'admin@gmail.com', N'travis', 1, N'taylor', N'94072793332', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}