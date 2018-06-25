using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("TransactionHistory", Schema="Production")]
        public partial class TransactionHistory : AbstractEntity
        {
                public TransactionHistory()
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

                [Column("ActualCost")]
                public decimal ActualCost { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("Quantity")]
                public int Quantity { get; private set; }

                [Column("ReferenceOrderID")]
                public int ReferenceOrderID { get; private set; }

                [Column("ReferenceOrderLineID")]
                public int ReferenceOrderLineID { get; private set; }

                [Column("TransactionDate")]
                public DateTime TransactionDate { get; private set; }

                [Key]
                [Column("TransactionID")]
                public int TransactionID { get; private set; }

                [Column("TransactionType")]
                public string TransactionType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9a0abae7468db2ba4fe6072369255b26</Hash>
</Codenesium>*/