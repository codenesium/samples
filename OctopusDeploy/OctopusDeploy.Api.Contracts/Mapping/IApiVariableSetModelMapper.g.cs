using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiVariableSetModelMapper
        {
                ApiVariableSetResponseModel MapRequestToResponse(
                        string id,
                        ApiVariableSetRequestModel request);

                ApiVariableSetRequestModel MapResponseToRequest(
                        ApiVariableSetResponseModel response);

                JsonPatchDocument<ApiVariableSetRequestModel> CreatePatch(ApiVariableSetRequestModel model);
        }
}

/*<Codenesium>
    <Hash>99ba27c0bc589f9386478212e0c14756</Hash>
</Codenesium>*/