using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStatusModelMapper
        {
                ApiPipelineStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStatusRequestModel request);

                ApiPipelineStatusRequestModel MapResponseToRequest(
                        ApiPipelineStatusResponseModel response);

                JsonPatchDocument<ApiPipelineStatusRequestModel> CreatePatch(ApiPipelineStatusRequestModel model);
        }
}

/*<Codenesium>
    <Hash>3ec889828d65b16e9891e5a8a554548f</Hash>
</Codenesium>*/