using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiCountryRequirementResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int countryId,
                        string details)
                {
                        this.Id = id;
                        this.CountryId = countryId;
                        this.Details = details;

                        this.CountryIdEntity = nameof(ApiResponse.Countries);
                }

                public int CountryId { get; private set; }

                public string CountryIdEntity { get; set; }

                public string Details { get; private set; }

                public int Id { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1df6f1506333f27d23c48a84c9de3185</Hash>
</Codenesium>*/