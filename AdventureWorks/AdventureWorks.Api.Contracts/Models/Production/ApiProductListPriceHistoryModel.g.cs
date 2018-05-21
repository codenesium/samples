using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductListPriceHistoryModel: AbstractModel
	{
		public ApiProductListPriceHistoryModel() : base()
		{}

		public ApiProductListPriceHistoryModel(
			Nullable<DateTime> endDate,
			decimal listPrice,
			DateTime modifiedDate,
			DateTime startDate)
		{
			this.EndDate = endDate.ToNullableDateTime();
			this.ListPrice = listPrice.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
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

		private decimal listPrice;

		[Required]
		public decimal ListPrice
		{
			get
			{
				return this.listPrice;
			}

			set
			{
				this.listPrice = value;
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
    <Hash>1370956ba98db4a3e27ae805f33feca1</Hash>
</Codenesium>*/