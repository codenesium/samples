using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
        public partial class ApiTimestampCheckResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        byte[] timestamp)
                {
                        this.Id = id;
                        this.Name = name;
                        this.Timestamp = timestamp;
                }

                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public byte[] Timestamp { get; private set; }
        }
}

/*<Codenesium>
    <Hash>75bbdaa974cc713e1a16265e78d8af9f</Hash>
</Codenesium>*/