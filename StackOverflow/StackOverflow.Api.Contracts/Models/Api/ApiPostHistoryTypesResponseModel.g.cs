using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostHistoryTypesResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string type)
                {
                        this.Id = id;
                        this.Type = type;
                }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>30fb6c2fdaec353907a9f20623ea288f</Hash>
</Codenesium>*/