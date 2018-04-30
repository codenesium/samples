using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductVendor
	{
		public POCOProductVendor()
		{}

		public POCOProductVendor(
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
			this.LastReceiptCost = lastReceiptCost.ToNullableDecimal();
			this.LastReceiptDate = lastReceiptDate.ToNullableDateTime();
			this.MaxOrderQty = maxOrderQty.ToInt();
			this.MinOrderQty = minOrderQty.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OnOrderQty = onOrderQty.ToNullableInt();
			this.ProductID = productID.ToInt();
			this.StandardPrice = standardPrice.ToDecimal();
			this.UnitMeasureCode = unitMeasureCode.ToString();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.Vendors));
		}

		public int AverageLeadTime { get; set; }
		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public Nullable<decimal> LastReceiptCost { get; set; }
		public Nullable<DateTime> LastReceiptDate { get; set; }
		public int MaxOrderQty { get; set; }
		public int MinOrderQty { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Nullable<int> OnOrderQty { get; set; }
		public int ProductID { get; set; }
		public decimal StandardPrice { get; set; }
		public string UnitMeasureCode { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAverageLeadTimeValue { get; set; } = true;

		public bool ShouldSerializeAverageLeadTime()
		{
			return this.ShouldSerializeAverageLeadTimeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastReceiptCostValue { get; set; } = true;

		public bool ShouldSerializeLastReceiptCost()
		{
			return this.ShouldSerializeLastReceiptCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastReceiptDateValue { get; set; } = true;

		public bool ShouldSerializeLastReceiptDate()
		{
			return this.ShouldSerializeLastReceiptDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMaxOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeMaxOrderQty()
		{
			return this.ShouldSerializeMaxOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMinOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeMinOrderQty()
		{
			return this.ShouldSerializeMinOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOnOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeOnOrderQty()
		{
			return this.ShouldSerializeOnOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStandardPriceValue { get; set; } = true;

		public bool ShouldSerializeStandardPrice()
		{
			return this.ShouldSerializeStandardPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitMeasureCodeValue { get; set; } = true;

		public bool ShouldSerializeUnitMeasureCode()
		{
			return this.ShouldSerializeUnitMeasureCodeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAverageLeadTimeValue = false;
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeLastReceiptCostValue = false;
			this.ShouldSerializeLastReceiptDateValue = false;
			this.ShouldSerializeMaxOrderQtyValue = false;
			this.ShouldSerializeMinOrderQtyValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeOnOrderQtyValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeStandardPriceValue = false;
			this.ShouldSerializeUnitMeasureCodeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>2979970c12bd6fa9e2ab5c6b89270047</Hash>
</Codenesium>*/