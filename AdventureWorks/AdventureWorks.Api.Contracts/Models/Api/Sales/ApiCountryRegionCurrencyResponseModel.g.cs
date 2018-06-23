using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public class ApiCountryRegionCurrencyResponseModel : AbstractApiResponseModel
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
    <Hash>a8f798657988c32a555aa2fb1a09663e</Hash>
</Codenesium>*/