using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiActionTemplateVersionRequestModel : AbstractApiRequestModel
        {
                public ApiActionTemplateVersionRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string actionType,
                        string jSON,
                        string latestActionTemplateId,
                        string name,
                        int version)
                {
                        this.ActionType = actionType;
                        this.JSON = jSON;
                        this.LatestActionTemplateId = latestActionTemplateId;
                        this.Name = name;
                        this.Version = version;
                }

                [JsonProperty]
                public string ActionType { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string LatestActionTemplateId { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>41847298a90c067136af5ba669eaae18</Hash>
</Codenesium>*/