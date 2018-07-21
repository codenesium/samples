using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiOctopusServerNodeModelMapper
        {
                ApiOctopusServerNodeResponseModel MapRequestToResponse(
                        string id,
                        ApiOctopusServerNodeRequestModel request);

                ApiOctopusServerNodeRequestModel MapResponseToRequest(
                        ApiOctopusServerNodeResponseModel response);

                JsonPatchDocument<ApiOctopusServerNodeRequestModel> CreatePatch(ApiOctopusServerNodeRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f64b71d1dfdffd5e000de8c2350d38f8</Hash>
</Codenesium>*/