using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductCostHistoryModel
	{
		public ProductCostHistoryModel()
		{}

		public ProductCostHistoryModel(
			DateTime startDate,
			Nullable<DateTime> endDate,
			decimal standardCost,
			DateTime modifiedDate)
		{
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.StandardCost = standardCost.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
    <Hash>79e0b43bd178e33e0a146e77e604b638</Hash>
</Codenesium>*/