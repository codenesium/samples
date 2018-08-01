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
    <Hash>3e92ee0b1a84b0bde0145101b52fd058</Hash>
</Codenesium>*/