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
			this.AverageLeadTime = averageLeadTime.ToInt();
			this.StandardPrice = standardPrice;
			this.LastReceiptCost = lastReceiptCost;
			this.LastReceiptDate = lastReceiptDate.ToNullableDateTime();
			this.MinOrderQty = minOrderQty.ToInt();
			this.MaxOrderQty = maxOrderQty.ToInt();
			this.OnOrderQty = onOrderQty.ToNullableInt();
			this.ModifiedDate = modifiedDate.ToDateTime();

			ProductID = new ReferenceEntity<int>(productID,
			                                     "Product");
			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "Vendor");
			UnitMeasureCode = new ReferenceEntity<string>(unitMeasureCode,
			                                              "UnitMeasure");
		}

		public ReferenceEntity<int>ProductID {get; set;}
		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public int AverageLeadTime {get; set;}
		public decimal StandardPrice {get; set;}
		public Nullable<decimal> LastReceiptCost {get; set;}
		public Nullable<DateTime> LastReceiptDate {get; set;}
		public int MinOrderQty {get; set;}
		public int MaxOrderQty {get; set;}
		public Nullable<int> OnOrderQty {get; set;}
		public ReferenceEntity<string>UnitMeasureCode {get; set;}
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
    <Hash>59f4ad92a915ec87443f6879b884dda1</Hash>
</Codenesium>*/