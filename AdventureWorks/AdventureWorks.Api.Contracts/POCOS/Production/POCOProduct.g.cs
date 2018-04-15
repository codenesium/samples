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
			int productID,
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
			this.Name = name.ToString();
			this.ProductNumber = productNumber.ToString();
			this.MakeFlag = makeFlag.ToBoolean();
			this.FinishedGoodsFlag = finishedGoodsFlag.ToBoolean();
			this.Color = color.ToString();
			this.SafetyStockLevel = safetyStockLevel;
			this.ReorderPoint = reorderPoint;
			this.StandardCost = standardCost.ToDecimal();
			this.ListPrice = listPrice.ToDecimal();
			this.Size = size.ToString();
			this.Weight = weight.ToNullableDecimal();
			this.DaysToManufacture = daysToManufacture.ToInt();
			this.ProductLine = productLine.ToString();
			this.@Class = @class.ToString();
			this.Style = style.ToString();
			this.SellStartDate = sellStartDate.ToDateTime();
			this.SellEndDate = sellEndDate.ToNullableDateTime();
			this.DiscontinuedDate = discontinuedDate.ToNullableDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.SizeUnitMeasureCode = new ReferenceEntity<string>(sizeUnitMeasureCode,
			                                                       nameof(ApiResponse.UnitMeasures));
			this.WeightUnitMeasureCode = new ReferenceEntity<string>(weightUnitMeasureCode,
			                                                         nameof(ApiResponse.UnitMeasures));
			this.ProductSubcategoryID = new ReferenceEntity<Nullable<int>>(productSubcategoryID,
			                                                               nameof(ApiResponse.ProductSubcategories));
			this.ProductModelID = new ReferenceEntity<Nullable<int>>(productModelID,
			                                                         nameof(ApiResponse.ProductModels));
		}

		public int ProductID { get; set; }
		public string Name { get; set; }
		public string ProductNumber { get; set; }
		public bool MakeFlag { get; set; }
		public bool FinishedGoodsFlag { get; set; }
		public string Color { get; set; }
		public short SafetyStockLevel { get; set; }
		public short ReorderPoint { get; set; }
		public decimal StandardCost { get; set; }
		public decimal ListPrice { get; set; }
		public string Size { get; set; }
		public ReferenceEntity<string> SizeUnitMeasureCode { get; set; }
		public ReferenceEntity<string> WeightUnitMeasureCode { get; set; }
		public Nullable<decimal> Weight { get; set; }
		public int DaysToManufacture { get; set; }
		public string ProductLine { get; set; }
		public string @Class { get; set; }
		public string Style { get; set; }
		public ReferenceEntity<Nullable<int>> ProductSubcategoryID { get; set; }
		public ReferenceEntity<Nullable<int>> ProductModelID { get; set; }
		public DateTime SellStartDate { get; set; }
		public Nullable<DateTime> SellEndDate { get; set; }
		public Nullable<DateTime> DiscontinuedDate { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductNumberValue { get; set; } = true;

		public bool ShouldSerializeProductNumber()
		{
			return this.ShouldSerializeProductNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMakeFlagValue { get; set; } = true;

		public bool ShouldSerializeMakeFlag()
		{
			return this.ShouldSerializeMakeFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFinishedGoodsFlagValue { get; set; } = true;

		public bool ShouldSerializeFinishedGoodsFlag()
		{
			return this.ShouldSerializeFinishedGoodsFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeColorValue { get; set; } = true;

		public bool ShouldSerializeColor()
		{
			return this.ShouldSerializeColorValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSafetyStockLevelValue { get; set; } = true;

		public bool ShouldSerializeSafetyStockLevel()
		{
			return this.ShouldSerializeSafetyStockLevelValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReorderPointValue { get; set; } = true;

		public bool ShouldSerializeReorderPoint()
		{
			return this.ShouldSerializeReorderPointValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStandardCostValue { get; set; } = true;

		public bool ShouldSerializeStandardCost()
		{
			return this.ShouldSerializeStandardCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeListPriceValue { get; set; } = true;

		public bool ShouldSerializeListPrice()
		{
			return this.ShouldSerializeListPriceValue;
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
		public bool ShouldSerializeWeightUnitMeasureCodeValue { get; set; } = true;

		public bool ShouldSerializeWeightUnitMeasureCode()
		{
			return this.ShouldSerializeWeightUnitMeasureCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeWeightValue { get; set; } = true;

		public bool ShouldSerializeWeight()
		{
			return this.ShouldSerializeWeightValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDaysToManufactureValue { get; set; } = true;

		public bool ShouldSerializeDaysToManufacture()
		{
			return this.ShouldSerializeDaysToManufactureValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductLineValue { get; set; } = true;

		public bool ShouldSerializeProductLine()
		{
			return this.ShouldSerializeProductLineValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeClassValue { get; set; } = true;

		public bool ShouldSerializeClass()
		{
			return this.ShouldSerializeClassValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStyleValue { get; set; } = true;

		public bool ShouldSerializeStyle()
		{
			return this.ShouldSerializeStyleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductSubcategoryIDValue { get; set; } = true;

		public bool ShouldSerializeProductSubcategoryID()
		{
			return this.ShouldSerializeProductSubcategoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue { get; set; } = true;

		public bool ShouldSerializeProductModelID()
		{
			return this.ShouldSerializeProductModelIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSellStartDateValue { get; set; } = true;

		public bool ShouldSerializeSellStartDate()
		{
			return this.ShouldSerializeSellStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSellEndDateValue { get; set; } = true;

		public bool ShouldSerializeSellEndDate()
		{
			return this.ShouldSerializeSellEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDiscontinuedDateValue { get; set; } = true;

		public bool ShouldSerializeDiscontinuedDate()
		{
			return this.ShouldSerializeDiscontinuedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
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
    <Hash>74bde74b5d7edc537327d4348498201e</Hash>
</Codenesium>*/