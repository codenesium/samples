using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Contracts
{
        public partial class ApiBreedRequestModel : AbstractApiRequestModel
        {
                public ApiBreedRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name)
                {
                        this.Name = name;
                }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2ffd522b5907ea08516781c092cee8cb</Hash>
</Codenesium>*/