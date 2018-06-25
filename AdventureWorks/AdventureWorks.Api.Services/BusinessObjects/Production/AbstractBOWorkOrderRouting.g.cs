using Codenesium.DataConversionExtensions;
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
                                                  decimal? actualCost,
                                                  DateTime? actualEndDate,
                                                  decimal? actualResourceHrs,
                                                  DateTime? actualStartDate,
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

                public decimal? ActualCost { get; private set; }

                public DateTime? ActualEndDate { get; private set; }

                public decimal? ActualResourceHrs { get; private set; }

                public DateTime? ActualStartDate { get; private set; }

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
    <Hash>ab4aa285a878cf45ca28264f2e171d99</Hash>
</Codenesium>*/