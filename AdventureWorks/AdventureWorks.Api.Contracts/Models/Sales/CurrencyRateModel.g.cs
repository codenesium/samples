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

		public CurrencyRateModel(DateTime currencyRateDate,
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

		public CurrencyRateModel(POCOCurrencyRate poco)
		{
			this.CurrencyRateDate = poco.CurrencyRateDate.ToDateTime();
			this.AverageRate = poco.AverageRate;
			this.EndOfDayRate = poco.EndOfDayRate;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.FromCurrencyCode = poco.FromCurrencyCode.Value.ToString();
			this.ToCurrencyCode = poco.ToCurrencyCode.Value.ToString();
		}

		private DateTime _currencyRateDate;
		[Required]
		public DateTime CurrencyRateDate
		{
			get
			{
				return _currencyRateDate;
			}
			set
			{
				this._currencyRateDate = value;
			}
		}

		private string _fromCurrencyCode;
		[Required]
		public string FromCurrencyCode
		{
			get
			{
				return _fromCurrencyCode;
			}
			set
			{
				this._fromCurrencyCode = value;
			}
		}

		private string _toCurrencyCode;
		[Required]
		public string ToCurrencyCode
		{
			get
			{
				return _toCurrencyCode;
			}
			set
			{
				this._toCurrencyCode = value;
			}
		}

		private decimal _averageRate;
		[Required]
		public decimal AverageRate
		{
			get
			{
				return _averageRate;
			}
			set
			{
				this._averageRate = value;
			}
		}

		private decimal _endOfDayRate;
		[Required]
		public decimal EndOfDayRate
		{
			get
			{
				return _endOfDayRate;
			}
			set
			{
				this._endOfDayRate = value;
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
    <Hash>5894e691d59e15e17932abae01ce7bb0</Hash>
</Codenesium>*/