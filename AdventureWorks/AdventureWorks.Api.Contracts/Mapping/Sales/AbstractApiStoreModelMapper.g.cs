using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiStoreModelMapper
        {
                public virtual ApiStoreResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiStoreRequestModel request)
                {
                        var response = new ApiStoreResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.Demographics,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.Rowguid,
                                               request.SalesPersonID);
                        return response;
                }

                public virtual ApiStoreRequestModel MapResponseToRequest(
                        ApiStoreResponseModel response)
                {
                        var request = new ApiStoreRequestModel();
                        request.SetProperties(
                                response.Demographics,
                                response.ModifiedDate,
                                response.Name,
                                response.Rowguid,
                                response.SalesPersonID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>2c2935c8a3a4e9a60fb964d98df51a93</Hash>
</Codenesium>*/