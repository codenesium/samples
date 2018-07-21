using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiWorkerModelMapper
        {
                ApiWorkerResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerRequestModel request);

                ApiWorkerRequestModel MapResponseToRequest(
                        ApiWorkerResponseModel response);

                JsonPatchDocument<ApiWorkerRequestModel> CreatePatch(ApiWorkerRequestModel model);
        }
}

/*<Codenesium>
    <Hash>d8026e47fe4026aacc657df8b1f7e2cf</Hash>
</Codenesium>*/