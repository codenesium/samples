using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiPurchaseOrderDetailRequestModel> CreatePatch(ApiPurchaseOrderDetailRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPurchaseOrderDetailRequestModel>();
                        patch.Replace(x => x.DueDate, model.DueDate);
                        patch.Replace(x => x.LineTotal, model.LineTotal);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.OrderQty, model.OrderQty);
                        patch.Replace(x => x.ProductID, model.ProductID);
                        patch.Replace(x => x.PurchaseOrderDetailID, model.PurchaseOrderDetailID);
                        patch.Replace(x => x.ReceivedQty, model.ReceivedQty);
                        patch.Replace(x => x.RejectedQty, model.RejectedQty);
                        patch.Replace(x => x.StockedQty, model.StockedQty);
                        patch.Replace(x => x.UnitPrice, model.UnitPrice);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>6d6747cb40742114e598c85c411dac82</Hash>
</Codenesium>*/