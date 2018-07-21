using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiWorkerPoolModelMapper
        {
                ApiWorkerPoolResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerPoolRequestModel request);

                ApiWorkerPoolRequestModel MapResponseToRequest(
                        ApiWorkerPoolResponseModel response);

                JsonPatchDocument<ApiWorkerPoolRequestModel> CreatePatch(ApiWorkerPoolRequestModel model);
        }
}

/*<Codenesium>
    <Hash>eeec61da4e290ab3e79abfaf063973b5</Hash>
</Codenesium>*/