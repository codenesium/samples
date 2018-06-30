using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductDescriptionModelMapper
        {
                public virtual ApiProductDescriptionResponseModel MapRequestToResponse(
                        int productDescriptionID,
                        ApiProductDescriptionRequestModel request)
                {
                        var response = new ApiProductDescriptionResponseModel();
                        response.SetProperties(productDescriptionID,
                                               request.Description,
                                               request.ModifiedDate,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiProductDescriptionRequestModel MapResponseToRequest(
                        ApiProductDescriptionResponseModel response)
                {
                        var request = new ApiProductDescriptionRequestModel();
                        request.SetProperties(
                                response.Description,
                                response.ModifiedDate,
                                response.Rowguid);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>58a46e6e9fad43ce2c118010cfb81379</Hash>
</Codenesium>*/