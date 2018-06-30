using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBODashboardConfiguration : AbstractBusinessObject
        {
                public AbstractBODashboardConfiguration()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
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
    <Hash>64c683fbc98cad2130bbffc17e8a302e</Hash>
</Codenesium>*/