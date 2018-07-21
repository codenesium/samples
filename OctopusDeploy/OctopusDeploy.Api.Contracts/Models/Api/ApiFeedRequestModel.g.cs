using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiFeedRequestModel : AbstractApiRequestModel
        {
                public ApiFeedRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string feedType,
                        string feedUri,
                        string jSON,
                        string name)
                {
                        this.FeedType = feedType;
                        this.FeedUri = feedUri;
                        this.JSON = jSON;
                        this.Name = name;
                }

                [JsonProperty]
                public string FeedType { get; private set; }

                [JsonProperty]
                public string FeedUri { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>06be89b17afea2b036c93db2196c1f84</Hash>
</Codenesium>*/