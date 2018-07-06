using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCurrencyRateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int currencyRateID,
                        decimal averageRate,
                        DateTime currencyRateDate,
                        decimal endOfDayRate,
                        string fromCurrencyCode,
                        DateTime modifiedDate,
                        string toCurrencyCode)
                {
                        this.CurrencyRateID = currencyRateID;
                        this.AverageRate = averageRate;
                        this.CurrencyRateDate = currencyRateDate;
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
        }
}

/*<Codenesium>
    <Hash>0400bed39e76de6f56ade3f403140fe7</Hash>
</Codenesium>*/