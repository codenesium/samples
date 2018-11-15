using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiSalesPersonClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int businessEntityID,
			decimal bonus,
			decimal commissionPct,
			DateTime modifiedDate,
			Guid rowguid,
			decimal salesLastYear,
			decimal? salesQuota,
			decimal salesYTD,
			int? territoryID)
		{
			this.BusinessEntityID = businessEntityID;
			this.Bonus = bonus;
			this.CommissionPct = commissionPct;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
			this.SalesLastYear = salesLastYear;
			this.SalesQuota = salesQuota;
			this.SalesYTD = salesYTD;
			this.TerritoryID = territoryID;

			this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
		}

		[JsonProperty]
		public decimal Bonus { get; private set; }

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public decimal CommissionPct { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public decimal SalesLastYear { get; private set; }

		[JsonProperty]
		public decimal? SalesQuota { get; private set; }

		[JsonProperty]
		public decimal SalesYTD { get; private set; }

		[JsonProperty]
		public int? TerritoryID { get; private set; }

		[JsonProperty]
		public string TerritoryIDEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>a8b75f6ae5cb763d59b8485319ece4a3</Hash>
</Codenesium>*/