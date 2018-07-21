using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiHandlerPipelineStepModelMapper
        {
                ApiHandlerPipelineStepResponseModel MapRequestToResponse(
                        int id,
                        ApiHandlerPipelineStepRequestModel request);

                ApiHandlerPipelineStepRequestModel MapResponseToRequest(
                        ApiHandlerPipelineStepResponseModel response);

                JsonPatchDocument<ApiHandlerPipelineStepRequestModel> CreatePatch(ApiHandlerPipelineStepRequestModel model);
        }
}

/*<Codenesium>
    <Hash>1693bb34c36cf5e9a91b1b3bc98439c8</Hash>
</Codenesium>*/