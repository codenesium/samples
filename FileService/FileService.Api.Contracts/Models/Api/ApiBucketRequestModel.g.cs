using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiBucketRequestModel : AbstractApiRequestModel
        {
                public ApiBucketRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        Guid externalId,
                        string name)
                {
                        this.ExternalId = externalId;
                        this.Name = name;
                }

                [JsonProperty]
                public Guid ExternalId { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c94f6d3aa43c9a284cdf643d89d76ab0</Hash>
</Codenesium>*/