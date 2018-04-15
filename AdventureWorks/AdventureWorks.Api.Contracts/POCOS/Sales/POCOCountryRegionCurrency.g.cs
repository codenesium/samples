using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCountryRegionCurrency
	{
		public POCOCountryRegionCurrency()
		{}

		public POCOCountryRegionCurrency(
			string countryRegionCode,
			string currencyCode,
			DateTime modifiedDate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.CountryRegionCode = new ReferenceEntity<string>(countryRegionCode,
			                                                     nameof(ApiResponse.CountryRegions));
			this.CurrencyCode = new ReferenceEntity<string>(currencyCode,
			                                                nameof(ApiResponse.Currencies));
		}

		public ReferenceEntity<string> CountryRegionCode { get; set; }
		public ReferenceEntity<string> CurrencyCode { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCodeValue { get; set; } = true;

		public bool ShouldSerializeCountryRegionCode()
		{
			return this.ShouldSerializeCountryRegionCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyCodeValue { get; set; } = true;

		public bool ShouldSerializeCurrencyCode()
		{
			return this.ShouldSerializeCurrencyCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCountryRegionCodeValue = false;
			this.ShouldSerializeCurrencyCodeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d2d1fdf4197b950f5ec176805bd7dc5d</Hash>
</Codenesium>*/