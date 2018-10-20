using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmployeePayHistoryRequestModel : AbstractApiRequestModel
	{
		public ApiEmployeePayHistoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			int payFrequency,
			decimal rate,
			DateTime rateChangeDate)
		{
			this.ModifiedDate = modifiedDate;
			this.PayFrequency = payFrequency;
			this.Rate = rate;
			this.RateChangeDate = rateChangeDate;
		}

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int PayFrequency { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public decimal Rate { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime RateChangeDate { get; private set; } = default(DateTime);
	}
}

/*<Codenesium>
    <Hash>45d75e0e37f6a4675ddeb1d60a1fd0e4</Hash>
</Codenesium>*/