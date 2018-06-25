using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductVendorRequestModel : AbstractApiRequestModel
        {
                public ApiProductVendorRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int averageLeadTime,
                        int businessEntityID,
                        decimal? lastReceiptCost,
                        DateTime? lastReceiptDate,
                        int maxOrderQty,
                        int minOrderQty,
                        DateTime modifiedDate,
                        int? onOrderQty,
                        decimal standardPrice,
                        string unitMeasureCode)
                {
                        this.AverageLeadTime = averageLeadTime;
                        this.BusinessEntityID = businessEntityID;
                        this.LastReceiptCost = lastReceiptCost;
                        this.LastReceiptDate = lastReceiptDate;
                        this.MaxOrderQty = maxOrderQty;
                        this.MinOrderQty = minOrderQty;
                        this.ModifiedDate = modifiedDate;
                        this.OnOrderQty = onOrderQty;
                        this.StandardPrice = standardPrice;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                private int averageLeadTime;

                [Required]
                public int AverageLeadTime
                {
                        get
                        {
                                return this.averageLeadTime;
                        }

                        set
                        {
                                this.averageLeadTime = value;
                        }
                }

                private int businessEntityID;

                [Required]
                public int BusinessEntityID
                {
                        get
                        {
                                return this.businessEntityID;
                        }

                        set
                        {
                                this.businessEntityID = value;
                        }
                }

                private decimal? lastReceiptCost;

                public decimal? LastReceiptCost
                {
                        get
                        {
                                return this.lastReceiptCost;
                        }

                        set
                        {
                                this.lastReceiptCost = value;
                        }
                }

                private DateTime? lastReceiptDate;

                public DateTime? LastReceiptDate
                {
                        get
                        {
                                return this.lastReceiptDate;
                        }

                        set
                        {
                                this.lastReceiptDate = value;
                        }
                }

                private int maxOrderQty;

                [Required]
                public int MaxOrderQty
                {
                        get
                        {
                                return this.maxOrderQty;
                        }

                        set
                        {
                                this.maxOrderQty = value;
                        }
                }

                private int minOrderQty;

                [Required]
                public int MinOrderQty
                {
                        get
                        {
                                return this.minOrderQty;
                        }

                        set
                        {
                                this.minOrderQty = value;
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

                private int? onOrderQty;

                public int? OnOrderQty
                {
                        get
                        {
                                return this.onOrderQty;
                        }

                        set
                        {
                                this.onOrderQty = value;
                        }
                }

                private decimal standardPrice;

                [Required]
                public decimal StandardPrice
                {
                        get
                        {
                                return this.standardPrice;
                        }

                        set
                        {
                                this.standardPrice = value;
                        }
                }

                private string unitMeasureCode;

                [Required]
                public string UnitMeasureCode
                {
                        get
                        {
                                return this.unitMeasureCode;
                        }

                        set
                        {
                                this.unitMeasureCode = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>07cf3558f068ebbd02b1cacb2e7129e9</Hash>
</Codenesium>*/