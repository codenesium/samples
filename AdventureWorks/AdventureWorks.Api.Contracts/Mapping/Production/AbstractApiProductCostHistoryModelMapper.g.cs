using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductCostHistoryModelMapper
        {
                public virtual ApiProductCostHistoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductCostHistoryRequestModel request)
                {
                        var response = new ApiProductCostHistoryResponseModel();
                        response.SetProperties(productID,
                                               request.EndDate,
                                               request.ModifiedDate,
                                               request.StandardCost,
                                               request.StartDate);
                        return response;
                }

                public virtual ApiProductCostHistoryRequestModel MapResponseToRequest(
                        ApiProductCostHistoryResponseModel response)
                {
                        var request = new ApiProductCostHistoryRequestModel();
                        request.SetProperties(
                                response.EndDate,
                                response.ModifiedDate,
                                response.StandardCost,
                                response.StartDate);
                        return request;
                }

                public JsonPatchDocument<ApiProductCostHistoryRequestModel> CreatePatch(ApiProductCostHistoryRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductCostHistoryRequestModel>();
                        patch.Replace(x => x.EndDate, model.EndDate);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.StandardCost, model.StandardCost);
                        patch.Replace(x => x.StartDate, model.StartDate);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>9ad9086edafca66ec7749f781b109cc6</Hash>
</Codenesium>*/