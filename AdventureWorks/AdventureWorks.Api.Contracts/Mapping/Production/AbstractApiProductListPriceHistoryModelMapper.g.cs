using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductListPriceHistoryModelMapper
        {
                public virtual ApiProductListPriceHistoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductListPriceHistoryRequestModel request)
                {
                        var response = new ApiProductListPriceHistoryResponseModel();
                        response.SetProperties(productID,
                                               request.EndDate,
                                               request.ListPrice,
                                               request.ModifiedDate,
                                               request.StartDate);
                        return response;
                }

                public virtual ApiProductListPriceHistoryRequestModel MapResponseToRequest(
                        ApiProductListPriceHistoryResponseModel response)
                {
                        var request = new ApiProductListPriceHistoryRequestModel();
                        request.SetProperties(
                                response.EndDate,
                                response.ListPrice,
                                response.ModifiedDate,
                                response.StartDate);
                        return request;
                }

                public JsonPatchDocument<ApiProductListPriceHistoryRequestModel> CreatePatch(ApiProductListPriceHistoryRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductListPriceHistoryRequestModel>();
                        patch.Replace(x => x.EndDate, model.EndDate);
                        patch.Replace(x => x.ListPrice, model.ListPrice);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.StartDate, model.StartDate);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>c2a30ab10fddd6774c07dd1ca8d3d35a</Hash>
</Codenesium>*/