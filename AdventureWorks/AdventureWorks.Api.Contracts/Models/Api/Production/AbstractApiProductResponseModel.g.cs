using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
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
                        this.@Class = @class;
                        this.Color = color;
                        this.DaysToManufacture = daysToManufacture;
                        this.DiscontinuedDate = discontinuedDate;
                        this.FinishedGoodsFlag = finishedGoodsFlag;
                        this.ListPrice = listPrice;
                        this.MakeFlag = makeFlag;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductID = productID;
                        this.ProductLine = productLine;
                        this.ProductModelID = productModelID;
                        this.ProductNumber = productNumber;
                        this.ProductSubcategoryID = productSubcategoryID;
                        this.ReorderPoint = reorderPoint;
                        this.Rowguid = rowguid;
                        this.SafetyStockLevel = safetyStockLevel;
                        this.SellEndDate = sellEndDate;
                        this.SellStartDate = sellStartDate;
                        this.Size = size;
                        this.SizeUnitMeasureCode = sizeUnitMeasureCode;
                        this.StandardCost = standardCost;
                        this.Style = style;
                        this.Weight = weight;
                        this.WeightUnitMeasureCode = weightUnitMeasureCode;
                }

                public string @Class { get; private set; }

                public string Color { get; private set; }

                public int DaysToManufacture { get; private set; }

                public Nullable<DateTime> DiscontinuedDate { get; private set; }

                public bool FinishedGoodsFlag { get; private set; }

                public decimal ListPrice { get; private set; }

                public bool MakeFlag { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductID { get; private set; }

                public string ProductLine { get; private set; }

                public Nullable<int> ProductModelID { get; private set; }

                public string ProductNumber { get; private set; }

                public Nullable<int> ProductSubcategoryID { get; private set; }

                public short ReorderPoint { get; private set; }

                public Guid Rowguid { get; private set; }

                public short SafetyStockLevel { get; private set; }

                public Nullable<DateTime> SellEndDate { get; private set; }

                public DateTime SellStartDate { get; private set; }

                public string Size { get; private set; }

                public string SizeUnitMeasureCode { get; private set; }

                public decimal StandardCost { get; private set; }

                public string Style { get; private set; }

                public Nullable<decimal> Weight { get; private set; }

                public string WeightUnitMeasureCode { get; private set; }

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

                public virtual void DisableAllFields()
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
    <Hash>d282189f8e4fe50e2c8ff1d7cfbd89dc</Hash>
</Codenesium>*/