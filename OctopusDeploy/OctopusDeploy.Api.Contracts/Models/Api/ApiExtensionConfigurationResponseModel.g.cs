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

                [Required]
                [JsonProperty]
                public string ExtensionAuthor { get; private set; }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a0cbe4a377e411134507b58ea9356b24</Hash>
</Codenesium>*/