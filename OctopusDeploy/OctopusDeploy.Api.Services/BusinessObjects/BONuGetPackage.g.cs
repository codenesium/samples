using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BONuGetPackage: AbstractBusinessObject
        {
                public BONuGetPackage() : base()
                {
                }

                public void SetProperties(string id,
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
    <Hash>6ef84a06ea45ca0177cf1d36e2664a14</Hash>
</Codenesium>*/