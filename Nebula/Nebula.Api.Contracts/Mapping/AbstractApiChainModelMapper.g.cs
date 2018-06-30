using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiChainModelMapper
        {
                public virtual ApiChainResponseModel MapRequestToResponse(
                        int id,
                        ApiChainRequestModel request)
                {
                        var response = new ApiChainResponseModel();
                        response.SetProperties(id,
                                               request.ChainStatusId,
                                               request.ExternalId,
                                               request.Name,
                                               request.TeamId);
                        return response;
                }

                public virtual ApiChainRequestModel MapResponseToRequest(
                        ApiChainResponseModel response)
                {
                        var request = new ApiChainRequestModel();
                        request.SetProperties(
                                response.ChainStatusId,
                                response.ExternalId,
                                response.Name,
                                response.TeamId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>515000c9ce7291910fa6dc28c31b2891</Hash>
</Codenesium>*/