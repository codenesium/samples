using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiVariableSetRequestModel : AbstractApiRequestModel
        {
                public ApiVariableSetRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        bool isFrozen,
                        string jSON,
                        string ownerId,
                        string relatedDocumentIds,
                        int version)
                {
                        this.IsFrozen = isFrozen;
                        this.JSON = jSON;
                        this.OwnerId = ownerId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Version = version;
                }

                [JsonProperty]
                public bool IsFrozen { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string OwnerId { get; private set; }

                [JsonProperty]
                public string RelatedDocumentIds { get; private set; }

                [JsonProperty]
                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>72e061c8f30f76ea55f082888bfdce72</Hash>
</Codenesium>*/