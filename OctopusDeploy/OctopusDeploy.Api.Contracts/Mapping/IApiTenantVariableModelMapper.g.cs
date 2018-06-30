using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiTenantVariableModelMapper
        {
                ApiTenantVariableResponseModel MapRequestToResponse(
                        string id,
                        ApiTenantVariableRequestModel request);

                ApiTenantVariableRequestModel MapResponseToRequest(
                        ApiTenantVariableResponseModel response);
        }
}

/*<Codenesium>
    <Hash>89cc621e3065f6cd031f517b07f2cc0b</Hash>
</Codenesium>*/