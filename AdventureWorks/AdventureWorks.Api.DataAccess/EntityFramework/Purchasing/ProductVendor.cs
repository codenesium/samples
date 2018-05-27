using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductVendor", Schema="Purchasing")]
	public partial class ProductVendor: AbstractEntityFrameworkDTO
	{
		public ProductVendor()
		{}

		public void SetProperties(
			int productID,
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
			this.ProductID = productID.ToInt();
			this.StandardPrice = standardPrice.ToDecimal();
			this.UnitMeasureCode = unitMeasureCode;
		}

		[Column("AverageLeadTime", TypeName="int")]
		public int AverageLeadTime { get; set; }

		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("LastReceiptCost", TypeName="money")]
		public Nullable<decimal> LastReceiptCost { get; set; }

		[Column("LastReceiptDate", TypeName="datetime")]
		public Nullable<DateTime> LastReceiptDate { get; set; }

		[Column("MaxOrderQty", TypeName="int")]
		public int MaxOrderQty { get; set; }

		[Column("MinOrderQty", TypeName="int")]
		public int MinOrderQty { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("OnOrderQty", TypeName="int")]
		public Nullable<int> OnOrderQty { get; set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("StandardPrice", TypeName="money")]
		public decimal StandardPrice { get; set; }

		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode { get; set; }
	}
}

/*<Codenesium>
    <Hash>7034d14aac83e613591111e14215789b</Hash>
</Codenesium>*/