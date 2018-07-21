using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiEventModelMapper
        {
                ApiEventResponseModel MapRequestToResponse(
                        string id,
                        ApiEventRequestModel request);

                ApiEventRequestModel MapResponseToRequest(
                        ApiEventResponseModel response);

                JsonPatchDocument<ApiEventRequestModel> CreatePatch(ApiEventRequestModel model);
        }
}

/*<Codenesium>
    <Hash>c4df8b07e5bf736355e8b8fc4125ab5c</Hash>
</Codenesium>*/