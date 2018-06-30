using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepModelMapper
        {
                ApiPipelineStepResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepRequestModel request);

                ApiPipelineStepRequestModel MapResponseToRequest(
                        ApiPipelineStepResponseModel response);
        }
}

/*<Codenesium>
    <Hash>ca544bf41a8cfe16a859996f1ce40a54</Hash>
</Codenesium>*/