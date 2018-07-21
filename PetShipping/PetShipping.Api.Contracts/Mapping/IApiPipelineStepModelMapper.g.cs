using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepModelMapper
        {
                ApiPipelineStepResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepRequestModel request);

                ApiPipelineStepRequestModel MapResponseToRequest(
                        ApiPipelineStepResponseModel response);

                JsonPatchDocument<ApiPipelineStepRequestModel> CreatePatch(ApiPipelineStepRequestModel model);
        }
}

/*<Codenesium>
    <Hash>88405c4878b699a3c54cef63a70c5ab2</Hash>
</Codenesium>*/