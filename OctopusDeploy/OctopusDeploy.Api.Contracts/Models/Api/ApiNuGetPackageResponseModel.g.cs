using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public class ApiNuGetPackageResponseModel : AbstractApiResponseModel
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

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePackageIdValue { get; set; } = true;

                public bool ShouldSerializePackageId()
                {
                        return this.ShouldSerializePackageIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionValue { get; set; } = true;

                public bool ShouldSerializeVersion()
                {
                        return this.ShouldSerializeVersionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionBuildValue { get; set; } = true;

                public bool ShouldSerializeVersionBuild()
                {
                        return this.ShouldSerializeVersionBuildValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionMajorValue { get; set; } = true;

                public bool ShouldSerializeVersionMajor()
                {
                        return this.ShouldSerializeVersionMajorValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionMinorValue { get; set; } = true;

                public bool ShouldSerializeVersionMinor()
                {
                        return this.ShouldSerializeVersionMinorValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionRevisionValue { get; set; } = true;

                public bool ShouldSerializeVersionRevision()
                {
                        return this.ShouldSerializeVersionRevisionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionSpecialValue { get; set; } = true;

                public bool ShouldSerializeVersionSpecial()
                {
                        return this.ShouldSerializeVersionSpecialValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializePackageIdValue = false;
                        this.ShouldSerializeVersionValue = false;
                        this.ShouldSerializeVersionBuildValue = false;
                        this.ShouldSerializeVersionMajorValue = false;
                        this.ShouldSerializeVersionMinorValue = false;
                        this.ShouldSerializeVersionRevisionValue = false;
                        this.ShouldSerializeVersionSpecialValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a59673267d3911566696504b69fdc0fa</Hash>
</Codenesium>*/