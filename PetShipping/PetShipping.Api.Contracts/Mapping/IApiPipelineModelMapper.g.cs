using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineModelMapper
        {
                ApiPipelineResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineRequestModel request);

                ApiPipelineRequestModel MapResponseToRequest(
                        ApiPipelineResponseModel response);

                JsonPatchDocument<ApiPipelineRequestModel> CreatePatch(ApiPipelineRequestModel model);
        }
}

/*<Codenesium>
    <Hash>170db0330fe52ab5bdbf032aaf6df224</Hash>
</Codenesium>*/