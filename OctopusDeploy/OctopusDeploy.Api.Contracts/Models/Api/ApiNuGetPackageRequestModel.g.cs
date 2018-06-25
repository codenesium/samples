using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiNuGetPackageRequestModel : AbstractApiRequestModel
        {
                public ApiNuGetPackageRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string jSON,
                        string packageId,
                        string version,
                        int versionBuild,
                        int versionMajor,
                        int versionMinor,
                        int versionRevision,
                        string versionSpecial)
                {
                        this.JSON = jSON;
                        this.PackageId = packageId;
                        this.Version = version;
                        this.VersionBuild = versionBuild;
                        this.VersionMajor = versionMajor;
                        this.VersionMinor = versionMinor;
                        this.VersionRevision = versionRevision;
                        this.VersionSpecial = versionSpecial;
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string packageId;

                [Required]
                public string PackageId
                {
                        get
                        {
                                return this.packageId;
                        }

                        set
                        {
                                this.packageId = value;
                        }
                }

                private string version;

                [Required]
                public string Version
                {
                        get
                        {
                                return this.version;
                        }

                        set
                        {
                                this.version = value;
                        }
                }

                private int versionBuild;

                [Required]
                public int VersionBuild
                {
                        get
                        {
                                return this.versionBuild;
                        }

                        set
                        {
                                this.versionBuild = value;
                        }
                }

                private int versionMajor;

                [Required]
                public int VersionMajor
                {
                        get
                        {
                                return this.versionMajor;
                        }

                        set
                        {
                                this.versionMajor = value;
                        }
                }

                private int versionMinor;

                [Required]
                public int VersionMinor
                {
                        get
                        {
                                return this.versionMinor;
                        }

                        set
                        {
                                this.versionMinor = value;
                        }
                }

                private int versionRevision;

                [Required]
                public int VersionRevision
                {
                        get
                        {
                                return this.versionRevision;
                        }

                        set
                        {
                                this.versionRevision = value;
                        }
                }

                private string versionSpecial;

                public string VersionSpecial
                {
                        get
                        {
                                return this.versionSpecial;
                        }

                        set
                        {
                                this.versionSpecial = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>d32a990ef69d823c827788e9f36d5d7c</Hash>
</Codenesium>*/