using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCountryRegionCurrencyResponseModel: AbstractApiResponseModel
        {
                public ApiCountryRegionCurrencyResponseModel() : base()
                {
                }

                public void SetProperties(
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

                public void DisableAllFields()
                {
                        this.ShouldSerializeCountryRegionCodeValue = false;
                        this.ShouldSerializeCurrencyCodeValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>0aa07eaaf9da58b5e53bea18f0ed5a59</Hash>
</Codenesium>*/