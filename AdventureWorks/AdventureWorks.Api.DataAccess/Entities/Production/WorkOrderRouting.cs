using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("WorkOrderRouting", Schema="Production")]
        public partial class WorkOrderRouting: AbstractEntity
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

                [Column("ActualCost", TypeName="money")]
                public Nullable<decimal> ActualCost { get; private set; }

                [Column("ActualEndDate", TypeName="datetime")]
                public Nullable<DateTime> ActualEndDate { get; private set; }

                [Column("ActualResourceHrs", TypeName="decimal")]
                public Nullable<decimal> ActualResourceHrs { get; private set; }

                [Column("ActualStartDate", TypeName="datetime")]
                public Nullable<DateTime> ActualStartDate { get; private set; }

                [Column("LocationID", TypeName="smallint")]
                public short LocationID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OperationSequence", TypeName="smallint")]
                public short OperationSequence { get; private set; }

                [Column("PlannedCost", TypeName="money")]
                public decimal PlannedCost { get; private set; }

                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }

                [Column("ScheduledEndDate", TypeName="datetime")]
                public DateTime ScheduledEndDate { get; private set; }

                [Column("ScheduledStartDate", TypeName="datetime")]
                public DateTime ScheduledStartDate { get; private set; }

                [Key]
                [Column("WorkOrderID", TypeName="int")]
                public int WorkOrderID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>79a2634038d339ac96e3d0184c78e9f4</Hash>
</Codenesium>*/