using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiLinkTypesResponseModel : AbstractApiResponseModel
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
    <Hash>643338f03af7fafabea64fce328dbc61</Hash>
</Codenesium>*/