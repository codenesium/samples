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
    <Hash>9049666adff842c2305c0a1cbc7b14af</Hash>
</Codenesium>*/