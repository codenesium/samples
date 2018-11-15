using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiWorkOrderServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int workOrderID,
			DateTime dueDate,
			DateTime? endDate,
			DateTime modifiedDate,
			int orderQty,
			int productID,
			short scrappedQty,
			short? scrapReasonID,
			DateTime startDate,
			int stockedQty)
		{
			this.WorkOrderID = workOrderID;
			this.DueDate = dueDate;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.OrderQty = orderQty;
			this.ProductID = productID;
			this.ScrappedQty = scrappedQty;
			this.ScrapReasonID = scrapReasonID;
			this.StartDate = startDate;
			this.StockedQty = stockedQty;
		}

		[JsonProperty]
		public DateTime DueDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? EndDate { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int OrderQty { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public short ScrappedQty { get; private set; }

		[Required]
		[JsonProperty]
		public short? ScrapReasonID { get; private set; }

		[JsonProperty]
		public DateTime StartDate { get; private set; }

		[JsonProperty]
		public int StockedQty { get; private set; }

		[JsonProperty]
		public int WorkOrderID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bdf7010c1f850aa06cc02bb861901496</Hash>
</Codenesium>*/