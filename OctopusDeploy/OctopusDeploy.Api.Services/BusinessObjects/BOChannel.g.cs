using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOChannel: AbstractBusinessObject
        {
                public BOChannel() : base()
                {
                }

                public void SetProperties(string id,
                                          byte[] dataVersion,
                                          string jSON,
                                          string lifecycleId,
                                          string name,
                                          string projectId,
                                          string tenantTags)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.LifecycleId = lifecycleId;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.TenantTags = tenantTags;
                }

                public byte[] DataVersion { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string LifecycleId { get; private set; }

                public string Name { get; private set; }

                public string ProjectId { get; private set; }

                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c7c0cc0ebb81cd1bafd020dbcdac6928</Hash>
</Codenesium>*/