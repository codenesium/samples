using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class PurchaseOrderDetailModel
	{
		public PurchaseOrderDetailModel()
		{}

		public PurchaseOrderDetailModel(
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
			this.ReceivedQty = receivedQty.ToDecimal();
			this.RejectedQty = rejectedQty.ToDecimal();
			this.StockedQty = stockedQty.ToDecimal();
			this.UnitPrice = unitPrice.ToDecimal();
		}

		private DateTime dueDate;

		[Required]
		public DateTime DueDate
		{
			get
			{
				return this.dueDate;
			}

			set
			{
				this.dueDate = value;
			}
		}

		private decimal lineTotal;

		[Required]
		public decimal LineTotal
		{
			get
			{
				return this.lineTotal;
			}

			set
			{
				this.lineTotal = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private short orderQty;

		[Required]
		public short OrderQty
		{
			get
			{
				return this.orderQty;
			}

			set
			{
				this.orderQty = value;
			}
		}

		private int productID;

		[Required]
		public int ProductID
		{
			get
			{
				return this.productID;
			}

			set
			{
				this.productID = value;
			}
		}

		private int purchaseOrderDetailID;

		[Required]
		public int PurchaseOrderDetailID
		{
			get
			{
				return this.purchaseOrderDetailID;
			}

			set
			{
				this.purchaseOrderDetailID = value;
			}
		}

		private decimal receivedQty;

		[Required]
		public decimal ReceivedQty
		{
			get
			{
				return this.receivedQty;
			}

			set
			{
				this.receivedQty = value;
			}
		}

		private decimal rejectedQty;

		[Required]
		public decimal RejectedQty
		{
			get
			{
				return this.rejectedQty;
			}

			set
			{
				this.rejectedQty = value;
			}
		}

		private decimal stockedQty;

		[Required]
		public decimal StockedQty
		{
			get
			{
				return this.stockedQty;
			}

			set
			{
				this.stockedQty = value;
			}
		}

		private decimal unitPrice;

		[Required]
		public decimal UnitPrice
		{
			get
			{
				return this.unitPrice;
			}

			set
			{
				this.unitPrice = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>09851129b6ef274cb6f4bdde51ce7ac9</Hash>
</Codenesium>*/