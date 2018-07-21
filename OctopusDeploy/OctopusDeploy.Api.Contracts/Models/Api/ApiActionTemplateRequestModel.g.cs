using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiActionTemplateRequestModel : AbstractApiRequestModel
        {
                public ApiActionTemplateRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string actionType,
                        string communityActionTemplateId,
                        string jSON,
                        string name,
                        int version)
                {
                        this.ActionType = actionType;
                        this.CommunityActionTemplateId = communityActionTemplateId;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Version = version;
                }

                [JsonProperty]
                public string ActionType { get; private set; }

                [JsonProperty]
                public string CommunityActionTemplateId { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5ff27e2297310af245e7562e6fc18f01</Hash>
</Codenesium>*/