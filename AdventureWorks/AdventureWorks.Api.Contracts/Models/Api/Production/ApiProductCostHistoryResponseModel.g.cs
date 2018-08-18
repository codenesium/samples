using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductCostHistoryResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int productID,
			DateTime? endDate,
			DateTime modifiedDate,
			decimal standardCost,
			DateTime startDate)
		{
			this.ProductID = productID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.StandardCost = standardCost;
			this.StartDate = startDate;
		}

		[Required]
		[JsonProperty]
		public DateTime? EndDate { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public decimal StandardCost { get; private set; }

		[JsonProperty]
		public DateTime StartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6c974bb436d138fac2d67728f479b405</Hash>
</Codenesium>*/