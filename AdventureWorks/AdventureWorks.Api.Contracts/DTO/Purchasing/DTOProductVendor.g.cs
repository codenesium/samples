using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductVendor: AbstractDTO
	{
		public DTOProductVendor() : base()
		{}

		public void SetProperties(int productID,
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

		public int AverageLeadTime { get; set; }
		public int BusinessEntityID { get; set; }
		public Nullable<decimal> LastReceiptCost { get; set; }
		public Nullable<DateTime> LastReceiptDate { get; set; }
		public int MaxOrderQty { get; set; }
		public int MinOrderQty { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Nullable<int> OnOrderQty { get; set; }
		public int ProductID { get; set; }
		public decimal StandardPrice { get; set; }
		public string UnitMeasureCode { get; set; }
	}
}

/*<Codenesium>
    <Hash>d74b215be60721c3f498cc9d9afd50cd</Hash>
</Codenesium>*/