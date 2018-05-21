using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductVendorModel: AbstractModel
	{
		public ApiProductVendorModel() : base()
		{}

		public ApiProductVendorModel(
			int averageLeadTime,
			int businessEntityID,
			Nullable<decimal> lastReceiptCost,
			Nullable<DateTime> lastReceiptDate,
			int maxOrderQty,
			int minOrderQty,
			DateTime modifiedDate,
			Nullable<int> onOrderQty,
			decimal standardPrice,
			string unitMeasureCode)
		{
			this.AverageLeadTime = averageLeadTime.ToInt();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.LastReceiptCost = lastReceiptCost.ToNullableDecimal();
			this.LastReceiptDate = lastReceiptDate.ToNullableDateTime();
			this.MaxOrderQty = maxOrderQty.ToInt();
			this.MinOrderQty = minOrderQty.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OnOrderQty = onOrderQty.ToNullableInt();
			this.StandardPrice = standardPrice.ToDecimal();
			this.UnitMeasureCode = unitMeasureCode;
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
	}
}

/*<Codenesium>
    <Hash>df413a54d58f5ebcde8a9fe34584c7d2</Hash>
</Codenesium>*/