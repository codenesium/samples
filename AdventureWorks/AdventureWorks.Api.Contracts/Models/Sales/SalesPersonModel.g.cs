using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesPersonModel
	{
		public SalesPersonModel()
		{}

		public SalesPersonModel(
			Nullable<int> territoryID,
			Nullable<decimal> salesQuota,
			decimal bonus,
			decimal commissionPct,
			decimal salesYTD,
			decimal salesLastYear,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.TerritoryID = territoryID.ToNullableInt();
			this.SalesQuota = salesQuota.ToNullableDecimal();
			this.Bonus = bonus.ToDecimal();
			this.CommissionPct = commissionPct.ToDecimal();
			this.SalesYTD = salesYTD.ToDecimal();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Nullable<int> territoryID;

		public Nullable<int> TerritoryID
		{
			get
			{
				return this.territoryID.IsEmptyOrZeroOrNull() ? null : this.territoryID;
			}

			set
			{
				this.territoryID = value;
			}
		}

		private Nullable<decimal> salesQuota;

		public Nullable<decimal> SalesQuota
		{
			get
			{
				return this.salesQuota.IsEmptyOrZeroOrNull() ? null : this.salesQuota;
			}

			set
			{
				this.salesQuota = value;
			}
		}

		private decimal bonus;

		[Required]
		public decimal Bonus
		{
			get
			{
				return this.bonus;
			}

			set
			{
				this.bonus = value;
			}
		}

		private decimal commissionPct;

		[Required]
		public decimal CommissionPct
		{
			get
			{
				return this.commissionPct;
			}

			set
			{
				this.commissionPct = value;
			}
		}

		private decimal salesYTD;

		[Required]
		public decimal SalesYTD
		{
			get
			{
				return this.salesYTD;
			}

			set
			{
				this.salesYTD = value;
			}
		}

		private decimal salesLastYear;

		[Required]
		public decimal SalesLastYear
		{
			get
			{
				return this.salesLastYear;
			}

			set
			{
				this.salesLastYear = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>cd2b03bbf4878bb3482ec72264a05958</Hash>
</Codenesium>*/