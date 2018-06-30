using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepStatusModelMapper
        {
                ApiPipelineStepStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepStatusRequestModel request);

                ApiPipelineStepStatusRequestModel MapResponseToRequest(
                        ApiPipelineStepStatusResponseModel response);
        }
}

/*<Codenesium>
    <Hash>983bfd3706b8b49b3bd9162d451d3cd7</Hash>
</Codenesium>*/