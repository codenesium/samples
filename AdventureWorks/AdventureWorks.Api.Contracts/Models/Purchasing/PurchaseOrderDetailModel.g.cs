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

		public PurchaseOrderDetailModel(POCOPurchaseOrderDetail poco)
		{
			this.PurchaseOrderDetailID = poco.PurchaseOrderDetailID.ToInt();
			this.DueDate = poco.DueDate.ToDateTime();
			this.OrderQty = poco.OrderQty;
			this.UnitPrice = poco.UnitPrice;
			this.LineTotal = poco.LineTotal;
			this.ReceivedQty = poco.ReceivedQty.ToDecimal();
			this.RejectedQty = poco.RejectedQty.ToDecimal();
			this.StockedQty = poco.StockedQty.ToDecimal();
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.ProductID = poco.ProductID.Value.ToInt();
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
    <Hash>e1c135084980f4e79ff700e58a830697</Hash>
</Codenesium>*/