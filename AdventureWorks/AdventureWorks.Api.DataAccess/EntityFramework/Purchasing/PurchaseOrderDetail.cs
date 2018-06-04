using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PurchaseOrderDetail", Schema="Purchasing")]
	public partial class PurchaseOrderDetail: AbstractEntity
	{
		public PurchaseOrderDetail()
		{}

		public void SetProperties(
			DateTime dueDate,
			decimal lineTotal,
			DateTime modifiedDate,
			short orderQty,
			int productID,
			int purchaseOrderDetailID,
			int purchaseOrderID,
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

		[Column("DueDate", TypeName="datetime")]
		public DateTime DueDate { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("LineTotal", TypeName="money")]
		public decimal LineTotal { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("OrderQty", TypeName="smallint")]
		public short OrderQty { get; private set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }

		[Column("PurchaseOrderDetailID", TypeName="int")]
		public int PurchaseOrderDetailID { get; private set; }

		[Key]
		[Column("PurchaseOrderID", TypeName="int")]
		public int PurchaseOrderID { get; private set; }

		[Column("ReceivedQty", TypeName="decimal")]
		public decimal ReceivedQty { get; private set; }

		[Column("RejectedQty", TypeName="decimal")]
		public decimal RejectedQty { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("StockedQty", TypeName="decimal")]
		public decimal StockedQty { get; private set; }

		[Column("UnitPrice", TypeName="money")]
		public decimal UnitPrice { get; private set; }
	}
}

/*<Codenesium>
    <Hash>da12087bb673f9e1ec330180b3553aba</Hash>
</Codenesium>*/