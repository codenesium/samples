using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProduct : AbstractBusinessObject
        {
                public AbstractBOProduct()
                        : base()
                {
                }

                public virtual void SetProperties(int productID,
                                                  string @class,
                                                  string color,
                                                  int daysToManufacture,
                                                  DateTime? discontinuedDate,
                                                  bool finishedGoodsFlag,
                                                  decimal listPrice,
                                                  bool makeFlag,
                                                  DateTime modifiedDate,
                                                  string name,
                                                  string productLine,
                                                  int? productModelID,
                                                  string productNumber,
                                                  int? productSubcategoryID,
                                                  short reorderPoint,
                                                  Guid rowguid,
                                                  short safetyStockLevel,
                                                  DateTime? sellEndDate,
                                                  DateTime sellStartDate,
                                                  string size,
                                                  string sizeUnitMeasureCode,
                                                  decimal standardCost,
                                                  string style,
                                                  double? weight,
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

                public DateTime? DiscontinuedDate { get; private set; }

                public bool FinishedGoodsFlag { get; private set; }

                public decimal ListPrice { get; private set; }

                public bool MakeFlag { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductID { get; private set; }

                public string ProductLine { get; private set; }

                public int? ProductModelID { get; private set; }

                public string ProductNumber { get; private set; }

                public int? ProductSubcategoryID { get; private set; }

                public short ReorderPoint { get; private set; }

                public Guid Rowguid { get; private set; }

                public short SafetyStockLevel { get; private set; }

                public DateTime? SellEndDate { get; private set; }

                public DateTime SellStartDate { get; private set; }

                public string Size { get; private set; }

                public string SizeUnitMeasureCode { get; private set; }

                public decimal StandardCost { get; private set; }

                public string Style { get; private set; }

                public double? Weight { get; private set; }

                public string WeightUnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2daa3495645b43893a75108c893a5742</Hash>
</Codenesium>*/