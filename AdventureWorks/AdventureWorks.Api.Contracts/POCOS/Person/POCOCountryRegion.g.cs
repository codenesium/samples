using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCountryRegion
	{
		public POCOCountryRegion()
		{}

		public POCOCountryRegion(
			string countryRegionCode,
			DateTime modifiedDate,
			string name)
		{
			this.CountryRegionCode = countryRegionCode.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
		}

		public string CountryRegionCode { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCodeValue { get; set; } = true;

		public bool ShouldSerializeCountryRegionCode()
		{
			return this.ShouldSerializeCountryRegionCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCountryRegionCodeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>722e85ca7e9be28245413e56fde693b0</Hash>
</Codenesium>*/