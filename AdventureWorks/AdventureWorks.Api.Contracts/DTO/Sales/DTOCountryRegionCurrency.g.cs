using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOCountryRegionCurrency: AbstractDTO
	{
		public DTOCountryRegionCurrency() : base()
		{}

		public void SetProperties(string countryRegionCode,
		                          string currencyCode,
		                          DateTime modifiedDate)
		{
			this.CountryRegionCode = countryRegionCode;
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string CountryRegionCode { get; set; }
		public string CurrencyCode { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>e034742783655391e0cb9518d9e2c40b</Hash>
</Codenesium>*/