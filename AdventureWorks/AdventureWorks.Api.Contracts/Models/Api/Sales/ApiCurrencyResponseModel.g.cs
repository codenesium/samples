using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public class ApiCurrencyResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
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

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCurrencyCodeValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>2f9cea777d3c33e558efa29bb111e262</Hash>
</Codenesium>*/