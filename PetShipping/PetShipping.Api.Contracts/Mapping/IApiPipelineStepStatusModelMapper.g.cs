using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepStatusModelMapper
        {
                ApiPipelineStepStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepStatusRequestModel request);

                ApiPipelineStepStatusRequestModel MapResponseToRequest(
                        ApiPipelineStepStatusResponseModel response);

                JsonPatchDocument<ApiPipelineStepStatusRequestModel> CreatePatch(ApiPipelineStepStatusRequestModel model);
        }
}

/*<Codenesium>
    <Hash>24f2cf75156ad187ab6335b93f5afe89</Hash>
</Codenesium>*/