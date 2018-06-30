using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiWorkerPoolModelMapper
        {
                ApiWorkerPoolResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerPoolRequestModel request);

                ApiWorkerPoolRequestModel MapResponseToRequest(
                        ApiWorkerPoolResponseModel response);
        }
}

/*<Codenesium>
    <Hash>2e3db08f0ce7403c4767534ed682713f</Hash>
</Codenesium>*/