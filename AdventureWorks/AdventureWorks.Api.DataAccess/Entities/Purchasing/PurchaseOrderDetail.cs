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
                        double receivedQty,
                        double rejectedQty,
                        double stockedQty,
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

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("PurchaseOrderDetailID")]
                public int PurchaseOrderDetailID { get; private set; }

                [Key]
                [Column("PurchaseOrderID")]
                public int PurchaseOrderID { get; private set; }

                [Column("ReceivedQty")]
                public double ReceivedQty { get; private set; }

                [Column("RejectedQty")]
                public double RejectedQty { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("StockedQty")]
                public double StockedQty { get; private set; }

                [Column("UnitPrice")]
                public decimal UnitPrice { get; private set; }
        }
}

/*<Codenesium>
    <Hash>cfedc8b5e82b4e66d87a4b3a6ef97880</Hash>
</Codenesium>*/