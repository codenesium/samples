using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOCountryRegionCurrency: AbstractBusinessObject
	{
		public BOCountryRegionCurrency() : base()
		{}

		public void SetProperties(string countryRegionCode,
		                          string currencyCode,
		                          DateTime modifiedDate)
		{
			this.CountryRegionCode = countryRegionCode;
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string CountryRegionCode { get; private set; }
		public string CurrencyCode { get; private set; }
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e137f9165f0b587ffcada0f7bec0aa45</Hash>
</Codenesium>*/