using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStatusModelMapper
        {
                ApiPipelineStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStatusRequestModel request);

                ApiPipelineStatusRequestModel MapResponseToRequest(
                        ApiPipelineStatusResponseModel response);
        }
}

/*<Codenesium>
    <Hash>aa429acece7f8bdd8b1209a3d119e02c</Hash>
</Codenesium>*/