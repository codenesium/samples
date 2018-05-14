using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCurrencyRateModel
	{
		public ApiCurrencyRateModel()
		{}

		public ApiCurrencyRateModel(
			decimal averageRate,
			DateTime currencyRateDate,
			decimal endOfDayRate,
			string fromCurrencyCode,
			DateTime modifiedDate,
			string toCurrencyCode)
		{
			this.AverageRate = averageRate.ToDecimal();
			this.CurrencyRateDate = currencyRateDate.ToDateTime();
			this.EndOfDayRate = endOfDayRate.ToDecimal();
			this.FromCurrencyCode = fromCurrencyCode.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ToCurrencyCode = toCurrencyCode.ToString();
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
	}
}

/*<Codenesium>
    <Hash>52a892f6632a04ed5f56ad49706f30d9</Hash>
</Codenesium>*/