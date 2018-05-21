using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCountryRegionCurrency: AbstractPOCO
	{
		public POCOCountryRegionCurrency() : base()
		{}

		public POCOCountryRegionCurrency(
			string countryRegionCode,
			string currencyCode,
			DateTime modifiedDate)
		{
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.CurrencyCode = new ReferenceEntity<string>(currencyCode,
			                                                nameof(ApiResponse.Currencies));
		}

		public string CountryRegionCode { get; set; }
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
    <Hash>c24bc96f6a97c68277cd9af153f59f5d</Hash>
</Codenesium>*/