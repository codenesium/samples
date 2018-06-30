using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiWorkerModelMapper
        {
                ApiWorkerResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerRequestModel request);

                ApiWorkerRequestModel MapResponseToRequest(
                        ApiWorkerResponseModel response);
        }
}

/*<Codenesium>
    <Hash>131f55a6c65fee42918fc1ab2b661bad</Hash>
</Codenesium>*/