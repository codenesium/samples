using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOWorkOrder: AbstractBusinessObject
	{
		public BOWorkOrder() : base()
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

		public DateTime DueDate { get; private set; }
		public Nullable<DateTime> EndDate { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int OrderQty { get; private set; }
		public int ProductID { get; private set; }
		public short ScrappedQty { get; private set; }
		public Nullable<short> ScrapReasonID { get; private set; }
		public DateTime StartDate { get; private set; }
		public int StockedQty { get; private set; }
		public int WorkOrderID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>87f76e360159820929ee0cb9d1f71769</Hash>
</Codenesium>*/