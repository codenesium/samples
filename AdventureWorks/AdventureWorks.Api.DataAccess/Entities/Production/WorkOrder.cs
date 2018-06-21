using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("WorkOrder", Schema="Production")]
        public partial class WorkOrder : AbstractEntity
        {
                public WorkOrder()
                {
                }

                public void SetProperties(
                        DateTime dueDate,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        int orderQty,
                        int productID,
                        short scrappedQty,
                        Nullable<short> scrapReasonID,
                        DateTime startDate,
                        int stockedQty,
                        int workOrderID)
                {
                        this.DueDate = dueDate;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.ScrappedQty = scrappedQty;
                        this.ScrapReasonID = scrapReasonID;
                        this.StartDate = startDate;
                        this.StockedQty = stockedQty;
                        this.WorkOrderID = workOrderID;
                }

                [Column("DueDate")]
                public DateTime DueDate { get; private set; }

                [Column("EndDate")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OrderQty")]
                public int OrderQty { get; private set; }

                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("ScrappedQty")]
                public short ScrappedQty { get; private set; }

                [Column("ScrapReasonID")]
                public Nullable<short> ScrapReasonID { get; private set; }

                [Column("StartDate")]
                public DateTime StartDate { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("StockedQty")]
                public int StockedQty { get; private set; }

                [Key]
                [Column("WorkOrderID")]
                public int WorkOrderID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d5e416e92fd1cbd2da27b1f56005952c</Hash>
</Codenesium>*/