using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepDestinationModelMapper
        {
                ApiPipelineStepDestinationResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepDestinationRequestModel request);

                ApiPipelineStepDestinationRequestModel MapResponseToRequest(
                        ApiPipelineStepDestinationResponseModel response);

                JsonPatchDocument<ApiPipelineStepDestinationRequestModel> CreatePatch(ApiPipelineStepDestinationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>c67901b4ce7e0e209b75184ddc936783</Hash>
</Codenesium>*/