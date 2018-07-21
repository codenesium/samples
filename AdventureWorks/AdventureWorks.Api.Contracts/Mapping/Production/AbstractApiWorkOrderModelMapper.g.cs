using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiWorkOrderModelMapper
        {
                public virtual ApiWorkOrderResponseModel MapRequestToResponse(
                        int workOrderID,
                        ApiWorkOrderRequestModel request)
                {
                        var response = new ApiWorkOrderResponseModel();
                        response.SetProperties(workOrderID,
                                               request.DueDate,
                                               request.EndDate,
                                               request.ModifiedDate,
                                               request.OrderQty,
                                               request.ProductID,
                                               request.ScrappedQty,
                                               request.ScrapReasonID,
                                               request.StartDate,
                                               request.StockedQty);
                        return response;
                }

                public virtual ApiWorkOrderRequestModel MapResponseToRequest(
                        ApiWorkOrderResponseModel response)
                {
                        var request = new ApiWorkOrderRequestModel();
                        request.SetProperties(
                                response.DueDate,
                                response.EndDate,
                                response.ModifiedDate,
                                response.OrderQty,
                                response.ProductID,
                                response.ScrappedQty,
                                response.ScrapReasonID,
                                response.StartDate,
                                response.StockedQty);
                        return request;
                }

                public JsonPatchDocument<ApiWorkOrderRequestModel> CreatePatch(ApiWorkOrderRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiWorkOrderRequestModel>();
                        patch.Replace(x => x.DueDate, model.DueDate);
                        patch.Replace(x => x.EndDate, model.EndDate);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.OrderQty, model.OrderQty);
                        patch.Replace(x => x.ProductID, model.ProductID);
                        patch.Replace(x => x.ScrappedQty, model.ScrappedQty);
                        patch.Replace(x => x.ScrapReasonID, model.ScrapReasonID);
                        patch.Replace(x => x.StartDate, model.StartDate);
                        patch.Replace(x => x.StockedQty, model.StockedQty);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>c8bed5efa13bd259f3ffcbd2d5ca60f5</Hash>
</Codenesium>*/