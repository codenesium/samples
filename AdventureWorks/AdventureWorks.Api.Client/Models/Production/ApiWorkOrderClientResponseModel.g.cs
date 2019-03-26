using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiWorkOrderClientResponseModel : AbstractApiClientResponseModel
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

			this.ProductIDEntity = nameof(ApiResponse.Products);

			this.ScrapReasonIDEntity = nameof(ApiResponse.ScrapReasons);
		}

		[JsonProperty]
		public ApiProductClientResponseModel ProductIDNavigation { get; private set; }

		public void SetProductIDNavigation(ApiProductClientResponseModel value)
		{
			this.ProductIDNavigation = value;
		}

		[JsonProperty]
		public ApiScrapReasonClientResponseModel ScrapReasonIDNavigation { get; private set; }

		public void SetScrapReasonIDNavigation(ApiScrapReasonClientResponseModel value)
		{
			this.ScrapReasonIDNavigation = value;
		}

		[JsonProperty]
		public DateTime DueDate { get; private set; }

		[JsonProperty]
		public DateTime? EndDate { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int OrderQty { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public string ProductIDEntity { get; set; }

		[JsonProperty]
		public short ScrappedQty { get; private set; }

		[JsonProperty]
		public short? ScrapReasonID { get; private set; }

		[JsonProperty]
		public string ScrapReasonIDEntity { get; set; }

		[JsonProperty]
		public DateTime StartDate { get; private set; }

		[JsonProperty]
		public int StockedQty { get; private set; }

		[JsonProperty]
		public int WorkOrderID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>323af1f56e64da42024dd1cbf6df712e</Hash>
</Codenesium>*/