using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOStateProvince
	{
		public POCOStateProvince()
		{}

		public POCOStateProvince(
			int stateProvinceID,
			string stateProvinceCode,
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			string name,
			int territoryID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.StateProvinceID = stateProvinceID.ToInt();
			this.StateProvinceCode = stateProvinceCode;
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
			this.Name = name;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.CountryRegionCode = new ReferenceEntity<string>(countryRegionCode,
			                                                     "CountryRegion");
			this.TerritoryID = new ReferenceEntity<int>(territoryID,
			                                            "SalesTerritory");
		}

		public int StateProvinceID { get; set; }
		public string StateProvinceCode { get; set; }
		public ReferenceEntity<string> CountryRegionCode { get; set; }
		public bool IsOnlyStateProvinceFlag { get; set; }
		public string Name { get; set; }
		public ReferenceEntity<int> TerritoryID { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceIDValue { get; set; } = true;

		public bool ShouldSerializeStateProvinceID()
		{
			return this.ShouldSerializeStateProvinceIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceCodeValue { get; set; } = true;

		public bool ShouldSerializeStateProvinceCode()
		{
			return this.ShouldSerializeStateProvinceCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCodeValue { get; set; } = true;

		public bool ShouldSerializeCountryRegionCode()
		{
			return this.ShouldSerializeCountryRegionCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIsOnlyStateProvinceFlagValue { get; set; } = true;

		public bool ShouldSerializeIsOnlyStateProvinceFlag()
		{
			return this.ShouldSerializeIsOnlyStateProvinceFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

		public bool ShouldSerializeTerritoryID()
		{
			return this.ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeStateProvinceIDValue = false;
			this.ShouldSerializeStateProvinceCodeValue = false;
			this.ShouldSerializeCountryRegionCodeValue = false;
			this.ShouldSerializeIsOnlyStateProvinceFlagValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d770d39c251ac3a07cd5d0c8c6dd1a5d</Hash>
</Codenesium>*/