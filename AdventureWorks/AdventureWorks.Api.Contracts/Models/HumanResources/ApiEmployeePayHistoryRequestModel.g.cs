using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmployeePayHistoryRequestModel: AbstractApiRequestModel
	{
		public ApiEmployeePayHistoryRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>8e694261ef90d1d89ca140d02bfc3d29</Hash>
</Codenesium>*/