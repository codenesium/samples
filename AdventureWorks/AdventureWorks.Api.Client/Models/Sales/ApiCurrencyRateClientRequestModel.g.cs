using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiCurrencyRateClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCurrencyRateClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal averageRate,
			DateTime currencyRateDate,
			decimal endOfDayRate,
			string fromCurrencyCode,
			DateTime modifiedDate,
			string toCurrencyCode)
		{
			this.AverageRate = averageRate;
			this.CurrencyRateDate = currencyRateDate;
			this.EndOfDayRate = endOfDayRate;
			this.FromCurrencyCode = fromCurrencyCode;
			this.ModifiedDate = modifiedDate;
			this.ToCurrencyCode = toCurrencyCode;
		}

		[JsonProperty]
		public decimal AverageRate { get; private set; } = default(decimal);

		[JsonProperty]
		public DateTime CurrencyRateDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public decimal EndOfDayRate { get; private set; } = default(decimal);

		[JsonProperty]
		public string FromCurrencyCode { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string ToCurrencyCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>236c86bf5f9d9b8d0403a87b4ab9e949</Hash>
</Codenesium>*/