using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiFeedResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string feedType,
                        string feedUri,
                        string jSON,
                        string name)
                {
                        this.Id = id;
                        this.FeedType = feedType;
                        this.FeedUri = feedUri;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public string FeedType { get; private set; }

                public string FeedUri { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeFeedTypeValue { get; set; } = true;

                public bool ShouldSerializeFeedType()
                {
                        return this.ShouldSerializeFeedTypeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFeedUriValue { get; set; } = true;

                public bool ShouldSerializeFeedUri()
                {
                        return this.ShouldSerializeFeedUriValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeFeedTypeValue = false;
                        this.ShouldSerializeFeedUriValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>0249581a68876fdf043166ffa968b3b1</Hash>
</Codenesium>*/