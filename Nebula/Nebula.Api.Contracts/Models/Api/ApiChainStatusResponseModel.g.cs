using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiChainStatusResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f72441f82737958ab0b3b2ce6c61687c</Hash>
</Codenesium>*/