using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiDestinationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int countryId,
                        string name,
                        int order)
                {
                        this.Id = id;
                        this.CountryId = countryId;
                        this.Name = name;
                        this.Order = order;

                        this.CountryIdEntity = nameof(ApiResponse.Countries);
                }

                public int CountryId { get; private set; }

                public string CountryIdEntity { get; set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int Order { get; private set; }

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

                [JsonIgnore]
                public bool ShouldSerializeOrderValue { get; set; } = true;

                public bool ShouldSerializeOrder()
                {
                        return this.ShouldSerializeOrderValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCountryIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeOrderValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a9da50de9d8b8c89a4b80b400066c7ea</Hash>
</Codenesium>*/