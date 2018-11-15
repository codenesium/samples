using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiSalesPersonServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSalesPersonServerRequestModel()
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

		[Required]
		[JsonProperty]
		public decimal Bonus { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public decimal CommissionPct { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public decimal SalesLastYear { get; private set; } = default(decimal);

		[JsonProperty]
		public decimal? SalesQuota { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public decimal SalesYTD { get; private set; } = default(decimal);

		[JsonProperty]
		public int? TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>70adb3eff7cf65dbfa4cefd8425c7379</Hash>
</Codenesium>*/