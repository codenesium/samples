using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiApiKeyResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string apiKeyHashed,
                        DateTimeOffset created,
                        string id,
                        string jSON,
                        string userId)
                {
                        this.ApiKeyHashed = apiKeyHashed;
                        this.Created = created;
                        this.Id = id;
                        this.JSON = jSON;
                        this.UserId = userId;
                }

                public string ApiKeyHashed { get; private set; }

                public DateTimeOffset Created { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string UserId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeApiKeyHashedValue { get; set; } = true;

                public bool ShouldSerializeApiKeyHashed()
                {
                        return this.ShouldSerializeApiKeyHashedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreatedValue { get; set; } = true;

                public bool ShouldSerializeCreated()
                {
                        return this.ShouldSerializeCreatedValue;
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
                public bool ShouldSerializeUserIdValue { get; set; } = true;

                public bool ShouldSerializeUserId()
                {
                        return this.ShouldSerializeUserIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeApiKeyHashedValue = false;
                        this.ShouldSerializeCreatedValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeUserIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>4ee8b9da3cd535b28f1f1b258eb60a24</Hash>
</Codenesium>*/