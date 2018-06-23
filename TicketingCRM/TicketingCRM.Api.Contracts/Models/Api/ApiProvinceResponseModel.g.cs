using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public class ApiProvinceResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int countryId,
                        int id,
                        string name)
                {
                        this.CountryId = countryId;
                        this.Id = id;
                        this.Name = name;

                        this.CountryIdEntity = nameof(ApiResponse.Countries);
                }

                public int CountryId { get; private set; }

                public string CountryIdEntity { get; set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCountryIdValue { get; set; } = true;

                public bool ShouldSerializeCountryId()
                {
                        return this.ShouldSerializeCountryIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCountryIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>fce4bebc46e5e5c551d822e16a31a462</Hash>
</Codenesium>*/