using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiNuGetPackageResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
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

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string PackageId { get; private set; }

                public string Version { get; private set; }

                public int VersionBuild { get; private set; }

                public int VersionMajor { get; private set; }

                public int VersionMinor { get; private set; }

                public int VersionRevision { get; private set; }

                public string VersionSpecial { get; private set; }
        }
}

/*<Codenesium>
    <Hash>112bc91753467671b20e24f91351bb5c</Hash>
</Codenesium>*/