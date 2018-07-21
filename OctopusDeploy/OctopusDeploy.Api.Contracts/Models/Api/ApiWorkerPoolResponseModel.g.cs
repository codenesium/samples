using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiWorkerPoolResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        bool isDefault,
                        string jSON,
                        string name,
                        int sortOrder)
                {
                        this.Id = id;
                        this.IsDefault = isDefault;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
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

                [Required]
                [JsonProperty]
                public int SortOrder { get; private set; }
        }
}

/*<Codenesium>
    <Hash>550e6b7f3d592960f0049a95f27980c4</Hash>
</Codenesium>*/