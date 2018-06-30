using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiWorkerTaskLeaseModelMapper
        {
                ApiWorkerTaskLeaseResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerTaskLeaseRequestModel request);

                ApiWorkerTaskLeaseRequestModel MapResponseToRequest(
                        ApiWorkerTaskLeaseResponseModel response);
        }
}

/*<Codenesium>
    <Hash>3cebfa97cdae9476465a0c3037b03aae</Hash>
</Codenesium>*/