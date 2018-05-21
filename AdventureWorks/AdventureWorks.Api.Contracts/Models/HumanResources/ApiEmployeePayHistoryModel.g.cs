using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmployeePayHistoryModel: AbstractModel
	{
		public ApiEmployeePayHistoryModel() : base()
		{}

		public ApiEmployeePayHistoryModel(
			DateTime modifiedDate,
			int payFrequency,
			decimal rate,
			DateTime rateChangeDate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PayFrequency = payFrequency.ToInt();
			this.Rate = rate.ToDecimal();
			this.RateChangeDate = rateChangeDate.ToDateTime();
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

		private int payFrequency;

		[Required]
		public int PayFrequency
		{
			get
			{
				return this.payFrequency;
			}

			set
			{
				this.payFrequency = value;
			}
		}

		private decimal rate;

		[Required]
		public decimal Rate
		{
			get
			{
				return this.rate;
			}

			set
			{
				this.rate = value;
			}
		}

		private DateTime rateChangeDate;

		[Required]
		public DateTime RateChangeDate
		{
			get
			{
				return this.rateChangeDate;
			}

			set
			{
				this.rateChangeDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>389185c5bf8ad2328cbd7890f5b89c12</Hash>
</Codenesium>*/