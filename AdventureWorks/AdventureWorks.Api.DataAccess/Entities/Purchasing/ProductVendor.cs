using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductVendor", Schema="Purchasing")]
	public partial class ProductVendor: AbstractEntity
	{
		public ProductVendor()
		{}

		public void SetProperties(
			int averageLeadTime,
			int businessEntityID,
			Nullable<decimal> lastReceiptCost,
			Nullable<DateTime> lastReceiptDate,
			int maxOrderQty,
			int minOrderQty,
			DateTime modifiedDate,
			Nullable<int> onOrderQty,
			int productID,
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
		public int AverageLeadTime { get; private set; }

		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; private set; }

		[Column("LastReceiptCost", TypeName="money")]
		public Nullable<decimal> LastReceiptCost { get; private set; }

		[Column("LastReceiptDate", TypeName="datetime")]
		public Nullable<DateTime> LastReceiptDate { get; private set; }

		[Column("MaxOrderQty", TypeName="int")]
		public int MaxOrderQty { get; private set; }

		[Column("MinOrderQty", TypeName="int")]
		public int MinOrderQty { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("OnOrderQty", TypeName="int")]
		public Nullable<int> OnOrderQty { get; private set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }

		[Column("StandardPrice", TypeName="money")]
		public decimal StandardPrice { get; private set; }

		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bfb10b9393873051bd32bc6de252f237</Hash>
</Codenesium>*/