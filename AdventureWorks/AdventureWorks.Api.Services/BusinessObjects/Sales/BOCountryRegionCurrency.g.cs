using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>4248d70dc4f9fbcbfc892052a84d2b40</Hash>
</Codenesium>*/