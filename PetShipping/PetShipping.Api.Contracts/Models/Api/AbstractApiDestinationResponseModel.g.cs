using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiDestinationResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int countryId,
                        int id,
                        string name,
                        int order)
                {
                        this.CountryId = countryId;
                        this.Id = id;
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
    <Hash>ab2fea901b16c1969e7b3d211969b525</Hash>
</Codenesium>*/