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
			this.CountryRegionCode = countryRegionCode;
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string CountryRegionCode {get; set;}
		public string CurrencyCode {get; set;}
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
    <Hash>3d75e5ddcd7d5888b38946f2ad28e6d2</Hash>
</Codenesium>*/