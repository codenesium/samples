using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                                               request.ActualResourceHr,
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
                                response.ActualResourceHr,
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

                public JsonPatchDocument<ApiWorkOrderRoutingRequestModel> CreatePatch(ApiWorkOrderRoutingRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiWorkOrderRoutingRequestModel>();
                        patch.Replace(x => x.ActualCost, model.ActualCost);
                        patch.Replace(x => x.ActualEndDate, model.ActualEndDate);
                        patch.Replace(x => x.ActualResourceHr, model.ActualResourceHr);
                        patch.Replace(x => x.ActualStartDate, model.ActualStartDate);
                        patch.Replace(x => x.LocationID, model.LocationID);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.OperationSequence, model.OperationSequence);
                        patch.Replace(x => x.PlannedCost, model.PlannedCost);
                        patch.Replace(x => x.ProductID, model.ProductID);
                        patch.Replace(x => x.ScheduledEndDate, model.ScheduledEndDate);
                        patch.Replace(x => x.ScheduledStartDate, model.ScheduledStartDate);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>f934670680eb2c2f0cc8a53b0cb4368f</Hash>
</Codenesium>*/