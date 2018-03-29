using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesPersonQuotaHistoryModel
	{
		public SalesPersonQuotaHistoryModel()
		{}

		public SalesPersonQuotaHistoryModel(DateTime quotaDate,
		                                    decimal salesQuota,
		                                    Guid rowguid,
		                                    DateTime modifiedDate)
		{
			this.QuotaDate = quotaDate.ToDateTime();
			this.SalesQuota = salesQuota;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public SalesPersonQuotaHistoryModel(POCOSalesPersonQuotaHistory poco)
		{
			this.QuotaDate = poco.QuotaDate.ToDateTime();
			this.SalesQuota = poco.SalesQuota;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
		}

		private DateTime _quotaDate;
		[Required]
		public DateTime QuotaDate
		{
			get
			{
				return _quotaDate;
			}
			set
			{
				this._quotaDate = value;
			}
		}

		private decimal _salesQuota;
		[Required]
		public decimal SalesQuota
		{
			get
			{
				return _salesQuota;
			}
			set
			{
				this._salesQuota = value;
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
    <Hash>fbb5f4cde4887b7c4bc6c1c2a2b1f606</Hash>
</Codenesium>*/