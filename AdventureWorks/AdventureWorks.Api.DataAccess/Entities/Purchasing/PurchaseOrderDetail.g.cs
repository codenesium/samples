using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PurchaseOrderDetail", Schema="Purchasing")]
	public partial class PurchaseOrderDetail : AbstractEntity
	{
		public PurchaseOrderDetail()
		{
		}

		public virtual void SetProperties(
			DateTime dueDate,
			decimal lineTotal,
			DateTime modifiedDate,
			short orderQty,
			int productID,
			int purchaseOrderDetailID,
			int purchaseOrderID,
			double receivedQty,
			double rejectedQty,
			double stockedQty,
			decimal unitPrice)
		{
			this.DueDate = dueDate;
			this.LineTotal = lineTotal;
			this.ModifiedDate = modifiedDate;
			this.OrderQty = orderQty;
			this.ProductID = productID;
			this.PurchaseOrderDetailID = purchaseOrderDetailID;
			this.PurchaseOrderID = purchaseOrderID;
			this.ReceivedQty = receivedQty;
			this.RejectedQty = rejectedQty;
			this.StockedQty = stockedQty;
			this.UnitPrice = unitPrice;
		}

		[Column("DueDate")]
		public virtual DateTime DueDate { get; private set; }

		[Column("LineTotal")]
		public virtual decimal LineTotal { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("OrderQty")]
		public virtual short OrderQty { get; private set; }

		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Key]
		[Column("PurchaseOrderDetailID")]
		public virtual int PurchaseOrderDetailID { get; private set; }

		[Key]
		[Column("PurchaseOrderID")]
		public virtual int PurchaseOrderID { get; private set; }

		[Column("ReceivedQty")]
		public virtual double ReceivedQty { get; private set; }

		[Column("RejectedQty")]
		public virtual double RejectedQty { get; private set; }

		[Column("StockedQty")]
		public virtual double StockedQty { get; private set; }

		[Column("UnitPrice")]
		public virtual decimal UnitPrice { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4b441d8f5966149b528070ad0a321786</Hash>
</Codenesium>*/