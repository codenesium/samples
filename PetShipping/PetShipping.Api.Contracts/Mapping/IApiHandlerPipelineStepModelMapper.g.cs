using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiHandlerPipelineStepModelMapper
        {
                ApiHandlerPipelineStepResponseModel MapRequestToResponse(
                        int id,
                        ApiHandlerPipelineStepRequestModel request);

                ApiHandlerPipelineStepRequestModel MapResponseToRequest(
                        ApiHandlerPipelineStepResponseModel response);
        }
}

/*<Codenesium>
    <Hash>98bb9e3867d10b92775e0d38039beddc</Hash>
</Codenesium>*/