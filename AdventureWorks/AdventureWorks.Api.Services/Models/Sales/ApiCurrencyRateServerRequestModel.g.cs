using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiCurrencyRateServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCurrencyRateServerRequestModel()
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
		public decimal AverageRate { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime CurrencyRateDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public decimal EndOfDayRate { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public string FromCurrencyCode { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string ToCurrencyCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c69411a115e3b45dc39c41c208d7ebed</Hash>
</Codenesium>*/