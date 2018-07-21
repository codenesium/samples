using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("PurchaseOrderDetail", Schema="Purchasing")]
        public partial class PurchaseOrderDetail : AbstractEntity
        {
                public PurchaseOrderDetail()
                {
                }

                public virtual void SetProperties(
                        DateTime dueDate,
                        decimal lineTotal,
                        DateTime modifiedDate,
                        short orderQty,
                        int productID,
                        int purchaseOrderDetailID,
                        int purchaseOrderID,
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
                        this.PurchaseOrderID = purchaseOrderID;
                        this.ReceivedQty = receivedQty;
                        this.RejectedQty = rejectedQty;
                        this.StockedQty = stockedQty;
                        this.UnitPrice = unitPrice;
                }

                [Column("DueDate")]
                public DateTime DueDate { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("LineTotal")]
                public decimal LineTotal { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OrderQty")]
                public short OrderQty { get; private set; }

                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("PurchaseOrderDetailID")]
                public int PurchaseOrderDetailID { get; private set; }

                [Key]
                [Column("PurchaseOrderID")]
                public int PurchaseOrderID { get; private set; }

                [Column("ReceivedQty")]
                public decimal ReceivedQty { get; private set; }

                [Column("RejectedQty")]
                public decimal RejectedQty { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("StockedQty")]
                public decimal StockedQty { get; private set; }

                [Column("UnitPrice")]
                public decimal UnitPrice { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8f85ad244cef26b2ec2f750eecfba2f1</Hash>
</Codenesium>*/