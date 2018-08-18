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
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int PayFrequency { get; private set; }

		[Required]
		[JsonProperty]
		public decimal Rate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime RateChangeDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>af0aebf28cc54ffe56e9acc0d89b0a79</Hash>
</Codenesium>*/