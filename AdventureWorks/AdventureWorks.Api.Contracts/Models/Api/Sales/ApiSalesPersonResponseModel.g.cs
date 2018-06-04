using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesPersonResponseModel: AbstractApiResponseModel
	{
		public ApiSalesPersonResponseModel() : base()
		{}

		public void SetProperties(
			decimal bonus,
			int businessEntityID,
			decimal commissionPct,
			DateTime modifiedDate,
			Guid rowguid,
			decimal salesLastYear,
			Nullable<decimal> salesQuota,
			decimal salesYTD,
			Nullable<int> territoryID)
		{
			this.Bonus = bonus.ToDecimal();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CommissionPct = commissionPct.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.SalesQuota = salesQuota.ToNullableDecimal();
			this.SalesYTD = salesYTD.ToDecimal();
			this.TerritoryID = territoryID.ToNullableInt();

			this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
		}

		public decimal Bonus { get; private set; }
		public int BusinessEntityID { get; private set; }
		public decimal CommissionPct { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Guid Rowguid { get; private set; }
		public decimal SalesLastYear { get; private set; }
		public Nullable<decimal> SalesQuota { get; private set; }
		public decimal SalesYTD { get; private set; }
		public Nullable<int> TerritoryID { get; private set; }
		public string TerritoryIDEntity { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBonusValue { get; set; } = true;

		public bool ShouldSerializeBonus()
		{
			return this.ShouldSerializeBonusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCommissionPctValue { get; set; } = true;

		public bool ShouldSerializeCommissionPct()
		{
			return this.ShouldSerializeCommissionPctValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
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
		public bool ShouldSerializeSalesQuotaValue { get; set; } = true;

		public bool ShouldSerializeSalesQuota()
		{
			return this.ShouldSerializeSalesQuotaValue;
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
			this.ShouldSerializeBonusValue = false;
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeCommissionPctValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSalesLastYearValue = false;
			this.ShouldSerializeSalesQuotaValue = false;
			this.ShouldSerializeSalesYTDValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>a28cc66b401ae4bc25c5894ae69709fe</Hash>
</Codenesium>*/