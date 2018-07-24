using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("WorkOrderRouting", Schema="Production")]
        public partial class WorkOrderRouting : AbstractEntity
        {
                public WorkOrderRouting()
                {
                }

                public virtual void SetProperties(
                        decimal? actualCost,
                        DateTime? actualEndDate,
                        double? actualResourceHr,
                        DateTime? actualStartDate,
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
                        this.ActualResourceHr = actualResourceHr;
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
                public decimal? ActualCost { get; private set; }

                [Column("ActualEndDate")]
                public DateTime? ActualEndDate { get; private set; }

                [Column("ActualResourceHrs")]
                public double? ActualResourceHr { get; private set; }

                [Column("ActualStartDate")]
                public DateTime? ActualStartDate { get; private set; }

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
    <Hash>4c8a1f670e539740fc5baa1869b8c49e</Hash>
</Codenesium>*/