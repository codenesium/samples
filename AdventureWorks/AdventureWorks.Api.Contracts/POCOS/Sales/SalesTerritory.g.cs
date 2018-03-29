using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesTerritory
	{
		public POCOSalesTerritory()
		{}

		public POCOSalesTerritory(int territoryID,
		                          string name,
		                          string countryRegionCode,
		                          string @group,
		                          decimal salesYTD,
		                          decimal salesLastYear,
		                          decimal costYTD,
		                          decimal costLastYear,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.TerritoryID = territoryID.ToInt();
			this.Name = name;
			this.@Group = @group;
			this.SalesYTD = salesYTD;
			this.SalesLastYear = salesLastYear;
			this.CostYTD = costYTD;
			this.CostLastYear = costLastYear;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			CountryRegionCode = new ReferenceEntity<string>(countryRegionCode,
			                                                "CountryRegion");
		}

		public int TerritoryID {get; set;}
		public string Name {get; set;}
		public ReferenceEntity<string>CountryRegionCode {get; set;}
		public string @Group {get; set;}
		public decimal SalesYTD {get; set;}
		public decimal SalesLastYear {get; set;}
		public decimal CostYTD {get; set;}
		public decimal CostLastYear {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue {get; set;} = true;

		public bool ShouldSerializeTerritoryID()
		{
			return ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCodeValue {get; set;} = true;

		public bool ShouldSerializeCountryRegionCode()
		{
			return ShouldSerializeCountryRegionCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeGroupValue {get; set;} = true;

		public bool ShouldSerializeGroup()
		{
			return ShouldSerializeGroupValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesYTDValue {get; set;} = true;

		public bool ShouldSerializeSalesYTD()
		{
			return ShouldSerializeSalesYTDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesLastYearValue {get; set;} = true;

		public bool ShouldSerializeSalesLastYear()
		{
			return ShouldSerializeSalesLastYearValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCostYTDValue {get; set;} = true;

		public bool ShouldSerializeCostYTD()
		{
			return ShouldSerializeCostYTDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCostLastYearValue {get; set;} = true;

		public bool ShouldSerializeCostLastYear()
		{
			return ShouldSerializeCostLastYearValue;
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
			this.ShouldSerializeTerritoryIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeCountryRegionCodeValue = false;
			this.ShouldSerializeGroupValue = false;
			this.ShouldSerializeSalesYTDValue = false;
			this.ShouldSerializeSalesLastYearValue = false;
			this.ShouldSerializeCostYTDValue = false;
			this.ShouldSerializeCostLastYearValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>f850d41ed5f55156525a2fbd54db1ca8</Hash>
</Codenesium>*/