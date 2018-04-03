using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPurchaseOrderDetail
	{
		public POCOPurchaseOrderDetail()
		{}

		public POCOPurchaseOrderDetail(int purchaseOrderID,
		                               int purchaseOrderDetailID,
		                               DateTime dueDate,
		                               short orderQty,
		                               int productID,
		                               decimal unitPrice,
		                               decimal lineTotal,
		                               decimal receivedQty,
		                               decimal rejectedQty,
		                               decimal stockedQty,
		                               DateTime modifiedDate)
		{
			this.PurchaseOrderID = purchaseOrderID.ToInt();
			this.PurchaseOrderDetailID = purchaseOrderDetailID.ToInt();
			this.DueDate = dueDate.ToDateTime();
			this.OrderQty = orderQty;
			this.ProductID = productID.ToInt();
			this.UnitPrice = unitPrice;
			this.LineTotal = lineTotal;
			this.ReceivedQty = receivedQty.ToDecimal();
			this.RejectedQty = rejectedQty.ToDecimal();
			this.StockedQty = stockedQty.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int PurchaseOrderID {get; set;}
		public int PurchaseOrderDetailID {get; set;}
		public DateTime DueDate {get; set;}
		public short OrderQty {get; set;}
		public int ProductID {get; set;}
		public decimal UnitPrice {get; set;}
		public decimal LineTotal {get; set;}
		public decimal ReceivedQty {get; set;}
		public decimal RejectedQty {get; set;}
		public decimal StockedQty {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderIDValue {get; set;} = true;

		public bool ShouldSerializePurchaseOrderID()
		{
			return ShouldSerializePurchaseOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderDetailIDValue {get; set;} = true;

		public bool ShouldSerializePurchaseOrderDetailID()
		{
			return ShouldSerializePurchaseOrderDetailIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDueDateValue {get; set;} = true;

		public bool ShouldSerializeDueDate()
		{
			return ShouldSerializeDueDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderQtyValue {get; set;} = true;

		public bool ShouldSerializeOrderQty()
		{
			return ShouldSerializeOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitPriceValue {get; set;} = true;

		public bool ShouldSerializeUnitPrice()
		{
			return ShouldSerializeUnitPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLineTotalValue {get; set;} = true;

		public bool ShouldSerializeLineTotal()
		{
			return ShouldSerializeLineTotalValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReceivedQtyValue {get; set;} = true;

		public bool ShouldSerializeReceivedQty()
		{
			return ShouldSerializeReceivedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRejectedQtyValue {get; set;} = true;

		public bool ShouldSerializeRejectedQty()
		{
			return ShouldSerializeRejectedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStockedQtyValue {get; set;} = true;

		public bool ShouldSerializeStockedQty()
		{
			return ShouldSerializeStockedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializePurchaseOrderIDValue = false;
			this.ShouldSerializePurchaseOrderDetailIDValue = false;
			this.ShouldSerializeDueDateValue = false;
			this.ShouldSerializeOrderQtyValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeUnitPriceValue = false;
			this.ShouldSerializeLineTotalValue = false;
			this.ShouldSerializeReceivedQtyValue = false;
			this.ShouldSerializeRejectedQtyValue = false;
			this.ShouldSerializeStockedQtyValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>edc12879a11e9bd549fab305b725ef39</Hash>
</Codenesium>*/