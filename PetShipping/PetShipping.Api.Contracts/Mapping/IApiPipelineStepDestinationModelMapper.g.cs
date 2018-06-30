using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepDestinationModelMapper
        {
                ApiPipelineStepDestinationResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepDestinationRequestModel request);

                ApiPipelineStepDestinationRequestModel MapResponseToRequest(
                        ApiPipelineStepDestinationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>581524f094b04744b745d63b2eeb5246</Hash>
</Codenesium>*/