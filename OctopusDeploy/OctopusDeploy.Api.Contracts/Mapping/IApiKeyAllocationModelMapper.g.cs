using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiKeyAllocationModelMapper
        {
                ApiKeyAllocationResponseModel MapRequestToResponse(
                        string collectionName,
                        ApiKeyAllocationRequestModel request);

                ApiKeyAllocationRequestModel MapResponseToRequest(
                        ApiKeyAllocationResponseModel response);

                JsonPatchDocument<ApiKeyAllocationRequestModel> CreatePatch(ApiKeyAllocationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>8b54303fccede9dc10302e6c370e2170</Hash>
</Codenesium>*/