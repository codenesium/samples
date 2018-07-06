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

                public string Id { get; private set; }

                public string IncludedEnvironmentIds { get; private set; }

                public string IncludedProjectIds { get; private set; }

                public string IncludedTenantIds { get; private set; }

                public string IncludedTenantTags { get; private set; }

                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9fe8b26a3ff5ddce8ff6c53cb902bfad</Hash>
</Codenesium>*/