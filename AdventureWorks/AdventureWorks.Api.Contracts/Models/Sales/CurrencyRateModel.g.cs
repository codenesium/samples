using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class CurrencyRateModel
	{
		public CurrencyRateModel()
		{}

		public CurrencyRateModel(
			DateTime currencyRateDate,
			string fromCurrencyCode,
			string toCurrencyCode,
			decimal averageRate,
			decimal endOfDayRate,
			DateTime modifiedDate)
		{
			this.CurrencyRateDate = currencyRateDate.ToDateTime();
			this.FromCurrencyCode = fromCurrencyCode;
			this.ToCurrencyCode = toCurrencyCode;
			this.AverageRate = averageRate;
			this.EndOfDayRate = endOfDayRate;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private DateTime currencyRateDate;

		[Required]
		public DateTime CurrencyRateDate
		{
			get
			{
				return this.currencyRateDate;
			}

			set
			{
				this.currencyRateDate = value;
			}
		}

		private string fromCurrencyCode;

		[Required]
		public string FromCurrencyCode
		{
			get
			{
				return this.fromCurrencyCode;
			}

			set
			{
				this.fromCurrencyCode = value;
			}
		}

		private string toCurrencyCode;

		[Required]
		public string ToCurrencyCode
		{
			get
			{
				return this.toCurrencyCode;
			}

			set
			{
				this.toCurrencyCode = value;
			}
		}

		private decimal averageRate;

		[Required]
		public decimal AverageRate
		{
			get
			{
				return this.averageRate;
			}

			set
			{
				this.averageRate = value;
			}
		}

		private decimal endOfDayRate;

		[Required]
		public decimal EndOfDayRate
		{
			get
			{
				return this.endOfDayRate;
			}

			set
			{
				this.endOfDayRate = value;
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
    <Hash>80d5e258b401ca42fbaa0cc02c3f9bda</Hash>
</Codenesium>*/