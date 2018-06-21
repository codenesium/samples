using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOCountryRegionCurrency : AbstractBusinessObject
        {
                public AbstractBOCountryRegionCurrency()
                        : base()
                {
                }

                public virtual void SetProperties(string countryRegionCode,
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
    <Hash>aa0dab68f741c50a18508c6741181cd1</Hash>
</Codenesium>*/