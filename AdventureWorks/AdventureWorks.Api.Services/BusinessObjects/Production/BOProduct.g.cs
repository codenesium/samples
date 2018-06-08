using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProduct: AbstractBusinessObject
        {
                public BOProduct() : base()
                {
                }

                public void SetProperties(int productID,
                                          string @class,
                                          string color,
                                          int daysToManufacture,
                                          Nullable<DateTime> discontinuedDate,
                                          bool finishedGoodsFlag,
                                          decimal listPrice,
                                          bool makeFlag,
                                          DateTime modifiedDate,
                                          string name,
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
        }
}

/*<Codenesium>
    <Hash>fd7b108c09a8eb56f9d59f7e4f8ce83d</Hash>
</Codenesium>*/