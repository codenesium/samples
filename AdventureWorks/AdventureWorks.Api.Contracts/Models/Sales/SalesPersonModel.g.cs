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
		public SalesPersonModel(Nullable<int> territoryID,
		                        Nullable<decimal> salesQuota,
		                        decimal bonus,
		                        decimal commissionPct,
		                        decimal salesYTD,
		                        decimal salesLastYear,
		                        Guid rowguid,
		                        DateTime modifiedDate)
		{
			this.TerritoryID = territoryID.ToNullableInt();
			this.SalesQuota = salesQuota;
			this.Bonus = bonus;
			this.CommissionPct = commissionPct;
			this.SalesYTD = salesYTD;
			this.SalesLastYear = salesLastYear;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Nullable<int> _territoryID;
		public Nullable<int> TerritoryID
		{
			get
			{
				return _territoryID.IsEmptyOrZeroOrNull() ? null : _territoryID;
			}
			set
			{
				this._territoryID = value;
			}
		}

		private Nullable<decimal> _salesQuota;
		public Nullable<decimal> SalesQuota
		{
			get
			{
				return _salesQuota.IsEmptyOrZeroOrNull() ? null : _salesQuota;
			}
			set
			{
				this._salesQuota = value;
			}
		}

		private decimal _bonus;
		[Required]
		public decimal Bonus
		{
			get
			{
				return _bonus;
			}
			set
			{
				this._bonus = value;
			}
		}

		private decimal _commissionPct;
		[Required]
		public decimal CommissionPct
		{
			get
			{
				return _commissionPct;
			}
			set
			{
				this._commissionPct = value;
			}
		}

		private decimal _salesYTD;
		[Required]
		public decimal SalesYTD
		{
			get
			{
				return _salesYTD;
			}
			set
			{
				this._salesYTD = value;
			}
		}

		private decimal _salesLastYear;
		[Required]
		public decimal SalesLastYear
		{
			get
			{
				return _salesLastYear;
			}
			set
			{
				this._salesLastYear = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e64fde13cbf3e38a0fda547738b5ddc3</Hash>
</Codenesium>*/