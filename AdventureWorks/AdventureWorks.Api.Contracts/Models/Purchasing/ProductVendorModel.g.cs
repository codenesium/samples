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

		public ProductVendorModel(
			int businessEntityID,
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
			this.StandardPrice = standardPrice.ToDecimal();
			this.LastReceiptCost = lastReceiptCost.ToNullableDecimal();
			this.LastReceiptDate = lastReceiptDate.ToNullableDateTime();
			this.MinOrderQty = minOrderQty.ToInt();
			this.MaxOrderQty = maxOrderQty.ToInt();
			this.OnOrderQty = onOrderQty.ToNullableInt();
			this.UnitMeasureCode = unitMeasureCode.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int businessEntityID;

		[Required]
		public int BusinessEntityID
		{
			get
			{
				return this.businessEntityID;
			}

			set
			{
				this.businessEntityID = value;
			}
		}

		private int averageLeadTime;

		[Required]
		public int AverageLeadTime
		{
			get
			{
				return this.averageLeadTime;
			}

			set
			{
				this.averageLeadTime = value;
			}
		}

		private decimal standardPrice;

		[Required]
		public decimal StandardPrice
		{
			get
			{
				return this.standardPrice;
			}

			set
			{
				this.standardPrice = value;
			}
		}

		private Nullable<decimal> lastReceiptCost;

		public Nullable<decimal> LastReceiptCost
		{
			get
			{
				return this.lastReceiptCost.IsEmptyOrZeroOrNull() ? null : this.lastReceiptCost;
			}

			set
			{
				this.lastReceiptCost = value;
			}
		}

		private Nullable<DateTime> lastReceiptDate;

		public Nullable<DateTime> LastReceiptDate
		{
			get
			{
				return this.lastReceiptDate.IsEmptyOrZeroOrNull() ? null : this.lastReceiptDate;
			}

			set
			{
				this.lastReceiptDate = value;
			}
		}

		private int minOrderQty;

		[Required]
		public int MinOrderQty
		{
			get
			{
				return this.minOrderQty;
			}

			set
			{
				this.minOrderQty = value;
			}
		}

		private int maxOrderQty;

		[Required]
		public int MaxOrderQty
		{
			get
			{
				return this.maxOrderQty;
			}

			set
			{
				this.maxOrderQty = value;
			}
		}

		private Nullable<int> onOrderQty;

		public Nullable<int> OnOrderQty
		{
			get
			{
				return this.onOrderQty.IsEmptyOrZeroOrNull() ? null : this.onOrderQty;
			}

			set
			{
				this.onOrderQty = value;
			}
		}

		private string unitMeasureCode;

		[Required]
		public string UnitMeasureCode
		{
			get
			{
				return this.unitMeasureCode;
			}

			set
			{
				this.unitMeasureCode = value;
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
    <Hash>11ddf45b25def02ab55a5fbcc776c326</Hash>
</Codenesium>*/