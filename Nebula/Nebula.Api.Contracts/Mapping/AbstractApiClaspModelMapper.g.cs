using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiClaspModelMapper
        {
                public virtual ApiClaspResponseModel MapRequestToResponse(
                        int id,
                        ApiClaspRequestModel request)
                {
                        var response = new ApiClaspResponseModel();
                        response.SetProperties(id,
                                               request.NextChainId,
                                               request.PreviousChainId);
                        return response;
                }

                public virtual ApiClaspRequestModel MapResponseToRequest(
                        ApiClaspResponseModel response)
                {
                        var request = new ApiClaspRequestModel();
                        request.SetProperties(
                                response.NextChainId,
                                response.PreviousChainId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>7e6b849e6b59ad28eaf0d32f4d4eb887</Hash>
</Codenesium>*/