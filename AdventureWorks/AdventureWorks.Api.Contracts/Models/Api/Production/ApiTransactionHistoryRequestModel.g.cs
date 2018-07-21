using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiTransactionHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiTransactionHistoryRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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

                [Required]
                [JsonProperty]
                public decimal ActualCost { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public int ProductID { get; private set; }

                [Required]
                [JsonProperty]
                public int Quantity { get; private set; }

                [Required]
                [JsonProperty]
                public int ReferenceOrderID { get; private set; }

                [Required]
                [JsonProperty]
                public int ReferenceOrderLineID { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime TransactionDate { get; private set; }

                [Required]
                [JsonProperty]
                public string TransactionType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9c149136abe0a3988448c1a7400a128c</Hash>
</Codenesium>*/