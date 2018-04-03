using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductVendorModel
	{
		public ProductVendorModel()
		{}
		public ProductVendorModel(int businessEntityID,
		                          int averageLeadTime,
		                          decimal standardPrice,
		                          Nullable<decimal> lastReceiptCost,
		                          Nullable<DateTime> lastReceiptDate,
		                          int minOrderQty,
		                          int maxOrderQty,
		                          Nullable<int> onOrderQty,
		                          string unitMeasureCode,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.AverageLeadTime = averageLeadTime.ToInt();
			this.StandardPrice = standardPrice;
			this.LastReceiptCost = lastReceiptCost;
			this.LastReceiptDate = lastReceiptDate.ToNullableDateTime();
			this.MinOrderQty = minOrderQty.ToInt();
			this.MaxOrderQty = maxOrderQty.ToInt();
			this.OnOrderQty = onOrderQty.ToNullableInt();
			this.UnitMeasureCode = unitMeasureCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _businessEntityID;
		[Required]
		public int BusinessEntityID
		{
			get
			{
				return _businessEntityID;
			}
			set
			{
				this._businessEntityID = value;
			}
		}

		private int _averageLeadTime;
		[Required]
		public int AverageLeadTime
		{
			get
			{
				return _averageLeadTime;
			}
			set
			{
				this._averageLeadTime = value;
			}
		}

		private decimal _standardPrice;
		[Required]
		public decimal StandardPrice
		{
			get
			{
				return _standardPrice;
			}
			set
			{
				this._standardPrice = value;
			}
		}

		private Nullable<decimal> _lastReceiptCost;
		public Nullable<decimal> LastReceiptCost
		{
			get
			{
				return _lastReceiptCost.IsEmptyOrZeroOrNull() ? null : _lastReceiptCost;
			}
			set
			{
				this._lastReceiptCost = value;
			}
		}

		private Nullable<DateTime> _lastReceiptDate;
		public Nullable<DateTime> LastReceiptDate
		{
			get
			{
				return _lastReceiptDate.IsEmptyOrZeroOrNull() ? null : _lastReceiptDate;
			}
			set
			{
				this._lastReceiptDate = value;
			}
		}

		private int _minOrderQty;
		[Required]
		public int MinOrderQty
		{
			get
			{
				return _minOrderQty;
			}
			set
			{
				this._minOrderQty = value;
			}
		}

		private int _maxOrderQty;
		[Required]
		public int MaxOrderQty
		{
			get
			{
				return _maxOrderQty;
			}
			set
			{
				this._maxOrderQty = value;
			}
		}

		private Nullable<int> _onOrderQty;
		public Nullable<int> OnOrderQty
		{
			get
			{
				return _onOrderQty.IsEmptyOrZeroOrNull() ? null : _onOrderQty;
			}
			set
			{
				this._onOrderQty = value;
			}
		}

		private string _unitMeasureCode;
		[Required]
		public string UnitMeasureCode
		{
			get
			{
				return _unitMeasureCode;
			}
			set
			{
				this._unitMeasureCode = value;
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
    <Hash>d1feadd4012965a4b929c6cc835023bb</Hash>
</Codenesium>*/