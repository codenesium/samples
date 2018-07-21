using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractWorkOrderRoutingMapper
        {
                public virtual WorkOrderRouting MapBOToEF(
                        BOWorkOrderRouting bo)
                {
                        WorkOrderRouting efWorkOrderRouting = new WorkOrderRouting();
                        efWorkOrderRouting.SetProperties(
                                bo.ActualCost,
                                bo.ActualEndDate,
                                bo.ActualResourceHr,
                                bo.ActualStartDate,
                                bo.LocationID,
                                bo.ModifiedDate,
                                bo.OperationSequence,
                                bo.PlannedCost,
                                bo.ProductID,
                                bo.ScheduledEndDate,
                                bo.ScheduledStartDate,
                                bo.WorkOrderID);
                        return efWorkOrderRouting;
                }

                public virtual BOWorkOrderRouting MapEFToBO(
                        WorkOrderRouting ef)
                {
                        var bo = new BOWorkOrderRouting();

                        bo.SetProperties(
                                ef.WorkOrderID,
                                ef.ActualCost,
                                ef.ActualEndDate,
                                ef.ActualResourceHr,
                                ef.ActualStartDate,
                                ef.LocationID,
                                ef.ModifiedDate,
                                ef.OperationSequence,
                                ef.PlannedCost,
                                ef.ProductID,
                                ef.ScheduledEndDate,
                                ef.ScheduledStartDate);
                        return bo;
                }

                public virtual List<BOWorkOrderRouting> MapEFToBO(
                        List<WorkOrderRouting> records)
                {
                        List<BOWorkOrderRouting> response = new List<BOWorkOrderRouting>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>da390c7037699ab56ecbc1cd8fca22ce</Hash>
</Codenesium>*/