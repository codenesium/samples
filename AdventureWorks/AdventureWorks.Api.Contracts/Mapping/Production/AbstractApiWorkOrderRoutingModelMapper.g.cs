using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiWorkOrderRoutingModelMapper
        {
                public virtual ApiWorkOrderRoutingResponseModel MapRequestToResponse(
                        int workOrderID,
                        ApiWorkOrderRoutingRequestModel request)
                {
                        var response = new ApiWorkOrderRoutingResponseModel();
                        response.SetProperties(workOrderID,
                                               request.ActualCost,
                                               request.ActualEndDate,
                                               request.ActualResourceHrs,
                                               request.ActualStartDate,
                                               request.LocationID,
                                               request.ModifiedDate,
                                               request.OperationSequence,
                                               request.PlannedCost,
                                               request.ProductID,
                                               request.ScheduledEndDate,
                                               request.ScheduledStartDate);
                        return response;
                }

                public virtual ApiWorkOrderRoutingRequestModel MapResponseToRequest(
                        ApiWorkOrderRoutingResponseModel response)
                {
                        var request = new ApiWorkOrderRoutingRequestModel();
                        request.SetProperties(
                                response.ActualCost,
                                response.ActualEndDate,
                                response.ActualResourceHrs,
                                response.ActualStartDate,
                                response.LocationID,
                                response.ModifiedDate,
                                response.OperationSequence,
                                response.PlannedCost,
                                response.ProductID,
                                response.ScheduledEndDate,
                                response.ScheduledStartDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>7bfda262cd9e04acc519b618b5cc9ae5</Hash>
</Codenesium>*/