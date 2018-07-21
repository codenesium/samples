using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTeamResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string environmentIds,
                        string jSON,
                        string memberUserIds,
                        string name,
                        string projectGroupIds,
                        string projectIds,
                        string tenantIds,
                        string tenantTags)
                {
                        this.Id = id;
                        this.EnvironmentIds = environmentIds;
                        this.JSON = jSON;
                        this.MemberUserIds = memberUserIds;
                        this.Name = name;
                        this.ProjectGroupIds = projectGroupIds;
                        this.ProjectIds = projectIds;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                }

                [Required]
                [JsonProperty]
                public string EnvironmentIds { get; private set; }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }

                [Required]
                [JsonProperty]
                public string MemberUserIds { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public string ProjectGroupIds { get; private set; }

                [Required]
                [JsonProperty]
                public string ProjectIds { get; private set; }

                [Required]
                [JsonProperty]
                public string TenantIds { get; private set; }

                [Required]
                [JsonProperty]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d8d5fd0905e681bdccc7a8f351479feb</Hash>
</Codenesium>*/