using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCountryRegion
	{
		public POCOCountryRegion()
		{}

		public POCOCountryRegion(string countryRegionCode,
		                         string name,
		                         DateTime modifiedDate)
		{
			this.CountryRegionCode = countryRegionCode;
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string CountryRegionCode {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCodeValue {get; set;} = true;

		public bool ShouldSerializeCountryRegionCode()
		{
			return ShouldSerializeCountryRegionCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
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
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>b57a6be7676c7c494baabe4fabf673e6</Hash>
</Codenesium>*/