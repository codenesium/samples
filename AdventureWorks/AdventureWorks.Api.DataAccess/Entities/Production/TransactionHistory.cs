using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("TransactionHistory", Schema="Production")]
        public partial class TransactionHistory: AbstractEntity
        {
                public TransactionHistory()
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
                        int transactionID,
                        string transactionType)
                {
                        this.ActualCost = actualCost;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.ReferenceOrderID = referenceOrderID;
                        this.ReferenceOrderLineID = referenceOrderLineID;
                        this.TransactionDate = transactionDate;
                        this.TransactionID = transactionID;
                        this.TransactionType = transactionType;
                }

                [Column("ActualCost", TypeName="money")]
                public decimal ActualCost { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }

                [Column("Quantity", TypeName="int")]
                public int Quantity { get; private set; }

                [Column("ReferenceOrderID", TypeName="int")]
                public int ReferenceOrderID { get; private set; }

                [Column("ReferenceOrderLineID", TypeName="int")]
                public int ReferenceOrderLineID { get; private set; }

                [Column("TransactionDate", TypeName="datetime")]
                public DateTime TransactionDate { get; private set; }

                [Key]
                [Column("TransactionID", TypeName="int")]
                public int TransactionID { get; private set; }

                [Column("TransactionType", TypeName="nchar(1)")]
                public string TransactionType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e2c80f8106cc644164cf8bcd35033629</Hash>
</Codenesium>*/