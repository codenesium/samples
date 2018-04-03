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
		public EmployeePayHistoryModel(DateTime rateChangeDate,
		                               decimal rate,
		                               int payFrequency,
		                               DateTime modifiedDate)
		{
			this.RateChangeDate = rateChangeDate.ToDateTime();
			this.Rate = rate;
			this.PayFrequency = payFrequency;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private DateTime _rateChangeDate;
		[Required]
		public DateTime RateChangeDate
		{
			get
			{
				return _rateChangeDate;
			}
			set
			{
				this._rateChangeDate = value;
			}
		}

		private decimal _rate;
		[Required]
		public decimal Rate
		{
			get
			{
				return _rate;
			}
			set
			{
				this._rate = value;
			}
		}

		private int _payFrequency;
		[Required]
		public int PayFrequency
		{
			get
			{
				return _payFrequency;
			}
			set
			{
				this._payFrequency = value;
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
    <Hash>fc9c2f701de23768e75aee5fcf71dedc</Hash>
</Codenesium>*/