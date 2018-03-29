using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesOrderDetailModel
	{
		public SalesOrderDetailModel()
		{}

		public SalesOrderDetailModel(int salesOrderDetailID,
		                             string carrierTrackingNumber,
		                             short orderQty,
		                             int productID,
		                             int specialOfferID,
		                             decimal unitPrice,
		                             decimal unitPriceDiscount,
		                             decimal lineTotal,
		                             Guid rowguid,
		                             DateTime modifiedDate)
		{
			this.SalesOrderDetailID = salesOrderDetailID.ToInt();
			this.CarrierTrackingNumber = carrierTrackingNumber;
			this.OrderQty = orderQty;
			this.ProductID = productID.ToInt();
			this.SpecialOfferID = specialOfferID.ToInt();
			this.UnitPrice = unitPrice;
			this.UnitPriceDiscount = unitPriceDiscount;
			this.LineTotal = lineTotal.ToDecimal();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public SalesOrderDetailModel(POCOSalesOrderDetail poco)
		{
			this.SalesOrderDetailID = poco.SalesOrderDetailID.ToInt();
			this.CarrierTrackingNumber = poco.CarrierTrackingNumber;
			this.OrderQty = poco.OrderQty;
			this.ProductID = poco.ProductID.ToInt();
			this.UnitPrice = poco.UnitPrice;
			this.UnitPriceDiscount = poco.UnitPriceDiscount;
			this.LineTotal = poco.LineTotal.ToDecimal();
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.SpecialOfferID = poco.SpecialOfferID.Value.ToInt();
		}

		private int _salesOrderDetailID;
		[Required]
		public int SalesOrderDetailID
		{
			get
			{
				return _salesOrderDetailID;
			}
			set
			{
				this._salesOrderDetailID = value;
			}
		}

		private string _carrierTrackingNumber;
		public string CarrierTrackingNumber
		{
			get
			{
				return _carrierTrackingNumber.IsEmptyOrZeroOrNull() ? null : _carrierTrackingNumber;
			}
			set
			{
				this._carrierTrackingNumber = value;
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

		private int _specialOfferID;
		[Required]
		public int SpecialOfferID
		{
			get
			{
				return _specialOfferID;
			}
			set
			{
				this._specialOfferID = value;
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

		private decimal _unitPriceDiscount;
		[Required]
		public decimal UnitPriceDiscount
		{
			get
			{
				return _unitPriceDiscount;
			}
			set
			{
				this._unitPriceDiscount = value;
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

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
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
    <Hash>817826453789135bdbdf35c9b97487ac</Hash>
</Codenesium>*/