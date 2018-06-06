using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOPurchaseOrderDetail: AbstractBusinessObject
	{
		public BOPurchaseOrderDetail() : base()
		{}

		public void SetProperties(int purchaseOrderID,
		                          DateTime dueDate,
		                          decimal lineTotal,
		                          DateTime modifiedDate,
		                          short orderQty,
		                          int productID,
		                          int purchaseOrderDetailID,
		                          decimal receivedQty,
		                          decimal rejectedQty,
		                          decimal stockedQty,
		                          decimal unitPrice)
		{
			this.DueDate = dueDate.ToDateTime();
			this.LineTotal = lineTotal.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderQty = orderQty;
			this.ProductID = productID.ToInt();
			this.PurchaseOrderDetailID = purchaseOrderDetailID.ToInt();
			this.PurchaseOrderID = purchaseOrderID.ToInt();
			this.ReceivedQty = receivedQty.ToDecimal();
			this.RejectedQty = rejectedQty.ToDecimal();
			this.StockedQty = stockedQty.ToDecimal();
			this.UnitPrice = unitPrice.ToDecimal();
		}

		public DateTime DueDate { get; private set; }
		public decimal LineTotal { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public short OrderQty { get; private set; }
		public int ProductID { get; private set; }
		public int PurchaseOrderDetailID { get; private set; }
		public int PurchaseOrderID { get; private set; }
		public decimal ReceivedQty { get; private set; }
		public decimal RejectedQty { get; private set; }
		public decimal StockedQty { get; private set; }
		public decimal UnitPrice { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4709f3f28137fddeaedf7e7d74d1f97c</Hash>
</Codenesium>*/