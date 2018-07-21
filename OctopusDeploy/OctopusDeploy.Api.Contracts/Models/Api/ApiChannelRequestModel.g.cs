using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiChannelRequestModel : AbstractApiRequestModel
        {
                public ApiChannelRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        byte[] dataVersion,
                        string jSON,
                        string lifecycleId,
                        string name,
                        string projectId,
                        string tenantTags)
                {
                        this.DataVersion = dataVersion;
                        this.JSON = jSON;
                        this.LifecycleId = lifecycleId;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.TenantTags = tenantTags;
                }

                [JsonProperty]
                public byte[] DataVersion { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string LifecycleId { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public string ProjectId { get; private set; }

                [JsonProperty]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>eede5bb99b7fd8843bf3044f619a273b</Hash>
</Codenesium>*/