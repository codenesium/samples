using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using CADNS.Api.DataAccess;

namespace CADNS.Api.DataAccess.Migrations
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

--IF (OBJECT_ID('dbo.FK_Call_callDispositionId_CallDisposition_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Call] DROP CONSTRAINT [FK_Call_callDispositionId_CallDisposition_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Call_callStatusId_CallStatus_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Call] DROP CONSTRAINT [FK_Call_callStatusId_CallStatus_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Call_callTypeId_CallType_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Call] DROP CONSTRAINT [FK_Call_callTypeId_CallType_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Call_addressId_Address_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Call] DROP CONSTRAINT [FK_Call_addressId_Address_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_callassignment_callid_call_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[CallAssignment] DROP CONSTRAINT [fk_callassignment_callid_call_id]
--END
--GO
--IF (OBJECT_ID('dbo.fk_callassignment_unitid_unit_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[CallAssignment] DROP CONSTRAINT [fk_callassignment_unitid_unit_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_CallPerson_personId_Person_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[CallPerson] DROP CONSTRAINT [FK_CallPerson_personId_Person_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_CallPerson_personTypeId_PersonType_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[CallPerson] DROP CONSTRAINT [FK_CallPerson_personTypeId_PersonType_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Note_callId_Call_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Note] DROP CONSTRAINT [FK_Note_callId_Call_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Note_officerId_Officer_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Note] DROP CONSTRAINT [FK_Note_officerId_Officer_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_OfficerRefCapability_officerId_Officer_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[OfficerCapabilities] DROP CONSTRAINT [FK_OfficerRefCapability_officerId_Officer_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_OfficerRefCapability_capabilityId_OfficerCapability_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[OfficerCapabilities] DROP CONSTRAINT [FK_OfficerRefCapability_capabilityId_OfficerCapability_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_UnitOfficer_unitId_Unit_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[UnitOfficer] DROP CONSTRAINT [FK_UnitOfficer_unitId_Unit_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_UnitOfficer_officerId_Officer_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[UnitOfficer] DROP CONSTRAINT [FK_UnitOfficer_officerId_Officer_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_VehicleRefCapability_vehicleId_Vehicle_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[VehicleCapabilities] DROP CONSTRAINT [FK_VehicleRefCapability_vehicleId_Vehicle_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_VehicleRefCapability_vehicleCapabilityId_VehicleCapability_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[VehicleCapabilities] DROP CONSTRAINT [FK_VehicleRefCapability_vehicleCapabilityId_VehicleCapability_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_VehicleOfficer_vehicleId_Vehicle_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[VehicleOfficer] DROP CONSTRAINT [FK_VehicleOfficer_vehicleId_Vehicle_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_VehicleOfficer_officerId_Officer_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[VehicleOfficer] DROP CONSTRAINT [FK_VehicleOfficer_officerId_Officer_id]
--END
--GO

--IF OBJECT_ID('dbo.Address', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Address]
--END
--GO
--IF OBJECT_ID('dbo.Call', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Call]
--END
--GO
--IF OBJECT_ID('dbo.CallAssignment', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[CallAssignment]
--END
--GO
--IF OBJECT_ID('dbo.CallDisposition', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[CallDisposition]
--END
--GO
--IF OBJECT_ID('dbo.CallPerson', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[CallPerson]
--END
--GO
--IF OBJECT_ID('dbo.CallStatus', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[CallStatus]
--END
--GO
--IF OBJECT_ID('dbo.CallType', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[CallType]
--END
--GO
--IF OBJECT_ID('dbo.Note', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Note]
--END
--GO
--IF OBJECT_ID('dbo.OffCapability', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[OffCapability]
--END
--GO
--IF OBJECT_ID('dbo.Officer', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Officer]
--END
--GO
--IF OBJECT_ID('dbo.OfficerCapabilities', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[OfficerCapabilities]
--END
--GO
--IF OBJECT_ID('dbo.Person', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Person]
--END
--GO
--IF OBJECT_ID('dbo.PersonType', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[PersonType]
--END
--GO
--IF OBJECT_ID('dbo.Unit', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Unit]
--END
--GO
--IF OBJECT_ID('dbo.UnitDisposition', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[UnitDisposition]
--END
--GO
--IF OBJECT_ID('dbo.UnitOfficer', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[UnitOfficer]
--END
--GO
--IF OBJECT_ID('dbo.VehCapability', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[VehCapability]
--END
--GO
--IF OBJECT_ID('dbo.Vehicle', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Vehicle]
--END
--GO
--IF OBJECT_ID('dbo.VehicleCapabilities', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[VehicleCapabilities]
--END
--GO
--IF OBJECT_ID('dbo.VehicleOfficer', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[VehicleOfficer]
--END
--GO

CREATE TABLE [dbo].[Address](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[address1] [varchar]  (128)   NOT NULL,
[address2] [varchar]  (128)   NULL,
[city] [varchar]  (128)   NOT NULL,
[state] [varchar]  (2)   NOT NULL,
[zip] [varchar]  (12)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Call](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[addressId] [int]     NULL,
[callDispositionId] [int]     NULL,
[callStatusId] [int]     NULL,
[callString] [varchar]  (24)   NOT NULL,
[callTypeId] [int]     NULL,
[dateCleared] [datetime]     NULL,
[dateCreated] [datetime]     NOT NULL,
[dateDispatched] [datetime]     NULL,
[quickCallNumber] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[CallAssignment](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[callId] [int]     NOT NULL,
[unitId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[CallDisposition](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[CallPerson](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[note] [varchar]  (8000)   NULL,
[personId] [int]     NOT NULL,
[personTypeId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[CallStatus](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[CallType](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Note](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[callId] [int]     NOT NULL,
[dateCreated] [datetime]     NOT NULL,
[noteText] [varchar]  (8000)   NOT NULL,
[officerId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[OffCapability](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Officer](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[badge] [varchar]  (128)   NULL,
[email] [varchar]  (128)   NOT NULL,
[firstName] [varchar]  (128)   NOT NULL,
[lastName] [varchar]  (128)   NOT NULL,
[password] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[OfficerCapabilities](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[capabilityId] [int]     NOT NULL,
[officerId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Person](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[firstName] [varchar]  (128)   NULL,
[lastName] [varchar]  (128)   NULL,
[phone] [varchar]  (32)   NULL,
[ssn] [varchar]  (12)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[PersonType](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Unit](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[callSign] [varchar]  (128)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[UnitDisposition](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[UnitOfficer](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[officerId] [int]     NOT NULL,
[unitId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[VehCapability](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Vehicle](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[name] [varchar]  (128)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[VehicleCapabilities](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[vehicleCapabilityId] [int]     NOT NULL,
[vehicleId] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[VehicleOfficer](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[officerId] [int]     NOT NULL,
[vehicleId] [int]     NOT NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Address]
ADD CONSTRAINT[PK_Address] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Call]
ADD CONSTRAINT[PK_Call] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_CallAssignment_callId] ON[dbo].[CallAssignment]
(
[callId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_CallAssignment_unitId] ON[dbo].[CallAssignment]
(
[unitId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[CallAssignment]
ADD CONSTRAINT[PK_CallAssignment] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[CallDisposition]
ADD CONSTRAINT[PK_CallDisposition] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[CallPerson]
ADD CONSTRAINT[PK_CallPerson] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[CallStatus]
ADD CONSTRAINT[PK_CallStatus] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[CallType]
ADD CONSTRAINT[PK_CallType] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Note]
ADD CONSTRAINT[PK_Note] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[OffCapability]
ADD CONSTRAINT[PK_OfficerCapability] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Officer]
ADD CONSTRAINT[PK_Officer] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[OfficerCapabilities]
ADD CONSTRAINT[PK_OfficerCapabilities] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Person]
ADD CONSTRAINT[PK_Person] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[PersonType]
ADD CONSTRAINT[PK_PersonType] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Unit]
ADD CONSTRAINT[PK_Unit] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[UnitDisposition]
ADD CONSTRAINT[PK_UnitDisposition] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[UnitOfficer]
ADD CONSTRAINT[PK_UnitOfficer] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[VehCapability]
ADD CONSTRAINT[PK_VehicleCapability] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Vehicle]
ADD CONSTRAINT[PK_Vehicle] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[VehicleCapabilities]
ADD CONSTRAINT[PK_VehicleCapabilities] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_VehicleOfficer_officerId] ON[dbo].[VehicleOfficer]
(
[officerId] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[VehicleOfficer]
ADD CONSTRAINT[PK_VehicleOfficer] PRIMARY KEY 
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[Call]  WITH CHECK ADD  CONSTRAINT[FK_Call_callDispositionId_CallDisposition_id] FOREIGN KEY([callDispositionId])
REFERENCES[dbo].[CallDisposition]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Call] CHECK CONSTRAINT[FK_Call_callDispositionId_CallDisposition_id]
GO
ALTER TABLE[dbo].[Call]  WITH CHECK ADD  CONSTRAINT[FK_Call_callStatusId_CallStatus_id] FOREIGN KEY([callStatusId])
REFERENCES[dbo].[CallStatus]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Call] CHECK CONSTRAINT[FK_Call_callStatusId_CallStatus_id]
GO
ALTER TABLE[dbo].[Call]  WITH CHECK ADD  CONSTRAINT[FK_Call_callTypeId_CallType_id] FOREIGN KEY([callTypeId])
REFERENCES[dbo].[CallType]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Call] CHECK CONSTRAINT[FK_Call_callTypeId_CallType_id]
GO
ALTER TABLE[dbo].[Call]  WITH CHECK ADD  CONSTRAINT[FK_Call_addressId_Address_id] FOREIGN KEY([addressId])
REFERENCES[dbo].[Address]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Call] CHECK CONSTRAINT[FK_Call_addressId_Address_id]
GO
ALTER TABLE[dbo].[CallAssignment]  WITH CHECK ADD  CONSTRAINT[fk_callassignment_callid_call_id] FOREIGN KEY([callId])
REFERENCES[dbo].[Call]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[CallAssignment] CHECK CONSTRAINT[fk_callassignment_callid_call_id]
GO
ALTER TABLE[dbo].[CallAssignment]  WITH CHECK ADD  CONSTRAINT[fk_callassignment_unitid_unit_id] FOREIGN KEY([unitId])
REFERENCES[dbo].[Unit]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[CallAssignment] CHECK CONSTRAINT[fk_callassignment_unitid_unit_id]
GO
ALTER TABLE[dbo].[CallPerson]  WITH CHECK ADD  CONSTRAINT[FK_CallPerson_personId_Person_id] FOREIGN KEY([personId])
REFERENCES[dbo].[Person]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[CallPerson] CHECK CONSTRAINT[FK_CallPerson_personId_Person_id]
GO
ALTER TABLE[dbo].[CallPerson]  WITH CHECK ADD  CONSTRAINT[FK_CallPerson_personTypeId_PersonType_id] FOREIGN KEY([personTypeId])
REFERENCES[dbo].[PersonType]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[CallPerson] CHECK CONSTRAINT[FK_CallPerson_personTypeId_PersonType_id]
GO
ALTER TABLE[dbo].[Note]  WITH CHECK ADD  CONSTRAINT[FK_Note_callId_Call_id] FOREIGN KEY([callId])
REFERENCES[dbo].[Call]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Note] CHECK CONSTRAINT[FK_Note_callId_Call_id]
GO
ALTER TABLE[dbo].[Note]  WITH CHECK ADD  CONSTRAINT[FK_Note_officerId_Officer_id] FOREIGN KEY([officerId])
REFERENCES[dbo].[Officer]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Note] CHECK CONSTRAINT[FK_Note_officerId_Officer_id]
GO
ALTER TABLE[dbo].[OfficerCapabilities]  WITH CHECK ADD  CONSTRAINT[FK_OfficerRefCapability_officerId_Officer_id] FOREIGN KEY([officerId])
REFERENCES[dbo].[Officer]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[OfficerCapabilities] CHECK CONSTRAINT[FK_OfficerRefCapability_officerId_Officer_id]
GO
ALTER TABLE[dbo].[OfficerCapabilities]  WITH CHECK ADD  CONSTRAINT[FK_OfficerRefCapability_capabilityId_OfficerCapability_id] FOREIGN KEY([capabilityId])
REFERENCES[dbo].[OffCapability]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[OfficerCapabilities] CHECK CONSTRAINT[FK_OfficerRefCapability_capabilityId_OfficerCapability_id]
GO
ALTER TABLE[dbo].[UnitOfficer]  WITH CHECK ADD  CONSTRAINT[FK_UnitOfficer_unitId_Unit_id] FOREIGN KEY([unitId])
REFERENCES[dbo].[Unit]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[UnitOfficer] CHECK CONSTRAINT[FK_UnitOfficer_unitId_Unit_id]
GO
ALTER TABLE[dbo].[UnitOfficer]  WITH CHECK ADD  CONSTRAINT[FK_UnitOfficer_officerId_Officer_id] FOREIGN KEY([officerId])
REFERENCES[dbo].[Officer]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[UnitOfficer] CHECK CONSTRAINT[FK_UnitOfficer_officerId_Officer_id]
GO
ALTER TABLE[dbo].[VehicleCapabilities]  WITH CHECK ADD  CONSTRAINT[FK_VehicleRefCapability_vehicleId_Vehicle_id] FOREIGN KEY([vehicleId])
REFERENCES[dbo].[Vehicle]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[VehicleCapabilities] CHECK CONSTRAINT[FK_VehicleRefCapability_vehicleId_Vehicle_id]
GO
ALTER TABLE[dbo].[VehicleCapabilities]  WITH CHECK ADD  CONSTRAINT[FK_VehicleRefCapability_vehicleCapabilityId_VehicleCapability_id] FOREIGN KEY([vehicleCapabilityId])
REFERENCES[dbo].[VehCapability]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[VehicleCapabilities] CHECK CONSTRAINT[FK_VehicleRefCapability_vehicleCapabilityId_VehicleCapability_id]
GO
ALTER TABLE[dbo].[VehicleOfficer]  WITH CHECK ADD  CONSTRAINT[FK_VehicleOfficer_vehicleId_Vehicle_id] FOREIGN KEY([vehicleId])
REFERENCES[dbo].[Vehicle]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[VehicleOfficer] CHECK CONSTRAINT[FK_VehicleOfficer_vehicleId_Vehicle_id]
GO
ALTER TABLE[dbo].[VehicleOfficer]  WITH CHECK ADD  CONSTRAINT[FK_VehicleOfficer_officerId_Officer_id] FOREIGN KEY([officerId])
REFERENCES[dbo].[Officer]([id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[VehicleOfficer] CHECK CONSTRAINT[FK_VehicleOfficer_officerId_Officer_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}