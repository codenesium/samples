using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiMachinePolicyResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        bool isDefault,
                        string jSON,
                        string name)
                {
                        this.Id = id;
                        this.IsDefault = isDefault;
                        this.JSON = jSON;
                        this.Name = name;
                }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public bool IsDefault { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0a1feba36df86947833eb7e57174793c</Hash>
</Codenesium>*/