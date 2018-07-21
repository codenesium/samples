using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiSchemaVersionsResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime applied,
                        string scriptName)
                {
                        this.Id = id;
                        this.Applied = applied;
                        this.ScriptName = scriptName;
                }

                [Required]
                [JsonProperty]
                public DateTime Applied { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string ScriptName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0048f4051cbcfcfbfb24dd50b9d6f722</Hash>
</Codenesium>*/