using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOWorkOrder: AbstractDTO
	{
		public DTOWorkOrder() : base()
		{}

		public void SetProperties(int workOrderID,
		                          DateTime dueDate,
		                          Nullable<DateTime> endDate,
		                          DateTime modifiedDate,
		                          int orderQty,
		                          int productID,
		                          short scrappedQty,
		                          Nullable<short> scrapReasonID,
		                          DateTime startDate,
		                          int stockedQty)
		{
			this.DueDate = dueDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderQty = orderQty.ToInt();
			this.ProductID = productID.ToInt();
			this.ScrappedQty = scrappedQty;
			this.ScrapReasonID = scrapReasonID;
			this.StartDate = startDate.ToDateTime();
			this.StockedQty = stockedQty.ToInt();
			this.WorkOrderID = workOrderID.ToInt();
		}

		public DateTime DueDate { get; set; }
		public Nullable<DateTime> EndDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int OrderQty { get; set; }
		public int ProductID { get; set; }
		public short ScrappedQty { get; set; }
		public Nullable<short> ScrapReasonID { get; set; }
		public DateTime StartDate { get; set; }
		public int StockedQty { get; set; }
		public int WorkOrderID { get; set; }
	}
}

/*<Codenesium>
    <Hash>573d38d249c71030e6555f778ec9bbd4</Hash>
</Codenesium>*/