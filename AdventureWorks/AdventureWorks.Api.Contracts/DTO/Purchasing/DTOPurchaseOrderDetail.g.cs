using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOPurchaseOrderDetail: AbstractDTO
	{
		public DTOPurchaseOrderDetail() : base()
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

		public DateTime DueDate { get; set; }
		public decimal LineTotal { get; set; }
		public DateTime ModifiedDate { get; set; }
		public short OrderQty { get; set; }
		public int ProductID { get; set; }
		public int PurchaseOrderDetailID { get; set; }
		public int PurchaseOrderID { get; set; }
		public decimal ReceivedQty { get; set; }
		public decimal RejectedQty { get; set; }
		public decimal StockedQty { get; set; }
		public decimal UnitPrice { get; set; }
	}
}

/*<Codenesium>
    <Hash>6fdbcbc49d5f1cbf01964e39d093b84b</Hash>
</Codenesium>*/