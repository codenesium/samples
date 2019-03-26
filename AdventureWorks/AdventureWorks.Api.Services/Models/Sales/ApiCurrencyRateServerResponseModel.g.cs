using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiCurrencyRateServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int currencyRateID,
			decimal averageRate,
			DateTime currencyRateDate,
			decimal endOfDayRate,
			string fromCurrencyCode,
			DateTime modifiedDate,
			string toCurrencyCode)
		{
			this.CurrencyRateID = currencyRateID;
			this.AverageRate = averageRate;
			this.CurrencyRateDate = currencyRateDate;
			this.EndOfDayRate = endOfDayRate;
			this.FromCurrencyCode = fromCurrencyCode;
			this.ModifiedDate = modifiedDate;
			this.ToCurrencyCode = toCurrencyCode;
		}

		[JsonProperty]
		public decimal AverageRate { get; private set; }

		[JsonProperty]
		public DateTime CurrencyRateDate { get; private set; }

		[JsonProperty]
		public int CurrencyRateID { get; private set; }

		[JsonProperty]
		public decimal EndOfDayRate { get; private set; }

		[JsonProperty]
		public string FromCurrencyCode { get; private set; }

		[JsonProperty]
		public string FromCurrencyCodeEntity { get; private set; } = RouteConstants.Currencies;

		[JsonProperty]
		public ApiCurrencyServerResponseModel FromCurrencyCodeNavigation { get; private set; }

		public void SetFromCurrencyCodeNavigation(ApiCurrencyServerResponseModel value)
		{
			this.FromCurrencyCodeNavigation = value;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string ToCurrencyCode { get; private set; }

		[JsonProperty]
		public string ToCurrencyCodeEntity { get; private set; } = RouteConstants.Currencies;

		[JsonProperty]
		public ApiCurrencyServerResponseModel ToCurrencyCodeNavigation { get; private set; }

		public void SetToCurrencyCodeNavigation(ApiCurrencyServerResponseModel value)
		{
			this.ToCurrencyCodeNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>205548ebfcf12f5221be3063d6473307</Hash>
</Codenesium>*/