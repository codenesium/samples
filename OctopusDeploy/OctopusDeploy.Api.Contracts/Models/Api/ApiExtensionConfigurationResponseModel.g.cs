using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiExtensionConfigurationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string extensionAuthor,
                        string jSON,
                        string name)
                {
                        this.Id = id;
                        this.ExtensionAuthor = extensionAuthor;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public string ExtensionAuthor { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeExtensionAuthorValue { get; set; } = true;

                public bool ShouldSerializeExtensionAuthor()
                {
                        return this.ShouldSerializeExtensionAuthorValue;
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
                        this.ShouldSerializeExtensionAuthorValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a6f1cae9bbfb8defbc1500bfaf4fd17b</Hash>
</Codenesium>*/