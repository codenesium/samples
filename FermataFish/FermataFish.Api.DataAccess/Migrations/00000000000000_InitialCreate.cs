using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.DataAccess.Migrations
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

IF (OBJECT_ID('FK_Admin_studioId_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Admin] DROP CONSTRAINT [FK_Admin_studioId_Studio_id]
END
GO
IF (OBJECT_ID('FK_Family_id_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Family] DROP CONSTRAINT [FK_Family_id_Studio_id]
END
GO
IF (OBJECT_ID('FK_Family_studioId_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Family] DROP CONSTRAINT [FK_Family_studioId_Studio_id]
END
GO
IF (OBJECT_ID('FK_Lesson_lessonStatusId_LessonStatus_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Lesson] DROP CONSTRAINT [FK_Lesson_lessonStatusId_LessonStatus_id]
END
GO
IF (OBJECT_ID('FK_Lesson_studioId_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Lesson] DROP CONSTRAINT [FK_Lesson_studioId_Studio_id]
END
GO
IF (OBJECT_ID('FK_LessonStatus_id_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[LessonStatus] DROP CONSTRAINT [FK_LessonStatus_id_Studio_id]
END
GO
IF (OBJECT_ID('FK_LessonStatus_studioId_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[LessonStatus] DROP CONSTRAINT [FK_LessonStatus_studioId_Studio_id]
END
GO
IF (OBJECT_ID('FK_LessonXStudent_lessonId_Lesson_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[LessonXStudent] DROP CONSTRAINT [FK_LessonXStudent_lessonId_Lesson_id]
END
GO
IF (OBJECT_ID('FK_LessonXStudent_studentId_Student_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[LessonXStudent] DROP CONSTRAINT [FK_LessonXStudent_studentId_Student_id]
END
GO
IF (OBJECT_ID('FK_LessonXTeacher_lessonId_Lesson_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[LessonXTeacher] DROP CONSTRAINT [FK_LessonXTeacher_lessonId_Lesson_id]
END
GO
IF (OBJECT_ID('FK_LessonXTeacher_studentId_Student_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[LessonXTeacher] DROP CONSTRAINT [FK_LessonXTeacher_studentId_Student_id]
END
GO
IF (OBJECT_ID('FK_Rate_teacherId_Teacher_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Rate] DROP CONSTRAINT [FK_Rate_teacherId_Teacher_id]
END
GO
IF (OBJECT_ID('FK_Rate_teacherSkillId_TeacherSkill_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Rate] DROP CONSTRAINT [FK_Rate_teacherSkillId_TeacherSkill_id]
END
GO
IF (OBJECT_ID('FK_Space_studioId_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Space] DROP CONSTRAINT [FK_Space_studioId_Studio_id]
END
GO
IF (OBJECT_ID('FK_SpaceFeature_studioId_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[SpaceFeature] DROP CONSTRAINT [FK_SpaceFeature_studioId_Studio_id]
END
GO
IF (OBJECT_ID('FK_SpaceXSpaceFeature_spaceFeatureId_SpaceFeature_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[SpaceXSpaceFeature] DROP CONSTRAINT [FK_SpaceXSpaceFeature_spaceFeatureId_SpaceFeature_id]
END
GO
IF (OBJECT_ID('FK_SpaceXSpaceFeature_spaceId_Space_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[SpaceXSpaceFeature] DROP CONSTRAINT [FK_SpaceXSpaceFeature_spaceId_Space_id]
END
GO
IF (OBJECT_ID('FK_Student_familyId_Family_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Student] DROP CONSTRAINT [FK_Student_familyId_Family_id]
END
GO
IF (OBJECT_ID('FK_Student_studioId_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Student] DROP CONSTRAINT [FK_Student_studioId_Studio_id]
END
GO
IF (OBJECT_ID('FK_StudentXFamily_familyId_Family_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[StudentXFamily] DROP CONSTRAINT [FK_StudentXFamily_familyId_Family_id]
END
GO
IF (OBJECT_ID('FK_StudentXFamily_studentId_Student_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[StudentXFamily] DROP CONSTRAINT [FK_StudentXFamily_studentId_Student_id]
END
GO
IF (OBJECT_ID('FK_Studio_stateId_State_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Studio] DROP CONSTRAINT [FK_Studio_stateId_State_id]
END
GO
IF (OBJECT_ID('FK_Teacher_studioId_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[Teacher] DROP CONSTRAINT [FK_Teacher_studioId_Studio_id]
END
GO
IF (OBJECT_ID('FK_TeacherSkill_studioId_Studio_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[TeacherSkill] DROP CONSTRAINT [FK_TeacherSkill_studioId_Studio_id]
END
GO
IF (OBJECT_ID('FK_TeacherXTeacherSkill_teacherId_Teacher_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[TeacherXTeacherSkill] DROP CONSTRAINT [FK_TeacherXTeacherSkill_teacherId_Teacher_id]
END
GO
IF (OBJECT_ID('FK_TeacherXTeacherSkill_teacherSkillId_TeacherSkill_id', 'F') IS NOT NULL)
BEGIN
ALTER TABLE [dbo].[TeacherXTeacherSkill] DROP CONSTRAINT [FK_TeacherXTeacherSkill_teacherSkillId_TeacherSkill_id]
END
GO

IF OBJECT_ID('dbo.Admin', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Admin]
END
GO
IF OBJECT_ID('dbo.Family', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Family]
END
GO
IF OBJECT_ID('dbo.Lesson', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Lesson]
END
GO
IF OBJECT_ID('dbo.LessonStatus', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[LessonStatus]
END
GO
IF OBJECT_ID('dbo.LessonXStudent', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[LessonXStudent]
END
GO
IF OBJECT_ID('dbo.LessonXTeacher', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[LessonXTeacher]
END
GO
IF OBJECT_ID('dbo.Rate', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Rate]
END
GO
IF OBJECT_ID('dbo.Space', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Space]
END
GO
IF OBJECT_ID('dbo.SpaceFeature', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[SpaceFeature]
END
GO
IF OBJECT_ID('dbo.SpaceXSpaceFeature', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[SpaceXSpaceFeature]
END
GO
IF OBJECT_ID('dbo.State', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[State]
END
GO
IF OBJECT_ID('dbo.Student', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Student]
END
GO
IF OBJECT_ID('dbo.StudentXFamily', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[StudentXFamily]
END
GO
IF OBJECT_ID('dbo.Studio', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Studio]
END
GO
IF OBJECT_ID('dbo.Teacher', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[Teacher]
END
GO
IF OBJECT_ID('dbo.TeacherSkill', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[TeacherSkill]
END
GO
IF OBJECT_ID('dbo.TeacherXTeacherSkill', 'U') IS NOT NULL 
BEGIN
DROP TABLE [dbo].[TeacherXTeacherSkill]
END
GO

CREATE TABLE [dbo].[Admin](
[id] [int]   IDENTITY(1,1) NOT NULL,
[birthday] [date]    NULL,
[email] [varchar]  (128)  NOT NULL,
[firstName] [varchar]  (128)  NOT NULL,
[lastName] [varchar]  (128)  NOT NULL,
[phone] [varchar]  (128)  NOT NULL,
[studioId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Family](
[id] [int]   IDENTITY(1,1) NOT NULL,
[notes] [text]    NOT NULL,
[pcEmail] [varchar]  (128)  NOT NULL,
[pcFirstName] [varchar]  (128)  NOT NULL,
[pcLastName] [varchar]  (128)  NOT NULL,
[pcPhone] [varchar]  (128)  NOT NULL,
[studioId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Lesson](
[id] [int]   IDENTITY(1,1) NOT NULL,
[actualEndDate] [datetime]    NULL,
[actualStartDate] [date]    NULL,
[billAmount] [money]    NULL,
[lessonStatusId] [int]    NOT NULL,
[scheduledEndDate] [datetime]    NULL,
[scheduledStartDate] [datetime]    NULL,
[studentNotes] [text]    NULL,
[studioId] [int]    NOT NULL,
[teacherNotes] [text]    NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[LessonStatus](
[id] [int]   IDENTITY(1,1) NOT NULL,
[name] [varchar]  (128)  NOT NULL,
[studioId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[LessonXStudent](
[id] [int]   IDENTITY(1,1) NOT NULL,
[lessonId] [int]    NOT NULL,
[studentId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[LessonXTeacher](
[id] [int]   IDENTITY(1,1) NOT NULL,
[lessonId] [int]    NOT NULL,
[studentId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Rate](
[id] [int]   IDENTITY(1,1) NOT NULL,
[amountPerMinute] [money]    NOT NULL,
[teacherId] [int]    NOT NULL,
[teacherSkillId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Space](
[id] [int]   IDENTITY(1,1) NOT NULL,
[description] [varchar]  (128)  NOT NULL,
[name] [varchar]  (128)  NOT NULL,
[studioId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[SpaceFeature](
[id] [int]   IDENTITY(1,1) NOT NULL,
[name] [varchar]  (128)  NOT NULL,
[studioId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[SpaceXSpaceFeature](
[id] [int]   IDENTITY(1,1) NOT NULL,
[spaceFeatureId] [int]    NOT NULL,
[spaceId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[State](
[id] [int]   IDENTITY(1,1) NOT NULL,
[name] [varchar]  (2)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Student](
[id] [int]   IDENTITY(1,1) NOT NULL,
[birthday] [date]    NOT NULL,
[email] [varchar]  (128)  NOT NULL,
[emailRemindersEnabled] [bit]    NOT NULL,
[familyId] [int]    NOT NULL,
[firstName] [varchar]  (128)  NOT NULL,
[isAdult] [bit]    NOT NULL,
[lastName] [varchar]  (128)  NOT NULL,
[phone] [varchar]  (128)  NOT NULL,
[smsRemindersEnabled] [bit]    NOT NULL,
[studioId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[StudentXFamily](
[id] [int]   IDENTITY(1,1) NOT NULL,
[familyId] [int]    NOT NULL,
[studentId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Studio](
[id] [int]   IDENTITY(1,1) NOT NULL,
[address1] [varchar]  (128)  NOT NULL,
[address2] [varchar]  (128)  NOT NULL,
[city] [varchar]  (128)  NOT NULL,
[name] [varchar]  (128)  NOT NULL,
[stateId] [int]    NOT NULL,
[website] [varchar]  (128)  NOT NULL,
[zip] [varchar]  (128)  NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Teacher](
[id] [int]   IDENTITY(1,1) NOT NULL,
[birthday] [date]    NOT NULL,
[email] [varchar]  (128)  NOT NULL,
[firstName] [varchar]  (128)  NOT NULL,
[lastName] [varchar]  (128)  NOT NULL,
[phone] [varchar]  (128)  NOT NULL,
[studioId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TeacherSkill](
[id] [int]   IDENTITY(1,1) NOT NULL,
[name] [varchar]  (128)  NOT NULL,
[studioId] [int]    NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[TeacherXTeacherSkill](
[id] [int]   IDENTITY(1,1) NOT NULL,
[teacherId] [int]    NOT NULL,
[teacherSkillId] [int]    NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Admin]
ADD CONSTRAINT[PK_Admin] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Family]
ADD CONSTRAINT[PK_Family] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Lesson]
ADD CONSTRAINT[PK_Lesson] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[LessonStatus]
ADD CONSTRAINT[PK_LessonStatus] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[LessonXStudent]
ADD CONSTRAINT[PK_LessonXStudent] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[LessonXTeacher]
ADD CONSTRAINT[PK_LessonXTeacher] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Rate]
ADD CONSTRAINT[PK_Rate] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Space]
ADD CONSTRAINT[PK_Space] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[SpaceFeature]
ADD CONSTRAINT[PK_SpaceFeature] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[SpaceXSpaceFeature]
ADD CONSTRAINT[PK_SpaceXSpaceFeature] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[State]
ADD CONSTRAINT[PK_State] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Student]
ADD CONSTRAINT[PK_Student] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[StudentXFamily]
ADD CONSTRAINT[PK_StudentXFamily] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Studio]
ADD CONSTRAINT[PK_Studio] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Teacher]
ADD CONSTRAINT[PK_Teacher] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TeacherSkill]
ADD CONSTRAINT[PK_TeacherSkill] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[TeacherXTeacherSkill]
ADD CONSTRAINT[PK_TeacherXTeacherSkill] PRIMARY KEY CLUSTERED
(
id ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

ALTER TABLE[dbo].[Admin]  WITH CHECK ADD  CONSTRAINT[FK_Admin_studioId_Studio_id] FOREIGN KEY([studioId])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[Admin] CHECK CONSTRAINT[FK_Admin_studioId_Studio_id]
GO
ALTER TABLE[dbo].[Family]  WITH CHECK ADD  CONSTRAINT[FK_Family_id_Studio_id] FOREIGN KEY([id])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[Family] CHECK CONSTRAINT[FK_Family_id_Studio_id]
GO
ALTER TABLE[dbo].[Family]  WITH CHECK ADD  CONSTRAINT[FK_Family_studioId_Studio_id] FOREIGN KEY([studioId])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[Family] CHECK CONSTRAINT[FK_Family_studioId_Studio_id]
GO
ALTER TABLE[dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT[FK_Lesson_lessonStatusId_LessonStatus_id] FOREIGN KEY([lessonStatusId])
REFERENCES[dbo].[LessonStatus]([id])
GO
ALTER TABLE[dbo].[Lesson] CHECK CONSTRAINT[FK_Lesson_lessonStatusId_LessonStatus_id]
GO
ALTER TABLE[dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT[FK_Lesson_studioId_Studio_id] FOREIGN KEY([studioId])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[Lesson] CHECK CONSTRAINT[FK_Lesson_studioId_Studio_id]
GO
ALTER TABLE[dbo].[LessonStatus]  WITH CHECK ADD  CONSTRAINT[FK_LessonStatus_id_Studio_id] FOREIGN KEY([id])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[LessonStatus] CHECK CONSTRAINT[FK_LessonStatus_id_Studio_id]
GO
ALTER TABLE[dbo].[LessonStatus]  WITH CHECK ADD  CONSTRAINT[FK_LessonStatus_studioId_Studio_id] FOREIGN KEY([studioId])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[LessonStatus] CHECK CONSTRAINT[FK_LessonStatus_studioId_Studio_id]
GO
ALTER TABLE[dbo].[LessonXStudent]  WITH CHECK ADD  CONSTRAINT[FK_LessonXStudent_lessonId_Lesson_id] FOREIGN KEY([lessonId])
REFERENCES[dbo].[Lesson]([id])
GO
ALTER TABLE[dbo].[LessonXStudent] CHECK CONSTRAINT[FK_LessonXStudent_lessonId_Lesson_id]
GO
ALTER TABLE[dbo].[LessonXStudent]  WITH CHECK ADD  CONSTRAINT[FK_LessonXStudent_studentId_Student_id] FOREIGN KEY([studentId])
REFERENCES[dbo].[Student]([id])
GO
ALTER TABLE[dbo].[LessonXStudent] CHECK CONSTRAINT[FK_LessonXStudent_studentId_Student_id]
GO
ALTER TABLE[dbo].[LessonXTeacher]  WITH CHECK ADD  CONSTRAINT[FK_LessonXTeacher_lessonId_Lesson_id] FOREIGN KEY([lessonId])
REFERENCES[dbo].[Lesson]([id])
GO
ALTER TABLE[dbo].[LessonXTeacher] CHECK CONSTRAINT[FK_LessonXTeacher_lessonId_Lesson_id]
GO
ALTER TABLE[dbo].[LessonXTeacher]  WITH CHECK ADD  CONSTRAINT[FK_LessonXTeacher_studentId_Student_id] FOREIGN KEY([studentId])
REFERENCES[dbo].[Student]([id])
GO
ALTER TABLE[dbo].[LessonXTeacher] CHECK CONSTRAINT[FK_LessonXTeacher_studentId_Student_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[FK_Rate_teacherId_Teacher_id] FOREIGN KEY([teacherId])
REFERENCES[dbo].[Teacher]([id])
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[FK_Rate_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[Rate]  WITH CHECK ADD  CONSTRAINT[FK_Rate_teacherSkillId_TeacherSkill_id] FOREIGN KEY([teacherSkillId])
REFERENCES[dbo].[TeacherSkill]([id])
GO
ALTER TABLE[dbo].[Rate] CHECK CONSTRAINT[FK_Rate_teacherSkillId_TeacherSkill_id]
GO
ALTER TABLE[dbo].[Space]  WITH CHECK ADD  CONSTRAINT[FK_Space_studioId_Studio_id] FOREIGN KEY([studioId])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[Space] CHECK CONSTRAINT[FK_Space_studioId_Studio_id]
GO
ALTER TABLE[dbo].[SpaceFeature]  WITH CHECK ADD  CONSTRAINT[FK_SpaceFeature_studioId_Studio_id] FOREIGN KEY([studioId])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[SpaceFeature] CHECK CONSTRAINT[FK_SpaceFeature_studioId_Studio_id]
GO
ALTER TABLE[dbo].[SpaceXSpaceFeature]  WITH CHECK ADD  CONSTRAINT[FK_SpaceXSpaceFeature_spaceFeatureId_SpaceFeature_id] FOREIGN KEY([spaceFeatureId])
REFERENCES[dbo].[SpaceFeature]([id])
GO
ALTER TABLE[dbo].[SpaceXSpaceFeature] CHECK CONSTRAINT[FK_SpaceXSpaceFeature_spaceFeatureId_SpaceFeature_id]
GO
ALTER TABLE[dbo].[SpaceXSpaceFeature]  WITH CHECK ADD  CONSTRAINT[FK_SpaceXSpaceFeature_spaceId_Space_id] FOREIGN KEY([spaceId])
REFERENCES[dbo].[Space]([id])
GO
ALTER TABLE[dbo].[SpaceXSpaceFeature] CHECK CONSTRAINT[FK_SpaceXSpaceFeature_spaceId_Space_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[FK_Student_familyId_Family_id] FOREIGN KEY([familyId])
REFERENCES[dbo].[Family]([id])
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[FK_Student_familyId_Family_id]
GO
ALTER TABLE[dbo].[Student]  WITH CHECK ADD  CONSTRAINT[FK_Student_studioId_Studio_id] FOREIGN KEY([studioId])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[Student] CHECK CONSTRAINT[FK_Student_studioId_Studio_id]
GO
ALTER TABLE[dbo].[StudentXFamily]  WITH CHECK ADD  CONSTRAINT[FK_StudentXFamily_familyId_Family_id] FOREIGN KEY([familyId])
REFERENCES[dbo].[Family]([id])
GO
ALTER TABLE[dbo].[StudentXFamily] CHECK CONSTRAINT[FK_StudentXFamily_familyId_Family_id]
GO
ALTER TABLE[dbo].[StudentXFamily]  WITH CHECK ADD  CONSTRAINT[FK_StudentXFamily_studentId_Student_id] FOREIGN KEY([studentId])
REFERENCES[dbo].[Student]([id])
GO
ALTER TABLE[dbo].[StudentXFamily] CHECK CONSTRAINT[FK_StudentXFamily_studentId_Student_id]
GO
ALTER TABLE[dbo].[Studio]  WITH CHECK ADD  CONSTRAINT[FK_Studio_stateId_State_id] FOREIGN KEY([stateId])
REFERENCES[dbo].[State]([id])
GO
ALTER TABLE[dbo].[Studio] CHECK CONSTRAINT[FK_Studio_stateId_State_id]
GO
ALTER TABLE[dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT[FK_Teacher_studioId_Studio_id] FOREIGN KEY([studioId])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[Teacher] CHECK CONSTRAINT[FK_Teacher_studioId_Studio_id]
GO
ALTER TABLE[dbo].[TeacherSkill]  WITH CHECK ADD  CONSTRAINT[FK_TeacherSkill_studioId_Studio_id] FOREIGN KEY([studioId])
REFERENCES[dbo].[Studio]([id])
GO
ALTER TABLE[dbo].[TeacherSkill] CHECK CONSTRAINT[FK_TeacherSkill_studioId_Studio_id]
GO
ALTER TABLE[dbo].[TeacherXTeacherSkill]  WITH CHECK ADD  CONSTRAINT[FK_TeacherXTeacherSkill_teacherId_Teacher_id] FOREIGN KEY([teacherId])
REFERENCES[dbo].[Teacher]([id])
GO
ALTER TABLE[dbo].[TeacherXTeacherSkill] CHECK CONSTRAINT[FK_TeacherXTeacherSkill_teacherId_Teacher_id]
GO
ALTER TABLE[dbo].[TeacherXTeacherSkill]  WITH CHECK ADD  CONSTRAINT[FK_TeacherXTeacherSkill_teacherSkillId_TeacherSkill_id] FOREIGN KEY([teacherSkillId])
REFERENCES[dbo].[TeacherSkill]([id])
GO
ALTER TABLE[dbo].[TeacherXTeacherSkill] CHECK CONSTRAINT[FK_TeacherXTeacherSkill_teacherSkillId_TeacherSkill_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
          
		}
	}
};