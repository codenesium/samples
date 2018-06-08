using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("PurchaseOrderDetail", Schema="Purchasing")]
        public partial class PurchaseOrderDetail: AbstractEntity
        {
                public PurchaseOrderDetail()
                {
                }

                public void SetProperties(
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

                [Column("DueDate", TypeName="datetime")]
                public DateTime DueDate { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("LineTotal", TypeName="money")]
                public decimal LineTotal { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OrderQty", TypeName="smallint")]
                public short OrderQty { get; private set; }

                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }

                [Column("PurchaseOrderDetailID", TypeName="int")]
                public int PurchaseOrderDetailID { get; private set; }

                [Key]
                [Column("PurchaseOrderID", TypeName="int")]
                public int PurchaseOrderID { get; private set; }

                [Column("ReceivedQty", TypeName="decimal")]
                public decimal ReceivedQty { get; private set; }

                [Column("RejectedQty", TypeName="decimal")]
                public decimal RejectedQty { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("StockedQty", TypeName="decimal")]
                public decimal StockedQty { get; private set; }

                [Column("UnitPrice", TypeName="money")]
                public decimal UnitPrice { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b346698611d718cb1736a6131eab94ad</Hash>
</Codenesium>*/