using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPurchaseOrderDetail
	{
		public POCOPurchaseOrderDetail()
		{}

		public POCOPurchaseOrderDetail(
			int purchaseOrderID,
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
			this.PurchaseOrderDetailID = purchaseOrderDetailID.ToInt();
			this.DueDate = dueDate.ToDateTime();
			this.OrderQty = orderQty;
			this.UnitPrice = unitPrice.ToDecimal();
			this.LineTotal = lineTotal.ToDecimal();
			this.ReceivedQty = receivedQty.ToDecimal();
			this.RejectedQty = rejectedQty.ToDecimal();
			this.StockedQty = stockedQty.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.PurchaseOrderID = new ReferenceEntity<int>(purchaseOrderID,
			                                                nameof(ApiResponse.PurchaseOrderHeaders));
			this.ProductID = new ReferenceEntity<int>(productID,
			                                          nameof(ApiResponse.Products));
		}

		public ReferenceEntity<int> PurchaseOrderID { get; set; }
		public int PurchaseOrderDetailID { get; set; }
		public DateTime DueDate { get; set; }
		public short OrderQty { get; set; }
		public ReferenceEntity<int> ProductID { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal LineTotal { get; set; }
		public decimal ReceivedQty { get; set; }
		public decimal RejectedQty { get; set; }
		public decimal StockedQty { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderIDValue { get; set; } = true;

		public bool ShouldSerializePurchaseOrderID()
		{
			return this.ShouldSerializePurchaseOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderDetailIDValue { get; set; } = true;

		public bool ShouldSerializePurchaseOrderDetailID()
		{
			return this.ShouldSerializePurchaseOrderDetailIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDueDateValue { get; set; } = true;

		public bool ShouldSerializeDueDate()
		{
			return this.ShouldSerializeDueDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeOrderQty()
		{
			return this.ShouldSerializeOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitPriceValue { get; set; } = true;

		public bool ShouldSerializeUnitPrice()
		{
			return this.ShouldSerializeUnitPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLineTotalValue { get; set; } = true;

		public bool ShouldSerializeLineTotal()
		{
			return this.ShouldSerializeLineTotalValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReceivedQtyValue { get; set; } = true;

		public bool ShouldSerializeReceivedQty()
		{
			return this.ShouldSerializeReceivedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRejectedQtyValue { get; set; } = true;

		public bool ShouldSerializeRejectedQty()
		{
			return this.ShouldSerializeRejectedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStockedQtyValue { get; set; } = true;

		public bool ShouldSerializeStockedQty()
		{
			return this.ShouldSerializeStockedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
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
    <Hash>26be6000bc8b114614790611d85dbd48</Hash>
</Codenesium>*/