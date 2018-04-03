using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProduct
	{
		public POCOProduct()
		{}

		public POCOProduct(int productID,
		                   string name,
		                   string productNumber,
		                   bool makeFlag,
		                   bool finishedGoodsFlag,
		                   string color,
		                   short safetyStockLevel,
		                   short reorderPoint,
		                   decimal standardCost,
		                   decimal listPrice,
		                   string size,
		                   string sizeUnitMeasureCode,
		                   string weightUnitMeasureCode,
		                   Nullable<decimal> weight,
		                   int daysToManufacture,
		                   string productLine,
		                   string @class,
		                   string style,
		                   Nullable<int> productSubcategoryID,
		                   Nullable<int> productModelID,
		                   DateTime sellStartDate,
		                   Nullable<DateTime> sellEndDate,
		                   Nullable<DateTime> discontinuedDate,
		                   Guid rowguid,
		                   DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.Name = name;
			this.ProductNumber = productNumber;
			this.MakeFlag = makeFlag;
			this.FinishedGoodsFlag = finishedGoodsFlag;
			this.Color = color;
			this.SafetyStockLevel = safetyStockLevel;
			this.ReorderPoint = reorderPoint;
			this.StandardCost = standardCost;
			this.ListPrice = listPrice;
			this.Size = size;
			this.SizeUnitMeasureCode = sizeUnitMeasureCode;
			this.WeightUnitMeasureCode = weightUnitMeasureCode;
			this.Weight = weight.ToNullableDecimal();
			this.DaysToManufacture = daysToManufacture.ToInt();
			this.ProductLine = productLine;
			this.@Class = @class;
			this.Style = style;
			this.ProductSubcategoryID = productSubcategoryID.ToNullableInt();
			this.ProductModelID = productModelID.ToNullableInt();
			this.SellStartDate = sellStartDate.ToDateTime();
			this.SellEndDate = sellEndDate.ToNullableDateTime();
			this.DiscontinuedDate = discontinuedDate.ToNullableDateTime();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductID {get; set;}
		public string Name {get; set;}
		public string ProductNumber {get; set;}
		public bool MakeFlag {get; set;}
		public bool FinishedGoodsFlag {get; set;}
		public string Color {get; set;}
		public short SafetyStockLevel {get; set;}
		public short ReorderPoint {get; set;}
		public decimal StandardCost {get; set;}
		public decimal ListPrice {get; set;}
		public string Size {get; set;}
		public string SizeUnitMeasureCode {get; set;}
		public string WeightUnitMeasureCode {get; set;}
		public Nullable<decimal> Weight {get; set;}
		public int DaysToManufacture {get; set;}
		public string ProductLine {get; set;}
		public string @Class {get; set;}
		public string Style {get; set;}
		public Nullable<int> ProductSubcategoryID {get; set;}
		public Nullable<int> ProductModelID {get; set;}
		public DateTime SellStartDate {get; set;}
		public Nullable<DateTime> SellEndDate {get; set;}
		public Nullable<DateTime> DiscontinuedDate {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductNumberValue {get; set;} = true;

		public bool ShouldSerializeProductNumber()
		{
			return ShouldSerializeProductNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMakeFlagValue {get; set;} = true;

		public bool ShouldSerializeMakeFlag()
		{
			return ShouldSerializeMakeFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFinishedGoodsFlagValue {get; set;} = true;

		public bool ShouldSerializeFinishedGoodsFlag()
		{
			return ShouldSerializeFinishedGoodsFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeColorValue {get; set;} = true;

		public bool ShouldSerializeColor()
		{
			return ShouldSerializeColorValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSafetyStockLevelValue {get; set;} = true;

		public bool ShouldSerializeSafetyStockLevel()
		{
			return ShouldSerializeSafetyStockLevelValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReorderPointValue {get; set;} = true;

		public bool ShouldSerializeReorderPoint()
		{
			return ShouldSerializeReorderPointValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStandardCostValue {get; set;} = true;

		public bool ShouldSerializeStandardCost()
		{
			return ShouldSerializeStandardCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeListPriceValue {get; set;} = true;

		public bool ShouldSerializeListPrice()
		{
			return ShouldSerializeListPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSizeValue {get; set;} = true;

		public bool ShouldSerializeSize()
		{
			return ShouldSerializeSizeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSizeUnitMeasureCodeValue {get; set;} = true;

		public bool ShouldSerializeSizeUnitMeasureCode()
		{
			return ShouldSerializeSizeUnitMeasureCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeWeightUnitMeasureCodeValue {get; set;} = true;

		public bool ShouldSerializeWeightUnitMeasureCode()
		{
			return ShouldSerializeWeightUnitMeasureCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeWeightValue {get; set;} = true;

		public bool ShouldSerializeWeight()
		{
			return ShouldSerializeWeightValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDaysToManufactureValue {get; set;} = true;

		public bool ShouldSerializeDaysToManufacture()
		{
			return ShouldSerializeDaysToManufactureValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductLineValue {get; set;} = true;

		public bool ShouldSerializeProductLine()
		{
			return ShouldSerializeProductLineValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeClassValue {get; set;} = true;

		public bool ShouldSerializeClass()
		{
			return ShouldSerializeClassValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStyleValue {get; set;} = true;

		public bool ShouldSerializeStyle()
		{
			return ShouldSerializeStyleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductSubcategoryIDValue {get; set;} = true;

		public bool ShouldSerializeProductSubcategoryID()
		{
			return ShouldSerializeProductSubcategoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue {get; set;} = true;

		public bool ShouldSerializeProductModelID()
		{
			return ShouldSerializeProductModelIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSellStartDateValue {get; set;} = true;

		public bool ShouldSerializeSellStartDate()
		{
			return ShouldSerializeSellStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSellEndDateValue {get; set;} = true;

		public bool ShouldSerializeSellEndDate()
		{
			return ShouldSerializeSellEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDiscontinuedDateValue {get; set;} = true;

		public bool ShouldSerializeDiscontinuedDate()
		{
			return ShouldSerializeDiscontinuedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
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
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeProductNumberValue = false;
			this.ShouldSerializeMakeFlagValue = false;
			this.ShouldSerializeFinishedGoodsFlagValue = false;
			this.ShouldSerializeColorValue = false;
			this.ShouldSerializeSafetyStockLevelValue = false;
			this.ShouldSerializeReorderPointValue = false;
			this.ShouldSerializeStandardCostValue = false;
			this.ShouldSerializeListPriceValue = false;
			this.ShouldSerializeSizeValue = false;
			this.ShouldSerializeSizeUnitMeasureCodeValue = false;
			this.ShouldSerializeWeightUnitMeasureCodeValue = false;
			this.ShouldSerializeWeightValue = false;
			this.ShouldSerializeDaysToManufactureValue = false;
			this.ShouldSerializeProductLineValue = false;
			this.ShouldSerializeClassValue = false;
			this.ShouldSerializeStyleValue = false;
			this.ShouldSerializeProductSubcategoryIDValue = false;
			this.ShouldSerializeProductModelIDValue = false;
			this.ShouldSerializeSellStartDateValue = false;
			this.ShouldSerializeSellEndDateValue = false;
			this.ShouldSerializeDiscontinuedDateValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>9160be5d347d6a995fd7ac5638fde4ab</Hash>
</Codenesium>*/