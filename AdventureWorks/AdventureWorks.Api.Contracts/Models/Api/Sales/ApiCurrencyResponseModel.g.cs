using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCurrencyResponseModel: AbstractApiResponseModel
        {
                public ApiCurrencyResponseModel() : base()
                {
                }

                public void SetProperties(
                        string currencyCode,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public string CurrencyCode { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

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

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeCurrencyCodeValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>7bed06b96c8ee1c994b1db0ddf31f964</Hash>
</Codenesium>*/