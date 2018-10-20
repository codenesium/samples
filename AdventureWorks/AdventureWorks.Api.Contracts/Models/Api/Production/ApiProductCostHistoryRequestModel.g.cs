using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductCostHistoryRequestModel : AbstractApiRequestModel
	{
		public ApiProductCostHistoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? endDate,
			DateTime modifiedDate,
			decimal standardCost,
			DateTime startDate)
		{
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.StandardCost = standardCost;
			this.StartDate = startDate;
		}

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public decimal StandardCost { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; } = default(DateTime);
	}
}

/*<Codenesium>
    <Hash>068e3687408d648a55420a1a8e522a83</Hash>
</Codenesium>*/