using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOCountryRegionCurrency: AbstractBusinessObject
        {
                public BOCountryRegionCurrency() : base()
                {
                }

                public void SetProperties(string countryRegionCode,
                                          string currencyCode,
                                          DateTime modifiedDate)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                }

                public string CountryRegionCode { get; private set; }

                public string CurrencyCode { get; private set; }

                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>eb77685dc569b1810a16d3afe590723f</Hash>
</Codenesium>*/