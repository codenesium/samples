using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesPerson
	{
		public POCOSalesPerson()
		{}

		public POCOSalesPerson(
			int businessEntityID,
			Nullable<int> territoryID,
			Nullable<decimal> salesQuota,
			decimal bonus,
			decimal commissionPct,
			decimal salesYTD,
			decimal salesLastYear,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.SalesQuota = salesQuota.ToNullableDecimal();
			this.Bonus = bonus.ToDecimal();
			this.CommissionPct = commissionPct.ToDecimal();
			this.SalesYTD = salesYTD.ToDecimal();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.Employees));
			this.TerritoryID = new ReferenceEntity<Nullable<int>>(territoryID,
			                                                      nameof(ApiResponse.SalesTerritories));
		}

		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public ReferenceEntity<Nullable<int>> TerritoryID { get; set; }
		public Nullable<decimal> SalesQuota { get; set; }
		public decimal Bonus { get; set; }
		public decimal CommissionPct { get; set; }
		public decimal SalesYTD { get; set; }
		public decimal SalesLastYear { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

		public bool ShouldSerializeTerritoryID()
		{
			return this.ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesQuotaValue { get; set; } = true;

		public bool ShouldSerializeSalesQuota()
		{
			return this.ShouldSerializeSalesQuotaValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBonusValue { get; set; } = true;

		public bool ShouldSerializeBonus()
		{
			return this.ShouldSerializeBonusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCommissionPctValue { get; set; } = true;

		public bool ShouldSerializeCommissionPct()
		{
			return this.ShouldSerializeCommissionPctValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesYTDValue { get; set; } = true;

		public bool ShouldSerializeSalesYTD()
		{
			return this.ShouldSerializeSalesYTDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesLastYearValue { get; set; } = true;

		public bool ShouldSerializeSalesLastYear()
		{
			return this.ShouldSerializeSalesLastYearValue;
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
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
			this.ShouldSerializeSalesQuotaValue = false;
			this.ShouldSerializeBonusValue = false;
			this.ShouldSerializeCommissionPctValue = false;
			this.ShouldSerializeSalesYTDValue = false;
			this.ShouldSerializeSalesLastYearValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>966b597e9ce3ca173db8aea5862d2b3a</Hash>
</Codenesium>*/