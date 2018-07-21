using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTeamRequestModel : AbstractApiRequestModel
        {
                public ApiTeamRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string environmentIds,
                        string jSON,
                        string memberUserIds,
                        string name,
                        string projectGroupIds,
                        string projectIds,
                        string tenantIds,
                        string tenantTags)
                {
                        this.EnvironmentIds = environmentIds;
                        this.JSON = jSON;
                        this.MemberUserIds = memberUserIds;
                        this.Name = name;
                        this.ProjectGroupIds = projectGroupIds;
                        this.ProjectIds = projectIds;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                }

                [JsonProperty]
                public string EnvironmentIds { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string MemberUserIds { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public string ProjectGroupIds { get; private set; }

                [JsonProperty]
                public string ProjectIds { get; private set; }

                [JsonProperty]
                public string TenantIds { get; private set; }

                [JsonProperty]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>07ab20832d8facf83eaaeb0f4f5b9c21</Hash>
</Codenesium>*/