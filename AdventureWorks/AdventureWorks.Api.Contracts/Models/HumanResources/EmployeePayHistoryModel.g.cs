using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class EmployeePayHistoryModel
	{
		public EmployeePayHistoryModel()
		{}

		public EmployeePayHistoryModel(
			DateTime rateChangeDate,
			decimal rate,
			int payFrequency,
			DateTime modifiedDate)
		{
			this.RateChangeDate = rateChangeDate.ToDateTime();
			this.Rate = rate.ToDecimal();
			this.PayFrequency = payFrequency.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
    <Hash>e1bf811cbca14b2811f47e55af775bcf</Hash>
</Codenesium>*/