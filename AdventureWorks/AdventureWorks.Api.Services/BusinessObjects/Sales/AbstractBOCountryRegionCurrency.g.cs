using Codenesium.DataConversionExtensions;
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
    <Hash>469546f875756314cb17fae497d006ef</Hash>
</Codenesium>*/