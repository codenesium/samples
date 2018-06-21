using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("WorkOrderRouting", Schema="Production")]
        public partial class WorkOrderRouting : AbstractEntity
        {
                public WorkOrderRouting()
                {
                }

                public void SetProperties(
                        Nullable<decimal> actualCost,
                        Nullable<DateTime> actualEndDate,
                        Nullable<decimal> actualResourceHrs,
                        Nullable<DateTime> actualStartDate,
                        short locationID,
                        DateTime modifiedDate,
                        short operationSequence,
                        decimal plannedCost,
                        int productID,
                        DateTime scheduledEndDate,
                        DateTime scheduledStartDate,
                        int workOrderID)
                {
                        this.ActualCost = actualCost;
                        this.ActualEndDate = actualEndDate;
                        this.ActualResourceHrs = actualResourceHrs;
                        this.ActualStartDate = actualStartDate;
                        this.LocationID = locationID;
                        this.ModifiedDate = modifiedDate;
                        this.OperationSequence = operationSequence;
                        this.PlannedCost = plannedCost;
                        this.ProductID = productID;
                        this.ScheduledEndDate = scheduledEndDate;
                        this.ScheduledStartDate = scheduledStartDate;
                        this.WorkOrderID = workOrderID;
                }

                [Column("ActualCost")]
                public Nullable<decimal> ActualCost { get; private set; }

                [Column("ActualEndDate")]
                public Nullable<DateTime> ActualEndDate { get; private set; }

                [Column("ActualResourceHrs")]
                public Nullable<decimal> ActualResourceHrs { get; private set; }

                [Column("ActualStartDate")]
                public Nullable<DateTime> ActualStartDate { get; private set; }

                [Column("LocationID")]
                public short LocationID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OperationSequence")]
                public short OperationSequence { get; private set; }

                [Column("PlannedCost")]
                public decimal PlannedCost { get; private set; }

                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("ScheduledEndDate")]
                public DateTime ScheduledEndDate { get; private set; }

                [Column("ScheduledStartDate")]
                public DateTime ScheduledStartDate { get; private set; }

                [Key]
                [Column("WorkOrderID")]
                public int WorkOrderID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>93222385f97e96261867ca9763b22c47</Hash>
</Codenesium>*/