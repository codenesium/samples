using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductCategoryModelMapper
        {
                public virtual ApiProductCategoryResponseModel MapRequestToResponse(
                        int productCategoryID,
                        ApiProductCategoryRequestModel request)
                {
                        var response = new ApiProductCategoryResponseModel();
                        response.SetProperties(productCategoryID,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiProductCategoryRequestModel MapResponseToRequest(
                        ApiProductCategoryResponseModel response)
                {
                        var request = new ApiProductCategoryRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name,
                                response.Rowguid);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>e3cf8748ef9666eecf4f260d235ea40e</Hash>
</Codenesium>*/