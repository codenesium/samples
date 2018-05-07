using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProduct
	{
		public POCOProduct()
		{}

		public POCOProduct(
			string @class,
			string color,
			int daysToManufacture,
			Nullable<DateTime> discontinuedDate,
			bool finishedGoodsFlag,
			decimal listPrice,
			bool makeFlag,
			DateTime modifiedDate,
			string name,
			int productID,
			string productLine,
			Nullable<int> productModelID,
			string productNumber,
			Nullable<int> productSubcategoryID,
			short reorderPoint,
			Guid rowguid,
			short safetyStockLevel,
			Nullable<DateTime> sellEndDate,
			DateTime sellStartDate,
			string size,
			string sizeUnitMeasureCode,
			decimal standardCost,
			string style,
			Nullable<decimal> weight,
			string weightUnitMeasureCode)
		{
			this.@Class = @class.ToString();
			this.Color = color.ToString();
			this.DaysToManufacture = daysToManufacture.ToInt();
			this.DiscontinuedDate = discontinuedDate.ToNullableDateTime();
			this.FinishedGoodsFlag = finishedGoodsFlag.ToBoolean();
			this.ListPrice = listPrice.ToDecimal();
			this.MakeFlag = makeFlag.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ProductID = productID.ToInt();
			this.ProductLine = productLine.ToString();
			this.ProductModelID = productModelID.ToNullableInt();
			this.ProductNumber = productNumber.ToString();
			this.ProductSubcategoryID = productSubcategoryID.ToNullableInt();
			this.ReorderPoint = reorderPoint;
			this.Rowguid = rowguid.ToGuid();
			this.SafetyStockLevel = safetyStockLevel;
			this.SellEndDate = sellEndDate.ToNullableDateTime();
			this.SellStartDate = sellStartDate.ToDateTime();
			this.Size = size.ToString();
			this.SizeUnitMeasureCode = sizeUnitMeasureCode.ToString();
			this.StandardCost = standardCost.ToDecimal();
			this.Style = style.ToString();
			this.Weight = weight.ToNullableDecimal();
			this.WeightUnitMeasureCode = weightUnitMeasureCode.ToString();
		}

		public string @Class { get; set; }
		public string Color { get; set; }
		public int DaysToManufacture { get; set; }
		public Nullable<DateTime> DiscontinuedDate { get; set; }
		public bool FinishedGoodsFlag { get; set; }
		public decimal ListPrice { get; set; }
		public bool MakeFlag { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int ProductID { get; set; }
		public string ProductLine { get; set; }
		public Nullable<int> ProductModelID { get; set; }
		public string ProductNumber { get; set; }
		public Nullable<int> ProductSubcategoryID { get; set; }
		public short ReorderPoint { get; set; }
		public Guid Rowguid { get; set; }
		public short SafetyStockLevel { get; set; }
		public Nullable<DateTime> SellEndDate { get; set; }
		public DateTime SellStartDate { get; set; }
		public string Size { get; set; }
		public string SizeUnitMeasureCode { get; set; }
		public decimal StandardCost { get; set; }
		public string Style { get; set; }
		public Nullable<decimal> Weight { get; set; }
		public string WeightUnitMeasureCode { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeClassValue { get; set; } = true;

		public bool ShouldSerializeClass()
		{
			return this.ShouldSerializeClassValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeColorValue { get; set; } = true;

		public bool ShouldSerializeColor()
		{
			return this.ShouldSerializeColorValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDaysToManufactureValue { get; set; } = true;

		public bool ShouldSerializeDaysToManufacture()
		{
			return this.ShouldSerializeDaysToManufactureValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDiscontinuedDateValue { get; set; } = true;

		public bool ShouldSerializeDiscontinuedDate()
		{
			return this.ShouldSerializeDiscontinuedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFinishedGoodsFlagValue { get; set; } = true;

		public bool ShouldSerializeFinishedGoodsFlag()
		{
			return this.ShouldSerializeFinishedGoodsFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeListPriceValue { get; set; } = true;

		public bool ShouldSerializeListPrice()
		{
			return this.ShouldSerializeListPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMakeFlagValue { get; set; } = true;

		public bool ShouldSerializeMakeFlag()
		{
			return this.ShouldSerializeMakeFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductLineValue { get; set; } = true;

		public bool ShouldSerializeProductLine()
		{
			return this.ShouldSerializeProductLineValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue { get; set; } = true;

		public bool ShouldSerializeProductModelID()
		{
			return this.ShouldSerializeProductModelIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductNumberValue { get; set; } = true;

		public bool ShouldSerializeProductNumber()
		{
			return this.ShouldSerializeProductNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductSubcategoryIDValue { get; set; } = true;

		public bool ShouldSerializeProductSubcategoryID()
		{
			return this.ShouldSerializeProductSubcategoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReorderPointValue { get; set; } = true;

		public bool ShouldSerializeReorderPoint()
		{
			return this.ShouldSerializeReorderPointValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSafetyStockLevelValue { get; set; } = true;

		public bool ShouldSerializeSafetyStockLevel()
		{
			return this.ShouldSerializeSafetyStockLevelValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSellEndDateValue { get; set; } = true;

		public bool ShouldSerializeSellEndDate()
		{
			return this.ShouldSerializeSellEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSellStartDateValue { get; set; } = true;

		public bool ShouldSerializeSellStartDate()
		{
			return this.ShouldSerializeSellStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSizeValue { get; set; } = true;

		public bool ShouldSerializeSize()
		{
			return this.ShouldSerializeSizeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSizeUnitMeasureCodeValue { get; set; } = true;

		public bool ShouldSerializeSizeUnitMeasureCode()
		{
			return this.ShouldSerializeSizeUnitMeasureCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStandardCostValue { get; set; } = true;

		public bool ShouldSerializeStandardCost()
		{
			return this.ShouldSerializeStandardCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStyleValue { get; set; } = true;

		public bool ShouldSerializeStyle()
		{
			return this.ShouldSerializeStyleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeWeightValue { get; set; } = true;

		public bool ShouldSerializeWeight()
		{
			return this.ShouldSerializeWeightValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeWeightUnitMeasureCodeValue { get; set; } = true;

		public bool ShouldSerializeWeightUnitMeasureCode()
		{
			return this.ShouldSerializeWeightUnitMeasureCodeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeClassValue = false;
			this.ShouldSerializeColorValue = false;
			this.ShouldSerializeDaysToManufactureValue = false;
			this.ShouldSerializeDiscontinuedDateValue = false;
			this.ShouldSerializeFinishedGoodsFlagValue = false;
			this.ShouldSerializeListPriceValue = false;
			this.ShouldSerializeMakeFlagValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeProductLineValue = false;
			this.ShouldSerializeProductModelIDValue = false;
			this.ShouldSerializeProductNumberValue = false;
			this.ShouldSerializeProductSubcategoryIDValue = false;
			this.ShouldSerializeReorderPointValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSafetyStockLevelValue = false;
			this.ShouldSerializeSellEndDateValue = false;
			this.ShouldSerializeSellStartDateValue = false;
			this.ShouldSerializeSizeValue = false;
			this.ShouldSerializeSizeUnitMeasureCodeValue = false;
			this.ShouldSerializeStandardCostValue = false;
			this.ShouldSerializeStyleValue = false;
			this.ShouldSerializeWeightValue = false;
			this.ShouldSerializeWeightUnitMeasureCodeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e33494d4ec227c4226f58e67f89fbc1f</Hash>
</Codenesium>*/