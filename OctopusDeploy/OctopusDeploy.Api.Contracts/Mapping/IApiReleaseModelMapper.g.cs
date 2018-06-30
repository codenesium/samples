using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiReleaseModelMapper
        {
                ApiReleaseResponseModel MapRequestToResponse(
                        string id,
                        ApiReleaseRequestModel request);

                ApiReleaseRequestModel MapResponseToRequest(
                        ApiReleaseResponseModel response);
        }
}

/*<Codenesium>
    <Hash>d54a1060d0086a81cb991605c038da82</Hash>
</Codenesium>*/