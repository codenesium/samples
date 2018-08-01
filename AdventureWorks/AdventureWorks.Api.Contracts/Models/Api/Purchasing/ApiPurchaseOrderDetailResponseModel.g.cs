using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPurchaseOrderDetailResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int purchaseOrderID,
			DateTime dueDate,
			decimal lineTotal,
			DateTime modifiedDate,
			short orderQty,
			int productID,
			int purchaseOrderDetailID,
			double receivedQty,
			double rejectedQty,
			double stockedQty,
			decimal unitPrice)
		{
			this.PurchaseOrderID = purchaseOrderID;
			this.DueDate = dueDate;
			this.LineTotal = lineTotal;
			this.ModifiedDate = modifiedDate;
			this.OrderQty = orderQty;
			this.ProductID = productID;
			this.PurchaseOrderDetailID = purchaseOrderDetailID;
			this.ReceivedQty = receivedQty;
			this.RejectedQty = rejectedQty;
			this.StockedQty = stockedQty;
			this.UnitPrice = unitPrice;
		}

		[JsonProperty]
		public DateTime DueDate { get; private set; }

		[JsonProperty]
		public decimal LineTotal { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public short OrderQty { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public int PurchaseOrderDetailID { get; private set; }

		[JsonProperty]
		public int PurchaseOrderID { get; private set; }

		[JsonProperty]
		public double ReceivedQty { get; private set; }

		[JsonProperty]
		public double RejectedQty { get; private set; }

		[JsonProperty]
		public double StockedQty { get; private set; }

		[JsonProperty]
		public decimal UnitPrice { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c71b141f6983487c5bde02c2a35c535a</Hash>
</Codenesium>*/