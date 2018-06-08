using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractWorkOrderRoutingMapper
        {
                public virtual BOWorkOrderRouting MapModelToBO(
                        int workOrderID,
                        ApiWorkOrderRoutingRequestModel model
                        )
                {
                        BOWorkOrderRouting boWorkOrderRouting = new BOWorkOrderRouting();

                        boWorkOrderRouting.SetProperties(
                                workOrderID,
                                model.ActualCost,
                                model.ActualEndDate,
                                model.ActualResourceHrs,
                                model.ActualStartDate,
                                model.LocationID,
                                model.ModifiedDate,
                                model.OperationSequence,
                                model.PlannedCost,
                                model.ProductID,
                                model.ScheduledEndDate,
                                model.ScheduledStartDate);
                        return boWorkOrderRouting;
                }

                public virtual ApiWorkOrderRoutingResponseModel MapBOToModel(
                        BOWorkOrderRouting boWorkOrderRouting)
                {
                        var model = new ApiWorkOrderRoutingResponseModel();

                        model.SetProperties(boWorkOrderRouting.ActualCost, boWorkOrderRouting.ActualEndDate, boWorkOrderRouting.ActualResourceHrs, boWorkOrderRouting.ActualStartDate, boWorkOrderRouting.LocationID, boWorkOrderRouting.ModifiedDate, boWorkOrderRouting.OperationSequence, boWorkOrderRouting.PlannedCost, boWorkOrderRouting.ProductID, boWorkOrderRouting.ScheduledEndDate, boWorkOrderRouting.ScheduledStartDate, boWorkOrderRouting.WorkOrderID);

                        return model;
                }

                public virtual List<ApiWorkOrderRoutingResponseModel> MapBOToModel(
                        List<BOWorkOrderRouting> items)
                {
                        List<ApiWorkOrderRoutingResponseModel> response = new List<ApiWorkOrderRoutingResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>95f524a425d5c85949e3fbc1736f23bf</Hash>
</Codenesium>*/