using System;
using System.Collections.Generic;

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
        }
}

/*<Codenesium>
    <Hash>238ff66907782aac095c4e5cd8a3c52b</Hash>
</Codenesium>*/