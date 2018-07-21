using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTagSetResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        byte[] dataVersion,
                        string jSON,
                        string name,
                        int sortOrder)
                {
                        this.Id = id;
                        this.DataVersion = dataVersion;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
                }

                [Required]
                [JsonProperty]
                public byte[] DataVersion { get; private set; }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

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
    <Hash>0cf5424cc42634451cd26b7cc056b47d</Hash>
</Codenesium>*/