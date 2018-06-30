using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPurchaseOrderDetailModelMapper
        {
                public virtual ApiPurchaseOrderDetailResponseModel MapRequestToResponse(
                        int purchaseOrderID,
                        ApiPurchaseOrderDetailRequestModel request)
                {
                        var response = new ApiPurchaseOrderDetailResponseModel();
                        response.SetProperties(purchaseOrderID,
                                               request.DueDate,
                                               request.LineTotal,
                                               request.ModifiedDate,
                                               request.OrderQty,
                                               request.ProductID,
                                               request.PurchaseOrderDetailID,
                                               request.ReceivedQty,
                                               request.RejectedQty,
                                               request.StockedQty,
                                               request.UnitPrice);
                        return response;
                }

                public virtual ApiPurchaseOrderDetailRequestModel MapResponseToRequest(
                        ApiPurchaseOrderDetailResponseModel response)
                {
                        var request = new ApiPurchaseOrderDetailRequestModel();
                        request.SetProperties(
                                response.DueDate,
                                response.LineTotal,
                                response.ModifiedDate,
                                response.OrderQty,
                                response.ProductID,
                                response.PurchaseOrderDetailID,
                                response.ReceivedQty,
                                response.RejectedQty,
                                response.StockedQty,
                                response.UnitPrice);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>a7704f271bb2b101f2b732b2deb287c7</Hash>
</Codenesium>*/