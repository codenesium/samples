using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiSalesPersonClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSalesPersonClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal bonus,
			decimal commissionPct,
			DateTime modifiedDate,
			Guid rowguid,
			decimal salesLastYear,
			decimal? salesQuota,
			decimal salesYTD,
			int? territoryID)
		{
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
		public decimal Bonus { get; private set; } = default(decimal);

		[JsonProperty]
		public decimal CommissionPct { get; private set; } = default(decimal);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public decimal SalesLastYear { get; private set; } = default(decimal);

		[JsonProperty]
		public decimal? SalesQuota { get; private set; } = default(decimal);

		[JsonProperty]
		public decimal SalesYTD { get; private set; } = default(decimal);

		[JsonProperty]
		public int? TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>13da56fb8bbb2bd5106e9612c570e055</Hash>
</Codenesium>*/