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
			DateTime quotaDate,
			decimal salesQuota,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.QuotaDate = quotaDate.ToDateTime();
			this.SalesQuota = salesQuota;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
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
    <Hash>d3007eeacb34eece87b3641e89d693c4</Hash>
</Codenesium>*/