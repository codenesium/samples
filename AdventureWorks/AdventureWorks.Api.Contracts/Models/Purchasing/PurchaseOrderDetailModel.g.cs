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
		public PurchaseOrderDetailModel(int purchaseOrderDetailID,
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
			this.UnitPrice = unitPrice;
			this.LineTotal = lineTotal;
			this.ReceivedQty = receivedQty.ToDecimal();
			this.RejectedQty = rejectedQty.ToDecimal();
			this.StockedQty = stockedQty.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _purchaseOrderDetailID;
		[Required]
		public int PurchaseOrderDetailID
		{
			get
			{
				return _purchaseOrderDetailID;
			}
			set
			{
				this._purchaseOrderDetailID = value;
			}
		}

		private DateTime _dueDate;
		[Required]
		public DateTime DueDate
		{
			get
			{
				return _dueDate;
			}
			set
			{
				this._dueDate = value;
			}
		}

		private short _orderQty;
		[Required]
		public short OrderQty
		{
			get
			{
				return _orderQty;
			}
			set
			{
				this._orderQty = value;
			}
		}

		private int _productID;
		[Required]
		public int ProductID
		{
			get
			{
				return _productID;
			}
			set
			{
				this._productID = value;
			}
		}

		private decimal _unitPrice;
		[Required]
		public decimal UnitPrice
		{
			get
			{
				return _unitPrice;
			}
			set
			{
				this._unitPrice = value;
			}
		}

		private decimal _lineTotal;
		[Required]
		public decimal LineTotal
		{
			get
			{
				return _lineTotal;
			}
			set
			{
				this._lineTotal = value;
			}
		}

		private decimal _receivedQty;
		[Required]
		public decimal ReceivedQty
		{
			get
			{
				return _receivedQty;
			}
			set
			{
				this._receivedQty = value;
			}
		}

		private decimal _rejectedQty;
		[Required]
		public decimal RejectedQty
		{
			get
			{
				return _rejectedQty;
			}
			set
			{
				this._rejectedQty = value;
			}
		}

		private decimal _stockedQty;
		[Required]
		public decimal StockedQty
		{
			get
			{
				return _stockedQty;
			}
			set
			{
				this._stockedQty = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>74c9f34640b97b7a2b1a1f1eaa9c1593</Hash>
</Codenesium>*/