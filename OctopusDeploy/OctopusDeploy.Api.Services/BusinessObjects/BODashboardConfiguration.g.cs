using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BODashboardConfiguration: AbstractBusinessObject
        {
                public BODashboardConfiguration() : base()
                {
                }

                public void SetProperties(string id,
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
    <Hash>8ed6e43cdbcfb72a01ce2c8eff2d10e1</Hash>
</Codenesium>*/