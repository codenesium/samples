using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTenantRequestModel : AbstractApiRequestModel
        {
                public ApiTenantRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        byte[] dataVersion,
                        string jSON,
                        string name,
                        string projectIds,
                        string tenantTags)
                {
                        this.DataVersion = dataVersion;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectIds = projectIds;
                        this.TenantTags = tenantTags;
                }

                [JsonProperty]
                public byte[] DataVersion { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public string ProjectIds { get; private set; }

                [JsonProperty]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>10422d709aa378f20a839dbdd78cce4b</Hash>
</Codenesium>*/