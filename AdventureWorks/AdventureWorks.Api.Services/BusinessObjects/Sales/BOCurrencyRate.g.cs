using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOCurrencyRate: AbstractBusinessObject
        {
                public BOCurrencyRate() : base()
                {
                }

                public void SetProperties(int currencyRateID,
                                          decimal averageRate,
                                          DateTime currencyRateDate,
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
                }

                public decimal AverageRate { get; private set; }

                public DateTime CurrencyRateDate { get; private set; }

                public int CurrencyRateID { get; private set; }

                public decimal EndOfDayRate { get; private set; }

                public string FromCurrencyCode { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string ToCurrencyCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f5bff5b29d3a15da7efefd3157a6989d</Hash>
</Codenesium>*/