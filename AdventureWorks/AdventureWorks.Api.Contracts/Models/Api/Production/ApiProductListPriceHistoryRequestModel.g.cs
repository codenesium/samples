using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductListPriceHistoryRequestModel : AbstractApiRequestModel
	{
		public ApiProductListPriceHistoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? endDate,
			decimal listPrice,
			DateTime modifiedDate,
			DateTime startDate)
		{
			this.EndDate = endDate;
			this.ListPrice = listPrice;
			this.ModifiedDate = modifiedDate;
			this.StartDate = startDate;
		}

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public decimal ListPrice { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; } = default(DateTime);
	}
}

/*<Codenesium>
    <Hash>afac74ed56b0591c2625dec8e07f30bd</Hash>
</Codenesium>*/