using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOTenant: AbstractBusinessObject
        {
                public BOTenant() : base()
                {
                }

                public void SetProperties(string id,
                                          byte[] dataVersion,
                                          string jSON,
                                          string name,
                                          string projectIds,
                                          string tenantTags)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectIds = projectIds;
                        this.TenantTags = tenantTags;
                }

                public byte[] DataVersion { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string ProjectIds { get; private set; }

                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>32f5473358c815131c104a115b48b4a2</Hash>
</Codenesium>*/