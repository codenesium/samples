using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductModelModelMapper
        {
                public virtual ApiProductModelResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelRequestModel request)
                {
                        var response = new ApiProductModelResponseModel();
                        response.SetProperties(productModelID,
                                               request.CatalogDescription,
                                               request.Instructions,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiProductModelRequestModel MapResponseToRequest(
                        ApiProductModelResponseModel response)
                {
                        var request = new ApiProductModelRequestModel();
                        request.SetProperties(
                                response.CatalogDescription,
                                response.Instructions,
                                response.ModifiedDate,
                                response.Name,
                                response.Rowguid);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>99ccebc3db71fbd29811d1291d1fa62d</Hash>
</Codenesium>*/