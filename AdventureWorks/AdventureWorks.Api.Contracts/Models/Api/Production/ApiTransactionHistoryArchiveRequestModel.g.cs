using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiTransactionHistoryArchiveRequestModel : AbstractApiRequestModel
        {
                public ApiTransactionHistoryArchiveRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        decimal actualCost,
                        DateTime modifiedDate,
                        int productID,
                        int quantity,
                        int referenceOrderID,
                        int referenceOrderLineID,
                        DateTime transactionDate,
                        string transactionType)
                {
                        this.ActualCost = actualCost;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.ReferenceOrderID = referenceOrderID;
                        this.ReferenceOrderLineID = referenceOrderLineID;
                        this.TransactionDate = transactionDate;
                        this.TransactionType = transactionType;
                }

                private decimal actualCost;

                [Required]
                public decimal ActualCost
                {
                        get
                        {
                                return this.actualCost;
                        }

                        set
                        {
                                this.actualCost = value;
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

                private int quantity;

                [Required]
                public int Quantity
                {
                        get
                        {
                                return this.quantity;
                        }

                        set
                        {
                                this.quantity = value;
                        }
                }

                private int referenceOrderID;

                [Required]
                public int ReferenceOrderID
                {
                        get
                        {
                                return this.referenceOrderID;
                        }

                        set
                        {
                                this.referenceOrderID = value;
                        }
                }

                private int referenceOrderLineID;

                [Required]
                public int ReferenceOrderLineID
                {
                        get
                        {
                                return this.referenceOrderLineID;
                        }

                        set
                        {
                                this.referenceOrderLineID = value;
                        }
                }

                private DateTime transactionDate;

                [Required]
                public DateTime TransactionDate
                {
                        get
                        {
                                return this.transactionDate;
                        }

                        set
                        {
                                this.transactionDate = value;
                        }
                }

                private string transactionType;

                [Required]
                public string TransactionType
                {
                        get
                        {
                                return this.transactionType;
                        }

                        set
                        {
                                this.transactionType = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>7cc9c7eeed9f12fa50d58199e9143537</Hash>
</Codenesium>*/