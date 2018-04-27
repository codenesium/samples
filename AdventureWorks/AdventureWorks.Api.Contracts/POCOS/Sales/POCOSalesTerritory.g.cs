using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesTerritory
	{
		public POCOSalesTerritory()
		{}

		public POCOSalesTerritory(
			decimal costLastYear,
			decimal costYTD,
			string countryRegionCode,
			string @group,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal salesLastYear,
			decimal salesYTD,
			int territoryID)
		{
			this.CostLastYear = costLastYear.ToDecimal();
			this.CostYTD = costYTD.ToDecimal();
			this.@Group = @group.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.SalesYTD = salesYTD.ToDecimal();
			this.TerritoryID = territoryID.ToInt();

			this.CountryRegionCode = new ReferenceEntity<string>(countryRegionCode,
			                                                     nameof(ApiResponse.CountryRegions));
		}

		public decimal CostLastYear { get; set; }
		public decimal CostYTD { get; set; }
		public ReferenceEntity<string> CountryRegionCode { get; set; }
		public string @Group { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public decimal SalesLastYear { get; set; }
		public decimal SalesYTD { get; set; }
		public int TerritoryID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCostLastYearValue { get; set; } = true;

		public bool ShouldSerializeCostLastYear()
		{
			return this.ShouldSerializeCostLastYearValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCostYTDValue { get; set; } = true;

		public bool ShouldSerializeCostYTD()
		{
			return this.ShouldSerializeCostYTDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCountryRegionCodeValue { get; set; } = true;

		public bool ShouldSerializeCountryRegionCode()
		{
			return this.ShouldSerializeCountryRegionCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeGroupValue { get; set; } = true;

		public bool ShouldSerializeGroup()
		{
			return this.ShouldSerializeGroupValue;
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
		public bool ShouldSerializeSalesLastYearValue { get; set; } = true;

		public bool ShouldSerializeSalesLastYear()
		{
			return this.ShouldSerializeSalesLastYearValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesYTDValue { get; set; } = true;

		public bool ShouldSerializeSalesYTD()
		{
			return this.ShouldSerializeSalesYTDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

		public bool ShouldSerializeTerritoryID()
		{
			return this.ShouldSerializeTerritoryIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCostLastYearValue = false;
			this.ShouldSerializeCostYTDValue = false;
			this.ShouldSerializeCountryRegionCodeValue = false;
			this.ShouldSerializeGroupValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSalesLastYearValue = false;
			this.ShouldSerializeSalesYTDValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>fed157f2baa642a37f954f893ce9de1d</Hash>
</Codenesium>*/