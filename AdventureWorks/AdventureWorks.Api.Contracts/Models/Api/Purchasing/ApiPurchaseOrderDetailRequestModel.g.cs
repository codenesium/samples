using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPurchaseOrderDetailRequestModel : AbstractApiRequestModel
        {
                public ApiPurchaseOrderDetailRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime dueDate,
                        decimal lineTotal,
                        DateTime modifiedDate,
                        short orderQty,
                        int productID,
                        int purchaseOrderDetailID,
                        decimal receivedQty,
                        decimal rejectedQty,
                        decimal stockedQty,
                        decimal unitPrice)
                {
                        this.DueDate = dueDate;
                        this.LineTotal = lineTotal;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.PurchaseOrderDetailID = purchaseOrderDetailID;
                        this.ReceivedQty = receivedQty;
                        this.RejectedQty = rejectedQty;
                        this.StockedQty = stockedQty;
                        this.UnitPrice = unitPrice;
                }

                private DateTime dueDate;

                [Required]
                public DateTime DueDate
                {
                        get
                        {
                                return this.dueDate;
                        }

                        set
                        {
                                this.dueDate = value;
                        }
                }

                private decimal lineTotal;

                [Required]
                public decimal LineTotal
                {
                        get
                        {
                                return this.lineTotal;
                        }

                        set
                        {
                                this.lineTotal = value;
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

                private short orderQty;

                [Required]
                public short OrderQty
                {
                        get
                        {
                                return this.orderQty;
                        }

                        set
                        {
                                this.orderQty = value;
                        }
                }

                private int productID;

                [Required]
                public int ProductID
                {
                        get
                        {
                                return this.productID;
                        }

                        set
                        {
                                this.productID = value;
                        }
                }

                private int purchaseOrderDetailID;

                [Required]
                public int PurchaseOrderDetailID
                {
                        get
                        {
                                return this.purchaseOrderDetailID;
                        }

                        set
                        {
                                this.purchaseOrderDetailID = value;
                        }
                }

                private decimal receivedQty;

                [Required]
                public decimal ReceivedQty
                {
                        get
                        {
                                return this.receivedQty;
                        }

                        set
                        {
                                this.receivedQty = value;
                        }
                }

                private decimal rejectedQty;

                [Required]
                public decimal RejectedQty
                {
                        get
                        {
                                return this.rejectedQty;
                        }

                        set
                        {
                                this.rejectedQty = value;
                        }
                }

                private decimal stockedQty;

                [Required]
                public decimal StockedQty
                {
                        get
                        {
                                return this.stockedQty;
                        }

                        set
                        {
                                this.stockedQty = value;
                        }
                }

                private decimal unitPrice;

                [Required]
                public decimal UnitPrice
                {
                        get
                        {
                                return this.unitPrice;
                        }

                        set
                        {
                                this.unitPrice = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b3a3c405db808391666fb9df3427ce21</Hash>
</Codenesium>*/