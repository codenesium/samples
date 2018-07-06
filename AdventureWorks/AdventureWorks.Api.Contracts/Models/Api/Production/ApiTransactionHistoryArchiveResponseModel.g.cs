using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiTransactionHistoryArchiveResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int transactionID,
                        decimal actualCost,
                        DateTime modifiedDate,
                        int productID,
                        int quantity,
                        int referenceOrderID,
                        int referenceOrderLineID,
                        DateTime transactionDate,
                        string transactionType)
                {
                        this.TransactionID = transactionID;
                        this.ActualCost = actualCost;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.ReferenceOrderID = referenceOrderID;
                        this.ReferenceOrderLineID = referenceOrderLineID;
                        this.TransactionDate = transactionDate;
                        this.TransactionType = transactionType;
                }

                public decimal ActualCost { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public int Quantity { get; private set; }

                public int ReferenceOrderID { get; private set; }

                public int ReferenceOrderLineID { get; private set; }

                public DateTime TransactionDate { get; private set; }

                public int TransactionID { get; private set; }

                public string TransactionType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>913284c8342307b1aa7bb2597b8cd4d1</Hash>
</Codenesium>*/