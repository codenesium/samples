using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiVariableSetModelMapper
        {
                ApiVariableSetResponseModel MapRequestToResponse(
                        string id,
                        ApiVariableSetRequestModel request);

                ApiVariableSetRequestModel MapResponseToRequest(
                        ApiVariableSetResponseModel response);
        }
}

/*<Codenesium>
    <Hash>a51d13ede06de7d3c1632b9ee58402e1</Hash>
</Codenesium>*/