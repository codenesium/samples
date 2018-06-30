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

                [JsonIgnore]
                public bool ShouldSerializeCountryIdValue { get; set; } = true;

                public bool ShouldSerializeCountryId()
                {
                        return this.ShouldSerializeCountryIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDetailsValue { get; set; } = true;

                public bool ShouldSerializeDetails()
                {
                        return this.ShouldSerializeDetailsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCountryIdValue = false;
                        this.ShouldSerializeDetailsValue = false;
                        this.ShouldSerializeIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>35919bdc3ec14a083e245d33e91385e5</Hash>
</Codenesium>*/