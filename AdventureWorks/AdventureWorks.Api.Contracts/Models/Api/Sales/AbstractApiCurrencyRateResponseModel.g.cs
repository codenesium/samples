using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCurrencyRateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        decimal averageRate,
                        DateTime currencyRateDate,
                        int currencyRateID,
                        decimal endOfDayRate,
                        string fromCurrencyCode,
                        DateTime modifiedDate,
                        string toCurrencyCode)
                {
                        this.AverageRate = averageRate;
                        this.CurrencyRateDate = currencyRateDate;
                        this.CurrencyRateID = currencyRateID;
                        this.EndOfDayRate = endOfDayRate;
                        this.FromCurrencyCode = fromCurrencyCode;
                        this.ModifiedDate = modifiedDate;
                        this.ToCurrencyCode = toCurrencyCode;

                        this.FromCurrencyCodeEntity = nameof(ApiResponse.Currencies);
                        this.ToCurrencyCodeEntity = nameof(ApiResponse.Currencies);
                }

                public decimal AverageRate { get; private set; }

                public DateTime CurrencyRateDate { get; private set; }

                public int CurrencyRateID { get; private set; }

                public decimal EndOfDayRate { get; private set; }

                public string FromCurrencyCode { get; private set; }

                public string FromCurrencyCodeEntity { get; set; }

                public DateTime ModifiedDate { get; private set; }

                public string ToCurrencyCode { get; private set; }

                public string ToCurrencyCodeEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeAverageRateValue { get; set; } = true;

                public bool ShouldSerializeAverageRate()
                {
                        return this.ShouldSerializeAverageRateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCurrencyRateDateValue { get; set; } = true;

                public bool ShouldSerializeCurrencyRateDate()
                {
                        return this.ShouldSerializeCurrencyRateDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCurrencyRateIDValue { get; set; } = true;

                public bool ShouldSerializeCurrencyRateID()
                {
                        return this.ShouldSerializeCurrencyRateIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEndOfDayRateValue { get; set; } = true;

                public bool ShouldSerializeEndOfDayRate()
                {
                        return this.ShouldSerializeEndOfDayRateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFromCurrencyCodeValue { get; set; } = true;

                public bool ShouldSerializeFromCurrencyCode()
                {
                        return this.ShouldSerializeFromCurrencyCodeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeToCurrencyCodeValue { get; set; } = true;

                public bool ShouldSerializeToCurrencyCode()
                {
                        return this.ShouldSerializeToCurrencyCodeValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAverageRateValue = false;
                        this.ShouldSerializeCurrencyRateDateValue = false;
                        this.ShouldSerializeCurrencyRateIDValue = false;
                        this.ShouldSerializeEndOfDayRateValue = false;
                        this.ShouldSerializeFromCurrencyCodeValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeToCurrencyCodeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>d67bf0f1db61caee4321dc074eb90bbf</Hash>
</Codenesium>*/