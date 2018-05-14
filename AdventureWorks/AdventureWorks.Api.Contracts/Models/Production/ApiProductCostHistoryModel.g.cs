using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductCostHistoryModel
	{
		public ApiProductCostHistoryModel()
		{}

		public ApiProductCostHistoryModel(
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			decimal standardCost,
			DateTime startDate)
		{
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.StandardCost = standardCost.ToDecimal();
			this.StartDate = startDate.ToDateTime();
		}

		private Nullable<DateTime> endDate;

		public Nullable<DateTime> EndDate
		{
			get
			{
				return this.endDate.IsEmptyOrZeroOrNull() ? null : this.endDate;
			}

			set
			{
				this.endDate = value;
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

		private decimal standardCost;

		[Required]
		public decimal StandardCost
		{
			get
			{
				return this.standardCost;
			}

			set
			{
				this.standardCost = value;
			}
		}

		private DateTime startDate;

		[Required]
		public DateTime StartDate
		{
			get
			{
				return this.startDate;
			}

			set
			{
				this.startDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>c6f0318d914bd0de02fded38222ca612</Hash>
</Codenesium>*/