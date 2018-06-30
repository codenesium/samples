using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiBusinessEntityModelMapper
        {
                public virtual ApiBusinessEntityResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityRequestModel request)
                {
                        var response = new ApiBusinessEntityResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.ModifiedDate,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiBusinessEntityRequestModel MapResponseToRequest(
                        ApiBusinessEntityResponseModel response)
                {
                        var request = new ApiBusinessEntityRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Rowguid);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>219d4b8ddedc4bb3ec689f8900ade02e</Hash>
</Codenesium>*/