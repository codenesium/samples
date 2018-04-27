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

		public SalesPersonQuotaHistoryModel(
			DateTime modifiedDate,
			DateTime quotaDate,
			Guid rowguid,
			decimal salesQuota)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.QuotaDate = quotaDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.SalesQuota = salesQuota.ToDecimal();
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

		private DateTime quotaDate;

		[Required]
		public DateTime QuotaDate
		{
			get
			{
				return this.quotaDate;
			}

			set
			{
				this.quotaDate = value;
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

		private decimal salesQuota;

		[Required]
		public decimal SalesQuota
		{
			get
			{
				return this.salesQuota;
			}

			set
			{
				this.salesQuota = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>cae326d2ddf9fd7eee0de0a665500bca</Hash>
</Codenesium>*/