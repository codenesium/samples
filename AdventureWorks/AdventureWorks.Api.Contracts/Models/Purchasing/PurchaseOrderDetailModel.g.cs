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
			this.ProductID = productID.ToInt();
			this.UnitPrice = unitPrice.ToDecimal();
			this.LineTotal = lineTotal.ToDecimal();
			this.ReceivedQty = receivedQty.ToDecimal();
			this.RejectedQty = rejectedQty.ToDecimal();
			this.StockedQty = stockedQty.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>59ded216510bfd455675b741b95a123a</Hash>
</Codenesium>*/