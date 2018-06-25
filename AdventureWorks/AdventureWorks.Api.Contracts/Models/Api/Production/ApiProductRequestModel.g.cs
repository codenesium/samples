using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductRequestModel : AbstractApiRequestModel
        {
                public ApiProductRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
                        decimal? weight,
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

                private string @class;

                public string @Class
                {
                        get
                        {
                                return this.@class;
                        }

                        set
                        {
                                this.@class = value;
                        }
                }

                private string color;

                public string Color
                {
                        get
                        {
                                return this.color;
                        }

                        set
                        {
                                this.color = value;
                        }
                }

                private int daysToManufacture;

                [Required]
                public int DaysToManufacture
                {
                        get
                        {
                                return this.daysToManufacture;
                        }

                        set
                        {
                                this.daysToManufacture = value;
                        }
                }

                private DateTime? discontinuedDate;

                public DateTime? DiscontinuedDate
                {
                        get
                        {
                                return this.discontinuedDate;
                        }

                        set
                        {
                                this.discontinuedDate = value;
                        }
                }

                private bool finishedGoodsFlag;

                [Required]
                public bool FinishedGoodsFlag
                {
                        get
                        {
                                return this.finishedGoodsFlag;
                        }

                        set
                        {
                                this.finishedGoodsFlag = value;
                        }
                }

                private decimal listPrice;

                [Required]
                public decimal ListPrice
                {
                        get
                        {
                                return this.listPrice;
                        }

                        set
                        {
                                this.listPrice = value;
                        }
                }

                private bool makeFlag;

                [Required]
                public bool MakeFlag
                {
                        get
                        {
                                return this.makeFlag;
                        }

                        set
                        {
                                this.makeFlag = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private string productLine;

                public string ProductLine
                {
                        get
                        {
                                return this.productLine;
                        }

                        set
                        {
                                this.productLine = value;
                        }
                }

                private int? productModelID;

                public int? ProductModelID
                {
                        get
                        {
                                return this.productModelID;
                        }

                        set
                        {
                                this.productModelID = value;
                        }
                }

                private string productNumber;

                [Required]
                public string ProductNumber
                {
                        get
                        {
                                return this.productNumber;
                        }

                        set
                        {
                                this.productNumber = value;
                        }
                }

                private int? productSubcategoryID;

                public int? ProductSubcategoryID
                {
                        get
                        {
                                return this.productSubcategoryID;
                        }

                        set
                        {
                                this.productSubcategoryID = value;
                        }
                }

                private short reorderPoint;

                [Required]
                public short ReorderPoint
                {
                        get
                        {
                                return this.reorderPoint;
                        }

                        set
                        {
                                this.reorderPoint = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }

                private short safetyStockLevel;

                [Required]
                public short SafetyStockLevel
                {
                        get
                        {
                                return this.safetyStockLevel;
                        }

                        set
                        {
                                this.safetyStockLevel = value;
                        }
                }

                private DateTime? sellEndDate;

                public DateTime? SellEndDate
                {
                        get
                        {
                                return this.sellEndDate;
                        }

                        set
                        {
                                this.sellEndDate = value;
                        }
                }

                private DateTime sellStartDate;

                [Required]
                public DateTime SellStartDate
                {
                        get
                        {
                                return this.sellStartDate;
                        }

                        set
                        {
                                this.sellStartDate = value;
                        }
                }

                private string size;

                public string Size
                {
                        get
                        {
                                return this.size;
                        }

                        set
                        {
                                this.size = value;
                        }
                }

                private string sizeUnitMeasureCode;

                public string SizeUnitMeasureCode
                {
                        get
                        {
                                return this.sizeUnitMeasureCode;
                        }

                        set
                        {
                                this.sizeUnitMeasureCode = value;
                        }
                }

                private decimal standardCost;

                [Required]
                public decimal StandardCost
                {
                        get
                        {
                                return this.standardCost;
                        }

                        set
                        {
                                this.standardCost = value;
                        }
                }

                private string style;

                public string Style
                {
                        get
                        {
                                return this.style;
                        }

                        set
                        {
                                this.style = value;
                        }
                }

                private decimal? weight;

                public decimal? Weight
                {
                        get
                        {
                                return this.weight;
                        }

                        set
                        {
                                this.weight = value;
                        }
                }

                private string weightUnitMeasureCode;

                public string WeightUnitMeasureCode
                {
                        get
                        {
                                return this.weightUnitMeasureCode;
                        }

                        set
                        {
                                this.weightUnitMeasureCode = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a683b5e8eb67cf205bc8fd5fd25f5192</Hash>
</Codenesium>*/