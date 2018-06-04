using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductVendor: AbstractBusinessObject
	{
		public BOProductVendor() : base()
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

		public int AverageLeadTime { get; private set; }
		public int BusinessEntityID { get; private set; }
		public Nullable<decimal> LastReceiptCost { get; private set; }
		public Nullable<DateTime> LastReceiptDate { get; private set; }
		public int MaxOrderQty { get; private set; }
		public int MinOrderQty { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Nullable<int> OnOrderQty { get; private set; }
		public int ProductID { get; private set; }
		public decimal StandardPrice { get; private set; }
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a7c149343c68e931487c03e0a5417252</Hash>
</Codenesium>*/