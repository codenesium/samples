using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiBreedRequestModel : AbstractApiRequestModel
        {
                public ApiBreedRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name,
                        int speciesId)
                {
                        this.Name = name;
                        this.SpeciesId = speciesId;
                }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int SpeciesId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a0c46ceb11446d6d68e64202c3032873</Hash>
</Codenesium>*/