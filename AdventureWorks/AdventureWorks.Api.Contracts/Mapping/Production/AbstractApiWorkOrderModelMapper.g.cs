using System;
using System.Collections.Generic;

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
        }
}

/*<Codenesium>
    <Hash>1f3346c26d785f4187382224278b212d</Hash>
</Codenesium>*/