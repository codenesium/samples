using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOStateProvince
	{
		public POCOStateProvince()
		{}

		public POCOStateProvince(int stateProvinceID,
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

			CountryRegionCode = new ReferenceEntity<string>(countryRegionCode,
			                                                "CountryRegion");
			TerritoryID = new ReferenceEntity<int>(territoryID,
			                                       "SalesTerritory");
		}

		public int StateProvinceID {get; set;}
		public string StateProvinceCode {get; set;}
		public ReferenceEntity<string>CountryRegionCode {get; set;}
		public bool IsOnlyStateProvinceFlag {get; set;}
		public string Name {get; set;}
		public ReferenceEntity<int>TerritoryID {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceIDValue {get; set;} = true;

		public bool ShouldSerializeStateProvinceID()
		{
			return ShouldSerializeStateProvinceIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceCodeValue {get; set;} = true;

		public bool ShouldSerializeStateProvinceCode()
		{
			return ShouldSerializeStateProvinceCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCodeValue {get; set;} = true;

		public bool ShouldSerializeCountryRegionCode()
		{
			return ShouldSerializeCountryRegionCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIsOnlyStateProvinceFlagValue {get; set;} = true;

		public bool ShouldSerializeIsOnlyStateProvinceFlag()
		{
			return ShouldSerializeIsOnlyStateProvinceFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue {get; set;} = true;

		public bool ShouldSerializeTerritoryID()
		{
			return ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>8de6f2a658dff09dd8cbe2541bd87994</Hash>
</Codenesium>*/