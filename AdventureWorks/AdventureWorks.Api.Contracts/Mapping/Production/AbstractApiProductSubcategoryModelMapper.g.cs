using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductSubcategoryModelMapper
        {
                public virtual ApiProductSubcategoryResponseModel MapRequestToResponse(
                        int productSubcategoryID,
                        ApiProductSubcategoryRequestModel request)
                {
                        var response = new ApiProductSubcategoryResponseModel();
                        response.SetProperties(productSubcategoryID,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.ProductCategoryID,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiProductSubcategoryRequestModel MapResponseToRequest(
                        ApiProductSubcategoryResponseModel response)
                {
                        var request = new ApiProductSubcategoryRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name,
                                response.ProductCategoryID,
                                response.Rowguid);
                        return request;
                }

                public JsonPatchDocument<ApiProductSubcategoryRequestModel> CreatePatch(ApiProductSubcategoryRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductSubcategoryRequestModel>();
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.ProductCategoryID, model.ProductCategoryID);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>d7544abdc8f70efb51d1c16c442a1d8b</Hash>
</Codenesium>*/