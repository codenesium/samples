using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("NuGetPackage", Schema="dbo")]
        public partial class NuGetPackage: AbstractEntity
        {
                public NuGetPackage()
                {
                }

                public void SetProperties(
                        string id,
                        string jSON,
                        string packageId,
                        string version,
                        int versionBuild,
                        int versionMajor,
                        int versionMinor,
                        int versionRevision,
                        string versionSpecial)
                {
                        this.Id = id;
                        this.JSON = jSON;
                        this.PackageId = packageId;
                        this.Version = version;
                        this.VersionBuild = versionBuild;
                        this.VersionMajor = versionMajor;
                        this.VersionMinor = versionMinor;
                        this.VersionRevision = versionRevision;
                        this.VersionSpecial = versionSpecial;
                }

                [Key]
                [Column("Id", TypeName="nvarchar(450)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("PackageId", TypeName="nvarchar(100)")]
                public string PackageId { get; private set; }

                [Column("Version", TypeName="nvarchar(349)")]
                public string Version { get; private set; }

                [Column("VersionBuild", TypeName="int")]
                public int VersionBuild { get; private set; }

                [Column("VersionMajor", TypeName="int")]
                public int VersionMajor { get; private set; }

                [Column("VersionMinor", TypeName="int")]
                public int VersionMinor { get; private set; }

                [Column("VersionRevision", TypeName="int")]
                public int VersionRevision { get; private set; }

                [Column("VersionSpecial", TypeName="nvarchar(250)")]
                public string VersionSpecial { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f42ee2681e8d0e0c4746fec635d04e26</Hash>
</Codenesium>*/