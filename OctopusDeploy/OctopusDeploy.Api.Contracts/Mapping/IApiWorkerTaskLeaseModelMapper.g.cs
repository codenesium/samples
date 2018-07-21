using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiWorkerTaskLeaseModelMapper
        {
                ApiWorkerTaskLeaseResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerTaskLeaseRequestModel request);

                ApiWorkerTaskLeaseRequestModel MapResponseToRequest(
                        ApiWorkerTaskLeaseResponseModel response);

                JsonPatchDocument<ApiWorkerTaskLeaseRequestModel> CreatePatch(ApiWorkerTaskLeaseRequestModel model);
        }
}

/*<Codenesium>
    <Hash>6934ec9ef64a25ac2288b5273f6ac582</Hash>
</Codenesium>*/