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
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			string stateProvinceCode,
			int stateProvinceID,
			int territoryID)
		{
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.StateProvinceCode = stateProvinceCode.ToString();
			this.StateProvinceID = stateProvinceID.ToInt();

			this.CountryRegionCode = new ReferenceEntity<string>(countryRegionCode,
			                                                     nameof(ApiResponse.CountryRegions));
			this.TerritoryID = new ReferenceEntity<int>(territoryID,
			                                            nameof(ApiResponse.SalesTerritories));
		}

		public ReferenceEntity<string> CountryRegionCode { get; set; }
		public bool IsOnlyStateProvinceFlag { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public string StateProvinceCode { get; set; }
		public int StateProvinceID { get; set; }
		public ReferenceEntity<int> TerritoryID { get; set; }

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

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceCodeValue { get; set; } = true;

		public bool ShouldSerializeStateProvinceCode()
		{
			return this.ShouldSerializeStateProvinceCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceIDValue { get; set; } = true;

		public bool ShouldSerializeStateProvinceID()
		{
			return this.ShouldSerializeStateProvinceIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

		public bool ShouldSerializeTerritoryID()
		{
			return this.ShouldSerializeTerritoryIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCountryRegionCodeValue = false;
			this.ShouldSerializeIsOnlyStateProvinceFlagValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeStateProvinceCodeValue = false;
			this.ShouldSerializeStateProvinceIDValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>1e255f604fbb755739eecb5029fd3d12</Hash>
</Codenesium>*/