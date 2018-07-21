using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiProjectTriggerModelMapper
        {
                ApiProjectTriggerResponseModel MapRequestToResponse(
                        string id,
                        ApiProjectTriggerRequestModel request);

                ApiProjectTriggerRequestModel MapResponseToRequest(
                        ApiProjectTriggerResponseModel response);

                JsonPatchDocument<ApiProjectTriggerRequestModel> CreatePatch(ApiProjectTriggerRequestModel model);
        }
}

/*<Codenesium>
    <Hash>5922085894eb72181976979deca42fa2</Hash>
</Codenesium>*/