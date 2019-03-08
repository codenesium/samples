using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using ESPIOTPostgresNS.Api.DataAccess;

namespace ESPIOTPostgresNS.Api.DataAccess.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
    [Migration("00000000000000_InitialCreate")]
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"CREATE SCHEMA IF NOT EXISTS ""dbo"";

--ALTER TABLE ""dbo"".""DeviceAction"" DISABLE TRIGGER ALL;

--DROP TABLE IF EXISTS ""dbo"".""Device"";
--DROP TABLE IF EXISTS ""dbo"".""DeviceAction"";

CREATE TABLE ""dbo"".""Device""(
""id""  SERIAL ,
""publicId"" uuid    NOT NULL,
""name"" character varying  (90)  NOT NULL);

CREATE TABLE ""dbo"".""DeviceAction""(
""id""  SERIAL ,
""deviceId"" integer    NOT NULL,
""name"" character varying  (90)  NOT NULL,
""action"" character varying  (128)  NOT NULL);

CREATE UNIQUE INDEX ""IX_Device"" ON ""dbo"".""Device""
(
""publicId"" ASC);
ALTER TABLE ""dbo"".""Device""
ADD CONSTRAINT ""PK_Device""
PRIMARY KEY
(
""id""
);
CREATE  INDEX ""IX_DeviceAction_DeviceId"" ON ""dbo"".""DeviceAction""
(
""deviceId"" ASC);
ALTER TABLE ""dbo"".""DeviceAction""
ADD CONSTRAINT ""PK_Action""
PRIMARY KEY
(
""id""
);


ALTER TABLE ""dbo"".""DeviceAction"" ADD CONSTRAINT ""FK_DeviceAction_Device"" FOREIGN KEY(""deviceId"")
REFERENCES ""dbo"".""Device"" (""id"");

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}