using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PurchaseOrderDetail", Schema="Purchasing")]
	public partial class EFPurchaseOrderDetail: AbstractEntityFrameworkPOCO
	{
		public EFPurchaseOrderDetail()
		{}

		public void SetProperties(
			int purchaseOrderID,
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

		[Column("DueDate", TypeName="datetime")]
		public DateTime DueDate { get; set; }

		[Column("LineTotal", TypeName="money")]
		public decimal LineTotal { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("OrderQty", TypeName="smallint")]
		public short OrderQty { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("PurchaseOrderDetailID", TypeName="int")]
		public int PurchaseOrderDetailID { get; set; }

		[Key]
		[Column("PurchaseOrderID", TypeName="int")]
		public int PurchaseOrderID { get; set; }

		[Column("ReceivedQty", TypeName="decimal")]
		public decimal ReceivedQty { get; set; }

		[Column("RejectedQty", TypeName="decimal")]
		public decimal RejectedQty { get; set; }

		[Column("StockedQty", TypeName="decimal")]
		public decimal StockedQty { get; set; }

		[Column("UnitPrice", TypeName="money")]
		public decimal UnitPrice { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }

		[ForeignKey("PurchaseOrderID")]
		public virtual EFPurchaseOrderHeader PurchaseOrderHeader { get; set; }
	}
}

/*<Codenesium>
    <Hash>271b5dd48ba17f27e61000c2dc2ea2c6</Hash>
</Codenesium>*/