using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCurrencyRateRequestModel : AbstractApiRequestModel
	{
		public ApiCurrencyRateRequestModel()
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

		[Required]
		[JsonProperty]
		public decimal AverageRate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime CurrencyRateDate { get; private set; }

		[Required]
		[JsonProperty]
		public decimal EndOfDayRate { get; private set; }

		[Required]
		[JsonProperty]
		public string FromCurrencyCode { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string ToCurrencyCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ce3ebd4843379b63ec341b4910374465</Hash>
</Codenesium>*/