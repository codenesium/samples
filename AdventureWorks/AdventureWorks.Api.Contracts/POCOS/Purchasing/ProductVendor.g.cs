using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductVendor
	{
		public POCOProductVendor()
		{}

		public POCOProductVendor(int productID,
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
			this.ProductID = productID.ToInt();
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

		public int ProductID {get; set;}
		public int BusinessEntityID {get; set;}
		public int AverageLeadTime {get; set;}
		public decimal StandardPrice {get; set;}
		public Nullable<decimal> LastReceiptCost {get; set;}
		public Nullable<DateTime> LastReceiptDate {get; set;}
		public int MinOrderQty {get; set;}
		public int MaxOrderQty {get; set;}
		public Nullable<int> OnOrderQty {get; set;}
		public string UnitMeasureCode {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAverageLeadTimeValue {get; set;} = true;

		public bool ShouldSerializeAverageLeadTime()
		{
			return ShouldSerializeAverageLeadTimeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStandardPriceValue {get; set;} = true;

		public bool ShouldSerializeStandardPrice()
		{
			return ShouldSerializeStandardPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastReceiptCostValue {get; set;} = true;

		public bool ShouldSerializeLastReceiptCost()
		{
			return ShouldSerializeLastReceiptCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastReceiptDateValue {get; set;} = true;

		public bool ShouldSerializeLastReceiptDate()
		{
			return ShouldSerializeLastReceiptDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMinOrderQtyValue {get; set;} = true;

		public bool ShouldSerializeMinOrderQty()
		{
			return ShouldSerializeMinOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMaxOrderQtyValue {get; set;} = true;

		public bool ShouldSerializeMaxOrderQty()
		{
			return ShouldSerializeMaxOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOnOrderQtyValue {get; set;} = true;

		public bool ShouldSerializeOnOrderQty()
		{
			return ShouldSerializeOnOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitMeasureCodeValue {get; set;} = true;

		public bool ShouldSerializeUnitMeasureCode()
		{
			return ShouldSerializeUnitMeasureCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeAverageLeadTimeValue = false;
			this.ShouldSerializeStandardPriceValue = false;
			this.ShouldSerializeLastReceiptCostValue = false;
			this.ShouldSerializeLastReceiptDateValue = false;
			this.ShouldSerializeMinOrderQtyValue = false;
			this.ShouldSerializeMaxOrderQtyValue = false;
			this.ShouldSerializeOnOrderQtyValue = false;
			this.ShouldSerializeUnitMeasureCodeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>5bedeb4298c793f3ec045a67cc09665e</Hash>
</Codenesium>*/