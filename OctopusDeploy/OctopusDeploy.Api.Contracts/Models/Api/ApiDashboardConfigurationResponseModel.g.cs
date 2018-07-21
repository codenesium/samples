using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiDashboardConfigurationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string includedEnvironmentIds,
                        string includedProjectIds,
                        string includedTenantIds,
                        string includedTenantTags,
                        string jSON)
                {
                        this.Id = id;
                        this.IncludedEnvironmentIds = includedEnvironmentIds;
                        this.IncludedProjectIds = includedProjectIds;
                        this.IncludedTenantIds = includedTenantIds;
                        this.IncludedTenantTags = includedTenantTags;
                        this.JSON = jSON;
                }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public string IncludedEnvironmentIds { get; private set; }

                [Required]
                [JsonProperty]
                public string IncludedProjectIds { get; private set; }

                [Required]
                [JsonProperty]
                public string IncludedTenantIds { get; private set; }

                [Required]
                [JsonProperty]
                public string IncludedTenantTags { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>de5b2c87d344ae05b8184818cee49fb0</Hash>
</Codenesium>*/