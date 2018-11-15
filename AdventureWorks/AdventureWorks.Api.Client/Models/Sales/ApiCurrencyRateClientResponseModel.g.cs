using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiCurrencyRateClientResponseModel : AbstractApiClientResponseModel
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

			this.FromCurrencyCodeEntity = nameof(ApiResponse.Currencies);
			this.ToCurrencyCodeEntity = nameof(ApiResponse.Currencies);
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
		public string FromCurrencyCodeEntity { get; set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string ToCurrencyCode { get; private set; }

		[JsonProperty]
		public string ToCurrencyCodeEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>289e5a38ba5e98b77d664ca33cd9d5ee</Hash>
</Codenesium>*/