using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiArtifactModelMapper
        {
                ApiArtifactResponseModel MapRequestToResponse(
                        string id,
                        ApiArtifactRequestModel request);

                ApiArtifactRequestModel MapResponseToRequest(
                        ApiArtifactResponseModel response);

                JsonPatchDocument<ApiArtifactRequestModel> CreatePatch(ApiArtifactRequestModel model);
        }
}

/*<Codenesium>
    <Hash>485219b98f128b39d6fcf46b1e84dfb3</Hash>
</Codenesium>*/