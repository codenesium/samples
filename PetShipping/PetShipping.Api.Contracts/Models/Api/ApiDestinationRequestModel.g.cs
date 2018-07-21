using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiDestinationRequestModel : AbstractApiRequestModel
        {
                public ApiDestinationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int countryId,
                        string name,
                        int order)
                {
                        this.CountryId = countryId;
                        this.Name = name;
                        this.Order = order;
                }

                [JsonProperty]
                public int CountryId { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int Order { get; private set; }
        }
}

/*<Codenesium>
    <Hash>405b0cd3777e56f6b3deb464c3767cfb</Hash>
</Codenesium>*/