using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiArtifactModelMapper
        {
                ApiArtifactResponseModel MapRequestToResponse(
                        string id,
                        ApiArtifactRequestModel request);

                ApiArtifactRequestModel MapResponseToRequest(
                        ApiArtifactResponseModel response);
        }
}

/*<Codenesium>
    <Hash>aee5659907f462d7ef0984a79873f594</Hash>
</Codenesium>*/