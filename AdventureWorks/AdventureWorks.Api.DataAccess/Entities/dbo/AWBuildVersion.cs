using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("AWBuildVersion", Schema="dbo")]
        public partial class AWBuildVersion: AbstractEntity
        {
                public AWBuildVersion()
                {
                }

                public void SetProperties(
                        string database_Version,
                        DateTime modifiedDate,
                        int systemInformationID,
                        DateTime versionDate)
                {
                        this.Database_Version = database_Version;
                        this.ModifiedDate = modifiedDate;
                        this.SystemInformationID = systemInformationID;
                        this.VersionDate = versionDate;
                }

                [Column("Database Version", TypeName="nvarchar(25)")]
                public string Database_Version { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("SystemInformationID", TypeName="tinyint")]
                public int SystemInformationID { get; private set; }

                [Column("VersionDate", TypeName="datetime")]
                public DateTime VersionDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>876cf10a4035e7e772b550b8893d2cd9</Hash>
</Codenesium>*/