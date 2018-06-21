using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOWorkOrderRouting : AbstractBusinessObject
        {
                public AbstractBOWorkOrderRouting()
                        : base()
                {
                }

                public virtual void SetProperties(int workOrderID,
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
                                                  DateTime scheduledStartDate)
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

                public Nullable<decimal> ActualCost { get; private set; }

                public Nullable<DateTime> ActualEndDate { get; private set; }

                public Nullable<decimal> ActualResourceHrs { get; private set; }

                public Nullable<DateTime> ActualStartDate { get; private set; }

                public short LocationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public short OperationSequence { get; private set; }

                public decimal PlannedCost { get; private set; }

                public int ProductID { get; private set; }

                public DateTime ScheduledEndDate { get; private set; }

                public DateTime ScheduledStartDate { get; private set; }

                public int WorkOrderID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4265eb4578e4b11640a46f57caa4bacf</Hash>
</Codenesium>*/