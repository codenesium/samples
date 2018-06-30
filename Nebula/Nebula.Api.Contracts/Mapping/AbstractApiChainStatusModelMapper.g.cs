using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiChainStatusModelMapper
        {
                public virtual ApiChainStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiChainStatusRequestModel request)
                {
                        var response = new ApiChainStatusResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiChainStatusRequestModel MapResponseToRequest(
                        ApiChainStatusResponseModel response)
                {
                        var request = new ApiChainStatusRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>ae5acd8a323ee61fa2656317d410e981</Hash>
</Codenesium>*/