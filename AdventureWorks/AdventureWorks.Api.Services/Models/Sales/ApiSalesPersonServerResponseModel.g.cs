using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiSalesPersonServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public decimal? SalesQuota { get; private set; }

		[JsonProperty]
		public decimal SalesYTD { get; private set; }

		[Required]
		[JsonProperty]
		public int? TerritoryID { get; private set; }

		[JsonProperty]
		public string TerritoryIDEntity { get; private set; } = RouteConstants.SalesTerritories;

		[JsonProperty]
		public ApiSalesTerritoryServerResponseModel TerritoryIDNavigation { get; private set; }

		public void SetTerritoryIDNavigation(ApiSalesTerritoryServerResponseModel value)
		{
			this.TerritoryIDNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>fc2caf21e6c8598ae857a4d11d2c1771</Hash>
</Codenesium>*/