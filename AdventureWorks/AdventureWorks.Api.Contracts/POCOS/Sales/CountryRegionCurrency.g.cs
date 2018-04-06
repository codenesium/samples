using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCountryRegionCurrency
	{
		public POCOCountryRegionCurrency()
		{}

		public POCOCountryRegionCurrency(string countryRegionCode,
		                                 string currencyCode,
		                                 DateTime modifiedDate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			CountryRegionCode = new ReferenceEntity<string>(countryRegionCode,
			                                                "CountryRegion");
			CurrencyCode = new ReferenceEntity<string>(currencyCode,
			                                           "Currency");
		}

		public ReferenceEntity<string>CountryRegionCode {get; set;}
		public ReferenceEntity<string>CurrencyCode {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCodeValue {get; set;} = true;

		public bool ShouldSerializeCountryRegionCode()
		{
			return ShouldSerializeCountryRegionCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyCodeValue {get; set;} = true;

		public bool ShouldSerializeCurrencyCode()
		{
			return ShouldSerializeCurrencyCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>4a5593aaa24238feaae2182c351447b5</Hash>
</Codenesium>*/