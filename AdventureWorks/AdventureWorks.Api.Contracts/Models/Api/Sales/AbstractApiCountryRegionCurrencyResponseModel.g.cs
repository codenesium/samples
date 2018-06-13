using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCountryRegionCurrencyResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string countryRegionCode,
                        string currencyCode,
                        DateTime modifiedDate)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;

                        this.CurrencyCodeEntity = nameof(ApiResponse.Currencies);
                }

                public string CountryRegionCode { get; private set; }

                public string CurrencyCode { get; private set; }

                public string CurrencyCodeEntity { get; set; }

                public DateTime ModifiedDate { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCountryRegionCodeValue { get; set; } = true;

                public bool ShouldSerializeCountryRegionCode()
                {
                        return this.ShouldSerializeCountryRegionCodeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCurrencyCodeValue { get; set; } = true;

                public bool ShouldSerializeCurrencyCode()
                {
                        return this.ShouldSerializeCurrencyCodeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCountryRegionCodeValue = false;
                        this.ShouldSerializeCurrencyCodeValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>517b021a3736d5f0593f628573cc18b2</Hash>
</Codenesium>*/